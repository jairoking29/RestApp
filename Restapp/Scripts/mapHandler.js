$(function () {
    function initMap() {
        var myLatLng = {lat: 18.4736744, lng: -69.9141168};

        var map = new google.maps.Map(document.getElementById('map'), {
            center: myLatLng,
            scrollwheel: true,
            zoom: 4
        });
    }

    $("#map").

    var marker = new google.maps.Marker({
        map: map,
        position: myLatLng,
        title: ''
    });
});

    <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap"
async defer>