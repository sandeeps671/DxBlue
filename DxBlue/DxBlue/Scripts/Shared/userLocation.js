let lActionName = "", lModule = "", lRemarks = "";
var options = {
    enableHighAccuracy: true,
    timeout: 5000,
    maximumAge: 5000
};

function pushUserLocationAction(module, actionName, remarks) {
    //lActionName = actionName, lModule = module, lRemarks = remarks;
    //if (navigator.geolocation) {
    //    navigator.geolocation.getCurrentPosition(showOrderPosition, showOrderError, options);
    //}
    ////else { $("#message").html("Geolocation is not supported by this browser."); }
}
function showOrderError(error) {
    switch (error.code) {
        case 1: console.log("User denied the request for Geolocation."); break;
        case 2: console.log("Location information is unavailable."); break;
        case 3: console.log("The request to get user location timed out."); break;
        default: console.log("An unknown error occurred."); break;
    }
}
function showOrderPosition(position) {
    //var latlondata = position.coords.latitude + "," + position.coords.longitude;//var latlon = "Latitude" + position.coords.latitude + "," + "Longitude" + position.coords.longitude;
    let lat = position.coords.latitude;
    let lng = position.coords.longitude;

    var isMobile = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);
    var url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + lat + "," + lng + "&key=AIzaSyBIIQsM2EiHmR1xn7tQhbkRX1nzt3oJeAkk";
    $.getJSON(url, function (data, textStatus) {
        let locParam = {};
        locParam.Lat = lat;
        locParam.Lng = lng;
        locParam.Address = data.results[0].formatted_address;
        locParam.SourceId = isMobile ? 0 : 1;
        locParam.SourceName = isMobile ? "Android" : "Desktop";
        locParam.Module = lModule;
        locParam.Remarks = lRemarks;
        locParam.Browser = getBrowserName();
        locParam.ActionName = lActionName;
        locParam.OS = "";

        $.ajax({
            type: "POST",
            url: baseApiUrl + "/api/cUserLocation/PushUserLocationAction",
            data: JSON.stringify(locParam),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {
                if (res.IsValid) { }
                else { toastr.error(res.Msg); }
            },
            error: function (err) { toastr.error("Please check your form entries and try again"); },
            complete: function (res) { }
        });
        return false;
    });
}

function getBrowserName() {
    if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
        return 'Opera';
    } else if (navigator.userAgent.indexOf("Chrome") != -1) {
        return 'Chrome';
    } else if (navigator.userAgent.indexOf("Safari") != -1) {
        return 'Safari';
    } else if (navigator.userAgent.indexOf("Firefox") != -1) {
        return 'Firefox';
    } else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) {
        return 'IE';//crap
    } else {
        return 'Unknown';
    }
}