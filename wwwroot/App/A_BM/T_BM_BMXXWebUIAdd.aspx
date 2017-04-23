<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_BMXXWebUIAdd.aspx.cs" Inherits="App.T_BM_BMXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">报名信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    table.<%=BZ.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_BZ_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_BMXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_BMXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_BMXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs- paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="BMBHContainer" runat="server" class="row">
                <div id="BMBHCaption" runat="server" class="fontbold col-xs- paddingleft0">报名编号</div>
                <div id="BMBHContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="BMBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HYBHContainer" runat="server" class="row">
                <div id="HYBHCaption" runat="server" class="fontbold col-xs- paddingleft0">会员编号</div>
                <div id="HYBHContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="HYBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="KCJGContainer" runat="server" class="row">
                <div id="KCJGCaption" runat="server" class="fontbold col-xs- paddingleft0">价格</div>
                <div id="KCJGContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCJG" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs- paddingleft0">课时数</div>
                <div id="KSSContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="KCZKContainer" runat="server" class="row">
                <div id="KCZKCaption" runat="server" class="fontbold col-xs- paddingleft0">折扣</div>
                <div id="KCZKContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="KCZK" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SJJGContainer" runat="server" class="row">
                <div id="SJJGCaption" runat="server" class="fontbold col-xs- paddingleft0">实际收款</div>
                <div id="SJJGContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="SJJG" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SKRContainer" runat="server" class="row">
                <div id="SKRCaption" runat="server" class="fontbold col-xs- paddingleft0">收款人</div>
                <div id="SKRContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="SKR" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="BMSJContainer" runat="server" class="row">
                <div id="BMSJCaption" runat="server" class="fontbold col-xs- paddingleft0">报名时间</div>
                <div id="BMSJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="BMSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="BZContainer" runat="server" class="row">
                <div id="BZCaption" runat="server" class="fontbold col-xs- paddingleft0">备注</div>
                <div id="BZContent" runat="server" class="col-xs-">
                                
                             <FTB:FreeTextBox ID="BZ" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                </div>
            </div>
  
            <div id="LRRContainer" runat="server" class="row">
                <div id="LRRCaption" runat="server" class="fontbold col-xs- paddingleft0">登记人</div>
                <div id="LRRContent" runat="server" class="col-xs-">
                                
                             <asp:DropDownList ID="LRR" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="LRSJContainer" runat="server" class="row">
                <div id="LRSJCaption" runat="server" class="fontbold col-xs- paddingleft0">登记时间</div>
                <div id="LRSJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="LRSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

