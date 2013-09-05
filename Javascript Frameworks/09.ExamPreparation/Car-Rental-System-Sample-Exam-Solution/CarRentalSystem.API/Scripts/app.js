/// <reference path="libs/_references.js" />
(function () {

    var router = new kendo.Router();
    var appLayout = new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");
    vmFactory.setPersister(data);

    router.route("/", function () {
        viewsFactory.getCarsView()
        .then(function (carsViewHtml) {
            var loginVM = vmFactory.getCarsVM()
            .then(function (viewModel) {
                var view = new kendo.View(carsViewHtml,
                    { model: viewModel });

                appLayout.showIn("#main-content", view);
            })
        })
    });

    router.route("/login", function () {
        viewsFactory.getLoginView()
        .then(function (loginViewHtml) {
            var loginVM = vmFactory.getLoginVM(function () {
                router.navigate("/");
            });
            var view = new kendo.View(loginViewHtml,
                { model: loginVM });
            appLayout.showIn("#main-content", view);

            $("#tabstrip").kendoTabStrip({
                animation: {
                    open: {
                        effects: "fadeIn"
                    }
                }
            });
        });
    });

    $(function () {
        appLayout.render("#app");
        router.start("/");
    });
})();