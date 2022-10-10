var parameterName = "";

function defineParameterName(name) {
    parameterName = name;
}

function addImageTo(filePath) {
    $("input[name='" + parameterName + "']").val(filePath);
    $("#photo-popup").dxPopup("instance").hide();
    $('#file-manager-popup').modal('hide');
}

$(function () {
    $("#file-manager").dxFileManager({
        name: "fileManager",
        fileSystemProvider: new DevExpress.fileManagement.RemoteFileSystemProvider({
            endpointUrl: "/api/file-manager-file-system-images"
        }),
        currentPath: "Widescreen",
        permissions: {
            create: true,
            copy: true,
            move: true,
            delete: true,
            rename: true,
            upload: true,
            download: true
        },
        onSelectedFileOpened: function (e) {
            let popup = $("#photo-popup").dxPopup("instance");
            let fileUrl = "/uploads/" + e.file.path;
            popup.option({
                showTitle: false,
                contentTemplate: '<button type="button" class="btn btn-primary waves-effect" onclick="addImageTo(\'' + fileUrl + '\')">Əlavə Et</button><p>Fayl url-i: ' + fileUrl + '</p><img src="' + fileUrl + '" class="photo-popup-image"  alt=""/>'
            });
            popup.show();
        }
    });

    $("#photo-popup").dxPopup({
        maxHeight: 600,
        closeOnOutsideClick: true,
        onContentReady: function (e) {
            let $contentElement = e.component.content();
            $contentElement.addClass("photo-popup-content");
        }
    });
});