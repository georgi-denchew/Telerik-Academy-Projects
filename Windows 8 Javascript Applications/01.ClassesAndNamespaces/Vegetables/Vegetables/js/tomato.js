/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="vegetable.js" />

WinJS.Namespace.defineWithParent(Plants, "Bio", {
    Tomato: WinJS.Class.derive(Plants.Vegetable, function (radius) {

        Plants.Vegetable.call(this, "red", true);
        this.radius = radius;
    })
})