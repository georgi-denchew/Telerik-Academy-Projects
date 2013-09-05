/// <reference path="require.js" />
/// <reference path="underscore.js" />
/// <reference path="mustache.js" />
/// <reference path="jquery-2.0.2.js" />
define(["jquery", "mustache", "jquery-ui", "underscore"], function ($, Mustache) {

    function buildLoginField() {
        return '<div id="forms">\
                <h1>Telerik Academy Battle Game</h1>\
            <ul>\
                <li><a href="#login">Log in</a></li>\
                <li><a href="#register">Register</a></li>\
                <li id="error-field"></li>\
            </ul>\
            <div id="login">\
                <label for="tb-login-username">Username: </label>\
                <input type="text" id="tb-login-username" />\
                <label for="tb-login-password">Password: </label>\
                <input type="text" id="tb-login-password" />\
                <a href="#/btn-login"><button>login</button></a>\
            </div>\
            <div id="register">\
                <label for="tb-register-username">Username: </label>\
                <input type="text" id="tb-register-username" />\
                <label for="tb-register-nickname">Nickname: </label>\
                <input type="text" id="tb-register-nickname" />\
                <label for="tb-register-password">Password: </label>\
                <input type="text" id="tb-register-password" />\
                <a href="#/btn-register"><button>Register</button></a>\
            </div>\
        </div>';
    };

    function buildGameContainer(nickname) {
        return '<div class="navbar"><div class="navbar-inner"><ul class="nav">\
                <li>\
                <a href="#/active-games">join games</a>\
                </li>\
                <li><a href="#/in-progress-games">my games</a></li>\
                <li><a id="logout" href="#/logout">Logout</a></li>\
                </ul></div></div>\
                <div id="container"></div>';
    }

    function buildOpenGames(games) {
        var list = document.createElement("ul");
        list.className = "nav nav-tabs nav-stacked";
        var openGamesTemplate = Mustache.compile(document.getElementById("open-games-template").innerHTML);

        _.each(games, function (game) {
            list.innerHTML += openGamesTemplate(game);
        });

        return list;
    }

    function buildActiveGames(games, nickname) {

        var list = document.createElement("ul");
        list.className = "nav nav-tabs nav-stacked";

        var activeGamesTemplate = Mustache.compile(document.getElementById("active-games-template").innerHTML);

        _.each(games, function (game) {
            list.innerHTML += activeGamesTemplate(game);
        });

        return list;
    }

    function buildMessages(messages) {

        var list = document.createElement("ul");
        list.className = "messages";

        var messagesTemplate = Mustache.compile(document.getElementById("messages-template").innerHTML);

        _.each(messages, function (msg) {
            list.innerHTML += messagesTemplate(msg);
        });

        return list;
    }

    function buildScoresField(scoresObjects) {
        var list = document.createElement("ul");
        list.className = "scores-list";

        var scoresTemplate = Mustache.compile(document.getElementById("scores-template").innerHTML);

        _.each(scoresObjects, function (obj) {
            list.innerHTML += scoresTemplate(obj);
        });

        return list;
    }

    function appendHeroes(owner) {
        var squareTemplate = Mustache.compile(document.getElementById("square-template").innerHTML);

        _.each(owner.units, function (unit) {
            
            var square = squareTemplate(unit);

            var currentRow = unit.position.x;
            var currentColl = unit.position.y;

            var element = $('#row' + currentColl + ' #coll' + currentRow);

            element.append(square);
            element.css("background", unit.owner);
            element.css('color', '#fff');
        });
    }

    function buildGameField(game) {
        var html = '<table class="table table-bordered" border="1" cellspacing="5" cellpadding="5" data-game-id="' + $("<div />").html(game.gameId).text() + '">\
        <tr>\
            <th id="game-title" colspan="9">' + $("<div />").html(game.title).text() + '</th>\
        </tr>\
        <tr>\
            <th class="player" colspan="9">' + '<span class="left">' + $("<div />").html(game.red.nickname).text() +
            '</span><span class="right">' + $("<div />").html(game.blue.nickname).text() + '</span></th>\
        </tr>';

        for (var i = 0; i < 9; i++) {
            html += '<tr id="row' + i + '" data-row="' + i + '">';

            for (var j = 0; j < 9; j++) {
                html += '<td id="coll' + j + '" data-coll="' + j + '">';

                html += '</td>';
            }

            html += '</tr>';
        }

        return html;
    }

    function buildHeroButtons() {

    }

    return {
        getLoginField: buildLoginField,
        getGameContainer: buildGameContainer,
        getOpenGames: buildOpenGames,
        getActiveGames: buildActiveGames,
        getScores: buildScoresField,
        getGameField: buildGameField,
        getHeroes: appendHeroes,
        getMessages: buildMessages,
        getHeroButtons: buildHeroButtons
    }
});