<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BM_HYXXWebUIAdd.aspx.cs" Inherits="T_BM_HYXXWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">会员信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_BM_HYXX" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BM_HYXX" runat="server">
        <AjaxSettings>
  
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_HYXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <div id="addpage" runat="server" class="addpage">
                <div class="toptoolsbar">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            会员信息 
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
  
                     <div class="content" id="HYBH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          会员编号
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="HYBH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="HYBH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="HYXM_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          姓名
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="HYXM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="HYXM_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="HYNC_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          昵称
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="HYNC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="HYNC_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="HYSR_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          生日
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="HYSR" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="HYSR_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="HYXX_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          学校
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="HYXX" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="HYXX_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="HYBJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          班级
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="HYBJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="HYBJ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JZXM_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          家长姓名
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JZXM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JZXM_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JZDH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          家长电话
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JZDH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JZDH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="ZCSJ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          注册时间
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="ZCSJ" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="ZCSJ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="ZKSS_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          课时总数
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="ZKSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="ZKSS_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="XHKSS_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          消耗课时
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="XHKSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="XHKSS_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SYKSS_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          剩余课时
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SYKSS" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SYKSS_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                <div class="clearboth"></div>
                <telerik:RadTabStrip ID="T_BM_HYXXTabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="T_BM_HYXXMultiPage" >
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
                <telerik:RadMultiPage CssClass="tab_table" ID="T_BM_HYXXMultiPage" runat="server" SelectedIndex="0">
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

