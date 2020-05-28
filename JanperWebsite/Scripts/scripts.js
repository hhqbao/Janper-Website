

    function handleMenuLoad(id) {
        $(".closeSubMenu").css("display", "none");
    $("#Dura").animate({left: '50px' }, 1000, function () {
        {
            $("#Dura").css("z-index", "10");
    }
});

$(".closeSubMenu").css("display", "none");
        if ($("#menu").hasClass("expanded")) {
        $("#container").animate({ left: '250px' }, { duration: 1000 });
    }
        else {
        $("#container").animate({ left: '50px' }, { duration: 1000 });
    }
        switch (id) {
            case "homeLink":
        $.ajax(
                    {
        url: "../Home/Index",
                        success: function (result) {
        $("#content-container").html(result);
    $(window).scrollTop(0);
}
})
break;
case "sheenMenu":
$.ajax(
                    {
        url: "../JanperAcrylic/Index",
                        success: function (result) {
        $("#content-container").html(result);
    $(window).scrollTop(0);
}
})
break;
case "edgeMenu":
$.ajax(
                    {
        url: "../JanperEdge/Index",
                        success: function (result) {
        $("#content-container").html(result);
    $(window).scrollTop(0);
}
})
break;
case "TradeMenu":
$.ajax(
                    {
        url: "../TradeArea/Index",
                        success: function (result) {
        $("#content-container").html(result);
    $(window).scrollTop(0);
}
})
break;
case "ContactMenu":
$.ajax(
                    {
        url: "../ContactPage/Index",
                        success: function (result) {
        $("#content-container").html(result);
    $(window).scrollTop(0);
}
})
break;
case "AboutLink":
$.ajax(
                    {
        url: "../Home/Index",
                        success: function (result) {
        $("#content-container").html(result);
    $("#red").scrollView();
}
})
break;
}
}

        function handleDuraFormLoad(id, isLoaded) {
        if (isLoaded) {
            switch (id) {
                case "DuraColours":
            $.ajax(
                        {
            url: "../DuraForm/Colours/Index",
                            success: function (result) {
            $("#DuraForm").replaceWith(result);
        $(window).scrollTop(0);
        $('#SeriesHeader').text("");
        $('#SeriesBlurb').text("");
    }
})
break;
case "DuraOptions":
$.ajax(
                        {
            url: "../DuraForm/Options",
                            success: function (result) {
            $("#DuraForm").replaceWith(result);
        $(window).scrollTop(0);
        $('#SeriesHeader').text("");
        $('#SeriesBlurb').text("");
    }
})
break;

default:
        switch (id)
                                    {
                                        case "DuraS1":
        $(window).scrollTop(0);
        $("#SeriesHeader").text("SeriesOne");
        $("#SeriesBlurb").text("@Html.Partial("../DuraForm/Blurbs/SeriesOne")");
            break;

        case "DuraS2":
            $('#SeriesTwo').scrollView();
        $("#SeriesHeader").text("SeriesTwo");
        $("#SeriesBlurb").text("@Html.Partial("../DuraForm/Blurbs/SeriesTwo")");
            break;

        case "DuraS3":
            $('#SeriesThree').scrollView();
        $("#SeriesHeader").text("SeriesThree");
        $("#SeriesBlurb").text("@Html.Partial("../DuraForm/Blurbs/SeriesThree")");
            break;

        case "DuraS4":
            $('#SeriesFour').scrollView();
        $("#SeriesHeader").text("SeriesFour");
        $("#SeriesBlurb").text("@Html.Partial("../DuraForm/Blurbs/SeriesOne")");
            break;

        case "DuraS5":
            $('#SeriesFive').scrollView();
        $('#SeriesHeader').text("SeriesFive");
        $('#SeriesBlurb').text("@Html.Partial("../DuraForm/Blurbs/SeriesFive")");
            break;
    }
}
}
        else {
            switch (id) {
                case "DuraColours":
            $.ajax(
                        {
            url: "../DuraForm/Colours/Index",
                            success: function (result) {
            $("#content-container").html(result);
        $(window).scrollTop(0);
        $('#SeriesHeader').text("");
        $('#SeriesBlurb').text("");
    }
})
break;
case "DuraOptions":
$.ajax(
                        {
            url: "../DuraForm/Options",
                            success: function (result) {
            $("#content-container").html(result);
        $(window).scrollTop(0);
        $('#SeriesHeader').text("");
        $('#SeriesBlurb').text("");
    }
})
break;

default:
$.ajax(
                        {
            url: "../DuraForm/Index",
                            success: function (result) {
            $("#content-container").html(result);
        }
    }).done(function ()
                        {

            setTimeout(function () {
                switch (id) {
                    case "DuraS1":
                        $(window).scrollTop(0);
                        $("#SeriesHeader").text("SeriesOne");
                        $("#SeriesBlurb").text("@Html.Partial("../ DuraForm / Blurbs / SeriesOne")");
                        break;

                    case "DuraS2":
                        $('#SeriesTwo').scrollView();
                        $("#SeriesHeader").text("SeriesTwo");
                        $("#SeriesBlurb").text("@Html.Partial("../ DuraForm / Blurbs / SeriesTwo")");
                        break;

                    case "DuraS3":
                        $('#SeriesThree').scrollView();
                        $("#SeriesHeader").text("SeriesThree");
                        $("#SeriesBlurb").text("@Html.Partial("../ DuraForm / Blurbs / SeriesThree")");
                        break;

                    case "DuraS4":
                        $('#SeriesFour').scrollView();
                        $("#SeriesHeader").text("SeriesFour");
                        $("#SeriesBlurb").text("@Html.Partial("../ DuraForm / Blurbs / SeriesOne")");
                        break;

                    case "DuraS5":
                        $('#SeriesFive').scrollView();
                        $('#SeriesHeader').text("SeriesFive");
                        $('#SeriesBlurb').text("@Html.Partial("../ DuraForm / Blurbs / SeriesFive")");
                        break;
                }
            }, 1000);
        });
}
}
}


        $.fn.scrollView = function () {
        return this.each(function () {
            $('html, body').animate({
                scrollTop: $(this).offset().top
            }, 1000);
        });
    }

        $("#menuHamburger").click(function () {
        if ($(window).width() > 1279) {
            $("header").animate({ left: '200px' }, { duration: 1000, queue: false });
        $("#menu").animate({left: '0px' }, {duration: 1000, queue: false });
        $("#menu").toggleClass("expanded");
            $("#container").animate({left: '250px' }, {duration: 1000, queue: false });
        $("#menuHamburger").css("display", "none");
        $("#closeMenu").css("display", "inline-block");
            if ($(".closeSubMenu").css("display") == "block") {
            $("#container").animate({ left: '450px' }, { duration: 1000, queue: false });
        }
    }
        else {
            $("#menu").css("height", "100vh");
        $(".menu-wrapper").animate({top: '0px' }, {duration: 1000 });
        $("#openMenu").css("display", "none");
        $("#closeMenu").css("display", "block");
    }
});

        $("#closeMenu").click(function () {
        if ($(window).width() > 1279) {
            $("#menu").animate({ left: '-200px' }, { duration: 1000 });
        $("#menu").toggleClass("expanded");
            $("#container").animate({left: '50px' }, {duration: 1000 });
            $("header").animate({left: '0' }, {duration: 1000, queue: false });
        $("#menuHamburger").css("display", "block");
        $("#closeMenu").css("display", "none");
        $(".closeSubMenu").css("display", "none");
            $("#Sheen").animate({left: '50px' }, {duration: 1000, queue: false });
            $("#Dura").animate({left: '50px' }, {duration: 1000, queue: false });
            $("#Edge").animate({left: '50px' }, {duration: 1000, queue: false });
            $("#Ease").animate({left: '50px' }, {duration: 1000, queue: false });
    }
        else {
            $(".menu-wrapper").animate({ top: '-100vh' }, 1000, function () {
                $("#menu").css("height", "75px");
            });

        $("#openMenu").css("display", "block");
        $("#closeMenu").css("display", "none");
    }
});

        function closeMenu(menuToClose) {
        if ($(window).width() > 1279) {

            $("#" + menuToClose).animate({ left: '50px' }, 1000, function () {
                {
                    $("#" + menuToClose).css("z-index", "10");
                }
            });

        $(".closeSubMenu").css("display", "none");
            if ($("#menu").hasClass("expanded")) {
            $("#container").animate({ left: '250px' }, { duration: 1000 });
        }
            else {
            $("#container").animate({ left: '50px' }, { duration: 1000 });
        }
    }
}

        $("#menuList li").click(function () {
        if ($(window).width() > 1279) {
            $("#menuList li").each(function () {
                $(this).removeClass("highlight");
            });
        $(this).add
            switch ($(this).attr('id')) {
                case 'sheenMenu':
                    $("#Sheen").animate({left: '250px' }, 1000);
        $(".closeSubMenu").css("display", "block");
                    $("#Dura").animate({left: '50px' }, 1000, function () {
        });
                    $("#Edge").animate({left: '50px' }, 1000, function () {
        });
                    $("#Ease").animate({left: '50px' }, 1000, function () {
        });

        break
    case 'duraMenu':
                    $("#Dura").animate({left: '250px' }, 1000);
                    $("#container").animate({left: '450px' }, {duration: 1000 });
        $(".closeSubMenu").css("display", "block");
                    $("#Sheen").animate({left: '50px' }, 1000, function () {
        });
                    $("#Edge").animate({left: '50px' }, 1000, function () {
        });
                    $("#Ease").animate({left: '50px' }, 1000, function () {
        });
        break
    case 'edgeMenu':
                    $("#Sheen").animate({left: '50px' }, 1000, function () {

        });
                    $("#Dura").animate({left: '50px' }, 1000, function () {

        });
                    $("#Ease").animate({left: '50px' }, 1000, function () {

        });
        break
    case 'easeMenu':
                    $("#Ease").animate({left: '250px' }, 1000);
                    $("#Sheen").animate({left: '50px' }, 1000, function () {
        });
                    $("#Dura").animate({left: '50px' }, 1000, function () {
        });
                    $("#Edge").animate({left: '50px' }, 1000, function () {
        });
        break
}
}
});

        $(".closeSubMenu").click(function () {
            $("#Dura li").each(function () {
                $(this).removeClass("highlight");
            });
        if ($(window).width() > 1279) {
            div = $(this).parent("div").eq(0).attr('id');
        closeMenu(div);

    }
});

        MutationObserver = window.MutationObserver || window.WebKitMutationObserver;
    
    var observer = new MutationObserver(function (mutations, observer) {
        // fired when a mutation occurs
        if ($("#content-container").children().first().attr("id") == "TradeArea") {
            $("#contact-form").hide();
        $("#HomeContact").show();
    }
        else {
            $("#contact-form").show();
        $("#HomeContact").hide();
    }

    // ...
});

// define what element should be observed by the observer
// and what types of mutations trigger the callback
    observer.observe(document, {
            subtree: true,
        attributes: true
        //...
    });

