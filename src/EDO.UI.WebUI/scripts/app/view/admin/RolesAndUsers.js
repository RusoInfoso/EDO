Ext.define('EDO.view.admin.RolesAndUsers', {
    extend: 'Ext.panel.Panel',
    title: '',
    border: false,
    layout: 'border',   
    

    requires: [
        'EDO.view.admin.RolesGrid',
        'EDO.view.admin.UsersGrid'
    ],

    initComponent: function () {
        this.callParent(arguments);
    },

    items: [
        {
            title: 'Роли',
            region: 'west',
            xtype: 'admin-rolesGrid',
            width: '20%',
            margins: '5 5 5 5',
            id: 'west-region-container',
            layout: 'fit'
        },
        {
            title: 'Пользователи',
            region: 'center',     
            xtype: 'admin-usersGrid',
            layout: 'fit',
            margins: '5 5 5 0'
        }
    ]
});