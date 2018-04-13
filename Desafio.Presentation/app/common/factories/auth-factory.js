(function () {
    angular.module('app').factory('auth', [
        '$http',
        'consts',
        AuthFactory
    ]);

    function AuthFactory($http, consts) {
        let user = null;

        function getUser() {
            if (!user) {
                user = JSON.parse(localStorage.getItem(consts.userkey));
            }
            return user;
        }

        function getUserData() {
            if (!user) {
                user = JSON.parse(localStorage.getItem(consts.userkey));
            }
            var base64Url = user.access_token.split('.')[1];
            var base64 = base64Url.replace('-', '+').replace('_', '/');
            var userData = JSON.parse(window.atob(base64));
            console.log(userData.role);
            return userData;
        }

        function login(user, callback) {
            console.log("login");
            if (user == undefined) {
                console.log("invalid user");
                return false;
            }
            var data = "grant_type=password&username=" + user.username + "&password=" + user.password;
            submit(data, callback);
        }

        function logout(callback) {
            user = null;
            localStorage.removeItem(consts.userkey);
            $http.defaults.headers.common.Authorization = '';
            if (callback) callback(null);
        }


        function submit(user, callback) {
            $http.post(consts.oauthTokenUrl, user, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then(resp => {
                    localStorage.setItem(consts.userkey, JSON.stringify(resp.data));
                    $http.defaults.headers.common.Authorization = resp.data.token;
                    if (callback) callback(null, resp.data);
                }).catch(resp => {
                    if (callback) callback({ error: resp.data.error }, null);
                });
        }

        return { login, logout, getUser, getUserData };

    }


})();