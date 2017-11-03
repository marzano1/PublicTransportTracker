var isSideMenuOpened = false;


function openNav() {
    if (!isSideMenuOpened) {
        document.getElementById("mySidenav").style.width = "280px";
        isSideMenuOpened = true
    }
    else {
        document.getElementById("mySidenav").style.width = "0";
        isSideMenuOpened = false
    }
    
}