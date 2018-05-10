(function ($) {
    app.modals.createRechargeModal = function () {
        var Serv = abp.services.app.trade;
        var _$Form = null;
        
        var _modalManager;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            _$Form = _modalManager.getModal().find('form[name=CustomerForm]');
            _modalManager.getModal()
                .find('#CreditRating')
                .selectpicker({
                    iconBase: "fa",
                    tickIcon: "fa fa-check"
                });

            
        };

        this.save = function () {
            if (!_$Form.valid()) {
                return;
            }

            var customer = _$Form.serializeFormToObject();
            
            _modalManager.setBusy(true);
            Serv.createOrUpdateCustomer({ customer: customer }).done(function () {
                abp.notify.info(app.localize("SavedSuccessfully"));
                _modalManager.close();
                abp.event.trigger("app.createRechargeModalSaved");
            }).always(function () {
                _modalManager.setBusy(false);
            });

        };
    };
})(jQuery);

