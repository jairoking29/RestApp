﻿function initMap() {
    var clickFlag = 0;
    var map;

    var initialPosition = { lat: 18.4736744, lng: -69.9141168 };

    geolocate();

    map = new google.maps.Map(document.getElementById('map'), {
        center: getLocationFromInputs(),
        scrollwheel: true,
        zoom: 15
    });

    placeMarker(getLocationFromInputs());

    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(event.latLng);
    });

    var autocomplete = new google.maps.places.Autocomplete(
                (document.getElementById('locationInput')),
                { types: ['geocode'] });
    autocomplete.addListener('place_changed', function () {
        var place = autocomplete.getPlace();
        if (place) {
            var location = { lat: place.geometry.location.lat(), lng: place.geometry.location.lng() };
            placeMarker(location);
            map.panTo(location);
        }
    });

    function placeMarker(location) {
        if (clickFlag == 0) {
            marker = new google.maps.Marker({
                position: location,
                animation: google.maps.Animation.DROP,
                map: map,
            });
            clickFlag = 1;
        }
        else {
            marker.setPosition(location);
            map.panTo(location);
        }
        setPositionOnInputs(location);
    }

    function setPositionOnInputs(location) {
        $("#latitude").val(location.lat);
        $("#longitude").val(location.lng);
    }

    function getLocationFromInputs() {
        return {
            lat: Number($("#latitude").val()) || initialPosition.lat,
            lng: Number($("#longitude").val()) || initialPosition.lng
        }
    }

    function geolocate() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                var geolocation = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude
                };
                var circle = new google.maps.Circle({
                    center: geolocation,
                    radius: position.coords.accuracy
                });
                autocomplete.setBounds(circle.getBounds());
            });
        }
    }
}
