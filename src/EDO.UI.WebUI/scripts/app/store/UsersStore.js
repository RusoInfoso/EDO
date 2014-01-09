Ext.define('EDO.store.UsersStore', {
    extend: 'Ext.data.Store',
    autoLoad: true,
    autoSync: true,
    storeId: 'usersStoreId',
    model: 'EDO.model.User',

    proxy: {
        type: 'rest',
        url: '/api/users',
        timeout: 120000,
        noCache: true,

        reader:
        {
            type: 'json',
            root: 'items',
            successProperty: 'success'
        },

        writer: {
            type: 'json'
        },

        afterRequest: function (request, success) {
            if (request.action == 'read') {
                this.readCallback(request);
            } else if (request.action == 'destroy') {
                this.destroyCallback(request);
            }

        },

        listeners: {
            exception: function (proxy, response, options) {
                var rspMsg = Ext.decode(response.responseText);
                var msg = rspMsg.message || "Произошла неизвестная ошибка";

                Ext.Msg.show({
                    title: 'Ошибка',
                    msg: msg,
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.ERROR,
                    fn: function () {
                        Ext.data.StoreManager.lookup('rolesStoreId').rejectChanges();
                    }
                });
            }
        },

        readCallback: function (request) {
            if (!request.operation.success) {
                Ext.Msg.show({
                    title: 'Warning',
                    msg: 'Could not load Roles. Please try again.',
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.WARNING
                });
            }
        },

        destroyCallback: function (request) {
            if (request.operation.success) {
                Ext.Msg.show({
                    title: 'Успешно',
                    msg: 'Роль успешно удалена',
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.OK
                });
            }
        }
    }
});