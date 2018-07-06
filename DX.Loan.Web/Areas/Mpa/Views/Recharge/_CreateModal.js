(function ($) {
    app.modals.createRechargeModal = function () {
        var Serv = abp.services.app.trade;
        var _$Form = null;
        
        var _modalManager;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            _$Form = _modalManager.getModal().find('form[name=CustomerForm]');

            _modalManager.getModal()
                .find('#TradeType')
                .selectpicker({
                    iconBase: "fa",
                    tickIcon: "fa fa-check"
                });
            
        };

        this.save = function () {
            if (!_$Form.valid()) {
                return;
            }

            var charge = _$Form.serializeFormToObject();
            _modalManager.setBusy(true);

            var tradeType = $("#TradeType").val();
            if (tradeType == "1") { //充值

                Serv.createRechargeTrade({ input: charge }).done(function () {
                    abp.notify.info(app.localize("SavedSuccessfully"));
                    _modalManager.close();
                    abp.event.trigger("app.createRechargeModalSaved");
                }).always(function () {
                    _modalManager.setBusy(false);
                });

            } else if (tradeType == "2") {
                Serv.createDeductionTrade({ input: charge }).done(function () {
                    abp.notify.info(app.localize("SavedSuccessfully"));
                    _modalManager.close();
                    abp.event.trigger("app.createRechargeModalSaved");
                }).always(function () {
                    _modalManager.setBusy(false);
                });
            }

            
            
            
            

        };
    };
})(jQuery);

