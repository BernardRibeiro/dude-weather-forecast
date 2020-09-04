(() => {
    "use strict";

    $(document).ready(function () {

        new Vue({
            el: '#app',
            data: {
                result: {},
                messageError: '',
                showResult: false,
                showError: false,
                showSuccess: false
            },
            methods: {
                getWeatherForecast: async function () {
                    const _this = this;

                    navigator.geolocation.getCurrentPosition(resp => {                       
                        const data = {
                            latitude: resp.coords.latitude,
                            longitude: resp.coords.longitude
                        };

                        $.post(
                            "/weatherforecast/index",
                            data,
                            function (response) {
                                _this.result = JSON.parse(response); 
                                _this.showSuccess = true;
                                _this.showResult = true;
                            }
                        ).fail(function (response) {
                            const data = JSON.parse(response.responseText);

                            _this.messageError = data.error;
                            _this.showError = true;
                            _this.showResult = true;
                        });
                    });
                }
            }
        });

    });
})();