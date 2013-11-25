Ext.Loader.setConfig({
    enabled:true,
    disableCaching:true,
    paths:{
        'Ext.ux': 'scripts/app/lib/ux',
        'EDO': 'scripts/app/',
        'EDO.core': 'scripts/app/lib/'
    }
});

// enable state
Ext.state.Manager.setProvider(new Ext.state.CookieProvider({
    expires:new Date(new Date().getTime() + (1000 * 60 * 60 * 24 * 7)) //7 days from now
}));

Ext.tip.QuickTipManager.init();