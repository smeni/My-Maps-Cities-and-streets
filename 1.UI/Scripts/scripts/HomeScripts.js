$(function () {

    var urlCity = 'http://localhost:51541/Home/GetAllCities';
    var urltreetes = 'http://localhost:51541/Home/GetAllstreetes?cityId=';

    $.get(urlCity, function (data, status) {

        if (status === "success") {

            $.each(data, function (i, data) {

                $('#cityesList').append($('<option>', {
                    value: data.ID,
                    text: data.Name
                }));
            });
        }
        if (status === "error")
            alert('error func');
    });

    $('#cityesList').change(function () {

        var cityId = $('#cityesList').find(":selected").val();

        $.get(urltreetes + cityId, function (data, status) {

            if (status == "success") {
                $.each(data, function (i, data) {

                    if (cityId == data.CityID) {
                        $('#streetesList').append($('<option>', {
                            value: data.ID,
                            text: data.Name
                        }));
                    }
                });
            }
            if (status == "error")
                alert('error func');
        });
        $('#streetesList').empty();
    });
});