(function () {
    "use strict";

    angular.module('app').controller('UserController', [
        '$http',
        'consts',
        function ($http, consts) {
            const vm = this;

            vm.showForm = true;
            vm.user = {};
            vm.address = {};
            vm.users = [];


            vm.changeShow = () => {
                vm.showForm = !vm.showForm;
            }
            vm.getUsers = () => {
                $http.get(`${consts.apiUrl}/users`)
                    .then(response => {
                        vm.users = response.data.result;
                    })
                    .catch(erro => console.log(erro));
            } 

            vm.createUser = () => {
                $http.post(`${consts.apiUrl}/users`, vm.user)
                    .then(callback => {
                        console.log(callback)
                    }).catch(error => console.log(error));
                vm.user = {};

            }
            vm.editUser = (user) => {
                $http.put(`${consts.apiUrl}/users`, user)
                    .then(callback => {
                        vm.getUsers();
                        console.log(callback);
                        angular.element('#modal-details').modal('hide');
                    }).catch(error => console.log(error));
            };
            vm.saveAddress = () => {
                $http.post(`${consts.apiUrl}/addresses`, vm.address)
                    .then(callback => console.log(callback))
                    .catch(error => console.log(error));
            };

            vm.getDetails = (user) => {
                vm.user = user;
                console.log(vm.user);
            }
            vm.changeUserStatus = (id) => {
                $http.get(`${consts.apiUrl}/users/${id}/${id}/status`)
                    .then(result => {
                        vm.getUsers();
                    })
                    .catch(error => console.log(error))
            }

            vm.getUserById = (id) => {
                $http.get(`${consts.apiUrl}/users/${id}`)
                    .then(result => {
                        console.log(result);
                    })
                    .catch(error => console.log(error))
            }

            vm.deleteUser = (id) => {
                if (confirm("Deseja apagar esse usuário")) {
                    $http.delete(`${consts.apiUrl}/users?id=${id}`)
                        .then(result => {
                            vm.getUsers();
                        })
                        .catch(error => console.log(error))

                }

            }

            vm.getCep = () => {
                $http.get(`https://viacep.com.br/ws/${vm.address.zipcode}/json/`)
                    .then(result => {
                        vm.address.city = result.data.localidade;
                        vm.address.state = result.data.uf;
                        vm.address.neighborhood = result.data.bairro;

                    })
                    .catch(error => console.log(error))
            }

        }
    ]);
})();
