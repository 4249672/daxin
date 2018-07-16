(function ($) {
    app.modals.createRechargeModal = function () {
        var Serv = abp.services.app.trade;
        var _$Form = null;
        
        var _modalManager;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            _$Form = _modalManager.getModal().find('form[name=RechargeForm]');

            _modalManager.getModal()
                .find('.selectpicker')
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
            
            var tradeType = charge.TradeType;
            if (tradeType == "CZ") { //充值

                Serv.createRechargeTrade(charge).done(function () {
                    abp.notify.info(app.localize("SavedSuccessfully"));
                    _modalManager.close();
                    abp.event.trigger("app.createRechargeModalSaved");
                }).always(function () {
                    _modalManager.setBusy(false);
                });

            } else if (tradeType == "KF") {
                Serv.createDeductionTrade(charge).done(function () {
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

