Ext.define('EDO.controller.Admin', {
    extend: 'EDO.controller.Base',
    views: [
        'admin.Index',
        'admin.RolesAndUsers'
    ],

    rolesAndUsers: function (request) {
        this.render("workspace", this["get" + this.id + "RolesAndUsersView"]());
    },

    hasRights: function () {
        return true;
    }
});