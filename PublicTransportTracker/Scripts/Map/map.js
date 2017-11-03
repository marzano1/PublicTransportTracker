var map = null;

function openMap() {
    var latlng = new google.maps.LatLng(-23.64340873969638, -46.730219057147224);
    var myOptions = {
        zoom: 15,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
    map.setCenter(new google.maps.LatLng(-20.7233106, -46.6146444));
}

function abreLink() {
    window.open('http://www.google.com.br');
}