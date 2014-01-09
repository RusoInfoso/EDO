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
            pluginId: 'rowEditingId',
            listeners: {
                cancelEdit: function (rowEditing, context) {
                    // Canceling editing of a locally added, unsaved record: remove it
                    if (context.record.phantom) {
                        store.remove(context.record);
                    }
                }
            }
        });

        var columns = [{
            text: 'Название роли',
            flex: 1,
            sortable: true,
            dataIndex: 'name',
            field: {
                xtype: 'textfield'
            }
        }];

        var dockedItems = [{
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
                    var selection = grid.getView().getSelectionModel().getSelection()[0];
                    if (selection) {
                        Ext.MessageBox.show({
                            title: 'Удаление роли',
                            msg: 'Вы действительно хотите удалить роль ' + selection.data.name + '?!',
                            buttons: Ext.MessageBox.YESNO,
                            icon: Ext.MessageBox.WARNING,    // иконка мб {ERROR,INFO,QUESTION,WARNING}
                            width: 300,                       
                            closable: false,
                            fn: function (btn) {
                                if (btn == 'yes') {
                                    store.remove(selection);
                                }
                            }
                        });
                    }
                }
            }]
        }];

        Ext.apply(this, {
            store: store,
            plugins: [rowEditing],
            columns: columns,
            dockedItems: dockedItems
        });

        grid.getSelectionModel().on('selectionchange', function (selModel, selections) {
            grid.down('#deleteRole').setDisabled(selections.length === 0);
        });

        this.callParent(arguments);
    },

    listeners: {
        afterrender: function () {
            this.getPlugin('rowEditingId').removeManagedListener(this.getPlugin('rowEditingId').view, 'celldblclick');
        }
    }
});