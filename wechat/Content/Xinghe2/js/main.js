var str = {
    inputname: "请输入您的姓名",
    leng: "长度必须小于10位",
    telTish: "手机号码有误，请重填",
    zhezhaotemplate: '<div class="zhezhao"></div>',
    closebtnimg: "<div class='closebtn'></div>",
    fenxiang: "<img src='/Content/yamaha/image/fenxiang.gif' class='fenxiang'/>",
    fenxiangtishi: "<div class='fenxiangtishi'>邀请朋友来玩,即可再玩一次</div>",
    getliuliang: "恭喜您获得10-20M流量",
    get20dikouquan: "恭喜您获得口乐清漱口水20元抵扣券",
    getwangteli:"万特力.护 护肘（5个）",
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
var sure1 = function () {
    $(".alertParent").hide();
    $(".zhezhao").hide();
}
var checkform = function () {
    var user = $("form .user").val();
    var tel = $("form .tel").val();
    if (user == null || user == "") {
        alertdialog1(str.inputname);
        return false;
    } else if (user.length > 10) {
        alertdialog1(str.leng);
        return false;
    }
    var reg = /^1[3|4|5|7|8]\d{9}$/;
    if (!(reg.test(tel))) {
        alertdialog1(str.telTish);
        return false;
    }
    return true;
}