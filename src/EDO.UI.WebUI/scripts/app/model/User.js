Ext.define('EDO.model.User', {
    extend: 'Ext.data.Model',
    fields: [{
        name: 'name',
        useNull: true
    }],

    validations: [{
        type: 'length',
        field: 'name',
        min: 1
    }]
});