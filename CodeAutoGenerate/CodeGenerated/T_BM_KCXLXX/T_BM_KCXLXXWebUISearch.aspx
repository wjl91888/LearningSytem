<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" validateRequest="false" AutoEventWireup="true" CodeFile="T_BM_KCXLXXWebUISearch.aspx.cs" Inherits="T_BM_KCXLXXWebUISearch" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">课程系列信息查询</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadCodeBlock ID="JsCodeBlock" runat="server">
    <script language="javascript" type="text/javascript">
    function EditorWindowClose(sender, eventArgs) {
        RefreshGrid();
    }
    function RefreshGrid() {
        $find("<%= ramT_BM_KCXLXX.ClientID %>").ajaxRequest("Refresh");
    }
    $(document).ready(function () {
        $(".needrefresh").on("change", function () { RefreshGrid(); });
        $("input.needrefresh[type='text']").on("keyup", function () { RefreshGrid(); });
    });
    </script>
    </telerik:RadCodeBlock>
    <telerik:RadScriptManager ID="rsmT_BM_KCXLXX" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BM_KCXLXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnOperate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageSize">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ramT_BM_KCXLXX">
                <UpdatedControls>
  
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>  
  
            <telerik:AjaxSetting AjaxControlID="btnAdvanceSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>    
            <telerik:AjaxSetting AjaxControlID="btnShowAdvanceSearchItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>    
            <telerik:AjaxSetting AjaxControlID="btnShowSimpleSearchItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSaveFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="FilterReportList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_KCXLXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_KCXLXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top" id="tddivtree">
                <div id="divtree" class="width240">
            <div id="advancesearchpage" runat="server" class="advancesearchpage">
                <div id="FilterReportContainer" runat="server" Visible="false">
                <div class="main">
                    <div class="block">
                        <ul>
                            <li>查询报告</li>
                        </ul>
                    </div>
                    <div class="content" id="FilterReportList_Area" runat="server">
                        <div class="field">
                            <div class="fieldname">报告列表</div>
                        </div>
                        <div class="fieldinput">
                            <asp:DropDownList ID="FilterReportList" runat="server" DataTextField="BGMC" CssClass="input" DataValueField="ObjectID" 
                            OnSelectedIndexChanged="FilterReportList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="content" id="FilterReportName_Area" runat="server">
                        <div class="field">
                            <div class="fieldname">报告名称</div>
                        </div>
                        <div class="fieldinput">
                            <asp:TextBox ID="FilterReportName" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="input needrefresh"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="operation alignright width100per" id="FilterReport" runat="server" >
                    <asp:Button Text="删除" ID="btnDeleteFilterReport" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="button floatright" OnClick="btnDeleteFilterReport_Click" />
                    <asp:Button Text="保存" ID="btnSaveFilterReport" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="button floatright" OnClick="btnSaveFilterReport_Click" />
                    <asp:Button Text="清空" ID="btnReset" runat="server" CssClass="button floatright" OnClick="btnReset_Click" />
                    <div class="clearboth"></div>
                </div>
                </div>
                <div class="main">
                    <div class="block">
                        <ul>
                            <li>查询条件</li>
                        </ul>
                    </div>

                       <div class="content" id="KCXLBH_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            课程系列编号
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="KCXLBH" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="KCXLMC_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            课程系列名称
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="KCXLMC" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content clearboth clearboth" id="KCXLSJBH_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            所属类别
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="KCXLSJBH" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                           <div class="fieldinput alignright width100per">
                                   <asp:CheckBox ID="chkShowSubItemKCXLSJBH" runat="server" Text = "包含子（下级）" Checked="true" CssClass="needrefresh" />
                                      
                           </div>
                       </div>
  
                       <div class="content" id="KCXLJJ_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            课程系列简介
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="KCXLJJ" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                  
                           </div>
                       </div>
  
                       <div class="content" id="NLD_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            年龄段
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="NLD" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="KSS_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            课时总数
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="KSS" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                    <div id="ShowField_Area" runat="server"><div class="block">
                        <ul>
                            <li>结果显示字段</li>
                        </ul>
                    </div>
                
                   <div ID="chkShowKCXLBH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowKCXLBH" runat="server"  CssClass="needrefresh" Text = "课程系列编号" 
                                         Checked="true" />
                               <asp:TextBox ID="txtKCXLBHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowKCXLMC_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowKCXLMC" runat="server"  CssClass="needrefresh" Text = "课程系列名称" 
                                         Checked="true" />
                               <asp:TextBox ID="txtKCXLMCColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowKCXLSJBH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowKCXLSJBH" runat="server"  CssClass="needrefresh" Text = "所属类别" 
                                         Checked="true" />
                               <asp:TextBox ID="txtKCXLSJBHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowNLD_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowNLD" runat="server"  CssClass="needrefresh" Text = "年龄段" 
                                         Checked="true" />
                               <asp:TextBox ID="txtNLDColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowKSS_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowKSS" runat="server"  CssClass="needrefresh" Text = "课时总数" 
                                         Checked="true" />
                               <asp:TextBox ID="txtKSSColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                </div></div>
                <div class="operation" id="operation" runat="server">
                    <center>
                        <asp:Button Text="查询" ID="btnAdvanceSearch" runat="server" CssClass="button floatright" OnClick="btnAdvanceSearch_Click" />
                        <asp:Button Text="高级界面" ID="btnShowAdvanceSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowAdvanceSearchItem_Click" />
                        <asp:Button Text="简单界面" ID="btnShowSimpleSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowSimpleSearchItem_Click" />
                    </center>
                </div>
            </div>
                    </div>
                </td>
                <td valign="top" id="tdmiddleblock">
                    <div style="float: left; width: 10px; height: 100%; vertical-align: middle;" onclick="changeWin();" onmousemove="this.style.cursor='pointer';" onmouseout="this.style.cursor='';">
                        <table border="0" style="background-color: #efefef; height: 100%;">
                            <tr>
                                <td valign="middle">
                                    <img id="menuSwitch" height="12" alt="隐藏" src="/App_Themes/Themes/Image/arrow_left.gif" width="8" border="0" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td valign="top" width="100%">
            <div id="listpage" runat="server" class="listpage listpageleftposition">
               <div id="toptoolsbar" runat="server" class="toptoolsbar listpageleftposition">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            <asp:Literal ID="PageTitle" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                <div id="SearchPageTopButtonBar" runat="server" class="quicksearch">
                    <input type="button" id="btnAddItem" runat="server" value="添加" class="button" />

                     <input type="button" id="btnStatisticItem" runat="server" value="统计" class="button" />
                     <input type="button" value="关闭" onclick="CloseWindow();" class="button displaynone" />
                     <asp:DropDownList runat="server" ID="ddlExportFileFormat">
                         <asp:ListItem Text="文件类型" Value="xls"></asp:ListItem>
                         <asp:ListItem Text="EXCEL文件(.xls)" Value="xls"></asp:ListItem>
                         <asp:ListItem Text="WORD文件(.doc)" Value="doc"></asp:ListItem>
                     </asp:DropDownList>
                     <asp:Button runat="server" ID="btnExportAllToFile" Text="导出" CssClass="button" OnClick="btnExportAllToFile_Click" />
                 <%=Convert.ToChar(38).ToString() +"nbsp;"%>
                 </div>
                <div id="SearchPageTopToolBar" runat="server" class="SearchPageTopToolBar">
                    <table>
                    <tr>
                    <td><input id="chkAll" type="checkbox" onclick="CheckAll(this);" runat="server" /></td>
                    <td><asp:DropDownList runat="server" ID="ddlOperation">
                        <asp:ListItem Text="操作" Value=""></asp:ListItem>
                        <asp:ListItem Text="删除" Value="remove"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="btnOperate" Text="执行" CssClass="button" OnClick="btnOperate_Click" /></td>
                    <td><asp:Button ID="btnFirstPage" runat="server" Text="|<" alt="第一页" OnClick="btnFirstPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnPrePage" runat="server" Text="<" alt="上一页" OnClick="btnPrePage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnNextPage" runat="server" Text=">" alt="下一页" OnClick="btnNextPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnLastPage" runat="server" Text=">|" alt="最后一页" OnClick="btnLastPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:DropDownList ID="ddlPageCount" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                    <td><asp:Label ID="lblPageInfo" runat="server" Text=""></asp:Label></td>
                    </tr>
                    </table>
                </div>
                </div>
                <div id="ListControl" runat="server" class="main">
                    <div class="list" id="divList" runat="server">
                        <asp:GridView ID="gvList" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table" CellPadding="5" Width="100%" BorderWidth="0px" HorizontalAlign="Center" OnRowDataBound="gvList_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="选中">
                                    <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" Width="25px" />
                                    <HeaderStyle CssClass="fieldname" />
                                    <FooterStyle CssClass="fieldname" />
                                    <ItemTemplate>
                                    <input type="checkbox" id="ObjectIDBatch" class="checkboxbatch" name="ObjectIDBatch" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' onclick="DoCheckAllFlag('ctl00$MainContentPlaceHolder$chkAll')" />
                                    <input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' />
                                    </ItemTemplate>
                                <FooterTemplate>
                                    合计
                                </FooterTemplate>
                                </asp:TemplateField>
                
                           <asp:TemplateField HeaderText="课程系列编号" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    课程系列编号<asp:LinkButton ID="btnSortKCXLBH" runat="server" CommandArgument="KCXLBH"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLBH"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="课程系列名称" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    课程系列名称<asp:LinkButton ID="btnSortKCXLMC" runat="server" CommandArgument="KCXLMC"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLMC"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="所属类别" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    所属类别<asp:LinkButton ID="btnSortKCXLSJBH" runat="server" CommandArgument="KCXLSJBH"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <a href="#" style="cursor:pointer;text-decoration:none;" onclick="OpenWindow('T_BM_KCXLXXWebUIDetail.aspx?KCXLBH=<%# DataBinder.Eval(Container.DataItem, "KCXLSJBH") %>',770,600,window);"><%# DataBinder.Eval(Container.DataItem, "KCXLSJBH_T_BM_KCXLXX_KCXLMC")%></a>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="年龄段" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    年龄段<asp:LinkButton ID="btnSortNLD" runat="server" CommandArgument="NLD"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "NLD"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="课时总数" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    课时总数<asp:LinkButton ID="btnSortKSS" runat="server" CommandArgument="KSS"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KSS"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="print" id="divPrint" runat="server">
                        <asp:GridView ID="gvPrint" ViewStateMode="Disabled" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table" CellSpacing="0" CellPadding="3" Width="100%" HorizontalAlign="Center">
                            <Columns>
                
                           <asp:TemplateField HeaderText="课程系列编号"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLBH"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="课程系列名称"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCXLMC"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="所属类别"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "KCXLSJBH_T_BM_KCXLXX_KCXLMC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="年龄段"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "NLD"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="课时总数"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KSS"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
                </td>
            </tr>
        </table>
        </center>
</asp:Content>

