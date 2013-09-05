/// <reference path="../libs/_references.js" />

(function () {

    var appLayout = new kendo.Layout('<div id=header></div><div id="main-content"></div>');
    var data = persisters.get("http://localhost:16274/api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/", function () {
        if (data.users.currentUser()) {
            router.navigate("/home");
        }
        else {
            viewsFactory.getLoginView()
            .then(function (loginViewHtml) {
                var loginVm = vmFactory.getLoginViewModel(function () {
                    router.navigate("/posts");
                });
                var view = new kendo.View(loginViewHtml,
                    { model: loginVm });
                appLayout.showIn("#header", view);

                $("#tabstrip").kendoTabStrip({
                    animation: {
                        open: {
                            effects: "fadeIn"
                        }
                    }
                });
            })
        }
    });

    router.route("/home", function () {
        viewsFactory.getNavigationView()
        .then(function (navigationViewHtml) {
            var view = new kendo.View(navigationViewHtml);
            appLayout.showIn("#header", view);

            $("#menu").kendoMenu();
        })
    });

    router.route("/posts", function () {
        //viewsFactory.getAllPostsView()
        //.then(function (allPostsViewHtml) {
        //    vmFactory.getAllPostsViewModel()
        //    .then(function (viewModel) {
        //        var view = new kendo.View(allPostsViewHtml,
        //             { model: viewModel });

        //        appLayout.showIn("#main-content", view);

        //        $(".menu").kendoMenu();
        //    })
        //});
        debugger;

        data.posts.all()
        .then(function (posts) {
            var dataSource = new kendo.data.DataSource({
                data: posts
            });

            $("#main-content").kendoGrid({
                dataSource: dataSource,
                selectable: true,
                sortable: true,
                groupable: true,
                editable: true,
                columns: [
                    { field: "title", title: "Title" },
                    { field: "postedBy", title: "Author" },
                    { field: "postDate", title: "Posted On" },
                ]
            });
        })


        
        //dataSource.read();
    });

    router.route("/posts/:tags", function () {

    });

    router.route("/logout", function () {
        controller.logout();
        router.navigate("/");
    });

    router.route("/posts/:postId", function () {

    });

    router.route("/posts/:postId/comment", function () {

    });

    $(function () {
        appLayout.render("#app");
        router.start();
        router.navigate("/");
    });

    return {
        router: function () {
            return router;
        }
    }

})();