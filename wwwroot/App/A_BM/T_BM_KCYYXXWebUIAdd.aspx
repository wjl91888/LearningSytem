<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCYYXXWebUIAdd.aspx.cs" Inherits="App.T_BM_KCYYXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">课程预约信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    table.<%=YYBZ.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_YYBZ_DesignBox { background-color: #ffffff !important;}    table.<%=JSPJ.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_JSPJ_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_KCYYXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_KCYYXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_KCYYXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs- paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCYYBHContainer" runat="server" class="row">
                <div id="KCYYBHCaption" runat="server" class="fontbold col-xs- paddingleft0">课程预约编号</div>
                <div id="KCYYBHContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCYYBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCBBHContainer" runat="server" class="row">
                <div id="KCBBHCaption" runat="server" class="fontbold col-xs- paddingleft0">课程表编号</div>
                <div id="KCBBHContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="KCBBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="HYBHContainer" runat="server" class="row">
                <div id="HYBHCaption" runat="server" class="fontbold col-xs- paddingleft0">会员编号</div>
                <div id="HYBHContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="HYBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="YYSJContainer" runat="server" class="row">
                <div id="YYSJCaption" runat="server" class="fontbold col-xs- paddingleft0">预约时间</div>
                <div id="YYSJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="YYSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="YYBZContainer" runat="server" class="row">
                <div id="YYBZCaption" runat="server" class="fontbold col-xs- paddingleft0">预约备注</div>
                <div id="YYBZContent" runat="server" class="col-xs-">
                                
                             <FTB:FreeTextBox ID="YYBZ" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="SKZTContainer" runat="server" class="row">
                <div id="SKZTCaption" runat="server" class="fontbold col-xs- paddingleft0">上课状态</div>
                <div id="SKZTContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="SKZT" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="XHKSContainer" runat="server" class="row">
                <div id="XHKSCaption" runat="server" class="fontbold col-xs- paddingleft0">消耗课时</div>
                <div id="XHKSContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="XHKS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KTZPContainer" runat="server" class="row">
                <div id="KTZPCaption" runat="server" class="fontbold col-xs- paddingleft0">课堂照片</div>
                <div id="KTZPContent" runat="server" class="col-xs-">
                                
                             <control:FilesList ID="KTZP" runat="server" CssClass="input"></control:FilesList>
                                                 
                </div>
            </div>
  
            <div id="JSPJContainer" runat="server" class="row">
                <div id="JSPJCaption" runat="server" class="fontbold col-xs- paddingleft0">教师评价</div>
                <div id="JSPJContent" runat="server" class="col-xs-">
                                
                             <FTB:FreeTextBox ID="JSPJ" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="PJRContainer" runat="server" class="row">
                <div id="PJRCaption" runat="server" class="fontbold col-xs- paddingleft0">评价人</div>
                <div id="PJRContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="PJR" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="PJSJContainer" runat="server" class="row">
                <div id="PJSJCaption" runat="server" class="fontbold col-xs- paddingleft0">评价时间</div>
                <div id="PJSJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="PJSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

