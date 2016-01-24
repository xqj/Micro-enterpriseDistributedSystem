/// <reference path="D:\my\github\Micro-enterpriseDistributedSystem\WebJsLib\JsTest\pageBase.js" />
/// <reference path="http://r.xieqj.net/lib/_references.js" />
var pageObject = {
    requestId: "",
    button:$("#buttonId"),
    base: pageBase,
    initPageObject: function () {
        this.base.validateDefinition();
        this.button.one("click", this.submit);//绑定点击事件
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
    resetRules: function () {
        //重置验证控件
        pageObject.base.pageValidator.resetForm();
        $("#inputid").rules("remove");
    },
    setSubmitRules: function () {
        pageObject.resetRules();//在设置规则前清理规则
        $("#mobile").rules("add", {//手机示例
            required: true,
            mobile:true,
            minlength: 11,
            maxlength: 11,
            messages: {
                required: "必填提示",
                mobile:"手机格式提示",
                minlength: "最小字符提示",
                maxlength: "最大字符提示"
            }
        });
    },
    submit: function () {
        pageObject.setSubmitRules();//设置校验规则
        if ($("#formid").valid()) {//进行校验
            pageObject.button.one("click", pageObject.submit);//校验后绑定点击事件
            return;
        }
        pageObject.base.loadJsonFun("url", { parama: "parama" }, function (data) {
            //逻辑处理,注意逻辑失败时可能需要重新绑定点击事件
        }, function () {
            //异常处理
            pageObject.button.one("click", pageObject.submit);//异常后绑定点击事件
        }, function () {
            //加载过场函数
        }, function () {
            //关闭过场函数
        })
    }
};
