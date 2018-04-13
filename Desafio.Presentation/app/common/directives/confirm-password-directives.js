(function () {
    angular.module('app').directive('confirmPassword', function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attr, mCtrl) {
                function myValidation(value) {;
                    if (value === scope.userForm.password.$viewValue) {
                        mCtrl.$setValidity('confirm', true);
                    }
                    else {
                        mCtrl.$setValidity('confirm', false);
                        
                    }
                    return value;
                }
                mCtrl.$parsers.push(myValidation);
            }
        };
    });

})();