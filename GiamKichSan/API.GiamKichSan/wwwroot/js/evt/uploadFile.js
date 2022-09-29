let common = {
    maxLengthFileUpload: 10240000,
    validateFileUpload: function (file) {
        let that = this;

        if (file == null) return false;
        if (file.size > that.maxLengthFileUpload) return false;
        return true;
    },
    convertFileContentToBlob: function (fileContentResult) {
        return new Blob([fileContentResult], { type: "application/octetstream" });
    },
    showFileDownload: function (blob, fileName) {
        var isIE = false || !!document.documentMode;
        if (isIE) {
            window.navigator.msSaveBlob(blob, fileName);
        } else {
            var url = window.URL || window.webkitURL;
            link = url.createObjectURL(blob);
            var a = $("<a />");
            a.attr("download", fileName);
            a.attr("href", link);
            $("body").append(a);
            a[0].click();
            $("body").remove(a);
        }
    },
    downloadFile: function (url, method, data, fileName) {
        let that = this;

        $.ajax({
            type: method,
            url: url,
            data: data,
            cache: false,
            xhr: function () {
                var xhr = new XMLHttpRequest();
                xhr.onreadystatechange = function () {
                    if (xhr.readyState == 2) {
                        if (xhr.status == 200) {
                            xhr.responseType = "blob";
                        } else {
                            xhr.responseType = "text";
                        }
                    }
                };
                return xhr;
            },
            success: function (data, fileName) {
                var blob = that.convertFileContentToBlob(data);
                that.showFileDownload(blob);
            }
        });
    }

}