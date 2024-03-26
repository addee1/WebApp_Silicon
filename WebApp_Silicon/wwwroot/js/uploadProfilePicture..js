document.getElementById('upload-button').addEventListener('click', function () {
    document.getElementById('file-input').click();
});

function uploadImage() {
    // Hämta filen som användaren valde
    var file = document.getElementById('file-input').files[0];

    // Här kan du lägga till kod för att hantera filen, till exempel ladda upp den med AJAX.
}
