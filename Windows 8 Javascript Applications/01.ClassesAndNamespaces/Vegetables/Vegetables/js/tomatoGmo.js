/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="vegetable.js" />
/// <reference path="tomato.js" />
/// <reference path="mushroom.js" />

WinJS.Namespace.defineWithParent(Plants, "GMO", {
    TomatoGmo: WinJS.Class.mix(Plants.Bio.Tomato, Plants.Mixin.Mushroom)
});