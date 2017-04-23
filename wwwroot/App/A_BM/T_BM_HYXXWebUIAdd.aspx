<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_HYXXWebUIAdd.aspx.cs" Inherits="App.T_BM_HYXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">会员信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_BM_HYXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_BM_HYXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_HYXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs- paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HYBHContainer" runat="server" class="row">
                <div id="HYBHCaption" runat="server" class="fontbold col-xs- paddingleft0">会员编号</div>
                <div id="HYBHContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="HYBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HYXMContainer" runat="server" class="row">
                <div id="HYXMCaption" runat="server" class="fontbold col-xs- paddingleft0">姓名</div>
                <div id="HYXMContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="HYXM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HYNCContainer" runat="server" class="row">
                <div id="HYNCCaption" runat="server" class="fontbold col-xs- paddingleft0">昵称</div>
                <div id="HYNCContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="HYNC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HYSRContainer" runat="server" class="row">
                <div id="HYSRCaption" runat="server" class="fontbold col-xs- paddingleft0">生日</div>
                <div id="HYSRContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="HYSR" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HYXXContainer" runat="server" class="row">
                <div id="HYXXCaption" runat="server" class="fontbold col-xs- paddingleft0">学校</div>
                <div id="HYXXContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="HYXX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="HYBJContainer" runat="server" class="row">
                <div id="HYBJCaption" runat="server" class="fontbold col-xs- paddingleft0">班级</div>
                <div id="HYBJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="HYBJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JZXMContainer" runat="server" class="row">
                <div id="JZXMCaption" runat="server" class="fontbold col-xs- paddingleft0">家长姓名</div>
                <div id="JZXMContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="JZXM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="JZDHContainer" runat="server" class="row">
                <div id="JZDHCaption" runat="server" class="fontbold col-xs- paddingleft0">家长电话</div>
                <div id="JZDHContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="JZDH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="ZCSJContainer" runat="server" class="row">
                <div id="ZCSJCaption" runat="server" class="fontbold col-xs- paddingleft0">注册时间</div>
                <div id="ZCSJContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ZCSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="ZKSSContainer" runat="server" class="row">
                <div id="ZKSSCaption" runat="server" class="fontbold col-xs- paddingleft0">课时总数</div>
                <div id="ZKSSContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="ZKSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="XHKSSContainer" runat="server" class="row">
                <div id="XHKSSCaption" runat="server" class="fontbold col-xs- paddingleft0">消耗课时</div>
                <div id="XHKSSContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="XHKSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="SYKSSContainer" runat="server" class="row">
                <div id="SYKSSCaption" runat="server" class="fontbold col-xs- paddingleft0">剩余课时</div>
                <div id="SYKSSContent" runat="server" class="col-xs-">
                                
                             <asp:TextBox ID="SYKSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
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

