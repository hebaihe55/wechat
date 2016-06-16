/**
 * Created by cheerlong on 2016/6/13.
 */
/**
 * 提示信息
 * @type {{chooseTishi: string, completeTishi: string}}
 */
var str = {
    chooseTishi: "请选择您的答案",
    completeTishi: "您已答完所有题目"
}
var q1img = "<img src='/Content/yamaha/image/Q1.png' class='q1'>"
var q2img = "<img src='/Content/yamaha/image/Q2.png' class='q1'>"
var q3img = "<img src='/Content/yamaha/image/Q3.png' class='q1'>"

function getrandom5() {
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
    //显示5个问题
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

$(function () {

    var cookiedata = checkCookie();

    if (cookiedata.indexOf(",") == -1) {
        $("body").append(q3img);
    } else {
        var arr3 = cookiedata.split(",");
        var arr3lenth = arr3.length;
        if (arr3lenth == 3) {
            $("body").append(q1img);
        } else if (arr3lenth == 2) {
            $("body").append(q2img);
        } else {

        }

    }
    /**
     * 点击下一题处理的事件
     * 1判断用户有无选择答案
     * 2判断cookie中数组的个数
     */

    $("form .nextbtn").on("click", function () {

        var checkval = $("form input[type=radio]:checked").val();
        if (checkval == null || checkval == "") {
            alertdialog1();
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
                alertdialog2();

            }
        }

    })
})
var getArrayItems = function (arr, num) {
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
var alertdialog1 = function () {
    var clientWidth = $(window).width();
    var clienHeight = $(window).height();
    var template = '<div class="alertParent"><div class="text"><span>' + str.chooseTishi + '</span></div><input type="button" value="确定" class="surebtn1"/></div>';
    var zhezhao = '<div class="zhezhao"></div>';
    $("body").append(zhezhao);
    $("body").append(template);

    $(".alertParent").css({
        "top": (clienHeight / 2 - 400) + "px",
        "left": (clientWidth / 2 - 224) + "px",
        "z-index": "3"
    });


}
var alertdialog2 = function (text) {
    var clientWidth = $(window).width();
    var clienHeight = $(window).height();
    var template = '<div class="alertParent"><div class="text"><span>' + str.completeTishi + '</span></div><input type="button" value="确定" class="surebtn2"/></div>';
    var zhezhao = '<div class="zhezhao"></div>';
    $("body").append(zhezhao);
    $("body").append(template);

    $(".alertParent").css({
        "top": (clienHeight / 2 - 400) + "px",
        "left": (clientWidth / 2 - 224) + "px",
        "z-index": "3"
    });
    return;

}
$("form .surebtn1").on("click", function () {
    $(".alertParent").hide();
    $(".zhezhao").hide();
})
$("form .surebtn2").on("click", function () {
    $(".alertParent").hide();
    $(".zhezhao").hide();
    location.href = "/Yamaha1/subinfo";
})
var sure1 = function () {
    $(".alertParent").hide();
    $(".zhezhao").hide();
}

