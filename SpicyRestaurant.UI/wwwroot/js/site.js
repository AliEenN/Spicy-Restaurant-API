// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {
            $("#form-modal .modal-body").html(response);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal('show');
        }
    });
}

jQueryAjaxPost = form => {
    try {

        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $("#view-all").html(res.html);
                    $("#form-modal .modal-body").html('');
                    $("#form-modal .modal-title").html('');
                    $("#form-modal").modal('hide');

                    toastr.success('Category Saved Successfly.');
                }
                else
                    $("#form-modal .modal-body").html(res.html);
            },
            error: function (err) {
                console.log(err);
            }
        });

    } catch (e) {
        console.log(e);
    }

    // To prevent default form submit event
    return false;
}

jQueryAjaxDelete = form => {
    bootbox.confirm({
        message: "Are you sure, You want to delete this Category?",
        buttons: {
            confirm: {
                label: 'Yes',
                className: 'btn-danger'
            },
            cancel: {
                label: 'No',
                className: 'btn-outline-secondary'
            }
        },
        callback: function (result) {
            if (result) {
                try {
                    $.ajax({
                        type: 'POST',
                        url: form.action,
                        data: new FormData(form),
                        contentType: false,
                        processData: false,
                        success: function (res) {
                            toastr.success('Category Deleted Successfully.');

                            $('#view-all').html(res.html);
                        },
                        error: function (err) {
                            console.log(err)
                        }
                    })
                } catch (ex) {
                    console.log(ex)
                }
            }
        }
    });

    //prevent default form submit event
    return false;
}