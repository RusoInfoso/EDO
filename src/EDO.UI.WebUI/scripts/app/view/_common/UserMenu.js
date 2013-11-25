Ext.define('EDO.view._common.UserMenu', {
    extend: 'Ext.toolbar.Toolbar',
    alias: 'widget.edo-usermenu',
    requires: [
        'EDO.store.MenuItems',
        'EDO.model.MenuItem'
    ],

    initComponent: function () {
        var me = this,
            menuList = [];

        me._readMenuFromStore();
        Ext.apply(this, {
            xtype: 'toolbar',
            autoHeight: true,
            cls: 'user-menu-bar',
            width: 'auto',
            items: []
        });

        me.callParent(arguments);
    },

    _readMenuFromStore: function () {
        var tb = this;

        var store = new EDO.store.MenuItems(); 
        store.on('load', function (storeref, records, success) {
            if (success) {
                menuList = this._buildMenuTree(storeref);
                
                for (var i in menuList) {
                    this.add(menuList[i]);
                }
            }
        }, tb);
    },

    _buildMenuTree: function (store) {
        
        var me = this,
            outList = [];

        if (store.count() == 0) return;

        store.each(function (item) {
            if (item.menuItems().count() > 0) {
                outList.push({
                    text: item.get('text'),
                    menu: {
                        xtype: 'menu',
                        items: me._buildMenuTree(item.menuItems())
                    }
                })
            } else {
                outList.push({
                    text: item.get('text'),
                    hrefTarget: item.get('target'),
                    href: me._buildMenuItemUrl(item.get('controller'), item.get('action'))
                });
            }

        }, me);
        
        return outList;
    },

    _buildMenuItemUrl: function (controller, action) {
        var url = '#' + controller;

        if (action && action != 'index') {
            url = url + '/' + action;
        }
        return url;
    }
});