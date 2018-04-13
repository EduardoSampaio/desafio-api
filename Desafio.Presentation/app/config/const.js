angular.module('app').constant('consts', {
    appName: 'Desafio',
    version: '1.0',
    owner: 'Eduardo Sampaio',
    year: '2018',
    oauthTokenUrl: 'http://localhost:3526/oauth/token',
    apiUrl: 'http://localhost:3526/api/v1/',
    userkey: 'app_user_key'
}).run(['$rootScope', 'consts', function ($rootScope, consts) {
    $rootScope.consts = consts;
}]);