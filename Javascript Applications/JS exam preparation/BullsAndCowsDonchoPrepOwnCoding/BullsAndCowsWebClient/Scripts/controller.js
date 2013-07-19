/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="jquery-ui-1.10.3.js" />
/// <reference path="ui.js" />

var controllers = (function () {

    var rootUrl = "http://localhost:40643/api/";

    var Controller = Class.create({

        init: function () {
            this.persister = persister.get(rootUrl);
        },

        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn(selector)) {
                this.loadGameUI(selector);
            }
            else {
                this.loadLoginFormUI(selector);
            }

            this.attachUIEventHandlers(selector);
        },

        loadLoginFormUI: function (selector) {
            var loginFormHtml = ui.generateLoginForms();
            $(selector).html(loginFormHtml);
            $("#forms").tabs();
        },

        loadGameUI: function (selector) {
            var html = ui.gameUI(this.persister.nickname());
            $(selector).html(html);

            this.persister.game.open(function (games) {
                var list = ui.generateOpenGames(games);
                $(selector + " #open-games-container").html(list);
            });

            this.persister.game.myActive(function (games) {
                var list = ui.generateActiveGames(games);
                $(selector + " #active-games-container").html(list);
            });
            var self = this;
            //setInterval(function () {
                
                this.persister.messages.all(function (messages) {
                    var list = ui.buildMessages(messages);
                    $(selector + " #messages-holder").html(list);
                });
            //}, 100);
        },

        loadGame: function (selector, gameId){
            this.persister.game.state(gameId, function (gameState) {
                debugger;
                var gameHtml = ui.buildGameState(gameState);
                $("#game-holder").html(gameHtml);
            });
        },

        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val(),
                }

                self.persister.user.login(
                    user,
                    function () {
                        $("#forms").hide("highlight", {}, 1000);
                        self.loadGameUI(selector);
                    },
                        function (error) {
                            wrapper.html("fuck");
                            console.log(error);
                        });

                return false;
            });

            wrapper.on("click", "#btn-register", function () {
                var user = {
                    username: $(selector + " #tb-register-username").val(),
                    nickname: $(selector + " #tb-register-nickname").val(),
                    password: $(selector + " #tb-register-password").val()
                };

                self.persister.user.register(
                    user,
                    function (data) {
                        $("#forms").hide("highlight", {}, 1000);
                        self.loadGameUI(selector);
                    },
                function (error) {
                    wrapper.html("errrrror");
                    console.log(error);
                });

                console.log("reached");
                return false;
            });

            wrapper.on('click', '#btn-logout', function () {
                self.persister.user.logout(function () {
                    self.loadLoginFormUI(selector);
                }, function () {
                })
            });

            wrapper.on('click', "#open-games-container a", function () {
                $("#game-join-inputs").remove();
                var html = '<div id="game-join-inputs">Number: <input type="text" id="tb-game-number" />\
                            Password: <input type="text" id="tb-game-password" />\
                            <button id="btn-join-game">join</button></div>';
                $(this).after(html);
                console.log('here');
            });

            wrapper.on('click', "#btn-join-game", function () {
                var game = {
                    number: $("#tb-game-number").val(),
                    gameId: $(this).parents("li").first().data("game-id"),
                };
                var password = $("#tb-game-password").val();

                if (password) {
                    game.password = password;
                }

                self.persister.game.join(game);
            });

            wrapper.on('click', "#btn-create-game", function () {

                debugger;
                var game = {
                    title: $("#tb-create-title").val(),
                    number: $("#tb-create-number").val()
                }

                var password = $("#tb-create-password").val();

                if (password) {
                    game.password = password;
                }

                self.persister.game.create(game);
            });

            wrapper.on('click', '.active-games .in-progress', function () {
                console.log('hi');
                self.loadGame(selector, $(this).parent().data('game-id'));
            });

            wrapper.on('click', '#make-guess', function () {
                
                var guess = {
                    number: $("#tb-make-guess"),
                    gameId: $(this).parents("#game-state").data("game-id")
                };
            });
        },
    });

    return {
        get: function () {
            return new Controller();
        }
    }
})();

$(function () {
    var controller = controllers.get();
    controller.loadUI("#wrapper");
});