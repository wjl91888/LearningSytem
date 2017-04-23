<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCBXXWebUIDetail.aspx.cs" Inherits="App.T_BM_KCBXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    课程表
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCBH"), null)%></h4>
            </div>
    
            <div id="KCBBHContainer" runat="server" class="row">
                <div id="KCBBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">编号</div>
                <div id="KCBBHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCBBH"), null)%>
                
                </div>
            </div>
        
            <div id="KCXLBHContainer" runat="server" class="row">
                <div id="KCXLBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课程系列</div>
                <div id="KCXLBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KCXLBH_T_BM_KCXLXX_KCXLMC")%>
        
                </div>
            </div>
        
            <div id="KCBHContainer" runat="server" class="row">
                <div id="KCBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课程</div>
                <div id="KCBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KCBH_T_BM_KCXX_KCMC")%>
        
                </div>
            </div>
        
            <div id="KCSJContainer" runat="server" class="row">
                <div id="KCSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">上课时间</div>
                <div id="KCSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCSJ"), "yy-MM-dd hh:mm")%>
                
                </div>
            </div>
        
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课时数</div>
                <div id="KSSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KSS"), null)%>
                
                </div>
            </div>
        
            <div id="SKJSContainer" runat="server" class="row">
                <div id="SKJSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">教师</div>
                <div id="SKJSContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SKJS_T_PM_UserInfo_UserNickName")%>
        
                </div>
            </div>
        
            <div id="SKFJContainer" runat="server" class="row">
                <div id="SKFJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">教室</div>
                <div id="SKFJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SKFJ"), null)%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <input type="button" id ="btnEditItem" runat ="server" value="修改" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>


