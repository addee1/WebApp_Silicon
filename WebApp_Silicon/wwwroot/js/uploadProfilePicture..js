document.getElementById('upload-button').addEventListener('click', function () {
    document.getElementById('file-input').click();
});

function uploadImage() {
    // H�mta filen som anv�ndaren valde
    var file = document.getElementById('file-input').files[0];

    // H�r kan du l�gga till kod f�r att hantera filen, till exempel ladda upp den med AJAX.
}
