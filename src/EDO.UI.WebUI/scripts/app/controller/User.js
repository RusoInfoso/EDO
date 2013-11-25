Ext.define('EDO.controller.User', {
    extend: 'EDO.controller.Base',
    views: [
        'user.Index'
    ],

    hasRights: function () {
        return true;
    }
});