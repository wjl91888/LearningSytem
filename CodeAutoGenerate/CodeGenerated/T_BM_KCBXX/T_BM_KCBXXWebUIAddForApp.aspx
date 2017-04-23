<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCBXXWebUIAdd.aspx.cs" Inherits="App.T_BM_KCBXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">课程表编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_KCBXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_KCBXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="KCXLBH">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="KCBH" LoadingPanelID="ralpT_BM_KCBXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_KCBXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs- paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCBBHContainer" runat="server" class="row">
                <div id="KCBBHCaption" runat="server" class="fontbold col-xs- paddingleft0">编号</div>
                <div id="KCBBHContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCBBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCXLBHContainer" runat="server" class="row">
                <div id="KCXLBHCaption" runat="server" class="fontbold col-xs- paddingleft0">课程系列</div>
                <div id="KCXLBHContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="KCXLBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="KCBHContainer" runat="server" class="row">
                <div id="KCBHCaption" runat="server" class="fontbold col-xs- paddingleft0">课程</div>
                <div id="KCBHContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="KCBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="KCSJContainer" runat="server" class="row">
                <div id="KCSJCaption" runat="server" class="fontbold col-xs- paddingleft0">上课时间</div>
                <div id="KCSJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs- paddingleft0">课时数</div>
                <div id="KSSContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SKJSContainer" runat="server" class="row">
                <div id="SKJSCaption" runat="server" class="fontbold col-xs- paddingleft0">教师</div>
                <div id="SKJSContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="SKJS" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="SKFJContainer" runat="server" class="row">
                <div id="SKFJCaption" runat="server" class="fontbold col-xs- paddingleft0">教室</div>
                <div id="SKFJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="SKFJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
        </div>
    <script>
        Sys.Application.add_load(function () {
            $('body,html').animate({ scrollTop: 0 }, 10);
        });
    </script>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
  <ul id="PageInfo" runat="server" class="nav  navbar-default">
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
      <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="btn btn-default navbar-btn" OnClick="btnSave_Click" />
    </li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
  </ul>
</asp:Content>

