
angular.module('app').config([
    '$routeProvider',
    '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider
            .when("/", {
                template: `
                    <div class="jumbotron welcome-jumbotron">
                        <h1>Bem vindo!</h1>
                    </div>
                `
            })
            .when("/users", {
                templateUrl: '../app/users/users.html',
                controller: 'UserController',
                controllerAs: 'ctrl',
            })
            .when("/users-create", {
                templateUrl: '../app/users/users-create.html',
                controller: 'UserController',
                controllerAs: 'ctrl',
            })
            .when("/my-data", {
                templateUrl: '../app/users/users-data.html',
                controller: 'UserController',
                controllerAs: 'ctrl',
            })
            .when("/login", {
                templateUrl: 'login.html',
                controller: 'AccountController',
                controllerAs: 'acc',
            })
            .otherwise({
                redirectTo: '/'
            });
    }
]).run([
    '$rootScope',
    '$http',
    '$location',
    '$window',
    'auth',
    function ($rootScope, $http, $location, $window, auth) {
        validateUser();
        $rootScope.$on('$locationChangeStart', () => validateUser());

        function validateUser() {
            const user = auth.getUser();
            const authPage = 'login.html';
            const isAuthPage = $window.location.href.includes(authPage);

            if (!user && !isAuthPage) {
                $window.location.href = authPage;
            } else if (user && !user.isValid) {
                user.isValid = true;
                $http.defaults.headers.common.Authorization = "Bearer " + user.access_token;
                isAuthPage ? $window.location.href = '/index.html' : $location.path('/');
            }
        }
    }
]);
