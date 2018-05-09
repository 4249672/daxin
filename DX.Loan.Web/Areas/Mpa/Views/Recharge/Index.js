(function () {
    $(function () {

        var _$table = $('#RechargeTable');
        var _service = abp.services.app.trade;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Customer.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Customer.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Customer.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/Customer/CreateModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/Customer/_CreateModal.js',
            modalClass: 'CreateCustomerModal'
        });

        _$table.jtable({

            title: app.localize('Recharge'),

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
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });
        
        $('#CreateNewButton').click(function () {
            _createOrEditModal.open();

        });

        $('#RefreshButton').click(function (e) {
            e.preventDefault();
            getCustomers();
        });

        function getCustomers() {
            _$table.jtable("load");
        }

        getCustomers();

        abp.event.on('app.createCustomerModalSaved', function () {
            getCustomers();
        })


    });
})();