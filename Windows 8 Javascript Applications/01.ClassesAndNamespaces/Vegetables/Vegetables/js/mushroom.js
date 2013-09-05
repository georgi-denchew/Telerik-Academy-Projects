/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="//Microsoft.WinJS.1.0/js/ui.js" />
/// <reference path="vegetable.js" />

WinJS.Namespace.defineWithParent(Plants, "Mixin", {
    Mushroom: {
        grow: function (waterLiters) {
            if (this.length) {
                this.length += waterLiters;
            }
            else if (this.radius) {
                this.radius += waterLiters;
            }
        }
    }
});