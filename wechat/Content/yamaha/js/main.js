/**
 * Created by cheerlong on 2016/6/13.
 */
var arr3 = [];
var getrandom3 = function () {
   // $(".form1 div.timu").hide();
    var flag = false;
    addramdom();
    checkarrquchong();
    while (flag) {
        arr3 = [];
        addramdom();
        setCookie("arr3key",arr3,365);
        checkarrquchong();
        //alert(flag)
        continue;
    }

    //for (var k = 0; k < arr.length; k++) {
    //    $(".form1 ." + arr[k]).show();
    //    //alert($("form ."+arr[k]));
    //}
    /*
    获取随机数
    */
    function getrandom() {
        var ramdom = Math.floor((Math.random() * 10) + 1);
        return ramdom;
    }

    //检测数组中有无重复数据
    function checkarrquchong() {

        var nary = arr3.sort();

        for (var i = 0; i < arr3.length; i++) {

            if (arr3[i] == arr3[i + 1]) {

                flag = true;
                return;
            }

        }
        flag = false;

    }
    //往数组中随机添加3个数据
    function addramdom() {
        for (var i = 0; i < 3; i++) {
            arr3.push("t" + getrandom());
        }
    }
    //arr3 = getArrayItems(arr,3);//从数组中随机获取3个数重新组成一个数组
    setCookie('arr3key',arr3, 365);
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
        //setCookie('arr3key', arr3, 365);
    }
}
function clearCookie(name) {
    setCookie(name, "", -1);
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
    erroranser: "回答错误",
    inputname: "请输入您的姓名",
    leng: "长度必须小于10位",
    telTish: "手机号码有误，请重填",
    chooseanser: "请选择您的答案",
    complete: "您已答完三题",
    address: "请输入地址",
    yzmtishi: "请输入验证码",
    erroryzm:"验证码不正确",
    zhezhaotemplate: '<div class="zhezhao"></div>',
    ruletemplate: "<div class='ruleshow'><img src='/Content/yamaha/image/gamerule.jpg'/></div>",
    closebtnimg: "<div class='closebtn'></div>",
   
    fenxiang:"<img src='/Content/yamaha/image/fenxiang.gif' class='fenxiang'/>",
    fenxiangtishi:"<div class='fenxiangtishi'>邀请朋友来玩,即可再玩一次</div>"

}
$(function(){
    
    //点击规则弹出规则页面
    $(".rule").on("click", function () {
        $("body").append(str.zhezhaotemplate);
        $("body").append(str.ruletemplate);
        // $("body").append(str.closebtnimg);
        $(".closebtn").show();

    })
    $(".closebtn").on("click", function () {
        $(".zhezhao").hide();
        $(".ruleshow").hide();
        $(".closebtn").hide();
    })
    $(".closebtn2").on("click", function () {
        $(".zhezhao").hide();
        $(".fenxiangtishi").hide();
        $(".closebtn2").hide();
        $(".fenxiang").hide();
    })
    $(".fxbtn").on("click", function () {
        $("body").append(str.zhezhaotemplate);
        $("body").append(str.fenxiang);
        $("body").append(str.fenxiangtishi);
        $(".closebtn2").show();
      
    })

})

var alertdialog1 = function (text) {
    var clientWidth = $(window).width();
    var clienHeight = $(window).height();
   var alerttemplate1= '<div class="alertParent"><div class="text"><span>'+text+'</span></div><input type="button" value="确定" onclick="sure1()" class="surebtn"/></div>'
    $("body").append(str.zhezhaotemplate);
    $("body").append(alerttemplate1);

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
    var alerttemplate2 = '<div class="alertParent"><div class="text"><span>' + text + '</span></div><input type="button" value="确定" onclick="sure2()" class="surebtn"/></div>';
    $("body").append(str.zhezhaotemplate);
    $("body").append(alerttemplate2);
    
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
    location.href = "/Yamaha1/guaguaka";
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
