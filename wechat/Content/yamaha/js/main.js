/**
 * Created by cheerlong on 2016/6/13.
 */
var arr3;
var getrandom5 = function () {
    $(".form1 div.timu").hide();
    var flag = false;
    var arr = [];
    addramdom();
    checkarrquchong();
    while (flag) {
        arr = [];
        addramdom();
        setCookie("arr3key", arr3, 365);
        checkarrquchong();
        //alert(flag)
        continue;
    }

    for (var k = 0; k < arr.length; k++) {
        $(".form1 ." + arr[k]).show();
        //alert($("form ."+arr[k]));
    }
    function getrandom() {
        var ramdom = Math.floor((Math.random() * 10) + 1);
        return ramdom;
    }

    //检测数组中有无重复数据
    function checkarrquchong() {

        var nary = arr.sort();

        for (var i = 0; i < arr.length; i++) {

            if (arr[i] == arr[i + 1]) {

                flag = true;
                return;
            }

        }
        flag = false;

    }
    //往数组中随机添加5个数据
    function addramdom() {
        for (var i = 0; i < 5; i++) {
            arr.push("t" + getrandom());
        }
    }
    arr3 = getArrayItems(arr, 3);
    setCookie('arr3key', arr3, 365);
    checkCookie();

}
function setCookie(c_name, value, expiredays) {
    var exdate = new Date()
    exdate.setDate(exdate.getDate() + expiredays)
    document.cookie = c_name + "=" + escape(value) +
        ((expiredays == null) ? "" : "; expires=" + exdate.toGMTString())
}
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=")
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1
            c_end = document.cookie.indexOf(";", c_start)
            if (c_end == -1) c_end = document.cookie.length
            return unescape(document.cookie.substring(c_start, c_end))
        }
    }
    return "";
}
function checkCookie() {
    var arr3key = getCookie('arr3key');
    if (arr3key != null && arr3key != "") {
        //alert(arr3key);
        return arr3key;

    }
    else {
        setCookie('arr3key', arr3, 365);
    }
}
function getArrayItems(arr, num) {
    //新建一个数组,将传入的数组复制过来,用于运算,而不要直接操作传入的数组;
    var temp_array = new Array();
    for (var index in arr) {
        temp_array.push(arr[index]);
    }
    //取出的数值项,保存在此数组
    var return_array = new Array();
    for (var i = 0; i < num; i++) {
        //判断如果数组还有可以取出的元素,以防下标越界
        if (temp_array.length > 0) {
            //在数组中产生一个随机索引
            var arrIndex = Math.floor(Math.random() * temp_array.length);
            //将此随机索引的对应的数组元素值复制出来
            return_array[i] = temp_array[arrIndex];
            //然后删掉此索引的数组元素,这时候temp_array变为新的数组
            temp_array.splice(arrIndex, 1);
        } else {
            //数组中数据项取完后,退出循环,比如数组本来只有10项,但要求取出20项.
            break;
        }
    }
    return return_array;
}
var str = {
    alertchooseTishi: "请选择您的答案",
    ansercompleteTish: "您已答完所有题目",
    inputname: "请输入您的姓名",
    leng: "长度必须小于10位",
    telTish: "手机号码有误，请重填",
    alerttemplate1: '<div class="alertParent"><div class="text"><span>' + str.alertchooseTishi + '</span></div><input type="button" value="确定" onclick="sure1()" class="surebtn"/></div>',
    alerttemplate2: '<div class="alertParent"><div class="text"><span>' + str.ansercompleteTish + '</span></div><input type="button" value="确定" onclick="sure1()" class="surebtn"/></div>',
    zhezhaotemplate: '<div class="zhezhao"></div>',
    ruletemplate:"<div class='ruleshow'></div>"
}
$(function () {
    $("form .nextbtn").on("click", function () {
        var checkval = $("form input[type=radio]:checked").val();
        if (checkval == null || checkval == "") {
            alertdialog1(str.alertchooseTishi);
            return;

        } else {
            //alert(checkval);
            setCookie("cookiet1", checkval, 365);
            var cookiedata = checkCookie();
            if (cookiedata.indexOf(",") != -1) {
                var arr3 = cookiedata.split(",");

                if (arr3.length > 0) {
                    console.log(arr3);
                    var arrti1 = arr3.shift();
                    // alert(arr3);
                    setCookie("arr3key", arr3, 365);
                    location.href = "/Yamaha1/" + arr3[0];
                }
            } else {
                alertdialog2(str.ansercompleteTish);

            }
        }

    })
    //点击规则弹出规则页面
    $(".rule").on("click", function () {
        $("body").append(str.zhezhaotemplate);
        $("body").append(str.ruletemplate);

    })

})

var alertdialog1 = function (text) {
    var clientWidth = $(window).width();
    var clienHeight = $(window).height();
   
    $("body").append(str.zhezhaotemplate);
    $("body").append(str.alerttemplate);

    $(".alertParent").css({
        "top": (clienHeight / 2 - 400) + "px",
        "left": (clientWidth / 2 - 224) + "px",
        "z-index": "3",
    });
    return;

}
var alertdialog2 = function (text) {
    var clientWidth = $(window).width();
    var clienHeight = $(window).height();
    $("body").append(str.zhezhaotemplate);
    $("body").append(str.alerttemplate);

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

var sure2 = function () {
    $(".alertParent").hide();
    $(".zhezhao").hide();
    location.href = "/Yamaha1/subinfo";
}
//信息提交信息验证
var checkform= function(){
    var user = $("form .user").val();
    var tel = $("form .tel").val();
    if (user == null || user == "") {
        alertdialog1(str.inputname);
        return false;
    } else if (user.length > 10) {
        alertdialog1(str.leng);
        return false;
    }
    var reg=/^1[3|4|5|7|8]\d{9}$/;
    if (!(reg.test(tel))) {
        alertdialog1(str.telTish);
        return false;
    }
    return true;
}
