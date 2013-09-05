/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="vegetable.js" />

WinJS.Namespace.defineWithParent(Plants, "Bio", {
    Cucumber: WinJS.Class.derive(Plants.Vegetable, function (length) {

        Plants.Vegetable.call(this, "green", false);
        this.length = length;
    })
});