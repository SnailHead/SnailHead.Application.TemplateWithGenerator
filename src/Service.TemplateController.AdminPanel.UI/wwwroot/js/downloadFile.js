window.downloadFile = function(base64, extension) {
    var blob = base64toBlob(base64, `application/${extension}`);
    var url = window.URL.createObjectURL(blob);

    var a = document.createElement("a");
    a.href = url;
    a.download = `document.${extension}`;
    document.body.appendChild(a);
    a.click();

    window.URL.revokeObjectURL(url);
    document.body.removeChild(a);
}

function base64toBlob(base64, type) {
    var binary = atob(base64);
    var array = [];
    for (var i = 0; i < binary.length; i++) {
        array.push(binary.charCodeAt(i));
    }
    return new Blob([new Uint8Array(array)], { type: type });
}

window.downloadFile = function (args) {
    const { fileName, byteArray } = args;

    // Create blob from byte array
    const blob = new Blob([byteArray], { type: 'application/octet-stream' });

    // Create URL for the blob
    const url = window.URL.createObjectURL(blob);

    // Create link element and trigger download
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();

    // Cleanup
    window.URL.revokeObjectURL(url);
    document.body.removeChild(link);
}