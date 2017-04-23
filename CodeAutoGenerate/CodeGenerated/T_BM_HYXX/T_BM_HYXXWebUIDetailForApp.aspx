<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_HYXXWebUIDetail.aspx.cs" Inherits="App.T_BM_HYXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    会员信息
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYXM"), null)%></h4>
            </div>
    
            <div id="HYBHContainer" runat="server" class="row">
                <div id="HYBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">会员编号</div>
                <div id="HYBHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYBH"), null)%>
                
                </div>
            </div>
        
            <div id="HYXMContainer" runat="server" class="row">
                <div id="HYXMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">姓名</div>
                <div id="HYXMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYXM"), null)%>
                
                </div>
            </div>
        
            <div id="HYNCContainer" runat="server" class="row">
                <div id="HYNCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">昵称</div>
                <div id="HYNCContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYNC"), null)%>
                
                </div>
            </div>
        
            <div id="HYSRContainer" runat="server" class="row">
                <div id="HYSRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">生日</div>
                <div id="HYSRContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYSR"), "yyyy.M.d")%>
                
                </div>
            </div>
        
            <div id="HYXXContainer" runat="server" class="row">
                <div id="HYXXCaption" runat="server" class="fontbold col-xs-3 paddingleft0">学校</div>
                <div id="HYXXContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYXX"), null)%>
                
                </div>
            </div>
        
            <div id="HYBJContainer" runat="server" class="row">
                <div id="HYBJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">班级</div>
                <div id="HYBJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYBJ"), null)%>
                
                </div>
            </div>
        
            <div id="JZXMContainer" runat="server" class="row">
                <div id="JZXMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">家长姓名</div>
                <div id="JZXMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JZXM"), null)%>
                
                </div>
            </div>
        
            <div id="JZDHContainer" runat="server" class="row">
                <div id="JZDHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">家长电话</div>
                <div id="JZDHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JZDH"), null)%>
                
                </div>
            </div>
        
            <div id="ZCSJContainer" runat="server" class="row">
                <div id="ZCSJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">注册时间</div>
                <div id="ZCSJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZCSJ"), "yyyy.M.d")%>
                
                </div>
            </div>
        
            <div id="ZKSSContainer" runat="server" class="row">
                <div id="ZKSSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">课时总数</div>
                <div id="ZKSSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZKSS"), null)%>
                
                </div>
            </div>
        
            <div id="XHKSSContainer" runat="server" class="row">
                <div id="XHKSSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">消耗课时</div>
                <div id="XHKSSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XHKSS"), null)%>
                
                </div>
            </div>
        
            <div id="SYKSSContainer" runat="server" class="row">
                <div id="SYKSSCaption" runat="server" class="fontbold col-xs-3 paddingleft0">剩余课时</div>
                <div id="SYKSSContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SYKSS"), null)%>
                
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


