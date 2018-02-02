var uiInteraction = {

    bindCollapseEvent: function () {
        $('.collapsable').click(uiInteraction.collapse);
    },

    bindTooltip: function (selector) {
        if (selector != null && selector != undefined)
            $(selector).tooltip();
        else
            $('[data-toggle="tooltip"]').tooltip();
    },

    collapse: function () {
        var removeChevron;
        var addChevron;
        var divToCollapse = $(this).parent().find(".collapse");
        if (divToCollapse.hasClass('in')) {
            divToCollapse.slideUp(500, function () { divToCollapse.removeClass('in'); });
            removeChevron = "glyphicon-chevron-up";
            addChevron = "glyphicon-chevron-down";
        }
        else {
            divToCollapse.slideDown(500, function () { divToCollapse.addClass('in'); });
            removeChevron = "glyphicon-chevron-down";
            addChevron = "glyphicon-chevron-up";
        }
        $(this).find("." + removeChevron).removeClass(removeChevron).addClass(addChevron);
    },

    showConfirmationModal: function (options) {
        $('#confirm-modal-cancel-button').hide();
        $('#confirm-modal-confirm-button').unbind('click');

        $('#confirm-modal-title').html(options.title);
        $('#confirm-modal-message').html(options.message);
        $('#confirm-modal-confirm-button').html(options.buttonText);
        $('#confirm-modal-confirm-button').addClass(options.buttonCssClass);
        $('#confirm-modal-confirm-button').click(options.onConfirm);
        if (options.cancellable === true)
            $('#confirm-modal-cancel-button').show();

        $('#confirm-modal-dialog').modal("show");
    },

    closeConfirmationModal: function () {
        $('#confirm-modal-confirm-button').unbind('click');
        $('#confirm-modal-dialog').modal("hide");
    },

    showDisplayModal: function (options) {
        $('#display-modal-title').html(options.title);
        $('#display-modal-body').html(options.content);
        $('#display-modal-dialog').modal("show");
    },

    closeDisplayModal: function () {
        $('#display-modal-dialog').modal("hide");
    },

    showNotifications: function (notifications) {
        if (notifications != null && notifications != undefined)
            $('#notifications').html(notifications);

        $('.alert-dismissable').show(300);
        $('body').scrollTop(0);
        setTimeout(function () { $('.alert-dismissable').fadeOut(10000); }, 30300);
    }
}