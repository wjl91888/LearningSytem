<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BM_KCBXXWebUIAdd.aspx.cs" Inherits="T_BM_KCBXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">课程表编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_BM_KCBXX" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BM_KCBXX" runat="server">
        <AjaxSettings>
  
            <telerik:AjaxSetting AjaxControlID="KCXLBH">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="KCBH" LoadingPanelID="ralpT_BM_KCBXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_KCBXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <div id="addpage" runat="server" class="addpage">
                <div class="toptoolsbar">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            课程表 
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
  
                     <div class="content" id="KCBBH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          编号
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="KCBBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="KCBBH_Note" runat="server">
                                      
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
  
                     <div class="content" id="KCBH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课程
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="KCBH" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="KCBH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="KCSJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          上课时间
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="KCSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="KCSJ_Note" runat="server">
                                      
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
  
                     <div class="content" id="SKJS_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          教师
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="SKJS" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="SKJS_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SKFJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          教室
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SKFJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SKFJ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                <div class="clearboth"></div>
                <telerik:RadTabStrip ID="T_BM_KCBXXTabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="T_BM_KCBXXMultiPage" >
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
                <telerik:RadMultiPage CssClass="tab_table" ID="T_BM_KCBXXMultiPage" runat="server" SelectedIndex="0">
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

