Ext.define('EDO.controller.Documents', {
    extend: 'EDO.controller.Base',
    views: [
        'documents.Index',
        'documents.Create',
        'documents.AllDocs'
    ],

    allDocs: function(request) {
        this.render("workspace", this["get" + this.id + "AllDocsView"]());
    },
    create: function (request) {
        this.render("workspace", this["get" + this.id + "CreateView"]());
    },

    hasRights: function () {
        return true;
    }
});