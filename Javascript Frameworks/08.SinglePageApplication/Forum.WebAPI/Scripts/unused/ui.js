/// <reference path="require.js" />
/// <reference path="underscore.js" />
/// <reference path="mustache.js" />
/// <reference path="jquery-2.0.2.js" />
var ui = (function () {

    function buildLoginField() {
        return '<div id="tabstrip">\
            <ul>\
                <li class="k-state-active">Log in</li>\
                <li>Register</li>\
            </ul>\
            <div id="login">\
                <label for="tb-login-username">Username: </label>\
                <input data-bind="value: username" type="text" id="tb-login-username" />\
                <label for="tb-login-password">Password: </label>\
                <input data-bind="value: password" type="text" id="tb-login-password" />\
                <button class="k-button" id="btn-login">login</button>\
            </div>\
            <div id="register">\
                <label  for="tb-register-username">Username: </label>\
                <input data-bind="value: username" type="text" id="tb-register-username" />\
                <label for="tb-register-nickname">Nickname: </label>\
                <input data-bind="value: nickname" type="text" id="tb-register-nickname" />\
                <label for="tb-register-password">Password: </label>\
                <input data-bind="value: password" type="text" id="tb-register-password" />\
                <button class="k-button" id="btn-register">Register</button>\
            </div>\
        </div>';
    };

    function buildGameContainer(nickname) {
        return '<header><nav>\
                <ul class="menu">\
                    <li>\
                        <a href="#/home">Home</a>\
                    </li>\
                    <li>\
                        <a href="#/posts">View Posts</a>\
                    </li>\
                    <li>\
                        <a href="#/create">Create Post</a>\
                    </li>\
                    <li>\
                        <a href="#/logout">Logout</a>\
                    </li>\
                </ul>\
            </nav>\
        </header><ul id="main-content"></ul>';
    }
    
    function getTable() {
        return '<table id="posts-table" class="metrotable">\
                    <thead>\
                        <tr>\
                            <th>Title</th>\
                            <th>Text</th>\
                            <th>Tags</th>\
                        </tr>\
                    </thead>\
                    <tbody>\
                        <tr>\
                            <td colspan="3"></td>\
                        </tr>\
                    </tbody>\
                </table>';
    }

    return {
        getLoginField: buildLoginField,
        getGameContainer: buildGameContainer,
        getTable: getTable,
    }
})();