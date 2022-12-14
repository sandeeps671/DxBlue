var baseApiUrl = "";
$.ajaxSetup({
    beforeSend: function (xhr) {
        if (localStorage.getItem("UserToken"))
            xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem("UserToken"));
    }
});