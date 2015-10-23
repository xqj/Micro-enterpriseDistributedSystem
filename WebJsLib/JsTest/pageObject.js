/// <reference path="D:\my\github\Micro-enterpriseDistributedSystem\WebJsLib\JsTest\pageBase.js" />
/// <reference path="http://localhost:36527/lib/_references.js" />

var pageObject = {
    requestId:"",
    base: pageBase,
    initPageObject: function () {
      
    },
    show: function () {
        this.base.netWebServiceJsonAjaxFun("/WebServiceTest.asmx/HelloWorld", null, function (result) {
            $("#show").html(result.Data);
        }, function () { alert("错了"); }, function () { $("#z").show() }, function () { $("#z").hide(); });
    },
    setrequestId: function (requestId) {
        this.requestId = requestId;
        this.base.requestId = this.requestId;
    }
};
pageObject.initPageObject();