/// <reference path="http://r.xieqj.net/lib/_references.js" />
var pageBase = {
    requestId: '',
    netWebServiceJsonAjaxFun: function (url, paramters, successFun, errFun,loadFun, loadHiddenFun) {
        if (paramters) paramters.requestId = this.requestId;//增加请求时序标识
        else {
            paramters = { "requestId": this.requestId };
        };
        if (typeof (loadFun) == "function")//判断是否需要关闭加载状态
            loadFun();
        $.ajax({
            url: url,
            data: JSON.stringify(paramters),
            type: 'post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (data) {
                successFun(data.d)
                if (typeof (loadHiddenFun) == "function")//判断是否需要关闭加载状态
                    loadHiddenFun();
            },
            error: errFun ? function () {
                errFun();
                if (typeof (loadHiddenFun) == "function")
                    loadHiddenFun();
            } : function (XMLHttpRequest, textStatus, errorThrown) {
                if (typeof (loadHiddenFun) == "function")
                    loadHiddenFun();
                //alert(XMLHttpRequest.status);
                //alert(XMLHttpRequest.readyState);
                alert(textStatus);
            },
            complete: function (XMLHttpRequest, textStatus) {

            }
        });
    } 
}