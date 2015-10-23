<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CodeHelper.aspx.cs" Inherits="WebDesingerCodeHelperTool.CodeHelper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="step0">
            页面：<input type="radio" id="pagegroup" name="groupType" value="page"  />---对话框：<input type="radio" id="dialoggroup" name="groupType" value="dialog" />
        </div>
        <div id="step1" title="创建对话框" style="display:none">
             <div>DialogId：<input type="text" id="DialogId" name="DialogId" value="" placeholder="对话框的id" /></div>
             <div>关闭按钮id：<input type="text" id="CloseDialogId" name="CloseDialogId" value="" placeholder="关闭对话框按钮id" /></div>
             <div>关闭css：<input type="text" id="CloseDialogCss" name="CloseDialogCss" value="" placeholder="关闭对话框按钮css" /></div>
        </div>
        <div id="step2" title="构建表单"  style="display:none">
             <div>FormId：<input type="text" id="FormId" name="FormId" value="" placeholder="Form的id" /></div>
            <div>
                <input type="checkbox" id="loadType" name="loadType" value="required"  checked=""/><br />
                <input type="text" id="loadingId" name="loadingId" value="" placeholder="加载图标id" />OR<input type="text" id="loadingCss" name="loadingCss" value="" placeholder="加载图标css" />
            </div>
            <div> <input id="addControl" name="addControl" type="button" value="添加控件" /><input id="sureForm" name="sureForm" type="button" value="确定表单" /></div>

        </div>
        <div id="Control" style="display:none">            
            <div>控件Id：<input type="text" id="LableID" name="LableID" value="" /></div>
            <div>控件Css：<input type="text" id="Css" name="Css" value="" /></div>
            <div>
                控件类型：<select id="ControlType" name="ControlType">
                    <option value="Select">下拉列表</option>
                    <option value="Text">文本框</option>
                      <option value="Radio">单选框</option>
                    <option value="Check">多选框</option>
                      <option value="Reset">重置按钮</option>
                     <option value="Submit">提交按钮</option>
                </select>
            </div>
            <div>
                验证类型:<ul>
                    <li><input type="checkbox" id="v1" name="v1" value="required" />必填 </li>
                     <li><input type="checkbox" id="v2" name="v2" value="number" />数字类型 </li>
                     <li><input type="checkbox" id="v3" name="v3" value="minLength" />最小长度限制 </li>
                     <li><input type="checkbox" id="v4" name="v4" value="maxLength" />最大长度限制 </li>
                    <li><input type="checkbox" id="v5" name="v5" value="email" />邮箱格式</li>
                    <li><input type="checkbox" id="v6" name="v6" value="mobile" />手机格式</li>
                    <li><input type="checkbox" id="v7" name="v7" value="time" />时间格式</li>
                     </ul>
                 <br />
                <input id="requiredMsg" name="requiredMsg" type="text"  value="" placeholder="必填提示"/>
                <br />
                  <input id="numberMsg" name="numberMsg" type="text"  value="" placeholder="数字类型提示"/>
                <br />
                <input id="mintxtLength" name="mintxtLength" type="text"  value="" placeholder="最小长度"/>:<input id="mintxtLengthMsg" name="mintxtLengthMsg" type="text"  value="" placeholder="最小长度提示"/>--<input id="maxtxtLength" name="maxtxtLength" type="text"  value="" placeholder="最大长度"/>:<input id="maxtxtLengthMsg" name="maxtxtLengthMsg" type="text"  value="" placeholder="最大长度提示"/>
                 <br />
                <input id="sureControl" name="sureControl" type="button" value="确定控件" />
            </div>
        </div>
    </form>
</body>
</html>
