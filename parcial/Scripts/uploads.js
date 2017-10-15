// A $( document ).ready() block.
var files = [];

$(document).ready(function () {
    debugger;
    $('input[type=file]').on('change', prepareUpload);

    function uploadFiles(files) {

        if (window.FormData !== undefined) {
            var data = new FormData();
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x].file);
            }
            $.ajax({
                type: "POST",
                url: $("#UrlUploadFiles").val(),
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    //debugger;
                    $(".UploadImage").val(result);
                    console.log(result);
                },
                error: function (xhr, status, p3, p4) {
                    //debugger;
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                    $("#thirdSection").show();
                }
            });
        } else {
            alert("This browser doesn't support HTML5 file uploads!");
            $("#thirdSection").show();
        }

    }

    function prepareUpload(event) {
        debugger;
        $.each(files, function (index, value) {
            if (value.name == event.target.id) {
                files.pop(index);
            }
        });
        files.push({
            file: event.target.files[0],
            name: event.target.id
        });

        uploadFiles(files);
    }
});