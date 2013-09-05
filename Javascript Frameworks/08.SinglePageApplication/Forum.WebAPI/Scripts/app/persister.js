/// <reference path="../libs/_references.js" />

window.persisters = (function () {
    var sessionKey = "";
    var bashUsername = "";
    function clearLocalStorage() {
        localStorage.removeItem("displayName");
        localStorage.removeItem("sessionKey");
        sessionKey = "";
        bashUsername = "";
    }

    function saveSessionKey(sessionKeyNew, displayName) {
        localStorage.setItem("displayName", displayName);
        localStorage.setItem("sessionKey", sessionKeyNew);
        bashUsername = displayName;
        sessionKey = sessionKeyNew;
    }

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.posts = new PostsPersister(apiUrl + "posts");
        }
    });

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            var user = {
                username: username,
                //for demo purpose
                authCode: CryptoJS.SHA1(password).toString()
            };
            debugger;
            var url = this.apiUrl + "login";
            //debugger;
            return httpRequester.postJSON(url, user)
				.then(function (data) {
				    saveSessionKey(data.sessionKey, data.nickname);
				    sessionKey = data.sessionKey;
				    bashUsername = data.nickname;
				    //return data;
				}, function (err) {
				    console.log(err);
				});
        },
        register: function (username, fullname, password) {
            debugger;
            var user = {
                username: username,
                nickname: fullname,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    saveSessionKey(data.sessionKey, data.nickname);
				    sessionKey = data.sessionKey;
				    bashUsername = data.nickname;
				    //return data.fullname;
				});
        },
        logout: function () {
            if (localStorage.getItem("sessionKey")) {

                return httpRequester.putJSON(this.apiUrl + "logout?sessionKey=" + localStorage.getItem("sessionKey"))
		    .then(function () {
		        clearLocalStorage();
		        console.log("in succes logut");
		        var router = application.router();
		        router.navigate("/");

		    }, function () {
		        debugger;
		        console.log("in error logout");
		        clearLocalStorage();
		        var router = application.router();
		        router.navigate("/");
		    });
            }
            else {
                console.log("It's allready logged out");
            }


        },
        currentUser: function () {
            return localStorage.getItem("displayName");
        }
    });

    var PostsPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
        },

        create: function (postModel) {
            var url = this.rootUrl + "?sessionKey=" + sessionKey;
            return httpRequester.postJSON(url, postModel);
        },

        all: function () {
            var url = this.rootUrl + "?sessionKey=" + localStorage.getItem("sessionKey");
            return httpRequester.getJSON(url);
        },

        getById: function (id, success, error) {
            var url = this.rootUrl + id + "?sessionKey=" + sessionKey;

            return httpRequester.getJSON(url);
        },

        getByTags: function (tags, success, error) {
            var url = this.rootUrl + "?tags=" + tags + "sessionKey" + sessionKey;

            return httpRequester.getJSON(url);
        }
    });
    
    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());