Ext.ns('Core');
Ext.ns('Core.User');

Core.startApplication = function () {
    App = Ext.create('Ext.ux.app.RoutedApplication', {
        name: 'EDO',
        appFolder: 'scripts/app',

        requires: [
            'EDO.view.Viewport'
        ],

        controllers: [
            'Base',
            'Dashboard',
            'Documents',
            'User'
        ],

        launch: function () {
            var me = this;

            this.initCore();

            // create Viewport instance
            this.viewport = Ext.create('EDO.view.Viewport', {
                controller: this
            }, { single: true });

            var workspace = this.viewport.down('container[region=center]');
            this.addLayout('workspace', workspace);
            Ext.defer(this.hideLoadingScreen, 250);

            Ext.History.init(me.initDispatch, me);
            Ext.History.on('change', me.historyChange, me);

            // Start with dashboard
            token = Ext.History.getToken();
            if (token == null) {
                Ext.History.add('dashboard', true);
            }

            this.initMenu();
        },

        initCore: function () {
        },

        initDispatch: function () {
            var me = this,
                token = Ext.History.getToken();
            Ext.log('Init dispatch with token: ' + token);
            me.historyChange(token);
        },

        historyChange: function (token) {
            var me = this;
            // and check if token is set
            Ext.log('History changed to: ' + token);
            if (token) {
                Ext.dispatch(token);
            }
        },
        hideLoadingScreen: function () {
            Ext.get('loading').remove();
            Ext.fly('loading-mask').animate({
                opacity: 0,
                remove: true
            });
        },
        initMenu: function () {
            var northpanel = Ext.getCmp(this.viewport.ids.northPanelId),
                topMenu = Ext.create('EDO.view._common.UserMenu', {});

            northpanel.insert(northpanel.items.getCount(), topMenu);

        }
    });
};

Ext.onReady(function () {
    Ext.require([
    'Ext.ux.app.RoutedApplication'
    ],
    function () {
        Ext.Ajax.request({
            url: '/api/coreapi',
            method: 'GET',
            success: function (response) {
                var obj = Ext.decode(response.responseText)
                if (obj.data) {
                    Core.User = obj.data.user;
                }
                
                Core.startApplication();
            },
            failure: function () {

            }
        });
    })
});