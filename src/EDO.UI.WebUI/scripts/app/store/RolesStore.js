Ext.define('EDO.store.RolesStore', {
    extend: 'Ext.data.Store',
    autoLoad: true,
    autoSync: true,
    storeId: 'rolesStoreId',
    model: 'EDO.model.Role',

    proxy: {
        type: 'rest',
        url: '/api/roles',
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
            }
        },

        readCallback: function (request) {

            if (!request.operation.success) {
                Ext.Msg.show(
                                {
                                    title: 'Warning',
                                    msg: 'Could not load Roles. Please try again.',
                                    buttons: Ext.Msg.OK,
                                    icon: Ext.Msg.WARNING
                                });
            }
        }
    },

    listeners: {
        write: function(store, operation) {
            var record = operation.getRecords()[0],
                name = Ext.String.capitalize(operation.action),
                verb;

            Ext.example.msg(name, Ext.String.format("{0} role: {1}", verb, record.getId()));
        }
    }
});