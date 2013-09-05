/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
define(["class"], function (Class) {
    var controls = controls || {};
    var ComboBox = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var list = document.createElement("select");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("a");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                list.appendChild(listItem);
            }
            return list.outerHTML;
        }
    });

    var DetailsBox = Class.create({
        init: function (singleItemSource) {
            this.singleItemSource = singleItemSource;
        },

        render: function (template) {
            var div = document.createElement("div");
            div.innerHTML = template(this.singleItemSource);

            return div;
        }
    });
    controls.comboBox = function (itemsSource) {
        return new ComboBox(itemsSource);
    }

    controls.detailsBox = function (singleItemSource) {
        return new DetailsBox(singleItemSource);
    }

    return controls;
});