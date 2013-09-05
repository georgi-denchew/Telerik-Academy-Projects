/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var ListView = Class.create({
        init: function (itemsSource, columnCount) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;
            this.columnCount = columnCount;
        },
        render: function (template) {
            var table = document.createElement("table");
            var row = document.createElement("tr");

            for (var i = 0; i < this.itemsSource.length; i++) {
                if (i % this.columnCount == 0) {
                    table.appendChild(row);
                    row = document.createElement("tr");
                }

                var cell = document.createElement("td");
                var item = this.itemsSource[i];
                cell.innerHTML = template(item);
                row.appendChild(cell);
            }

            table.appendChild(row);

            return table.outerHTML;
        }
    });

    c.getListView = function (itemsSource, columnCount) {
        return new ListView(itemsSource, columnCount);
    }
}(controls || {}));