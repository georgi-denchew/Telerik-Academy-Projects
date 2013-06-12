var imageGalleryRepository = (function () {

    //if (!localStorage) {
    //    var localStorage = document.localStorage;
    //}

    function saveData(key, data) {
        
        document.localStorage.setItem(key, JSON.stringify(data));

    };

    function loadData(key) {
        var stringified = document.localStorage.getItem(key);
        var object = JSON.parse(stringified);
        return object;
    };

    return {
        save: function (key, data) {
            saveData(key, data);
        },

        load: function (key) {
            return loadData(key);
        }
    }
})();
