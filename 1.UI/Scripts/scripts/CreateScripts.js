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

    $('#AddNewBtn').click(function () {

        var cityId = $('#cityesList').find(":selected").val();

        var cityName = $('#newCity').val();

        var streetNameToAdd = $('#newStreet').val();


        $.get('/Home/Create/', { cityId: cityId, streetName: streetNameToAdd, cityName: cityName },
            function (returnedData) {
                console.log(returnedData);
            });

    });

    $("#new_city").hide();

    $("#hide").click(function () {
        $("#exist_city").hide();
        $("#new_city").show();

        $('#cityesList').find(":selected").val('select city');
    });
});