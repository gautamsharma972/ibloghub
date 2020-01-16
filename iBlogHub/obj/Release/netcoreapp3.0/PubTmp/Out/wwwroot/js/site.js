$(document).ready(function () {
    $('article.article-post *').removeAttr('style');

    var img = $('.article-post').find('img:first');
    if ($("#imgFeatured").length > 0) {
        $("#imgFeatured").attr("src", img[0].src);
    }

    $("#btndelAll").click(function () {
        Swal.fire({
            title: "Confirm Delete",
            text: "Are you sure to remove all posts from you Collection?",
            showCancelButton: true,
            confirmButtonColor: "#d9534f",
            confirmButtonText: "Delete",
            cancelButtonText: "Cancel",
            buttonsStyling: true
        }).then(function (result) {
            if (result.dismiss !== "cancel") {
                $.ajax({
                    url: '/Stories/RemoveAllStory',
                    type: 'POST',
                    data: {
                        __RequestVerificationToken: token
                    },
                    success: function (response) {
                        Swal.fire(
                            "Deleted",
                            "" + response.msg
                        ).then(function () { window.location.reload(); });
                    },
                    failure: function (response) {
                        Swal.fire(
                            "Error",
                            "Oops, something went wrong! Please try again later.",
                            "error"
                        )
                    }
                });
            }
            else {
                Swal.fire(
                    "Cancelled",
                    "Your Posts are safe!",
                    "info"
                )
            }
        });
    });

    $("#btnDel").click(function () {
        var id = $(this).attr("data-id");
        var title = $(this).attr("data-title");
        Swal.fire({
            title: "Confirm Delete",
            text: "Are you sure to delete this post - " + title + "?",
            showCancelButton: true,
            confirmButtonColor: "#d9534f",
            confirmButtonText: "Delete",
            cancelButtonText: "Cancel",
            buttonsStyling: true
        }).then(function (result) {
            if (result.dismiss !== "cancel") {
                $.ajax({
                    url: '/Stories/DeleteConfirmed',
                    type: 'POST',
                    data: {
                        __RequestVerificationToken: token,
                        'id': id
                    },
                    success: function (response) {
                        Swal.fire(
                            "Deleted",
                            "" + response.msg
                        ).then(function () { location.reload(); });
                    },
                    failure: function (response) {
                        Swal.fire(
                            "Error",
                            "Oops, something went wrong! Please try again later.",
                            "error"
                        )
                    }
                });
            }
            else {
                Swal.fire(
                    "Cancelled",
                    "Your Post is safe!",
                    "info"
                )
            }
        });
    });
});

var form = $('#__AjaxAntiForgeryForm');
var token = $('input[name="__RequestVerificationToken"]', form).val();
function delPost(id, title) {
    Swal.fire({
        title: "Confirm Delete",
        text: "Are you sure to delete this post - " + title + "?",
        showCancelButton: true,
        confirmButtonColor: "#d9534f",
        confirmButtonText: "Delete",
        cancelButtonText: "Cancel",
        buttonsStyling: true
    }).then(function (result) {
        if (result.dismiss !== "cancel") {
            $.ajax({
                url: '/Stories/DeleteConfirmed',
                type: 'POST',
                data: {
                    __RequestVerificationToken: token,
                    'id': id
                },
                success: function (response) {
                    Swal.fire(
                        "Deleted",
                        "" + response.msg
                    ).then(function () { location.reload(); });
                },
                failure: function (response) {
                    Swal.fire(
                        "Error",
                        "Oops, something went wrong! Please try again later.",
                        "error"
                    )
                }
            });
        }
        else {
            Swal.fire(
                "Cancelled",
                "Your Post is safe!",
                "info"
            )
        }

    });
}

function removePost(id, title) {
    Swal.fire({
        title: "Confirm Delete",
        text: "Are you sure to delete this post from your Bookmarks - " + title + "?",
        showCancelButton: true,
        confirmButtonColor: "#d9534f",
        confirmButtonText: "Delete",
        cancelButtonText: "Cancel",
        buttonsStyling: true
    }).then(function (result) {
        if (result.dismiss !== "cancel") {
            $.ajax({
                url: '/Stories/DeleteBookmark',
                type: 'POST',
                data: {
                    __RequestVerificationToken: token,
                    'id': id
                },
                success: function (response) {
                    Swal.fire(
                        "Deleted",
                        "" + response.msg
                    ).then(function () { location.reload(); });
                },
                failure: function (response) {
                    Swal.fire(
                        "Error",
                        "Oops, something went wrong! Please try again later.",
                        "error"
                    )
                }
            });
        }
        else {
            Swal.fire(
                "Cancelled",
                "Your Post is safe!",
                "info"
            )
        }

    });
}

var onBegin = function () {
    $("#loader").fadeIn();
};
function Notify(data) {
    $("#loader").fadeOut();

    if (data.error == true) {
        Swal.fire({
            icon: "success",
            html: data.msg,
            showConfirmButton: false,
            timer: 1500
        })
    }
    else {
        Swal.fire({
            icon: "success",
            html: data.msg,
            showConfirmButton: false,
            timer: 1500
        })
    }

}
function NotifyError(data) {
    $("#loader").fadeOut();
    Swal.fire({
        title: "Error!",
        text: "Some error occurred, please try again later.",
        buttonsStyling: true
    });

}