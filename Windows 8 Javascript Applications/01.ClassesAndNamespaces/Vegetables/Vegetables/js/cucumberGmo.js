/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="vegetable.js" />
/// <reference path="mushroom.js" />
/// <reference path="cucumber.js" />
WinJS.Namespace.defineWithParent(Plants, "GMO", {
    CucumberGmo: WinJS.Class.mix(Plants.Bio.Cucumber, Plants.Mixin.Mushroom)
});