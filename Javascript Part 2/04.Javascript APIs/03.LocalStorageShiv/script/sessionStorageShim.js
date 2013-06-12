(function () {

    var sessionStoragePrototype = {

        init: function () {

            // that's the only differnce bewtween the shim and the actual sessionStorage
            // the prototype design pattern cannot have private properties
            this.pairs = {};

            // That's probably not the best way to implement the length property,
            // but it's the only one i came up with
            this.length = 0;
        },

        getItem: function (key) {
            return this.pairs[key];
        },

        setItem: function (key, value) {
            this.pairs[key] = [value];
            this.length += 1;
        },

        key: function (position) {
            var currentPosition = 0,
                key;

            for (key in this.pairs) {

                if (this.pairs.hasOwnProperty(key)) {

                    if (currentPosition === position) {
                        return key;
                    }
                    currentPosition += 1;
                }
            }
        },

        clear: function () {
            this.pairs = {};
            this.length = 0;
        },

        removeItem: function (key) {
            delete this.pairs[key];
            this.length -= 1;
        }
    };

    function sessionStorageShim() {

        function F() { };
        F.prototype = sessionStoragePrototype;

        var f = new F();

        f.init();
        return f;
    }


    window['sessionStorage'] = window['sessionStorage'] || new sessionStorageShim();

})();