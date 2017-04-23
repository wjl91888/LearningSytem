<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_BMXXWebUIDetail.aspx.cs" Inherits="App.T_BM_BMXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    ������Ϣ
</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
<div id="AppDetailPage">
    <asp:Repeater ID="rptDetail" runat="server">
        <ItemTemplate>
            <div class="page-header">
                <h4>
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYBH"), null)%></h4>
            </div>
    
            <div id="BMBHContainer" runat="server" class="row">
                <div id="BMBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�������</div>
                <div id="BMBHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BMBH"), null)%>
                
                </div>
            </div>
        
            <div id="HYBHContainer" runat="server" class="row">
                <div id="HYBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��Ա���</div>
                <div id="HYBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "HYBH_T_BM_HYXX_HYXM")%>
        
                </div>
            </div>
        
            <div id="KCJGContainer" runat="server" class="row">
                <div id="KCJGCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�۸�</div>
                <div id="KCJGContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCJG"), null)%>
                
                </div>
            </div>
        
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��ʱ��</div>
                <div id="KSSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KSS"), null)%>
                
                </div>
            </div>
        
            <div id="KCZKContainer" runat="server" class="row">
                <div id="KCZKCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ۿ�</div>
                <div id="KCZKContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCZK"), null)%>
                
                </div>
            </div>
        
            <div id="SJJGContainer" runat="server" class="row">
                <div id="SJJGCaption" runat="server" class="fontbold col-xs-3 paddingleft0">ʵ���տ�</div>
                <div id="SJJGContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SJJG"), null)%>
                
                </div>
            </div>
        
            <div id="SKRContainer" runat="server" class="row">
                <div id="SKRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�տ���</div>
                <div id="SKRContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SKR_T_PM_UserInfo_UserNickName")%>
        
                </div>
            </div>
        
            <div id="BMSJContainer" runat="server" class="row">
                <div id="BMSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����ʱ��</div>
                <div id="BMSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BMSJ"), "yyyy-MM-dd")%>
                
                </div>
            </div>
        
            <div id="BZContainer" runat="server" class="row">
                <div id="BZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��ע</div>
                <div id="BZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BZ"), null)%>
                
                </div>
            </div>
        
            <div id="LRRContainer" runat="server" class="row">
                <div id="LRRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�Ǽ���</div>
                <div id="LRRContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "LRR_T_PM_UserInfo_UserNickName")%>
        
                </div>
            </div>
        
            <div id="LRSJContainer" runat="server" class="row">
                <div id="LRSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�Ǽ�ʱ��</div>
                <div id="LRSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LRSJ"), "yyyy-MM-dd")%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <input type="button" id ="btnEditItem" runat ="server" value="�޸�" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>


