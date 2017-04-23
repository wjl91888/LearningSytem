<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCXXWebUIAdd.aspx.cs" Inherits="App.T_BM_KCXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">课程信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .ctl00_MainContentPlaceHolder_KCNR_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_KCXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_KCXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_KCXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs- paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCBHContainer" runat="server" class="row">
                <div id="KCBHCaption" runat="server" class="fontbold col-xs- paddingleft0">课程编号</div>
                <div id="KCBHContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCMCContainer" runat="server" class="row">
                <div id="KCMCCaption" runat="server" class="fontbold col-xs- paddingleft0">课程名称</div>
                <div id="KCMCContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCMC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCXLBHContainer" runat="server" class="row">
                <div id="KCXLBHCaption" runat="server" class="fontbold col-xs- paddingleft0">课程系列</div>
                <div id="KCXLBHContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="KCXLBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="KCTPContainer" runat="server" class="row">
                <div id="KCTPCaption" runat="server" class="fontbold col-xs- paddingleft0">课程图片</div>
                <div id="KCTPContent" runat="server" class="col-xs-">
                                
                             <control:FilesList ID="KCTP" runat="server" CssClass="input"></control:FilesList>
                                                 
                </div>
            </div>
  
            <div id="KCNRContainer" runat="server" class="row">
                <div id="KCNRCaption" runat="server" class="fontbold col-xs- paddingleft0">课程简介</div>
                <div id="KCNRContent" runat="server" class="col-xs-">
                                
                             <FTB:FreeTextBox ID="KCNR" runat="server" Language="zh-cn"  ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste,Delete;Undo,Redo,Print|InsertTable, EditTable, InsertTableRowBefore, InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, DeleteTableColumn|InsertDiv, Preview, SelectAll, EditStyle"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="KCKKSJContainer" runat="server" class="row">
                <div id="KCKKSJCaption" runat="server" class="fontbold col-xs- paddingleft0">开课时间</div>
                <div id="KCKKSJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCKKSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs- paddingleft0">课时数</div>
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

