Ext.define('EDO.view.layout.SouthPanel', {
    extend: 'Ext.Toolbar',
    alias: 'widget.SouthPanel',
    cls: 'toolbar-south-panel',
    border: true,
    height: 25,

    defaultType: 'tbtext',
    items: [
      {
          id: 'site-copyright',
          text: '© Мегакрутая Система Документо Оборота',
          cls: 'x-statusbar cleanborder x-unselectable copyright-panel'
      },
      '->',
      {
          id: 'site-clock',
          xtype: 'tbtext'
      }
    ],
    listeners: {
        render: {
            fn: function () {
                var
                  clock = Ext.getCmp('site-clock'),
                  diff = null,
                  update = function () {
                      var
                        local = new Date(),
                        server = null
                      ;

                      var text = 'Местное время: ' + Ext.Date.format(local, 'd M H:i');
                      clock.setText(text)
                  }
                ;
                update();
                Ext.fly(clock.getEl().parent()).addCls('x-status-text-panel').createChild({ cls: 'spacer' });

                Ext.TaskManager.start({
                    run: update,
                    interval: 1000
                });
            },
            delay: 100
        }
    }
});