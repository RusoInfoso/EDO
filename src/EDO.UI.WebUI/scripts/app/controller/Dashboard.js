Ext.define('EDO.controller.Dashboard', {
    extend: 'EDO.controller.Base',
    views: [
        'dashboard.Index'
    ],

    hasRights: function () {
        return true;
    }
});