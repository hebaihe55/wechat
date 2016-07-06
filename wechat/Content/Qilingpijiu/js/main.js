var isdrag = false;
var tx, x, ty, y;

function movemouse(e) {

    if (isdrag) {

        var n = tx + e.touches[0].pageX - x;
        var m = ty + e.touches[0].pageY - y;
        var predivwidth = $(".dragme").parent().width();//393
        var predivheight = $(".dragme").parent().height();//424
        // alert(predivwidth + "||" + predivheight)
        if (n <= -predivwidth) {
            n = -predivwidth;
        } else if (n >= predivwidth) {
            n = predivwidth - 200;
        }
        if (m <= -predivheight) {
            m = -predivheight;
        } else if (m >= predivheight) {
            m = predivheight - 150;
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

var str = {
    inputname:"请输入支付宝账号",
    telTish: "手机号码有误",
    zhezhaotemplate: '<div class="zhezhao"></div>',
    closebtnimg: "<div class='closebtn'></div>",
    ruletemplate: "<div class='ruleshow'><img src='/Content/Qilingpijiu/img/gamerulebg.jpg'/></div>",
}
var alertdialog1 = function (text) {
    var clientWidth = $(window).width();
    var clienHeight = $(window).height();
    var alerttemplate1 = '<div class="alertParent"><div class="text"><span>' + text + '</span></div><input type="button" value="确定" onclick="sure1()" class="surebtn"/></div>'
    $("body").append(str.zhezhaotemplate);
    $("body").append(alerttemplate1);

    $(".alertParent").css({
        "top": (clienHeight / 2 - 400) + "px",
        "left": (clientWidth / 2 - 224) + "px",
        "z-index": "3",
    });
    return;

}
var checkform = function () {
    var user = $("form .user").val();
    var tel = $("form .tel").val();
    if (user == null || user == "") {
        alertdialog1(str.inputname);
        return false;
    }
    var reg = /^1[3|4|5|7|8]\d{9}$/;
    if (!(reg.test(tel))) {
        alertdialog1(str.telTish);
        return false;
    }
    return true;
}
var sure1 = function () {
    $(".alertParent").hide();
    $(".zhezhao").hide();
}
$(function () {
    $(".lingwangbtn").on("click", function () {
        $("body").append(str.zhezhaotemplate);
        $("body").append(str.ruletemplate);
        $(".ruleclose").show();
    })
    $(".ruleclose").on("click", function () {
        $(".ruleshow").hide();
        $(".ruleclose").hide();
        $(".zhezhao").hide();
    })
})
