$.validator.addMethod("allowedExtensions",
    function (value, element, param) {

        value = "." + value.split(".").pop().toLowerCase();

        if (value != ".pdf" && value != ".jpeg" && value != ".jpg" && value != ".png") {
            
            return false;
        }
        else {
            
            return true;
        }

    });

$.validator.unobtrusive.adapters.addBool("allowedExtensions");