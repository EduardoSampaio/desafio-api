(function () {
    angular.module('app').factory('userFactory', [
        '$http',
        'consts',
        '$q',
        UserFactory
    ]);

    function UserFactory($http, consts,$q) {

        //let users = [];
        //function getUser() {               
        //    $http.get(`${consts.apiUrl}/users`)
        //        .then(response => {
        //            users = response.data.result;
        //            console.log(users);
        //        })
        //        .catch(erro => console.log(erro));
        //    return users;
        //}

        //return { getUser };
    }

})();