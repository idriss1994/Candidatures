$.validator.addMethod("allowedExtensions",
       function (value, element, param) {
        
       value = "." + value.split(".").pop();

        if (value != ".pdf" && value != ".jpeg" && value != ".jpg" &&
        value != ".png") {
            console.log("The value is: "+ value);
            return false;
        } 
        else {
            return true;
        }

});

$.validator.unobtrusive.adapters.addBool("allowedExtensions");