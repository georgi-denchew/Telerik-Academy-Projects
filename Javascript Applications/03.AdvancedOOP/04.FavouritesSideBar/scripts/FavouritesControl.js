var favouritesControl = (function () {

    var SideBar = Class.create({
        init: function (selector, URLs, folders) {
            this.container = document.querySelector(selector);
            this.URLs = URLs;
            this.folders = folders;
        },
        addURL: function (URL) {
            if (!this.URLs) {
                this.URLs = [];
            }
            this.URLs.push(URL);
        },
        addFolder: function (folder) {
            if (!this.folders) {
                this.folders = [];
            }
            this.folders.push(folder);
        },
        display: function () {

            // Cleaning the contaniner
            while (this.container.firstChild) {
                this.container.removeChild(this.container.firstChild);
            }

            var fragment = document.createDocumentFragment();

            for (var i = 0, len = this.URLs.length; i < len; i++) {
                fragment.appendChild(this.URLs[i].getHTMLElement());
            }

            for (i = 0, len = this.folders.length; i < len; i++) {
                fragment.appendChild(this.folders[i].getHTMLElement());
            }
            this.container.appendChild(fragment);
        },
    });

    function removeAllChildren(container) {
        while (container.firstChild) {
            container.removeChild(container.firstChild);
        }
    };

    var Folder = Class.create({
        init: function (title, URLs) {
            this.title = title;
            this.URLs = URLs;
        },
        addURL: function (URL) {
            if (!this.URLs) {
                this.URLs = [];
            }
            this.URLs.push(URL);
        },
        getHTMLElement: function () {
            var container = document.createElement("li");
            var list = document.createElement("ul");
            container.innerHTML ="<a href='#'>" +  this.title + "</a>";

            for (i = 0, len = this.URLs.length; i < len; i++) {
                var listItem = document.createElement("li");
                listItem.appendChild(this.URLs[i].getHTMLElement());
                list.appendChild(listItem);
            }
            container.className = "folder";
            container.appendChild(list);
            return container;
        },
    });

    var URL = Class.create({
        init: function (title, URL) {
            this.title = title;
            this.URL = URL;
        },
        getHTMLElement: function () {
            var anchor = document.createElement("a");
            anchor.href = this.URL;
            anchor.innerHTML = this.title;
            anchor.target = "_blank";
            return anchor;
        }
    });

    return {
        getSideBar: SideBar,
        createFolder: Folder,
        createURL: URL,
    }
})();