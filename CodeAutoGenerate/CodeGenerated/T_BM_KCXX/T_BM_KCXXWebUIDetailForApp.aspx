<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCXXWebUIDetail.aspx.cs" Inherits="App.T_BM_KCXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    �γ���Ϣ
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCMC"), null)%></h4>
            </div>
    
            <div id="KCBHContainer" runat="server" class="row">
                <div id="KCBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�γ̱��</div>
                <div id="KCBHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCBH"), null)%>
                
                </div>
            </div>
        
            <div id="KCMCContainer" runat="server" class="row">
                <div id="KCMCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�γ�����</div>
                <div id="KCMCContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCMC"), null)%>
                
                </div>
            </div>
        
            <div id="KCXLBHContainer" runat="server" class="row">
                <div id="KCXLBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�γ�ϵ��</div>
                <div id="KCXLBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KCXLBH_T_BM_KCXLXX_KCXLMC")%>
        
                </div>
            </div>
        
            <div id="KCTPContainer" runat="server" class="row">
                <div id="KCTPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�γ�ͼƬ</div>
                <div id="KCTPContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KCTP") == DBNull.Value ? "" : "<img class='img-responsive' src='" + DataBinder.Eval(Container.DataItem, "KCTP") + "' />"%>
                
                </div>
            </div>
        
            <div id="KCNRContainer" runat="server" class="row">
                <div id="KCNRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�γ̼��</div>
                <div id="KCNRContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCNR"), null)%>
                
                </div>
            </div>
        
            <div id="KCKKSJContainer" runat="server" class="row">
                <div id="KCKKSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����ʱ��</div>
                <div id="KCKKSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCKKSJ"), "yyyy-MM-dd")%>
                
                </div>
            </div>
        
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��ʱ��</div>
                <div id="KSSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KSS"), null)%>
                
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


