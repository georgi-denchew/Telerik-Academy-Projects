var controls = (function () {
    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
             .replace(/'/g, "&#039;");
    }

    function getFirstChild(el){
        var firstChild = el.firstChild;
        while(firstChild != null && firstChild.nodeType == 3){ // skip TextNodes
            firstChild = firstChild.nextSibling;
        }
        return firstChild;
    }

    function getNextSiblingOfType(currentNode, type) {
        var currentNodeSibling = currentNode.nextElementSibling;
        while (currentNodeSibling && !(currentNodeSibling instanceof type)) {
            currentNodeSibling = currentNodeSibling.nextElementSibling;
        }

        return currentNodeSibling;
    }

    function compareAlbumAsc(a, b) {
        if (a.title < b.title)
            return -1;
        if (a.title > b.title)
            return 1;
        return 0;
    }

    function compareAlbumDesc(a, b) {
        if (a.title < b.title)
            return 1;
        if (a.title > b.title)
            return -1;
        return 0;
    }

    function addImage(title, path) {
        var newImage = new Image(title, path);
        return newImage;
    }
    
    function imageClickEvenet(ev) {
        var clickedItem = ev.target;

        var bigImage = document.querySelector("#gallery_image_big_display");

        if (bigImage) {
            bigImage.src = clickedItem.src;
        } else {
            bigImage = document.createElement("img");
            bigImage.id = "gallery_image_big_display";
            bigImage.src = clickedItem.src;
            document.body.appendChild(bigImage);
        }
    }

    function addAlbum(title) {
        var newAlbum = new Album(title);
        return newAlbum;
    }

    function loadAlbum(albumParent, albumData) {
        var titleAlbum = albumData.title;
        var newAlbum = albumParent.addAlbum(titleAlbum);
        
        var imagesAlbumData = albumData.images;
        var i, len;
        if (imagesAlbumData) {
            for (i = 0, len = imagesAlbumData.length; i < len; i += 1) {
                newAlbum.addImage(imagesAlbumData[i].title, imagesAlbumData[i].path);
            }
        }

        var albumsAlbumData = albumData.subAlbums;
        if (albumsAlbumData) {
            for (i = 0, len = albumsAlbumData.length; i < len; i += 1) {
                loadAlbum(newAlbum, albumsAlbumData[i]);
            }
        }

        return newAlbum;
    }

    function albumTitleClickEvenet(ev) {
        var clickedItem = ev.target;

        // First Sublist - may be the images list or the Albums list if no images
        var firstSublist = getNextSiblingOfType(clickedItem, HTMLUListElement);

        if (!firstSublist) {
            return;
        }

        if (firstSublist.style.display === "none") {
            firstSublist.style.display = "";
        } else {
            firstSublist.style.display = "none";
        }

        // Second Sublist - this is the Albums list if we have an images sublist before that
        var secondSublist = getNextSiblingOfType(firstSublist, HTMLUListElement);

        if (!secondSublist) {
            return;
        }

        if (secondSublist.style.display === "none") {
            secondSublist.style.display = "";
        } else {
            secondSublist.style.display = "none";
        }
    }

    function albumSortClickEvenet(ev) {
        var clickedItem = ev.target;
        var clickedItemClassName = clickedItem.className;

        // We search for the UL which holds the subAlbums
        var clickedItemSibling = getNextSiblingOfType(clickedItem, HTMLUListElement);

        var subAlbumsList = [];
        if (clickedItemSibling) {
            subAlbumsList = clickedItemSibling.childNodes;
        }

        if (subAlbumsList.length > 0) {
            var subAlbumsTitleList = [];
            var i, len;
            for (i = 0, len = subAlbumsList.length; i < len; i += 1) {
                var subAlbumItem = subAlbumsList[i];
                var subAlbumTitle = getFirstChild(subAlbumItem).innerHTML;
                subAlbumsTitleList.push({
                    title: subAlbumTitle,
                    obj: subAlbumItem
                });
            }

            if (clickedItemClassName === "gallery_album_list_item_sort_asc") {
                subAlbumsTitleList.sort(compareAlbumAsc);
            } else {
                subAlbumsTitleList.sort(compareAlbumDesc);
            }

            var subAlbumsParrent = subAlbumsList[0].parentNode;
            for (i = 0, len = subAlbumsTitleList.length; i < len; i += 1) {
                subAlbumsParrent.appendChild(subAlbumsTitleList[i].obj);
            }
        }

        if (clickedItemClassName === "gallery_album_list_item_sort_asc") {
            clickedItem.className = "gallery_album_list_item_sort_desc";
            clickedItem.innerHTML = "SortDesc";
        } else {
            clickedItem.className = "gallery_album_list_item_sort_asc";
            clickedItem.innerHTML = "SortAsc";
        }
    }

    function buildImageGalleryFromData(selector, imageGalleryData) {
        var newImageGallery = new ImageGallery(selector);
        var imagesImageGallery = imageGalleryData.images;
        var i, len;
        if (imagesImageGallery) {
            for (i = 0, len = imagesImageGallery.length; i < len; i+=1) {
                newImageGallery.addImage(imagesImageGallery[i].title, imagesImageGallery[i].path);
            }
        }

        var albumsImageGallery = imageGalleryData.albums;
        if (albumsImageGallery) {
            for (i = 0, len = albumsImageGallery.length; i < len; i += 1) {
                loadAlbum(newImageGallery, albumsImageGallery[i]);
            }
        }

        return newImageGallery;
    }

    function imageGalleryEventListener (ev) {
        if (!ev) {
            ev = window.event;
        }
        
        if (ev.stopPropagation) {
            ev.stopPropagation();
        }
        if (ev.preventDefault) {
            ev.preventDefault();
        }

        var clickedItem = ev.target;

        if ((clickedItem instanceof HTMLAnchorElement) && (clickedItem.className === "gallery_album_title")) {
            albumTitleClickEvenet(ev);
        }

        if ((clickedItem instanceof HTMLImageElement) && (clickedItem.className === "gallery_img")) {
            imageClickEvenet(ev);
        }

        if ((clickedItem instanceof HTMLAnchorElement) &&
            ((clickedItem.className === "gallery_album_list_item_sort_asc") ||
            (clickedItem.className === "gallery_album_list_item_sort_desc"))
           ) {
            albumSortClickEvenet(ev);
        }
    }

    function ImageGallery(selector) {
        var images = [];
        var albums = [];
        var gallerHolder = document.querySelector(selector);
        
        if (gallerHolder.addEventListener) {
            gallerHolder.addEventListener("click", imageGalleryEventListener, false);
        }

        if (gallerHolder.attachEvent) {
            gallerHolder.attachEvent('onclick', imageGalleryEventListener);
        }
        
        var imagesList = document.createElement("ul");
        var albumsList = document.createElement("ul");

        this.addImage = function (title, path) {
            var newImage = addImage(title, path);
            images.push(newImage);
            return newImage;
        }

        this.addAlbum = function (title) {
            var newAlbum = addAlbum(title);
            albums.push(newAlbum);
            return newAlbum;
        }
        
        this.render = function () {
            emptyGallery();
            renderImagas();
            renderAlbums();

            return this;
        }

        this.getImageGalleryData = function () {
            var thisGalleryData = {};

            var i, len;
            if (images.length > 0) {
                var imagesData = [];

                for (i = 0, len = images.length; i < len; i+=1) {
                    imagesData.push(images[i].serialize());
                }
                thisGalleryData.images = imagesData;
            }

            if (albums.length > 0) {
                var albumsData = [];

                for (i = 0, len = albums.length; i < len; i += 1) {
                    albumsData.push(albums[i].serialize());
                }
                thisGalleryData.albums = albumsData;
            }

            return thisGalleryData;
        }

        function emptyGallery() {
            while (gallerHolder.firstChild) {
                gallerHolder.removeChild(gallerHolder.firstChild);
            }

            while (imagesList.firstChild) {
                imagesList.removeChild(imagesList.firstChild);
            }

            while (albumsList.firstChild) {
                albumsList.removeChild(albumsList.firstChild);
            }

            return this;
        }

        function renderImagas() {
            for (var i = 0, len = images.length; i < len; i += 1) {
                var domImage = images[i].render();
                imagesList.appendChild(domImage);
            }
            gallerHolder.appendChild(imagesList);

            return this;
        }

        function renderAlbums() {
            for (var i = 0, len = albums.length; i < len; i += 1) {
                var domAlbum = albums[i].render();
                albumsList.appendChild(domAlbum);
            }
            gallerHolder.appendChild(albumsList);

            return this;
        }
    }

    function Image(titleIn, pathIn) {
        var title = escapeHtml(titleIn);
        var path = escapeHtml(pathIn);

        this.render = function () {
            var itemNode = document.createElement("li");
            itemNode.className = "gallery_img_list";
            itemNode.innerHTML = "<p>" + title + "</p><a href='#'class=\"gallery_image_link\" ><img src=\"" + path + "\" alt=\"" + title + "\" class=\"gallery_img\"/></a>";

            return itemNode;
        }

        this.serialize = function () {
            var thisImageData = {
                title: titleIn,
                path: pathIn
            };

            return thisImageData;
        }
    }

    function Album(titleIn) {
        var title = escapeHtml(titleIn);
        var images = [];
        var subAlbums = [];

        this.addImage = function (titleImg, pathImg) {
            var newImage = addImage(titleImg, pathImg);
            images.push(newImage);
            return newImage;
        }

        this.addAlbum = function (titleAlbum) {
            var newAlbum = addAlbum(titleAlbum);
            subAlbums.push(newAlbum);
            return newAlbum;
        }

        this.render = function () {
            var itemNode = document.createElement("li");
            itemNode.className = "gallery_album_list_item";
            itemNode.innerHTML = "<a href='#' class='gallery_album_title'>" + title + "</a>" +
                                 "<a href='#' class='gallery_album_list_item_sort_asc'>SortAsc</a>";            

            var i, len;
            if (images.length > 0) {
                var imagesSublist = document.createElement("ul");

                for (i = 0, len = images.length; i < len; i += 1) {
                    var domImage = images[i].render();
                    imagesSublist.appendChild(domImage);
                }
                itemNode.appendChild(imagesSublist);
            }

            if (subAlbums.length > 0) {
                var albumsSublist = document.createElement("ul");

                for (i = 0, len = subAlbums.length; i < len; i += 1) {
                    var domSubAlbums = subAlbums[i].render();
                    albumsSublist.appendChild(domSubAlbums);
                }
                itemNode.appendChild(albumsSublist);
            }

            return itemNode;
        }

        this.serialize = function () {
            var thisAlbumData = {
                title : titleIn
            };

            var i, len;
            if (images.length > 0) {
                var imagesData = [];

                for (i = 0, len = images.length; i < len; i += 1) {
                    imagesData.push(images[i].serialize());
                }
                thisAlbumData.images = imagesData;
            }

            if (subAlbums.length > 0) {
                var albumsData = [];

                for (i = 0, len = subAlbums.length; i < len; i += 1) {
                    albumsData.push(subAlbums[i].serialize());
                }
                thisAlbumData.subAlbums = albumsData;
            }

            return thisAlbumData;
        }
    }

    return {
        getImageGallery: function (selector) {
            return new ImageGallery(selector);
        },

        buildImageGallery: buildImageGalleryFromData
    }
}())

