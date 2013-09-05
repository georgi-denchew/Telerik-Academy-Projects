/// <reference path="../libs/_references.js" />
window.persisters = (function () {

    var displayName = localStorage.getItem("displayName");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("displayName", userData.displayName);
        localStorage.setItem("sessionKey", userData.sessionKey);
        displayName = userData.displayName;
        sessionKey = userData.sessionKey;
    };

    function clearUserData() {
        localStorage.removeItem("displayName");
        localStorage.removeItem("sessionKey");
        displayName = "";
        sessionKey = "";
    };

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        login: function (username, password) {
            //var promise = new RSVP.Promise(function (resolve, reject) {
                var user = {
                    username: username,
                    authCode: CryptoJS.SHA1(password).toString()
                };

                return httpRequester.postJSON(this.apiUrl + "login", user)
                .then(function (data) {
                    saveUserData(data);
                });
           // });
        },

        register: function (username, password) {
            //var promise = new RSVP.Promise(function (resolve, reject) {
                var user = {
                    username: username,
                    authCode: CryptoJS.SHA1(password).toString()
                };

                return httpRequester.postJSON(this.apiUrl + "register", user)
                .then(function (data) {
                    saveUserData(data);
                });
            //});
        },

        logout: function () {

            if (sessionKey) {
                var headers = {
                    "X-sessionKey": sessionKey,
                };
                clearUserData();
                return httpRequester.putJSON(this.apiUrl + "logout", {}, headers);
            }
        }
    });



    var CarsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            return httpRequester.getJSON(this.apiUrl);
        }
    });

    var StoresPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.cars = new CarsPersister(apiUrl + "cars/");
            this.stores = new StoresPersister(apiUrl + "store/");
        }
    })

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
})();