<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCXLXXWebUIAdd.aspx.cs" Inherits="App.T_BM_KCXLXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">课程系列信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .ctl00_MainContentPlaceHolder_KCXLJJ_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_KCXLXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_KCXLXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs- paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCXLBHContainer" runat="server" class="row">
                <div id="KCXLBHCaption" runat="server" class="fontbold col-xs- paddingleft0">课程系列编号</div>
                <div id="KCXLBHContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCXLBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCXLMCContainer" runat="server" class="row">
                <div id="KCXLMCCaption" runat="server" class="fontbold col-xs- paddingleft0">课程系列名称</div>
                <div id="KCXLMCContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCXLMC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCXLSJBHContainer" runat="server" class="row">
                <div id="KCXLSJBHCaption" runat="server" class="fontbold col-xs- paddingleft0">所属类别</div>
                <div id="KCXLSJBHContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="KCXLSJBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="KCXLJJContainer" runat="server" class="row">
                <div id="KCXLJJCaption" runat="server" class="fontbold col-xs- paddingleft0">课程系列简介</div>
                <div id="KCXLJJContent" runat="server" class="col-xs-">
                                
                             <FTB:FreeTextBox ID="KCXLJJ" runat="server" Language="zh-cn"  ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste,Delete;Undo,Redo,Print|InsertTable, EditTable, InsertTableRowBefore, InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, DeleteTableColumn|InsertDiv, Preview, SelectAll, EditStyle"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="KCXLTPContainer" runat="server" class="row">
                <div id="KCXLTPCaption" runat="server" class="fontbold col-xs- paddingleft0">系列图片</div>
                <div id="KCXLTPContent" runat="server" class="col-xs-">
                                
                             <control:FilesList ID="KCXLTP" runat="server" CssClass="input"></control:FilesList>
                                                 
                </div>
            </div>
  
            <div id="NLDContainer" runat="server" class="row">
                <div id="NLDCaption" runat="server" class="fontbold col-xs- paddingleft0">年龄段</div>
                <div id="NLDContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="NLD" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs- paddingleft0">课时总数</div>
                <div id="KSSContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

