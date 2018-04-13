(function () {
    angular.module('app').directive('ngEmail', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attr, mCtrl) {
                function myValidation(value) {
                    let pattern = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                    if (pattern.test(value)) {
                        mCtrl.$setValidity('email', true);
                    }
                    else {
                        mCtrl.$setValidity('email', false);

                    }
                    return value;
                }
                mCtrl.$parsers.push(myValidation);
            }
        };
    });

})();