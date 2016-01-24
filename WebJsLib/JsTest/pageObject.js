/// <reference path="D:\my\github\Micro-enterpriseDistributedSystem\WebJsLib\JsTest\pageBase.js" />
/// <reference path="http://r.xieqj.net/lib/_references.js" />
var pageObject = {
    requestId: "",
    button:$("#buttonId"),
    base: pageBase,
    initPageObject: function () {
        this.button.one("click", this.submit);
    },   
    setrequestId: function (requestId) {
        this.requestId = requestId;
        this.base.requestId = this.requestId;
    },
    showDialog: function () {
        pageObject.base.showDialog(function () {
            //展示对话框初始函数
        }, "dialogId");
    },
    closeDialog: function () {
        pageObject.base.closeDialog(function () {
            //关闭对话框清理函数
        });
    },
    submit: function () {
        pageObject.base.loadJsonFun("url", { parama: "parama" }, function (data) {
            //逻辑处理
        }, function () {
            //异常处理
            pageObject.button.one("click", this.submit);
        }, function () {
            //加载过场函数
        }, function () {
            //关闭过场函数
        })
    }
};
