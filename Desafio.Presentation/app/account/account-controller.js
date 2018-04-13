(function () {
    angular.module('app').controller('AccountController', [
        '$location',
        'auth',
        AccountController
    ]);

    function AccountController($location, auth) {
        const vm = this;
        vm.user = {};
        vm.role = {};
        vm.userData = {};
        vm.loginMode = true;
        vm.changeMode = () => vm.loginMode = !vm.loginMode;
        vm.login = () => auth.login(vm.user, err => err ? console.log(err) : window.location.href = "/index.html");
        vm.logout = () => auth.logout(() => window.location.href = "/login.html");
        vm.getUser = () => vm.user = auth.getUser();
        vm.getData = () => {
            vm.userData = auth.getUserData();
            console.log(vm.userData);
            let roles = vm.userData.role;
            for (let i = 0; i < roles.length; i++) {
                if (roles[i] == "GOD") {
                    vm.role.god = true;
                }
                if (roles[i] == "user-edited") {
                    vm.role.userEdited = true;
                }
                if (roles[i] == "user-view") {
                    vm.role.userView = true;
                }
                if (roles[i] == "user-status") {
                    vm.role.userStatus = true;
                }
                if (roles[i] == "user-created") {
                    vm.role.userCreated = true;
                }
                if (roles[i] == "profile-edit") {
                    vm.role.profileEdit = true;
                }
                if (roles[i] == "user-deleted") {
                    vm.role.userDeleted = true;
                }
              
            }
            

        } 

    }

})();

