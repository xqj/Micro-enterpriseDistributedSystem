/// <reference path="http://r.xieqj.net/lib/_references.js" />
var pageBase = {
    requestId: '',
    netWebServiceJsonAjaxFun: function (url, paramters, successFun, errFun, loadFun, closeLoadFun) {
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
                if (typeof (closeLoadFun) == "function")//判断是否需要关闭加载状态
                    closeLoadFun();
            },
            error: errFun ? function () {
                errFun();
                if (typeof (closeLoadFun) == "function")
                    closeLoadFun();
            } : function (XMLHttpRequest, textStatus, errorThrown) {
                if (typeof (closeLoadFun) == "function")
                    closeLoadFun();
                //alert(XMLHttpRequest.status);
                //alert(XMLHttpRequest.readyState);
               // alert(textStatus);
            },
            complete: function (XMLHttpRequest, textStatus) {

            }
        });
    },
    loadJsonFun: function (url, paramters, successFun, errFun, loadFun, closeLoadFun) {
        if (typeof (loadFun) == "function")
            loadFun();
        $.ajax({
            url: url,
            data: paramters,
            type: 'post',
            cache: false,
            dataType: 'json',
            success: function (data) {
                if (typeof (closeLoadFun) == "function")
                    closeLoadFun();
                if (typeof (successFun) == "function")
                    successFun(data);
            },
            error: errFun ? function () {
                if (typeof (closeLoadFun) == "function")
                    closeLoadFun();
                errFun();
            } : function (XMLHttpRequest, textStatus, errorThrown) {
                if (typeof (closeLoadFun) == "function")
                    closeLoadFun();
                //alert(XMLHttpRequest.status);
                //alert(XMLHttpRequest.readyState);
                //alert(textStatus);
            },
            complete: function (XMLHttpRequest, textStatus) {

            }
        });
    },
    getJsonFun: function (url, drawFun) {
        $.getScript(url, drawFun);
    },
    showDialog: function (showFun,dialogId) {
        if (typeof (showFun) == "function")//判断是否需要关闭加载状态
            showFun();
        $.fancybox.open({
            padding: 0,
            closeBtn: false,
            closeClick: false,
            scrolling: "no",
            href: "#" + dialogId
        }, {
            helpers: {
                overlay: {
                    closeClick: false
                }
            }
        })
    },
    showMultiDialog: function (showFun, dialogId) {
        if (typeof (showFun) == "function")//判断是否需要关闭加载状态
            showFun();
        $.fancybox.open({
            href: '#' + dialogId,
            padding: 0,
            closeBtn: false,
            closeClick: false,
            scrolling: "no",
            helpers: {
                overlay: null
            }
        });
    },
    closeDialog: function (closeFun) {
        if (typeof (closeFun) == "function")//判断是否需要关闭加载状态
            closeFun();
        $.fancybox.close();
    },
    validateDefinition: function (formid) {
        pageObject.pageValidator = $("#" + formid).hdvalidate({
            success: function (element) {
                var cssName = "." + element.attr("id") + "error";
                $(cssName).hide();
            },
            errorPlacement: function (error, element) {
                var cssName = "." + element.attr("id") + "error";
                $(cssName).html(error.text());
                $(cssName).show();
            }
        });
        $.validator.addMethod("isMobile", function (value, element) {
            var length = value.length;
            var mobile = /^(13[0-9]{9})|(18[0-9]{9})|(14[0-9]{9})|(17[0-9]{9})|(15[0-9]{9})$/;
            return this.optional(element) || (length == 11 && mobile.test(value));
        }, "请正确填写您的手机号码");
    },
}