Ext.define('EDO.store.MenuItems', {
    extend: 'Ext.data.Store',
    autoLoad: true,
    autoSync: true,
    model: 'EDO.model.MenuItem',
    storeId: 'MenuItemsStore'
});