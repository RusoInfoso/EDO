Ext.define('EDO.view.Viewport', {
    extend: 'Ext.container.Viewport',

    requires: [
        'EDO.view.layout.NorthPanel',
        'EDO.view.layout.SouthPanel'
    ],

    layout: 'border',
    autoWidth: true,
    autoHeight: true,

    initComponent: function () {
        this.ids = {
            northPanelId: Ext.id(),
            southPanelId: Ext.id(),
            layoutCenterContainerId: Ext.id()
        };

        Ext.apply(this, {
            items: [
                {
                    region: 'north',
                    border: false,
                    id: this.ids.northPanelId,
                    xtype: 'NorthPanel'
                },
                {
                    region: 'center',
                    autoScroll: true,
                    border: false,
                    id: this.ids.layoutCenterContainerId,
                    xtype:'container', 
                    layout:'card',
                    stateful:true,
                    stateId:'center-card'
                },
                {
                    region: 'south',
                    xtype: 'SouthPanel',
                    id: this.ids.southPanelId
                }
            ]
        });

        this.callParent(arguments);
    }
});