(function () {
    $(function () {

        var _$table = $('#CustomerTable');
        var _service = abp.services.app.customer;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Customer.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Customer.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Customer.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Mpa/Customer/CreateOrEditModal',
            scriptUrl: abp.appPath + 'Areas/Mpa/Views/Customer/_CreateOrEditModal.js',
            modalClass: 'CreateCustomerModal'
        });

        _$table.jtable({

            title: app.localize('Customer'),

            actions: {
                listAction: {
                    method: _service.getCustomers
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {title: app.localize('Actions'),//操作列
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
                            return  true;
                        },
                        action: function (data) {
                            deleteCustomer(data.record);
                        }
                    }]
                },
                name: {
                    title: app.localize('Name'),
                    width: '10%',
                },
                age: {
                    title: app.localize('Age'),
                    width: '5%',
                },
                idCard: {
                    title: app.localize('IdCard'),
                    width: '10%',
                },
                area: {
                    title: app.localize('Area'),
                    width: '10%',
                },
                tel: {
                    title: app.localize('Tel'),
                    width: '10%',
                },
                weChat: {
                    title: app.localize('WeChat'),
                    width: '10%',
                },
                qq: {
                    title: app.localize('QQ'),
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

        function deleteCustomer(cust) {
            abp.message.confirm(
                app.localize('CustomerDeleteWarningMessage', cust.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _service.deleteCustomer({
                            id: cust.id
                        }).done(function () {
                            getCustomers();
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