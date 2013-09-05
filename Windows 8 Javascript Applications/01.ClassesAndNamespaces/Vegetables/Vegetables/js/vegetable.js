/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
WinJS.Namespace.define("Plants", {
    Vegetable: WinJS.Class.define(function (color, directlyEatable) {

        this.color = color;

        this.directlyEatable = directlyEatable;
    }, {
    }, {

    })
});