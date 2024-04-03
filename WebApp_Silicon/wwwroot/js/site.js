document.addEventListener('DOMContentLoaded', function () {

    handleProfileImageUpload()

})

function handleProfileImageUpload() {
    try {

        let fileUploader = document.getElementById("uploadFile")

        if (uploadFile != undefined) {
            uploadFile.addEventListener('change', function () {
                if (this.files.length > 0)
                    this.form.submit()
            })
        }
    }
    catch { }
}