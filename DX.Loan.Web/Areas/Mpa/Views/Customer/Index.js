(function () {
    $(function () {

        var _$rolesTable = $('#CustomerTable');
        var _service = abp.services.app.customer;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Administration.Customer.Create'),
            edit: abp.auth.hasPermission('Pages.Administration.Customer.Edit'),
            'delete': abp.auth.hasPermission('Pages.Administration.Customer.Delete')
        };

        //var _createOrEditModal = new app.ModalManager({
        //    viewUrl: abp.appPath + 'Mpa/Roles/CreateOrEditModal',
        //    scriptUrl: abp.appPath + 'Areas/Mpa/Views/Roles/_CreateOrEditModal.js',
        //    modalClass: 'CreateOrEditRoleModal'
        //});

        _$rolesTable.jtable({

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
                //actions: {
                //    type: 'record-actions',
                //    cssClass: 'btn btn-xs btn-primary blue',
                //    text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                //    items: [{
                //        text: app.localize('Edit'),
                //        visible: function () {
                //            return _permissions.edit;
                //        },
                //        action: function (data) {
                //            _createOrEditModal.open({ id: data.record.id });
                //        }
                //    }, {
                //        text: app.localize('Delete'),
                //        visible: function (data) {
                //            return !data.record.isStatic && _permissions.delete;
                //        },
                //        action: function (data) {
                //            //deleteRole(data.record);
                //        }
                //    }]
                //},
                actions: {
                    title: app.localize('Actions'),//操作列
                    width: '15%',
                    sorting: false
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
                //displayName: {
                //    title: app.localize('RoleName'),
                //    width: '35%',
                //    display: function (data) {
                //        var $span = $('<span></span>');

                //        $span.append(data.record.displayName + " &nbsp; ");

                //        //if (data.record.isStatic) {
                //        //    $span.append('<span class="label label-info" data-toggle="tooltip" title="' + app.localize('StaticRole_Tooltip') + '" data-placement="top">' + app.localize('Static') + '</span>&nbsp;');
                //        //}

                //        //if (data.record.isDefault) {
                //        //    $span.append('<span class="label label-default" data-toggle="tooltip" title="' + app.localize('DefaultRole_Description') + '" data-placement="top">' + app.localize('Default') + '</span>&nbsp;');
                //        //}

                //        //$span.find('[data-toggle=tooltip]').tooltip();

                //        return $span;
                //    }
                //},
                creationTime: {
                    title: app.localize('CreationTime'),
                    width: '25%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });

        //function deleteRole(role) {
        //    abp.message.confirm(
        //        app.localize('RoleDeleteWarningMessage', role.displayName),
        //        function (isConfirmed) {
        //            if (isConfirmed) {
        //                _roleService.deleteRole({
        //                    id: role.id
        //                }).done(function () {
        //                    getRoles();
        //                    abp.notify.success(app.localize('SuccessfullyDeleted'));
        //                });
        //            }
        //        }
        //    );
        //};

        $('#CreateNewButton').click(function () {
            _createOrEditModal.open();
        });

        $('#RefreshButton').click(function (e) {
            e.preventDefault();
            getRoles();
        });

        function getRoles() {
            _$rolesTable.jtable('load', { permission: $('#PermissionSelectionCombo').val() });
        }

        //abp.event.on('app.createOrEditRoleModalSaved', function () {
        //    getRoles();
        //});

        getRoles();
    });
})();