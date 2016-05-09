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

function loadRooms(dept_id){
    var type = document.getElementById('roomtypeinput').value;
    var park = document.getElementById('parkinput').value;

    var api_url  = "./api/rooms.php?dept=" + dept_id;
    if(type && park){
        api_url = "./api/rooms.php?type=" + type + "&park=" + park + "&dept=" + dept_id;
    }
    $.ajax({
        url : api_url,
        method: 'GET',
        contentType : 'application/json',
        success: function (data) {
            data = JSON.parse(data);
            var list = document.getElementById('roomlist');
            list.innerHTML = "<option value=''>No preference</option>";
            for (n in data) { 
                list.innerHTML += '<option value="' + data[n]['room_code'] + '">' + data[n]['room_code'] + '</option>';
            }
            loadRoomInfo();
        }
    });
}

function loadRoomInfo() {
    var code = document.getElementById('roomlist').value;

    var api_url = "./api/room.php?code=" + code;

    $.ajax({
        url: api_url,
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {
            data = JSON.parse(data);
            var el = document.getElementById('roominfo');
            if (data != null) {
                el.innerHTML = "Park: " + data['park'] + " Capacity:" + data["capacity"] + " Type:" + data["type"];
            } else {
                el.innerHTML = "No room selected";
            }
            
        }
    });
}



 function loadModules(dept_id) {
    var code = document.getElementById('partinput').value;

    var api_url = "./api/modules.php?part=" + part + "&dept=" + dept_id;
    $.ajax({
        url: api_url,
        method: 'GET',
        contentType: 'application/json',
        success: function (data) {
            data = JSON.parse(data);
            var list = document.getElementById('moduleinput');
            list.innerHTML = "<option value=''>--</option>";
            for (n in data) {
                row = data[n];
                list.innerHTML += '<option value="' + row['module_code'] + '">' + row['module_code'] + ' - ' + row['module_title'] + '</option>';
            }
        }
    });
}

function deleteRequest(id) {

    if (confirm("Delete request " + id + "?")) {
        window.location.href = "./editrequest?delete=" + id;
    }
}


function withdrawRequest(id) {

    if (confirm("Withdraw request " + id + "?")) {
        window.location.href = "./editrequest?withdraw=" + id;
    }
}

function deleteRoomReq(id, reqid) {

    if (confirm("Delete room request " + id + "?")) {
        window.location.href = "./editroom?delete=" + id + "&reqid=" + reqid;
    }
}

var fontSize = 1;
var inverted = 0;
function zoomIn() {
    /* Button to make the font size bigger using JavaScript */
    fontSize += 0.1;
    //document.body.style.fontSize = fontSize + "em";
    document.getElementById("wrapper").style.fontSize = fontSize + "em";
    //document.getElementById("Button").style.fontSize = fontSize + "em";
}
function zoomOut() {
    /* Button to make the font size smaller using JavaScript */
    fontSize -= 0.1;
    //document.body.style.fontSize = fontSize + "em";
    document.getElementById("wrapper").style.fontSize = fontSize + "em";
    //document.getElementById("Button").style.fontSize = fontSize + "em";
}

function reset() {
    fontSize = 1;
    /* Button to reset the font size using JavaScript */
    document.getElementById("wrapper").style.fontSize = "initial";

}

function invert(){
    /* Javascript for inverting page colours */
    if (inverted) {
        document.body.style.webkitFilter = "initial";

        document.body.style.backgroundColor = "initial";
        inverted = 0;
    } else {

        document.body.style.webkitFilter = "invert(100%)";
        document.body.style.backgroundColor = "black";
        inverted = 1;
    }
}

function reinvert(){
    /* Javascript for re-inverting page colours */
    
}