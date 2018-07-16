(function ($) {
    app.modals.createNoticeModal = function () {
        var Serv = abp.services.app.notice;
        var _$Form = null;

        var _modalManager;

        this.init = function (modalManager) {
            _modalManager = modalManager;
            _$Form = _modalManager.getModal().find('form[name=createOrUpdateForm]');

            _$Form.find(".datepicker").datetimepicker();

        };

        this.save = function () {
            if (!_$Form.valid()) {
                return;
            }

            var notice = _$Form.serializeFormToObject();
            _modalManager.setBusy(true);

            Serv.createOrUpdateNotice({ notice: notice }).done(function () {
                abp.notify.info(app.localize("SavedSuccessfully"));
                _modalManager.close();
                abp.event.trigger("app.createNoticeModalSaved");
            }).always(function () {
                _modalManager.setBusy(false);
            });

        };
    };
})(jQuery);

