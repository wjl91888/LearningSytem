<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BM_KCYYXXWebUIDetail.aspx.cs" Inherits="T_BM_KCYYXXWebUIDetail" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">�γ�ԤԼ��Ϣ����</asp:Content>
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
                                    �γ�ԤԼ��Ϣ
                                </div>
                            </div>
                        </div>
                        <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                        <div class="operation">
                        <div style="display:none;">
                    ����PDFҳ�����ã���С<asp:DropDownList ID="ddlPrintPageSize" runat="server" Visible = "false"></asp:DropDownList>
                    ����<asp:DropDownList ID="ddlPrintPageOrientation" runat="server" Visible = "false"></asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlExportFileFormat" Visible="false"><asp:ListItem Text="PDF�ļ�(.PDF)" Value="pdf"></asp:ListItem></asp:DropDownList>
                    �ϱ߾�<asp:TextBox ID="txtMarginTop" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    �ұ߾�<asp:TextBox ID="txtMarginRight" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    �±߾�<asp:TextBox ID="txtMarginBottom" runat="server" Width="20" Text="50" ></asp:TextBox>
                    ��߾�<asp:TextBox ID="txtMarginLeft" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>
                    <br />
                        </div>

                    <input type="button" id ="btnEditItem" runat ="server" value="�޸�" class="button" />

                    <input id="btnPrintPage" runat="server" type="button" value="��ӡ��ҳ" onclick="nonprintarea.style.display = 'none'; window.print();nonprintarea.style.display = 'block';" class="button" />
                    <input type="button" value="�رմ���" onclick="CloseWindow();" class="button" />
                        </div>
                    </div>
                    <div ID="ControlContainer" runat="server" class="print">
                        <asp:GridView ID="gvPrint" runat="server" AutoGenerateColumns="False" CellSpacing="0" CellPadding="0" HorizontalAlign="Center" BorderWidth="0" onrowdatabound="gvPrint_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle CssClass="detailtitle" HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        �γ�ԤԼ��Ϣ
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <!-- ������Ϣ -->
                                        <div id="divmain" runat="server"></div>
                                        <div id="divvaluearea" runat="server" style = "display:none;">
                                    
                                            <div id = "KCYYBH" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KCYYBH"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "KCBBH" runat = "server" >
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "KCBBH_T_BM_KCBXX_KCBH") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                           </div>
                                      
                                            <div id = "HYBH" runat = "server" >
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "HYBH_T_BM_HYXX_HYXM") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                           </div>
                                      
                                            <div id = "YYSJ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YYSJ"), "yyyy-MM-dd") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "YYBZ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YYBZ"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "SKZT" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SKZT"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "XHKS" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XHKS"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "KTZP" runat = "server" >
                                        
                               <%# DataBinder.Eval(Container.DataItem, "KTZP") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?a=d"+ AndChar +"file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "KTZP")) + "' target='_blank'>����</a>"%>
                               <%# DataBinder.Eval(Container.DataItem, "KTZP") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "KTZP")) + "' target='_blank'>Ԥ��</a>"%>
                                                
                                           </div>
                                      
                                            <div id = "JSPJ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JSPJ"), null) + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                            <div id = "PJR" runat = "server" >
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "PJR_T_PM_UserInfo_UserNickName") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                           </div>
                                      
                                            <div id = "PJSJ" runat = "server" >
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "PJSJ"), "yyyy-MM-dd") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                           </div>
                                      
                                        </div>
                                        <!-- һ�Զ���ر���Ϣ -->
                                                
                                        <div id = "relatedtable_1" runat = "server" style = "display:none;">
                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">
                                           <tr>
                                                
                                           </tr>
                                                
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
