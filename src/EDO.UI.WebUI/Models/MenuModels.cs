using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.Web;
using System.Xml.Linq;

namespace EDO.UI.WebUI.Models
{
    
    public class MenuParser
    {
        private IPrincipal _user = null;

        private Menu _menu;

        public MenuParser(IPrincipal user)
        {
            if(user == null)
            {
                throw new Exception("Not authorized user");
            }

            _user = user;
            _menu = new Menu();
            
        }

        public Menu LoadFromXMLFile(string path)
        {
            var xml = XDocument.Load(path);
            var items = xml.Element("menu").Element("items").Elements("item");

            _menu.Items = ParseXMLItemsList(items);

            return _menu;
        }

        private List<MenuItem> ParseXMLItemsList(IEnumerable<XElement> items)
        {
            var result = new List<MenuItem>();

            foreach(var item in items)
            {
                var itemRoles = item.Element("roles").Elements("role");

                if(!itemRoles.Any(p => p.Value == "All" || _user.IsInRole(p.Value)) )
                {
                    continue;
                }

                var text = item.Element("text").Value;
                var subMenu = item.Element("items");

                MenuItem newItem = null;

                if (subMenu == null)
                {
                    newItem = new MenuItem
                    {
                        Text = text,
                        Controller = item.Element("controller").Value,
                        Action = item.Element("action").Value,
                        Target = item.Element("target").Value
                    };
                }
                else
                {
                    newItem = new MenuItem
                    {
                        Text = text,
                        Items = ParseXMLItemsList(subMenu.Elements("item"))
                    };
                }

                result.Add(newItem);
            }

            return result;
        }
    }

    [DataContract(Name = "Menu", Namespace = "")]
    public class Menu
    {
        [DataMember(Name = "MenuItems")]
        public List<MenuItem> Items { get; set; }
        [DataMember(Name = "TotalItems")]
        public int TotalItems
        {
            get
            {
                return Items.Count();
            }
        }
    }

    [DataContract(Name = "MenuItem", Namespace = "")]
    public class MenuItem
    {
        [DataMember(EmitDefaultValue = false)]
        public string Text { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Controller { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Action { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Target { get; set; }
        [DataMember(Name = "MenuItems", EmitDefaultValue = false)]
        public List<MenuItem> Items { get; set; }
    }
}