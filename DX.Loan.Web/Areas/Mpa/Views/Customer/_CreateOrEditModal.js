(function ($) {
    app.modals.CreateCustomerModal = function () {
        var customerServ = abp.services.app.customer;
        var _$customerForm = null;
        
        var _modalManager;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            _$customerForm = _modalManager.getModal().find('form[name=CustomerForm]');
            _modalManager.getModal()
                .find('#CreditRating')
                .selectpicker({
                    iconBase: "fa",
                    tickIcon: "fa fa-check"
                });

            
        };

        this.save = function () {
            if (!_$customerForm.valid()) {
                return;
            }

            var customer = _$customerForm.serializeFormToObject();
            
            _modalManager.setBusy(true);
            customerServ.createOrUpdateCustomer({ customer: customer }).done(function () {
                abp.notify.info(app.localize("SavedSuccessfully"));
                _modalManager.close();
                abp.event.trigger("app.createCustomerModalSaved");
            }).always(function () {
                _modalManager.setBusy(false);
            });

        };
    };
})(jQuery);

