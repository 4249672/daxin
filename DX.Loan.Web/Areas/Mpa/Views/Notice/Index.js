(function () {
    $(function () {

        var _$table = $('#NoticeTable');
        var _service = abp.services.app.notice;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Notice.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Notice.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Notice.Delete')
        };

        var _$filterForm = $('#frmId');
        var _selectedDateRange = {
            startDate: moment().startOf('day'),
            endDate: moment().endOf('day')
        };
        _$filterForm.find('input.date-range-picker').daterangepicker(
            $.extend(true, app.createDateRangePickerOptions(), _selectedDateRange),
            function (start, end, label) {
                _selectedDateRange.startDate = start.format('YYYY-MM-DDT00:00:00Z');
                _selectedDateRange.endDate = end.format('YYYY-MM-DDT23:59:59.999Z');
            });


        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/Notice/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/Notice/_CreateOrEditModal.js',
            modalClass: 'createNoticeModal'
        });
        
        _$table.jtable({
            title: app.localize('Notice'),
            paging: true,
            sorting: false,
            multiSorting: false,

            actions: {
                listAction: {
                    method: _service.getNotices
                }
            },
            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: app.localize('Actions'),//操作列
                    width: '10%',
                    sorting: false,
                    type: 'record-actions',
                    cssClass: 'btn btn-xs btn-primary blue',
                    text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                    items: [{
                        text: app.localize('Edit'),
                        visible: function () {
                            return true;
                        },
                        action: function (data) {
                            _createOrEditModal.open({ id: data.record.id });
                        }
                    }, {
                        text: app.localize('Delete'),
                        visible: function (data) {
                            return true;
                        },
                        action: function (data) {
                            deleteCustomer(data.record);
                        }
                    }]
                },
                title: {
                    title: app.localize('NoticeTitle'),
                    width: '10%',
                },
                shortTitle: {
                    title: app.localize('ShortTitle'),
                    width: '5%',
                },
                author: {
                    title: app.localize('Author'),
                    width: '10%',
                },
                prior: {
                    title: app.localize('Prior'),
                    width: '10%',
                },
                publicDate: {
                    title: app.localize('PublicDate'),
                    width: '10%',
                    display: function (data) {
                        return moment(data.record.publicDate).format('YYYY-MM-DD HH:mm:ss');
                    }
                },
                creationTime: {
                    title: app.localize('CreationTime'),
                    width: '25%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('YYYY-MM-DD HH:mm:ss');
                    }
                }
            }

        });

        function deleteCustomer(cust) {
            abp.message.confirm(
                app.localize('Delete'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _service.deleteNotice({
                            id: cust.id
                        }).done(function () {
                            getTableList(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewButton').click(function () {
            _createOrEditModal.open();

        });

        $('#RefreshButton').click(function (e) {
            e.preventDefault();
            getTableList();
        });

        function getTableList(reload) {
            if (reload) {
                _$table.jtable('reload');
            } else {

                _$table.jtable('load', {
                    title: $('#titleId').val(),
                    startDate: _selectedDateRange.startDate,
                    endDate: _selectedDateRange.endDate
                });
            }
        }

        getTableList();

        abp.event.on('app.createNoticeModalSaved', function () {
            getTableList(true);
        })


    });
})();