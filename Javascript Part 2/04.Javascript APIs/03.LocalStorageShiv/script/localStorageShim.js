(function () {
    var localStorageShimPrototype = {

        init: function () {
            if (document.cookie == "") {
                this.length = 0;
            }
            else {
                this.length = document.cookie.split(';').length;
            }
        },

        getItem: function (key) {
            var allItems = document.cookie.split(";"),
            i,
            j,
            currentItem,
            pair;

            for (i = 0; i < allItems.length; i++) {
                currentItem = allItems[i];
                for (j = 0; j < currentItem.length; j++) {
                    if (currentItem[j] !== " ") {
                        break;
                    }
                }

                currentItem = currentItem.substring(j);
                pair = currentItem.split("=");

                if (pair[0] === key) {
                    return pair[1];
                }
            }
        },

        setItem: function (key, value) {
            var futureDate = new Date();
            futureDate.setTime(futureDate.getTime() + (1000 * 24 * 60 * 60 * 1000));
            document.cookie = key + "=" + value + "; expires=" + futureDate.toGMTString() + ";";

            // If length is not altered explicitly, it won't change until the next page refresh
            // And thil will also have no negative effect after page refresh, because
            // the value is checked after each refresh in the init function. The same applies for 
            // clear() and removeItem();
            this.length += 1;
        },

        key: function (position) {

            var currentPosition = 0,
                i,
                j,
                allItems,
                currentItem;

            allItems = document.cookie.split(";");

            for (i = 0; i < allItems.length; i++) {
                currentItem = allItems[i];

                if (position === currentPosition) {
                    return currentItem.split("=")[0];
                }
                else {
                    currentPosition++;
                }
            }

        },

        clear: function () {
            var allItems,
                currentItem,
                i,
                j,
                pair,
                date,
                expires,

            allItems = document.cookie.split(";");

            for (i = 0; i < allItems.length; i++) {

                currentItem = allItems[i];

                for (j = 0; j < currentItem.length; j++) {
                    if (currentItem[j] !== " ") {
                        break;
                    }
                }

                currentItem = currentItem.substring(j);

                pair = currentItem.split("=");

                date = new Date();
                date.setTime(date.getTime() + (-1 * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toGMTString();
                document.cookie = pair[0] + "=" + "" + expires + ";";

            }
            this.length = 0;
        },

        removeItem: function (key) {
            var allItems,
                currentItem,
                i,
                j,
                pair;

            allItems = document.cookie.split(";");

            for (i = 0; i < allItems.length; i++) {

                currentItem = allItems[i];

                for (j = 0; j < currentItem.length; j++) {
                    if (currentItem[j] !== " ") {
                        break;
                    }
                }

                currentItem = currentItem.substring(j);

                pair = currentItem.split("=");

                if (pair[0] === key) {
                    var date = new Date();
                    date.setTime(date.getTime() + (-1 * 24 * 60 * 60 * 1000));
                    var expires = "; expires=" + date.toGMTString();
                    document.cookie = key + "=" + "" + expires + ";";
                    break;
                }
            }
            this.length -= 1;
        }
    };

    function LocalStorageShim() {

        function F() { };
        F.prototype = localStorageShimPrototype;

        var f = new F();

        f.init();
        return f;
    }

    var local = new LocalStorageShim();

    window["localStorage"] = window["localStorage"] || new LocalStorageShim();

})();