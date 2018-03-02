function Verify() {
    var myDate = new Date();
    var currentDate = new Date();
    myDate.setFullYear(2011, 6, 20);
    if (typeof (kk) == "undefined") {
        if (currentDate > myDate) {
            alert("请安装ekey插件");
            return false;
        }
        return confirm("请安装ekey插件");
    }
    if (kk.object == null) {
        if (currentDate > myDate) {
            alert("请安装ekey插件");
            return false;
        }
        return confirm("请安装ekey插件");
    }
    if (kk.Verify()) {
        return true;
    }
    else {
        if (currentDate > myDate) {
            alert("请插ekey");
            return false;
        }
        return confirm("请插ekey");
    }
    return confirm("请安装ekey插件");
}
function ReadCard() {
    //        if (!cc.hasOwnProperty("ReadCard")) {
    //            if (Date > "2011-05-12") {
    //                alert("请安装读卡器插件");
    //                return false;
    //            }
    //            return true;
    //        }
    //return "12346";
    //return "99123";
    if (typeof (cc) == "undefined") {
        return "";
    }
    if (cc.object == null) {
        return "";
    }
    return cc.ReadCard();
}
function PutCard(CardNo) {
    //        if (!cc.hasOwnProperty("PutCard")) {
    //            if (Date > "2011-05-12") {
    //                alert("请安装读卡器插件");
    //                return false;
    //            }
    //            return true;
    //        }
    //return true;
    if (typeof (cc) == "undefined") {
        return "";
    }
    if (cc.object == null) {
        return "";
    }
    return cc.PutCard(CardNo);
}

    