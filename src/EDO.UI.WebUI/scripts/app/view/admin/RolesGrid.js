Ext.define('EDO.view.admin.RolesGrid', {
    extend: 'Ext.grid.Panel',
    alias: ['widget.admin-rolesGrid'],
    
    layout: 'fit',
    frame: false,

    store: {},
    
    initComponent: function () {
        var grid = this;
        var store = Ext.create('EDO.store.RolesStore');        

        var rowEditing = Ext.create('Ext.grid.plugin.RowEditing', {
            listeners: {
                cancelEdit: function (rowEditing, context) {
                    // Canceling editing of a locally added, unsaved record: remove it
                    if (context.record.phantom) {
                        store.remove(context.record);
                    }
                }
            }
        });
        
        this.store = store;

        this.columns = [{
            text: 'Название роли',
            flex: 1,
            sortable: true,
            dataIndex: 'name',
            field: {
                xtype: 'textfield'
            }
        }];

        this.dockedItems = [{
            xtype: 'toolbar',
            items: [{
                text: 'Add',
                iconCls: 'icon-add',
                handler: function () {
                    store.insert(0, new EDO.model.Role());
                    rowEditing.startEdit(0, 0);
                }
            }, '-', {
                itemId: 'deleteRole',
                text: 'Delete',
                iconCls: 'icon-delete',
                disabled: true,
                handler: function () {
                }
            }]
        }];       


        grid.getSelectionModel().on('selectionchange', function (selModel, selections) {
            grid.down('#deleteRole').setDisabled(selections.length === 0);
        });

        this.callParent(arguments);
    }
});