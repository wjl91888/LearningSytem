<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCYYXXWebUIDetail.aspx.cs" Inherits="App.T_BM_KCYYXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    课程预约信息
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCBBH"), null)%></h4>
            </div>
    
            <div id="KCYYBHContainer" runat="server" class="row">
                <div id="KCYYBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课程预约编号</div>
                <div id="KCYYBHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCYYBH"), null)%>
                
                </div>
            </div>
        
            <div id="KCBBHContainer" runat="server" class="row">
                <div id="KCBBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课程表编号</div>
                <div id="KCBBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KCBBH_T_BM_KCBXX_KCBH")%>
        
                </div>
            </div>
        
            <div id="HYBHContainer" runat="server" class="row">
                <div id="HYBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">会员编号</div>
                <div id="HYBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "HYBH_T_BM_HYXX_HYXM")%>
        
                </div>
            </div>
        
            <div id="YYSJContainer" runat="server" class="row">
                <div id="YYSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">预约时间</div>
                <div id="YYSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YYSJ"), "yyyy-MM-dd")%>
                
                </div>
            </div>
        
            <div id="YYBZContainer" runat="server" class="row">
                <div id="YYBZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">预约备注</div>
                <div id="YYBZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YYBZ"), null)%>
                
                </div>
            </div>
        
            <div id="SKZTContainer" runat="server" class="row">
                <div id="SKZTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">上课状态</div>
                <div id="SKZTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SKZT"), null)%>
                
                </div>
            </div>
        
            <div id="XHKSContainer" runat="server" class="row">
                <div id="XHKSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">消耗课时</div>
                <div id="XHKSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XHKS"), null)%>
                
                </div>
            </div>
        
            <div id="KTZPContainer" runat="server" class="row">
                <div id="KTZPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课堂照片</div>
                <div id="KTZPContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KTZP") == DBNull.Value ? "" : "<img class='img-responsive' src='" + DataBinder.Eval(Container.DataItem, "KTZP") + "' />"%>
                
                </div>
            </div>
        
            <div id="JSPJContainer" runat="server" class="row">
                <div id="JSPJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">教师评价</div>
                <div id="JSPJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JSPJ"), null)%>
                
                </div>
            </div>
        
            <div id="PJRContainer" runat="server" class="row">
                <div id="PJRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">评价人</div>
                <div id="PJRContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "PJR_T_PM_UserInfo_UserNickName")%>
        
                </div>
            </div>
        
            <div id="PJSJContainer" runat="server" class="row">
                <div id="PJSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">评价时间</div>
                <div id="PJSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "PJSJ"), "yyyy-MM-dd")%>
                
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


