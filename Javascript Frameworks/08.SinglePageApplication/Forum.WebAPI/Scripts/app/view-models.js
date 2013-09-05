/// <reference path="../libs/_references.js" />
window.vmFactory = (function () {
    var data = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "a",
            nickname: "b",
            password: "c",
            login: function () {

                data.users.login(this.get("username"), this.get("password"))
                .then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                }, function () {
                    if (errorCallback) {
                        errorCallback();
                    }
                });
            },

            register: function () {
                data.users.register(this.get("username"), this.get("nickname"), this.get("password"))
                .then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                });
            }
        }

        return kendo.observable(viewModel);
    }

    function getAllPostsViewModel() {
        return data.posts.all()
        .then(function (posts) {
            var viewModel = {
                posts: posts
            };

            return kendo.observable(viewModel);
        });
    }

    function setPersister(persister) {
        data = persister;
    }

    return {
        setPersister: setPersister,
        getLoginViewModel: getLoginViewModel,
        getAllPostsViewModel: getAllPostsViewModel
    }

})();