var isdrag = false;
var tx, x, ty, y;
$(function () {
    document.getElementsByClassName("dragme")[0].addEventListener('touchend', function () {
        sdrag = false;
    });
    document.getElementsByClassName("dragme")[0].addEventListener('touchstart', selectmouse);
    document.getElementsByClassName("dragme")[0].addEventListener('touchmove', movemouse);

});
function movemouse(e) {
    
    if(isdrag) {
      
        var n = tx + e.touches[0].pageX - x;
        var m = ty + e.touches[0].pageY - y;
        var predivwidth = $(".dragme").parent().width();//393
        var predivheight = $(".dragme").parent().height();//424
      // alert(predivwidth + "||" + predivheight)
        if (n <= -predivwidth) {
            n = -predivwidth;
        } else if (n >= predivwidth) {
            n = predivwidth-200;
        }
        if (m <= -predivheight) {
            m = -predivheight;
        } else if (m >= predivheight) {
            m = predivheight-150;
        }

        $(".dragme").css("left", n);
      
        $(".dragme").css("top", m);

       
        
        return false;
    }
}
function selectmouse(e) {
    // alert(123);
    isdrag = true;

    tx = parseInt(document.getElementsByClassName("dragme")[0].style.left + 0);
    ty = parseInt(document.getElementsByClassName("dragme")[0].style.top + 0);

    x = e.touches[0].pageX;

    y = e.touches[0].pageY;

    return false;
}