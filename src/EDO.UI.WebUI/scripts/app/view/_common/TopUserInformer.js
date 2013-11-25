

Ext.define('EDO.view._common.TopUserInformer', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.edo-userinformer',

    requires: [],

    layout: {
        type: 'vbox',
        align: 'stretch'
    },
    header: false,
    border: false,
    height: 70,
    padding: '5 10',
    margin: '5 10',
    minWidth: 300,
    maxWidth: 500,
    baseCls: 'top-userInformer',

    initComponent: function() {
        var me = this;

        Ext.apply(this, {
            
            defaults: {
                xtype: 'container',
                cls: 'top-userInformerItem'
            },
            items: [
              {
                  html: Core.User.business.title,
                  flex: 1
              },
              {
                  html: Core.User.name,
                  flex: 1
              },
              {
                  xtype: 'panel',
                  layout: {
                      type: 'hbox'
                  },
                  frame: false,
                  border: false,
                  align: 'stretch',
                  cls: 'top-userInformerButtonPanel',
                  items: [
                      {
                          cls: 'top-userInformerItem',
                          html: '<a href="/#user">Настройки</a>'
                      },
                      {
                          xtype: 'tbfill'
                      },
                      {
                          cls: 'top-userInformerItem',
                          html: '<form action="/Account/LogOff" id="logoutForm" method="POST"><a href="Javascript: document.getElementById(\'logoutForm\').submit()">Выйти</a></form>'
                      }
                  ]
              }
            ]
        });

        me.callParent(arguments);
    }
});