<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BM_KCXXWebUIAdd.aspx.cs" Inherits="T_BM_KCXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">课程信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .ctl00_MainContentPlaceHolder_KCNR_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_BM_KCXX" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BM_KCXX" runat="server">
        <AjaxSettings>
  
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_KCXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <div id="addpage" runat="server" class="addpage">
                <div class="toptoolsbar">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            课程信息 
                        </div>
                    </div>
                </div>
                <div class="operation">
                    <center>
                        <asp:Button Text="导入数据" ID="btnInfoFromDS" runat="server" CssClass="button" OnClick="btnInfoFromDS_Click" />
                        <asp:Button Text="Word导入" ID="btnInfoFromDoc" runat="server" CssClass="button" OnClick="btnInfoFromDoc_Click" />
                        <asp:Button Text="批量Word导入" ID="btnInfoFromDocBatch" runat="server" CssClass="button" OnClick="btnInfoFromDocBatch_Click" Visible="false" />
                        <asp:Button Text="取消" ID="btnInfoFromDocCancel" runat="server" CssClass="button" OnClick="btnInfoFromDocCancel_Click" />
                        <input type="button" id ="btnEditItem" runat ="server" value="修改" class="button" />

                        <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="button" OnClientClick="return AddConfirmDialog();" OnClick="btnSave_Click" />

                        <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                    </center>
                </div>
                </div>
                <div class="main">
                     <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                     <div  id= "ImportControlContainer" runat="server">
                     <div class="content clearboth" id="InfoFromDoc_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">导入文件</div><div class="redstar">*</div>
                         </div>
                         <div class="fieldinput">
                                 <asp:TextBox ID="InfoFromDoc" runat="server" CssClass="input widthfull"></asp:TextBox>
                         </div>
                         <div class="fieldnote" id="InfoFromDoc_Note" runat="server"></div>
                     </div>
                     </div>
                     <div  id= "ControlContainer" runat="server">

                     <div class="content" id="ObjectID_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="ObjectID_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="KCBH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课程编号
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="KCBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="KCBH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="KCMC_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课程名称
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="KCMC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="KCMC_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="KCXLBH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课程系列
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="KCXLBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="KCXLBH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content clearboth" id="KCTP_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课程图片
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <control:FilesList ID="KCTP" runat="server" CssClass="input"></control:FilesList>
                                                 
                         </div><div class="fieldnote" id="KCTP_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content clearboth" id="KCNR_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课程简介
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <FTB:FreeTextBox ID="KCNR" runat="server" Language="zh-cn"  ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste,Delete;Undo,Redo,Print|InsertTable, EditTable, InsertTableRowBefore, InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, DeleteTableColumn|InsertDiv, Preview, SelectAll, EditStyle"></FTB:FreeTextBox>
                                                 
                         </div><div class="fieldnote" id="KCNR_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="KCKKSJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          开课时间
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="KCKKSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="KCKKSJ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="KSS_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课时数
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="KSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="KSS_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                <div class="clearboth"></div>
                <telerik:RadTabStrip ID="T_BM_KCXXTabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="T_BM_KCXXMultiPage" >
                    <Tabs>
                        <telerik:RadTab Visible="false" runat = "server" Value="1" PageViewID="PageView1"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="2" PageViewID="PageView2"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="3" PageViewID="PageView3"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="4" PageViewID="PageView4"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="5" PageViewID="PageView5"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="6" PageViewID="PageView6"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="7" PageViewID="PageView7"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="8" PageViewID="PageView8"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage CssClass="tab_table" ID="T_BM_KCXXMultiPage" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="PageView1" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView2" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView3" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView4" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView5" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView6" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView7" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView8" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <!-- 相关表批量添加 -->

                </div>
                </div>
            </div>
        </center>
</asp:Content>

