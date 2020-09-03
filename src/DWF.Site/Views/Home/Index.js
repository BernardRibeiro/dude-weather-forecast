(() => {
    "use strict";

    $(document).ready(function () {

        const setShowElement = (element, show) => {
            $(element).css('visibility', show ? 'visible' : 'hidden');
        };

        const initialize = () => {
            setShowElement('#result', false);
            setShowElement('#error-content', false);
        };

        $('#btnYes').click(() => {
            initialize();

            navigator.geolocation.getCurrentPosition(resp => {
                const data = {
                    latitude: resp.coords.latitude,
                    longitude: resp.coords.longitude
                };

                $.post(
                    "/weatherforecast/index",
                    data,
                    function (response) {
                        const data = JSON.parse(response);

                        $('#description').html(data.weather[0].description);
                        $('#temp').html(data.main.temp);
                        $('#temp-min').html(data.main.temp_min);
                        $('#temp-max').html(data.main.temp_max);
                        $('#localization').html(data.name);

                        setShowElement('#result', true);
                    }
                ).fail(function (response) {
                    const data = JSON.parse(response.responseText);

                    $("#error-content h4").html(data.error);

                    setShowElement('#error-content', true);
                });
            });

        });

        initialize();
    });
})();