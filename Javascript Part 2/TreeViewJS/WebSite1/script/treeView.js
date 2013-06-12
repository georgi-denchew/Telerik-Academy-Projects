(function () {
    var db = {
        folders: ["New Folder", "New Folder(1)", "New Folder(2)"]
    };

    TreeView = function (param) {
        this.treeViewContainer = param.treeViewContainer
    }

    TreeView.prototype = {
        init: function () {
            this.initDB();
        },
        initDB: function () {
            var i;
            var foldersCount = db.folders.length;

            for (i = 0; i < foldersCount; i++) {
                this.treeViewContainer.innerHTML += "<li>" + db.folders[i] + "</li>";
            }
        }
    };


})();
