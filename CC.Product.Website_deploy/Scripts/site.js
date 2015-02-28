$(function () {

    $("ul.nav.navbar-nav li a").each(function (index, element) {
        var url = $(this).attr("href");
        if (url == window.location.pathname) {
            $(this).css("border-top-color", "#DD4B39");
            $(this).css("color", "white");
        }
    });

})