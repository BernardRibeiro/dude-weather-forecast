(() => {
    "use strict";

    $(document).ready(function () {
        $('#btnYes').click(() => {

            navigator.geolocation.getCurrentPosition(resp => {
                const data = {
                    latitude: resp.coords.latitude,
                    longitude: resp.coords.longitude
                };

                $.post("/weatherforecast/index", data, function (response) {
                    $(".result").html(response);
                });
            });
        });
    });
})();