var cookies = (function () {
    if (!String.prototype.startsWith) {
        String.prototype.startsWith = function (str) {
            if (this.length < str.length) {
                return false;
            }
            for (var i = 0; i < str.length; i++) {
                if (this[i] !== str[i]) {
                    return false;
                }
            }
            return true;
        }
    }

    function readCookie(name) {
        var allCookies = document.cookie.split(";");
        for (var i = 0; i < allCookies.length; i++) {
            var cookie = allCookies[i];
            var trailingZeros = 0;
            for (var j = 0; j < cookie.length; j++) {
                if (cookie[j] !== " ") {
                    break;
                }
            }
            cookie = cookie.substring(j);
            if (cookie.startsWith(name + "=")) {
                return cookie;
            }
        }
    }

    function createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        } else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    function removeCookie(name) {
        createCookie(name, "", -1);
    }

    return {
        read: readCookie,
        create: createCookie,
        remove: removeCookie
    };
}());

var imageGalleryRepository = (function(){
    function saveImageData(key, imageGalleryData) {
        var jsonObj = JSON.stringify(imageGalleryData);
        if (localStorage) {
            localStorage.setItem(key, jsonObj);
        } else {
            cookies.create(key, jsonObj, 100000);
        }
    }

    function loadImageData(key) {
        var jsonObj;
        if (localStorage) {
            jsonObj = localStorage.getItem(key);
        } else {
            jsonObj = cookies.read(key);
        }

        var imageGalleryData;
        if (jsonObj) {
            imageGalleryData = JSON.parse(jsonObj);
        }
        return imageGalleryData;
    }

    return{
        save: saveImageData,
        load: loadImageData
    }
}())