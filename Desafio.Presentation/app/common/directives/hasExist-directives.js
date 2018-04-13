(function () {
    angular.module('app').directive('hasExist', [
    '$http',
    'consts',
    function ($http, consts) {
        return {
            require: 'ngModel',
            link: function (scope, element, attr, mCtrl) {
                function myValidation(value) {       
                    if (value == "") {
                        return false;
                    }
                    $http.get(`${consts.apiUrl}/users/${value}/${attr.id}`)
                        .then(callback => {
                            if (callback.data.result == true) {
                                mCtrl.$setValidity('has', true);
                            }
                            else {
                                mCtrl.$setValidity('has', false);
                            }
                        })
                        .catch(error => console.log(error));
                    return value;
                }
                mCtrl.$parsers.push(myValidation);
            }
        };
    }

    ])
})();