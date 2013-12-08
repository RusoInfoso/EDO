Ext.define('EDO.view.admin.RolesGrid', {
    extend: 'Ext.grid.Panel',
    alias: ['widget.admin-rolesGrid'],
    
    layout: 'fit',
    frame: false,
    
    initComponent: function() {
        this.getSelectionModel().on('selectionchange', function (selModel, selections) {
            grid.down('#deleteRole').setDisabled(selections.length === 0);
        });
        
        this.callParent(arguments);
    },

    columns: [{
        text: 'ID',
        width: 50,
        sortable: true,
        dataIndex: 'id'
    }, {
        text: 'Название роли',
        flex: 1,
        sortable: true,
        dataIndex: 'title',
        field: {
            xtype: 'textfield'
        }
    }],
    dockedItems: [{
        xtype: 'toolbar',
        items: [{
            text: 'Add',
            iconCls: 'icon-add',
            handler: function () {
            }
        }, '-', {
            itemId: 'deleteRole',
            text: 'Delete',
            iconCls: 'icon-delete',
            disabled: true,
            handler: function () {
            }
        }]
    }]
});