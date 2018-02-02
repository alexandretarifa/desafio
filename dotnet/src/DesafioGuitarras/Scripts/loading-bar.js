function onBegin() {
    $('#resultSearch').hide(500);
    $('#loadingBar').show(0);
    $('#loadProgressBar').removeClass("concluded");
    $('#loadProgressBar').css('width', '90%').attr("aria-valuenow", 90);
}

function onComplete() {
    $('#loadProgressBar').addClass("concluded");
    $('#loadProgressBar').css('width', '100%').attr("aria-valuenow", 100);
    $("#loadingBar").delay(500).fadeOut(20).queue(function (next) {
        $('#loadProgressBar').delay(1200).css('width', '0%').attr("aria-valuenow", 0);
        next();
    });
}

function onSuccess() {
    $('#resultSearch').delay(800).slideDown(500);
}