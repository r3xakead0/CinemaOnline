
window.onscroll = function () {
    var scrol = (window.pageYOffset || document.documentElement.scrollTop);
    if (scrol > 200) {
        $(".btn-top").animate({ height: "show" }, 300);
    }
    if (scrol < 200) {
        $(".btn-top").animate({ height: "hide" }, 300);
    }
};

