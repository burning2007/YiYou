//Custom js functions
$(function () {
    var url = window.location.href.toLowerCase();
    if (url.indexOf('integration') > -1) {
        $('.no-ign').hide();
    }
});
