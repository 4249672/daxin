(function () {
    $(function () {

        var _$table = $('#RechargeTable');
        var _service = abp.services.app.trade;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Recharge.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Recharge.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Recharge.Delete')
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
            viewUrl: abp.appPath + 'Mpa/Recharge/CreateModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/Recharge/_CreateModal.js',
            modalClass: 'createRechargeModal'
        });

        //var _userModal = new app.ModalManager({
        //    viewUrl: abp.appPath + 'Mpa/Users/PermissionsModal',
        //    scriptUrl: abp.appPath + 'Areas/Mpa/Views/Users/_PermissionsModal.js',
        //    modalClass: 'UserPermissionsModal'
        //});

        _$table.jtable({
            title: app.localize('Recharge'),
            paging: true,
            sorting: false,
            multiSorting: false,

            actions: {
                listAction: {
                    method: _service.getUserTradeRecordList
                }
            },
            fields: {
                id: {
                    key: true,
                    list: false
                },
                serialNo: {
                    title: app.localize('SerialNo'),
                    width: '10%',
                },
                tradeType: {
                    title: app.localize('TradeType'),
                    width: '5%',
                },
                amount: {
                    title: app.localize('Amount'),
                    width: '10%',
                },
                remarkSubmit: {
                    title: app.localize('RemarkSubmit'),
                    width: '10%',
                },
                remarkAudit: {
                    title: app.localize('RemarkAudit'),
                    width: '10%',
                },
                refNo: {
                    title: app.localize('RefNo'),
                    width: '10%',
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
                    userID: $('#userId').val(),
                    startDate: _selectedDateRange.startDate,
                    endDate: _selectedDateRange.endDate,
                    tradeType: $("#TradeType").val()
                });
            }
        }

        getTableList();

        abp.event.on('app.createRechargeModalSaved', function () {
            getTableList(true);
        })


    });
})();