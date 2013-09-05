/// <reference path="http-requester.js" />
/// <reference path="class.js" />
var persister = (function () {

    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.nickname);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = "";
        sessionKey = "";
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.post = new PostPersister(this.rootUrl);

        },
        isUserLoggedIn: function () {
            var isLoggedIn = nickname != null && sessionKey != null;
            return isLoggedIn;
        },
        nickname: function () {
            return nickname;
        },
        sessionKey: function () {
            return sessionKey;
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "users/";
        },
        login: function (user, success, error) {
            var url = this.rootUrl + "login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString(),
            };

            httpRequester.postJSON(url, userData,
                function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
        },
        register: function (user, success, error) {
            var url = this.rootUrl + "register";
            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.username + user.password).toString(),
            };

            httpRequester.postJSON(url, userData,
                function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
        },
        logout: function (success, error) {
            var url = this.rootUrl + "logout/" + sessionKey;
            httpRequester.getJSON(url, function (data) {
                clearUserData();
                success(data);
            }, error);
        },
    });

    var PostPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "posts";
        },

        create: function (postModel, success, error) {
            var url = this.rootUrl + "?sessionKey=" + sessionKey;
            httpRequester.postJSON(url, postModel, function (data) {
                success(data);
            }, error);

        },

        all: function (success, error) {
            var url = this.rootUrl + "?sessionKey=" + sessionKey;

            httpRequester.getJSON(url, function (data) {
                success(data);
            }, error);
        },

        getById: function (id, success, error) {
            var url = this.rootUrl + id + "?sessionKey=" + sessionKey;

            httpRequester.getJSON(url, function (data) {
                success(data);
            }, error);
        },

        getByTags: function (tags, success, error) {
            var url = this.rootUrl + "?tags=" + tags + "sessionKey" + sessionKey;

            httpRequester.getJSON(url, function (data) {
                success(data);
            }, error);
        }
    });

    function getSessionKey() {
        return sessionKey;
    }

    return {
        get: function (url) {
            return new MainPersister(url)
        }
    };
})();