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