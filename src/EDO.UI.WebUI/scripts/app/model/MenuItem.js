// Usefull link
// http://techknowfreak.com/2011/10/extjs-4-mvc-asp-net-mvc-3-crud-rest/#.UnjD1_nIbX8

Ext.define('EDO.model.MenuItem', {
    extend: 'Ext.data.Model',

    fields: [
                {
                    name: 'text',
                    dataType: 'string'
                },
                {
                    name: 'controller',
                    dataType: 'string',
                    optional: true
                },
                {
                    name: 'action',
                    dataType: 'string',
                    optional: true
                },
                {
                    name: 'target',
                    dataType: 'string',
                    optional: true
                }
    ],
    associations: [
        { type: 'hasMany', model: 'EDO.model.MenuItem', name: 'menuItems' }
    ],
    proxy: {

        type: 'rest',
        url: '/api/sitemenu',
        timeout: 120000,
        noCache: true,

        reader:
        {
            type: 'json',
            root: 'menuItems',
            successProperty: 'success'
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
                                    msg: 'Could not load Menu. Please try again.',
                                    buttons: Ext.Msg.OK,
                                    icon: Ext.Msg.WARNING
                                });
            }
        }
    }
});