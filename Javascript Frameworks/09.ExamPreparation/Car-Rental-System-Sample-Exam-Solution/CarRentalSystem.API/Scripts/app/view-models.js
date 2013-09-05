/// <reference path="../libs/_references.js" />
window.vmFactory = (function () {

    var data = null;

    function getLoginVM(successCallback, errorCallback) {
        var viewModel = {
            username: "username",
            password: "password",
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
            register: function (successCallback, errorCallback) {
                data.users.register(this.get("username"), this.get("password"))
                .then(function () {
                    if (successCallback) {
                        successCallback();
                    }
                }, function () {
                    if (errorCallback) {
                        errorCallback();
                    }
                });
            }
        };

        return new kendo.observable(viewModel);
    }

    function getCarsVM() {
        return data.cars.all()
        .then(function (cars) {
            var viewModel = {
                cars: cars,
                message: ""
            };

            return kendo.observable(viewModel);
        });
    }

    function setPersister(persister) {
        debugger;
        data = persister;
    }

    return {
        getLoginVM: getLoginVM,
        getCarsVM: getCarsVM,
        setPersister: setPersister
    }
})();