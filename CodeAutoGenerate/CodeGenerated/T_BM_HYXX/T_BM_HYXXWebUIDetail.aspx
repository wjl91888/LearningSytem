<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BM_HYXXWebUIDetail.aspx.cs" Inherits="T_BM_HYXXWebUIDetail" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">会员信息详情</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .print .detailtitle {font-size:26px; padding-top:10px; padding-bottom:15px;}
    .print .detailtable{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:14px;}
    .print .detailtable_10{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:10px;}
    .print .detailtable_12{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:12px;}
    .print .detailtable_14{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:14px;}
    .print .detailtable_16{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:16px;}
    .print .detailtable_18{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:18px;}
    .print .fieldname{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white; font-weight:bold; height:25px; line-height:18px;text-align:center;}
    .print .fieldinput{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white;text-align:center; height:25px; line-height:18px;}
    .prln { page-break-before: always; page-break-after: always;}
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <center>
                <div id="detailpage" runat="server" class="detailpage">
                    <div id="nonprintarea">
                        <div class="title">
                            <div class="bar">
                                <div class="lefttitle">
                                    会员信息
                                </div>
                            </div>
                        </div>
                        <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                        <div class="operation">
                        <div style="display:none;">
                    导出PDF页面设置：大小<asp:DropDownList ID="ddlPrintPageSize" runat="server" Visible = "false"></asp:DropDownList>
                    版面<asp:DropDownList ID="ddlPrintPageOrientation" runat="server" Visible = "false"></asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlExportFileFormat" Visible="false"><asp:ListItem Text="PDF文件(.PDF)" Value="pdf"></asp:ListItem></asp:DropDownList>
                    上边距<asp:TextBox ID="txtMarginTop" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    右边距<asp:TextBox ID="txtMarginRight" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    下边距<asp:TextBox ID="txtMarginBottom" runat="server" Width="20" Text="50" ></asp:TextBox>
                    左边距<asp:TextBox ID="txtMarginLeft" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    <br />
                        </div>

                    <input type="button" id ="btn" runat ="server" value="报名" class="button" />

                    <input type="button" id ="btnEditItem" runat ="server" value="修改" class="button" />

                    <input id="btnPrintPage" runat="server" type="button" value="打印本页" onclick="nonprintarea.style.display = 'none'; window.print();nonprintarea.style.display = 'block';" class="button" />
                    <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                        </div>
                    </div>
                    <div ID="ControlContainer" runat="server" class="print">
                        <asp:GridView ID="gvPrint" runat="server" AutoGenerateColumns="False" CellSpacing="0" CellPadding="0" HorizontalAlign="Center" BorderWidth="0" onrowdatabound="gvPrint_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="detailtitle" HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        会员信息
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <!-- 主表信息 -->
                                        <div id="divmain" runat="server"></div>
                                        <div id="divvaluearea" runat="server" style = "display:none;">
                                    
                                            <div id = "HYBH" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYBH"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "HYXM" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYXM"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "HYNC" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYNC"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "HYSR" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYSR"), "yyyy.M.d") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "HYXX" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYXX"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "HYBJ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HYBJ"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JZXM" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JZXM"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "JZDH" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JZDH"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "ZCSJ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZCSJ"), "yyyy.M.d") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "ZKSS" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZKSS"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "XHKSS" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XHKSS"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "SYKSS" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SYKSS"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                        </div>
                                        <!-- 一对多相关表信息 -->
                                                
                                        <!-- 相关表报名信息开始 -->
                                        <table class="detailtable" cellspacing="0" cellpadding="0" width="615">
                                           <tr>
                                           <td class="fieldname">
                                               <b>报名信息</b>
                                           </td>
                                           </tr>
                                        </table>
                                                      
                                        <div id = "relatedtable_1" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                               <td class="fieldname">
                                                            报名编号
                                               </td>
                                                          
                                               <td class="fieldname">
                                                            价格
                                               </td>
                                                          
                                               <td class="fieldname">
                                                            课时数
                                               </td>
                                                          
                                               <td class="fieldname">
                                                            折扣
                                               </td>
                                                          
                                               <td class="fieldname">
                                                            实际收款
                                               </td>
                                                          
                                               <td class="fieldname">
                                                            报名时间
                                               </td>
                                                          
                                               <td style="display:none;"></td>

                                                  
                                           </tr>
                                                
                                        <asp:Repeater runat="server"
                                        ID="rptT_BM_BMXX"
                                        DataSource='<%# GetT_BM_BMXX(DataBinder.Eval(Container.DataItem, "HYBH"))%>' onprerender="rptRelatedTable_PreRender">
                                            <ItemTemplate>
                                           <tr id="row" runat="server">
                                                      
                                               <td class="fieldinput"  id = "BMBH" runat="server">
                                               <div style="width:100%;text-align:;">
                                                        
                                                 <%# DataBinder.Eval(Container.DataItem, "BMBH") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "BMBH")%>
                                                            
                                               </div>
                                               </td>
                                                          
                                               <td class="fieldinput"  id = "KCJG" runat="server">
                                               <div style="width:100%;text-align:;">
                                                        
                                                 <%# DataBinder.Eval(Container.DataItem, "KCJG") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "KCJG")%>
                                                            
                                               </div>
                                               </td>
                                                          
                                               <td class="fieldinput"  id = "KSS" runat="server">
                                               <div style="width:100%;text-align:;">
                                                        
                                                 <%# DataBinder.Eval(Container.DataItem, "KSS") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "KSS")%>
                                                            
                                               </div>
                                               </td>
                                                          
                                               <td class="fieldinput"  id = "KCZK" runat="server">
                                               <div style="width:100%;text-align:;">
                                                        
                                                 <%# DataBinder.Eval(Container.DataItem, "KCZK") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "KCZK")%>
                                                            
                                               </div>
                                               </td>
                                                          
                                               <td class="fieldinput"  id = "SJJG" runat="server">
                                               <div style="width:100%;text-align:;">
                                                        
                                                 <%# DataBinder.Eval(Container.DataItem, "SJJG") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "SJJG")%>
                                                            
                                               </div>
                                               </td>
                                                          
                                               <td class="fieldinput"  id = "BMSJ" runat="server">
                                               <div style="width:100%;text-align:;">
                                                        
                                                 <%# DataBinder.Eval(Container.DataItem, "BMSJ") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "BMSJ")%>
                                                            
                                               </div>
                                               </td>
                                                          
                                               <td style="display:none;">
                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>
                                    <!-- 这里用来定义需要显示的右键菜单 -->
                                    <div id="itemMenu" style="display: none;" runat="server">
                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">
                                            <tr>
                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow('T_BM_BMXXWebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&amp;RelatedTableName=T_BM_HYXX',770,600,window);">
                                                    查看
                                               </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- 右键菜单结束-->
                                               </td>
                                                  
                                           </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <!-- 相关表报名信息结束 -->
                                                      
                                        </table>
                                        </div>
                                                
                                        <div id = "relatedtable_2" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_3" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>
                                                
                                        <div id = "relatedtable_4" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_5" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_6" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_7" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_8" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_9" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>

                                                
                                        <div id = "relatedtable_10" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
                                        </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
        </center>
</asp:Content>

