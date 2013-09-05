/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="jquery-ui-1.10.3.js" />
/// <reference path="ui.js" />
/// <reference path="require.js" />

var controllers = (function () {

    var rootUrl = "http://localhost:16274/api/";


    var Controller = Class.create({
        init: function () {
            this.persister = persister.get(rootUrl);
        },

        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {

                this.loadHomeUI(selector);
            }
            else {
                this.loadLoginFormsUI(selector);
            }

            this.attachEvents();
        },

        loadHomeUI: function (selector) {
            var html = ui.getGameContainer(this.persister.nickname());
            $(selector).html(html);

            $(".menu").kendoMenu();

            //this.attachEvents();
        },

        attachEvents: function () {
            var self = this;

            $("#wrapper").on("click", "#btn-register", function () {
                var user = {
                    username: self.registerViewModel.username,
                    nickname: self.registerViewModel.nickname,
                    password: self.registerViewModel.password
                };

                debugger;

                self.persister.user.register(
                user,
                function () {
                    $("#tabstrip").hide("drop", { direction: "down" }, 1000, self.loadHomeUI("#wrapper"));

                },
                function (error) {
                    var errorObject = JSON.parse(error.responseText);
                    console.log(errorObject);
                    //$("#error-field").html(errorObject.Message);
                });

            });

            $("#wrapper").on("click", "#btn-login", function () {
                debugger;
                var user = {
                    username: self.loginViewModel.username,
                    password: self.loginViewModel.password
                };

                self.persister.user.login(
                    user,
                    function () {
                        $("#tabstrip").hide("drop", { direction: "down" }, 1000, self.loadHomeUI("#wrapper"));

                    },
                    function (error) {
                        var errorObject = JSON.parse(error.responseText);
                        console.log(errorObject);
                        //$("#error-field").html(errorObject.Message);
                    });
            });

            $(".navbar").on("click", "li", function (ev) {
                $(".active").removeClass("active");

                console.log(ev);

                $(ev.target).parent("li").addClass("active");
            });

            $(".navbar").on("click", "#logout", function () {
                self.logout("#wrapper");
            });
        },

        loadLoginFormsUI: function (selector) {
            var loginFormHtml = ui.getLoginField();
            $(selector).html(loginFormHtml);

            $("#tabstrip").kendoTabStrip({
                animation: {
                    open: {
                        effects: "fadeIn"
                    }
                }
            });

            debugger;

            this.registerViewModel = kendo.observable({
                username: "",
                nickname: "",
                password: ""
            });

            this.loginViewModel = kendo.observable({
                username: "",
                password: ""
            });

            kendo.bind("#tabstrip-2", this.registerViewModel);
            kendo.bind("#tabstrip-1", this.loginViewModel);
        },

        loadPosts: function (selector) {
            this.persister.post.all(function (posts) {
                var dataSource = new kendo.data.DataSource({
                    data: posts,
                    pageSize: 15,
                    //selectable: true,
                });
                debugger;
                $("#main-content").kendoListView({
                    dataSource: dataSource,
                    template: kendo.template($("#main-content").html())
                });
            }, function (error) {

            });
        },

        login: function (selector) {
            var self = this;

            var user = {
                username: $("#tb-login-username").val(),
                password: $("#tb-login-password").val(),
            }

            self.persister.user.login(
                user,
                function () {
                    $("#forms").hide("drop", { direction: "down" }, 1000, self.loadHomeUI(selector));

                },
                function (error) {
                    var errorObject = JSON.parse(error.responseText);
                    $("#error-field").html(errorObject.Message);
                });
        },

        register: function (selector) {
            var self = this;
            var user = {
                username: $("#tb-register-username").val(),
                nickname: $("#tb-register-nickname").val(),
                password: $("#tb-register-password").val()
            };
            this.persister.user.register(
                user,
                function (data) {
                    $("#forms").hide();
                    self.loadHomeUI(selector);
                },
            function (error) {
                var errorObject = JSON.parse(error.responseText);
                $("#error-field").html(errorObject.Message);
            });
        },

        logout: function () {
            this.persister.user.logout();
            this.loadLoginFormsUI("#wrapper");
        },

    });

    return {
        get: function () {
            return new Controller();
        }
    }

})();