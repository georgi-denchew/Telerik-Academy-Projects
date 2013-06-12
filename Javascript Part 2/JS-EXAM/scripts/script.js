var controls = (function () {

    var i = 0;

    function Gallery(selector) {
        var images = [];
        var albums = [];
        var galleryContainer = document.querySelector(selector);
        galleryContainer.style.display = "inline-block";


        this.addImage = function (title, source) {
            var newImage = new Image(title, source);
            images.push(newImage);
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };


        galleryContainer.addEventListener("click",
            function (ev) {
                if (!ev) {
                    ev = window.event;
                }
                ev.stopPropagation();
                ev.preventDefault();

                var clickedElement = ev.target;

                //Show/Hide Albums
                if (clickedElement instanceof HTMLAnchorElement) {
                    var parentToClickedElement = clickedElement.parentNode;

                    if (parentToClickedElement.nextElementSibling) {
                        var elementToHide = parentToClickedElement.nextElementSibling;

                        while (elementToHide) {
                            if (elementToHide.style.display === "none") {
                                if (elementToHide instanceof HTMLDivElement) {
                                    elementToHide.style.display = "block";
                                }
                                else if (elementToHide instanceof HTMLInputElement) {
                                    elementToHide.style.display = "block";
                                }
                                else {
                                    elementToHide.style.display = "inline-block";
                                }
                            }
                            else {
                                elementToHide.style.display = "none";
                            }
                            elementToHide = elementToHide.nextElementSibling;
                        }
                    }
                }

                //Show/Hide images
                if (clickedElement instanceof HTMLImageElement) {
                    var copyElement = clickedElement.cloneNode(true);
                    var displayContainer = document.querySelector("#image-container");
                    displayContainer.style.position = "absolute";
                    copyElement.style.width = "200%";
                    displayContainer.style.margin = "40px";
                    if (displayContainer.firstChild) {
                        while (displayContainer.firstChild) {
                            displayContainer.removeChild(displayContainer.firstChild);
                        }
                    }
                    displayContainer.appendChild(copyElement);
                }

                if (clickedElement instanceof HTMLInputElement) {
                    if (clickedElement.nextElementSibling) {
                        var elementToSort = clickedElement.nextElementSibling;
                        var titleElement;
                        var titleName;
                        while (elementToSort) {

                            if (elementToSort instanceof HTMLDivElement) {
                                titleElement = elementToSort.querySelector("div").querySelector("a");
                                titleName = titleElement.innerHTML;
                            }

                            elementToSort = elementToSort.nextElementSibling;
                        }
                    }
                }
            },
            false);

        this.render = function () {

            if (galleryContainer.firstChild) {
                while (galleryContainer.firstChild) {
                    galleryContainer.removeChild(galleryContainer.firstChild);
                }
            }

            var sortButton = document.createElement("input");
            sortButton.type = "button";
            sortButton.value = "Sort";
            sortButton.style.display = "block";
            sortButton.style.margin = "0 auto";
            galleryContainer.appendChild(sortButton);


            if (images) {
                for (var i = 0; i < images.length; i += 1) {
                    var newImage = images[i].render();
                    galleryContainer.appendChild(newImage);
                }
            }

            if (albums) {
                for (var i = 0; i < albums.length; i += 1) {
                    var newAlbum = albums[i].render();
                    galleryContainer.appendChild(newAlbum);
                }
            }
        }

        this.serialize = function () {

            var serializedImages = [];
            var serializedAlbums = [];

            for (var i = 0; i < images.length; i += 1) {
                serializedImages.push(images[i].serialize());
            }

            for (var i = 0; i < albums.length; i += 1) {
                serializedAlbums.push(albums[i].serialize());
            }

            var serialized = {
                serializedImages: serializedImages,
                serializedAlbums: serializedAlbums
            };
            return serialized;
        }
    }

    function Image(title, source) {


        var img = document.createElement("img");
        img.src = source;

        var imageContainer = document.createElement("span");
        imageContainer.style.display = "inline-block";

        var titleContainer = document.createElement("header");
        titleContainer.style.textAlign = "center";
        var stringTitle = title.replace("<", "&#60");
        stringTitle = stringTitle.replace(">", "&#62")
        titleContainer.innerHTML = stringTitle;
        
        imageContainer.appendChild(titleContainer);

        var anchor = document.createElement("a");
        
        anchor.href = "#";
        anchor.appendChild(img);
        imageContainer.appendChild(anchor);

        this.render = function () {
            return imageContainer;
        }

        this.serialize = function () {
            var currnetItem = {
                title: title,
                source: source
            };
            return currnetItem;
        }
    }

    function Album(title) {

        var images = [];
        var albums = [];
        var albumContainer = document.createElement("div");
        albumContainer.style.padding = "10px";
        albumContainer.style.marginBottom = "2px";

        this.addImage = function (title, source) {
            var newImage = new Image(title, source);
            images.push(newImage);
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.render = function () {
            var titleContainer = document.createElement("div");
            titleContainer.style.display = "block";
            var stringTitle = title.replace("<", "&#60");
            stringTitle = stringTitle.replace(">", "&#62")
            titleContainer.innerHTML = "<a href='#'>" + stringTitle + "</a>";
            titleContainer.style.textAlign = "center";

            if (albumContainer.firstChild) {
                while (albumContainer.firstChild) {
                    albumContainer.removeChild(albumContainer.firstChild);
                }
            }

            albumContainer.appendChild(titleContainer);
            var sortButton = document.createElement("input");
            sortButton.type = "button";
            sortButton.value = "Sort";
            sortButton.style.display = "block";
            sortButton.style.margin = "0 auto";
            albumContainer.appendChild(sortButton);
            albumContainer.style.border = "1px solid #ccc";

            if (images) {
                for (i = 0; i < images.length; i += 1) {
                    var newImage = images[i].render();
                    albumContainer.appendChild(newImage);
                }
            }

            if (albums) {
                for (i = 0; i < albums.length; i += 1) {
                    var newAlbum = albums[i].render();
                    albumContainer.appendChild(newAlbum);
                }
            }

            return albumContainer;
        };


        this.serialize = function () {
            var currentItem = {
                title: title
            };

            if (images.length > 0) {
                var serializedImages = [];
                var serializedAlbums = [];

                for (i = 0; i < images.length; i += 1) {
                    serializedImages.push(images[i].serialize());
                }

                for (i = 0; i < albums.length; i++) {
                    serializedAlbums.push(albums[i].serialize());
                }
            }
            currentItem.images = serializedImages;
            currentItem.albums = serializedAlbums;
            return currentItem;
        };
    }

    function addItem(item, data) {

        if (data.title && data.source) {
            item.addImage(data.title, data.source);
        }

        else if (data.images && data.albums) {

            var album = item.addAlbum(data.title);

            if (data.images.length > 0) {
                for (i = 0; i < data.images.length; i+= 1) {
                    addItem(album, data.images[i]);
                }
            }

            if (data.albums.length > 0) {
                for (i = 0; i < data.albums.length; i++) {
                    addItem(album, data.albums[i]);
                }
            }
        }
    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        },

        buildImageGallery: function (selector, data) {
            var imageGallery = this.getImageGallery(selector);

            if (data.serializedImages) {
                for (i = 0; i < data.serializedImages.length; i++) {
                    addItem(imageGallery, data.serializedImages[i]);
                }
            }

            if (data.serializedAlbums) {
                for (i = 0; i < data.serializedAlbums.length; i++) {
                    addItem(imageGallery, data.serializedAlbums[i]);
                }
            }

            return imageGallery;
        }
    }
})();