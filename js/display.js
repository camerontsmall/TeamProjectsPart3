function showHelp(){
    var backdrop = document.getElementById('help_backdrop');
    var helpscreen = document.getElementById('help_screen');

    helpscreen.style.display = 'block';
    backdrop.style.display = 'block';
    backdrop.style.opacity = 1;
}

function hideHelp() {
    var backdrop = document.getElementById('help_backdrop');
    var helpscreen = document.getElementById('help_screen');
    helpscreen.style.display = 'none';
    backdrop.style.display = 'none';
    backdrop.style.opacity = 0;
}

function loadRooms(){
    var type = document.getElementById('roomtypeinput').value;
    var park = document.getElementById('parkinput').value;

    var api_url  = "./api/rooms.php";
    if(type && park){
        api_url = "./api/rooms.php?type=" + type + "&park=" + park;
    }
    $.ajax({
        url : api_url,
        method: 'GET',
        contentType : 'application/json',
        success: function (data) {
            data = JSON.parse(data);
            var list = document.getElementById('roomlist');
            list.innerHTML = "";
            for (n in data) { 
                list.innerHTML += '<option value="' + data[n]['room_code'] + '"></option>';
            }
        }
    });
}