<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_KCXLXXWebUIDetail.aspx.cs" Inherits="App.T_BM_KCXLXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    课程系列信息
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLMC"), null)%></h4>
            </div>
    
            <div id="KCXLBHContainer" runat="server" class="row">
                <div id="KCXLBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课程系列编号</div>
                <div id="KCXLBHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLBH"), null)%>
                
                </div>
            </div>
        
            <div id="KCXLMCContainer" runat="server" class="row">
                <div id="KCXLMCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课程系列名称</div>
                <div id="KCXLMCContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLMC"), null)%>
                
                </div>
            </div>
        
            <div id="KCXLSJBHContainer" runat="server" class="row">
                <div id="KCXLSJBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">所属类别</div>
                <div id="KCXLSJBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KCXLSJBH_T_BM_KCXLXX_KCXLMC")%>
        
                </div>
            </div>
        
            <div id="KCXLTPContainer" runat="server" class="row">
                <div id="KCXLTPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">系列图片</div>
                <div id="KCXLTPContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "KCXLTP") == DBNull.Value ? "" : "<img class='img-responsive' src='" + DataBinder.Eval(Container.DataItem, "KCXLTP") + "' />"%>
                
                </div>
            </div>
        
            <div id="KCXLJJContainer" runat="server" class="row">
                <div id="KCXLJJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课程系列简介</div>
                <div id="KCXLJJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLJJ"), null)%>
                
                </div>
            </div>
        
            <div id="NLDContainer" runat="server" class="row">
                <div id="NLDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">年龄段</div>
                <div id="NLDContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "NLD"), null)%>
                
                </div>
            </div>
        
            <div id="KSSContainer" runat="server" class="row">
                <div id="KSSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课时总数</div>
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
            <input type="button" id ="btnEditItem" runat ="server" value="修改" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>


