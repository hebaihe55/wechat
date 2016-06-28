/**
 * Created by mengdi on 2015/10/29.
 */

var neusoft={};
neusoft.matchingGame={};
neusoft.matchingGame.cardWidth=208;//牌宽
neusoft.matchingGame.cardHeight=207;
neusoft.matchingGame.deck=
    [
        "yp1", "yp2",
        "yp3", "yp4",
        "yp5", "yp6",
        "yp7", "yp4",
        "yp6"
    ]
//随机排序函数，返回-1或1
function shuffle()
{
    //Math.random能返回0~1之间的数
    return Math.random()>0.5 ? -1 : 1
}
//  翻牌功能的实现
function selectCard() {
    var $fcard=$(".card-flipped");
    //翻了四张牌后退出翻牌
    if($fcard.length>3)
    {
        return;
    }
    //alert($(this).data("pattern"));
    $(this).addClass("card-flipped");
//    若翻动了两张牌，检测一致性
    var $fcards=$(".card-flipped");
    if($fcards.length==3)
    {
       // checkPattern($fcards);
        setTimeout(function(){
        checkPattern($fcards);},700);
    }
}
//检测2张牌是否一致
function checkPattern(cards)
{
    var pattern1 = $(cards[0]).data("pattern");
    var pattern2 = $(cards[1]).data("pattern");
    var pattern3 = $(cards[2]).data("pattern");
    var pattern4 = $(cards[3]).data("pattern");
  
    //alert(pattern1);
    //alert(pattern2);
//    if(pattern1!=pattern2)
//    {
//        $(cards).removeClass("card-flipped")
//    }
//    else
//    {
//        $(cards).addClass("card-removed")
//        $(cards).removeClass("card-flipped")
//    }
    
    if (pattern1 == pattern2 == pattern3 || pattern1 == pattern2 == pattern4 || pattern2 == pattern3 == pattern4)
    {
        //        .bind
        alert("恭喜您中二等奖");
        
    } else if (pattern1 == pattern2 == pattern3 == pattern4) {
        alert("恭喜您中一等奖");
    }
}