Ext.define('EDO.view.admin.UsersGrid', {
    extend: 'Ext.grid.Panel',
    alias: ['widget.admin-usersGrid'],

    layout: 'fit',
    frame: false,

    role: '',

    initComponent: function () {        
        var component = this;
        var store = Ext.create('EDO.store.UsersStore');

        this.getSelectionModel().on('selectionchange', function (selModel, selections) {
            grid.down('#deleteUser').setDisabled(selections.length === 0);
        });

        this.addEvents('roleselected');

        Ext.apply(this.listeners, {
            roleselected: function () {
                console.log('UsersGrid');
            }
        });


        this.callParent(arguments);
    },

    columns: [{
        text: 'ID',
        width: 50,
        sortable: true,
        dataIndex: 'id'
    }, {
        text: 'Имя пользователя',
        flex: 0.7,
        sortable: true,
        dataIndex: 'title'
    }, {
        text: 'Организация',
        flex: 0.3,
        sortable: true,
        dataIndex: 'office'
    }, {
        text: 'Должность',
        width: 120,
        sortable: true,
        dataIndex: 'position'
    }, {
        text: 'Роль',
        width: 120,
        sortable: true,
        dataIndex: 'role'
    }, {
        text: 'Дата регистрации',
        width: 120,
        sortable: true,
        dataIndex: 'regDate'
    }
    ],
    dockedItems: [{
        xtype: 'toolbar',
        items: [{
            text: 'Add',
            iconCls: 'icon-add',
            handler: function () {
            }
        }, '-', {
            itemId: 'deleteUser',
            text: 'Delete',
            iconCls: 'icon-delete',
            disabled: true,
            handler: function () {
            }
        }]
    }]
});