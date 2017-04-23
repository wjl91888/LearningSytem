/****************************************************** 
FileName:T_BM_BMXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_BMXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_BMXXWebUIDetail : RICH.Common.BM.T_BM_BMXX.T_BM_BMXXWebUI
{
    protected override void Page_Init(object sender, EventArgs e)
    {
        base.Page_Init(sender, e);
    }

    //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            Initalize();
        }
        base.Page_Load(sender, e);
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
   protected override void Initalize()
    {
        // 界面初始化
        // 初始化打印页面大小
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A4", "A4"));
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A3", "A3"));
        // 初始化打印页面方向大小
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("竖向", "portrait"));
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("横向", "landscape"));

        // 读取记录详细资料
        appData = new T_BM_BMXXApplicationData();
        appData.ObjectID = ObjectID;
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        QueryRecord();
        Header.DataBind();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        // 按钮初始化

        if (IsPostBack != true)
        {
            foreach (DataRow drTemp in appData.ResultSet.Tables[0].Rows)
            {
                //记录日志开始
                string strLogTypeID = "A10";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "报名信息";
                strMessageParam[2] = drTemp["HYBH"].ToString();
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                //记录日志结束
            }
        }
    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载ExportToFile
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new T_BM_BMXXApplicationData();
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        appData.ObjectID = base.ObjectID;
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFile(gvPrint, "Result");
                break;
            case "pdf":
                string pageSize = ddlPrintPageSize.SelectedValue;
                bool boolOrientation = ddlPrintPageOrientation.SelectedValue == "landscape" ? true : false;
                float marginTop = DataValidateManager.ValidateNumberFormat(txtMarginTop.Text) == true ? Convert.ToSingle(txtMarginTop.Text) : 50;
                float marginRight = DataValidateManager.ValidateNumberFormat(txtMarginRight.Text) == true ? Convert.ToSingle(txtMarginRight.Text) : 50;
                float marginBottom = DataValidateManager.ValidateNumberFormat(txtMarginBottom.Text) == true ? Convert.ToSingle(txtMarginBottom.Text) : 50;
                float marginLeft = DataValidateManager.ValidateNumberFormat(txtMarginLeft.Text) == true ? Convert.ToSingle(txtMarginLeft.Text) : 50;
                ExportToPDFFile(appData.ResultSet, "Result", pageSize, boolOrientation, marginTop, marginRight, marginBottom, marginLeft);
                break;
            default:
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
        }
        gvPrint.Visible = false;
    }

    protected void gvPrint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Control hcTemp;
            // 生成详情表并设置属性
            System.Web.UI.WebControls.Table tDetailView = new System.Web.UI.WebControls.Table();
            tDetailView.CssClass = "detailtable";
            tDetailView.CellPadding = 0;
            tDetailView.CellSpacing = 0;
            tDetailView.BorderColor = System.Drawing.Color.Black;
            tDetailView.BorderWidth = 0;
            tDetailView.Width = 615;
            // 获得列数
            int intColumn = 0;
            
            intColumn += 4 + 4;
            intColumn += 4 + 4;
            // 获得行数
            int intLength = 0;
    
            intLength = 6;
            intLength++;
            // 生成行
            for (int i = 0; i < intLength; i++)
            {
                TableRow trTemp = new TableRow();
                tDetailView.Rows.Add(trTemp);
            }
            // 得到值区域控件
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                hcTemp = tcTemp.FindControl("divvaluearea");
                if (hcTemp != null)
                {
                    // 生成表格
                    // 生成主表表格
                    for (int i = intColumn; i > 0; i--)
                    {
                        TableCell tcBlank = new TableCell();
                        tcBlank.ColumnSpan = 1;
                        tcBlank.RowSpan = 1;
                        tcBlank.Height = 0;
                        tcBlank.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        tcBlank.Style.Add("height", "0");
                        tDetailView.Rows[0].Cells.Add(tcBlank);
                    }
                    tDetailView.Rows[0].Height = 0;
            
                    // 显示报名编号标题
                    TableCell tcBMBHTitle = new TableCell();
                    tcBMBHTitle.Text = "报名编号";
                    tcBMBHTitle.ColumnSpan = 4;
                    tcBMBHTitle.RowSpan = 1;
                    tcBMBHTitle.CssClass = "fieldname";
                    tcBMBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBMBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcBMBHTitle);
                    
                    // 显示报名编号值
                    TableCell tcBMBHContent = new TableCell();
                      
                    tcBMBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BMBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BMBH")).InnerHtml = "";
                    tcBMBHContent.ColumnSpan = 4;
                    tcBMBHContent.RowSpan = 1;
                    tcBMBHContent.CssClass = "fieldinput";
                    tcBMBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcBMBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcBMBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcBMBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBMBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcBMBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcBMBHContent);
              
                    // 显示会员编号标题
                    TableCell tcHYBHTitle = new TableCell();
                    tcHYBHTitle.Text = "会员编号";
                    tcHYBHTitle.ColumnSpan = 4;
                    tcHYBHTitle.RowSpan = 1;
                    tcHYBHTitle.CssClass = "fieldname";
                    tcHYBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcHYBHTitle);
                    
                    // 显示会员编号值
                    TableCell tcHYBHContent = new TableCell();
                      
                    tcHYBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HYBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HYBH")).InnerHtml = "";
                    tcHYBHContent.ColumnSpan = 4;
                    tcHYBHContent.RowSpan = 1;
                    tcHYBHContent.CssClass = "fieldinput";
                    tcHYBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHYBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcHYBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcHYBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHYBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcHYBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcHYBHContent);
              
                    // 显示价格标题
                    TableCell tcKCJGTitle = new TableCell();
                    tcKCJGTitle.Text = "价格";
                    tcKCJGTitle.ColumnSpan = 4;
                    tcKCJGTitle.RowSpan = 1;
                    tcKCJGTitle.CssClass = "fieldname";
                    tcKCJGTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCJGTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcKCJGTitle);
                    
                    // 显示价格值
                    TableCell tcKCJGContent = new TableCell();
                      
                    tcKCJGContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCJG")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCJG")).InnerHtml = "";
                    tcKCJGContent.ColumnSpan = 4;
                    tcKCJGContent.RowSpan = 1;
                    tcKCJGContent.CssClass = "fieldinput";
                    tcKCJGContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCJGContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCJGContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCJGContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCJGContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCJGContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcKCJGContent);
              
                    // 显示课时数标题
                    TableCell tcKSSTitle = new TableCell();
                    tcKSSTitle.Text = "课时数";
                    tcKSSTitle.ColumnSpan = 4;
                    tcKSSTitle.RowSpan = 1;
                    tcKSSTitle.CssClass = "fieldname";
                    tcKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcKSSTitle);
                    
                    // 显示课时数值
                    TableCell tcKSSContent = new TableCell();
                      
                    tcKSSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KSS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KSS")).InnerHtml = "";
                    tcKSSContent.ColumnSpan = 4;
                    tcKSSContent.RowSpan = 1;
                    tcKSSContent.CssClass = "fieldinput";
                    tcKSSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKSSContent.Style.Add("border-top", "1px black solid");
                        
                    tcKSSContent.Style.Add("border-left", "1px black solid");
                        
                    tcKSSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKSSContent.Style.Add("border-right", "1px black solid");
                        
                    tcKSSContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcKSSContent);
              
                    // 显示折扣标题
                    TableCell tcKCZKTitle = new TableCell();
                    tcKCZKTitle.Text = "折扣";
                    tcKCZKTitle.ColumnSpan = 4;
                    tcKCZKTitle.RowSpan = 1;
                    tcKCZKTitle.CssClass = "fieldname";
                    tcKCZKTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCZKTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcKCZKTitle);
                    
                    // 显示折扣值
                    TableCell tcKCZKContent = new TableCell();
                      
                    tcKCZKContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCZK")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCZK")).InnerHtml = "";
                    tcKCZKContent.ColumnSpan = 4;
                    tcKCZKContent.RowSpan = 1;
                    tcKCZKContent.CssClass = "fieldinput";
                    tcKCZKContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCZKContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCZKContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCZKContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCZKContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCZKContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcKCZKContent);
              
                    // 显示实际收款标题
                    TableCell tcSJJGTitle = new TableCell();
                    tcSJJGTitle.Text = "实际收款";
                    tcSJJGTitle.ColumnSpan = 4;
                    tcSJJGTitle.RowSpan = 1;
                    tcSJJGTitle.CssClass = "fieldname";
                    tcSJJGTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSJJGTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcSJJGTitle);
                    
                    // 显示实际收款值
                    TableCell tcSJJGContent = new TableCell();
                      
                    tcSJJGContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJJG")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJJG")).InnerHtml = "";
                    tcSJJGContent.ColumnSpan = 4;
                    tcSJJGContent.RowSpan = 1;
                    tcSJJGContent.CssClass = "fieldinput";
                    tcSJJGContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSJJGContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJJGContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJJGContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJJGContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJJGContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcSJJGContent);
              
                    // 显示收款人标题
                    TableCell tcSKRTitle = new TableCell();
                    tcSKRTitle.Text = "收款人";
                    tcSKRTitle.ColumnSpan = 4;
                    tcSKRTitle.RowSpan = 1;
                    tcSKRTitle.CssClass = "fieldname";
                    tcSKRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSKRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSKRTitle);
                    
                    // 显示收款人值
                    TableCell tcSKRContent = new TableCell();
                      
                    tcSKRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SKR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SKR")).InnerHtml = "";
                    tcSKRContent.ColumnSpan = 4;
                    tcSKRContent.RowSpan = 1;
                    tcSKRContent.CssClass = "fieldinput";
                    tcSKRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSKRContent.Style.Add("border-top", "1px black solid");
                        
                    tcSKRContent.Style.Add("border-left", "1px black solid");
                        
                    tcSKRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSKRContent.Style.Add("border-right", "1px black solid");
                        
                    tcSKRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSKRContent);
              
                    // 显示报名时间标题
                    TableCell tcBMSJTitle = new TableCell();
                    tcBMSJTitle.Text = "报名时间";
                    tcBMSJTitle.ColumnSpan = 4;
                    tcBMSJTitle.RowSpan = 1;
                    tcBMSJTitle.CssClass = "fieldname";
                    tcBMSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBMSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcBMSJTitle);
                    
                    // 显示报名时间值
                    TableCell tcBMSJContent = new TableCell();
                      
                    tcBMSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BMSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BMSJ")).InnerHtml = "";
                    tcBMSJContent.ColumnSpan = 4;
                    tcBMSJContent.RowSpan = 1;
                    tcBMSJContent.CssClass = "fieldinput";
                    tcBMSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcBMSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcBMSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcBMSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBMSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcBMSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcBMSJContent);
              
                    // 显示备注标题
                    TableCell tcBZTitle = new TableCell();
                    tcBZTitle.Text = "备注";
                    tcBZTitle.ColumnSpan = 4;
                    tcBZTitle.RowSpan = 1;
                    tcBZTitle.CssClass = "fieldname";
                    tcBZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcBZTitle);
                    
                    // 显示备注值
                    TableCell tcBZContent = new TableCell();
                      
                    tcBZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BZ")).InnerHtml = "";
                    tcBZContent.ColumnSpan = 12;
                    tcBZContent.RowSpan = 1;
                    tcBZContent.CssClass = "fieldinput";
                    tcBZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcBZContent.Style.Add("border-top", "1px black solid");
                        
                    tcBZContent.Style.Add("border-left", "1px black solid");
                        
                    tcBZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBZContent.Style.Add("border-right", "1px black solid");
                        
                    tcBZContent.Style.Add("text-align", "left");
                    tDetailView.Rows[5].Cells.Add(tcBZContent);
              
                    // 显示登记人标题
                    TableCell tcLRRTitle = new TableCell();
                    tcLRRTitle.Text = "登记人";
                    tcLRRTitle.ColumnSpan = 4;
                    tcLRRTitle.RowSpan = 1;
                    tcLRRTitle.CssClass = "fieldname";
                    tcLRRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLRRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcLRRTitle);
                    
                    // 显示登记人值
                    TableCell tcLRRContent = new TableCell();
                      
                    tcLRRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LRR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LRR")).InnerHtml = "";
                    tcLRRContent.ColumnSpan = 4;
                    tcLRRContent.RowSpan = 1;
                    tcLRRContent.CssClass = "fieldinput";
                    tcLRRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcLRRContent.Style.Add("border-top", "1px black solid");
                        
                    tcLRRContent.Style.Add("border-left", "1px black solid");
                        
                    tcLRRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLRRContent.Style.Add("border-right", "1px black solid");
                        
                    tcLRRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[6].Cells.Add(tcLRRContent);
              
                    // 显示登记时间标题
                    TableCell tcLRSJTitle = new TableCell();
                    tcLRSJTitle.Text = "登记时间";
                    tcLRSJTitle.ColumnSpan = 4;
                    tcLRSJTitle.RowSpan = 1;
                    tcLRSJTitle.CssClass = "fieldname";
                    tcLRSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLRSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcLRSJTitle);
                    
                    // 显示登记时间值
                    TableCell tcLRSJContent = new TableCell();
                      
                    tcLRSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LRSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LRSJ")).InnerHtml = "";
                    tcLRSJContent.ColumnSpan = 4;
                    tcLRSJContent.RowSpan = 1;
                    tcLRSJContent.CssClass = "fieldinput";
                    tcLRSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcLRSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcLRSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcLRSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLRSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcLRSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[6].Cells.Add(tcLRSJContent);
              
                    // 生成一对一相关表表格
            
                    break;
                }
            }
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                // 设置主表信息
                hcTemp = tcTemp.FindControl("divmain");
                if (hcTemp != null)
                {
                    hcTemp.Controls.Add(tDetailView);
                }
    
            }
        }
    }

    protected void ExportToPDFFile(DataSet dsMainTable,
        string filename,
        string pageSize,
        bool boolOrientation,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft
        )
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = GeneratePDFDocument(dsMainTable, pageSize, boolOrientation, marginTop, marginRight, marginBottom, marginLeft);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        Response.Write(pdfDoc);
        Response.End();
    }

    private iTextSharp.text.Document GeneratePDFDocument(DataSet dsMainTable,
        string pageSize,
        bool boolOrientation,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft
        )
    {
        Rectangle rect;
        switch (pageSize)
        {
            case "A0":
                rect = new Rectangle(boolOrientation == true ? PageSize.A0.Rotate() : PageSize.A0);
                break;
            case "A1":
                rect = new Rectangle(boolOrientation == true ? PageSize.A1.Rotate() : PageSize.A1);
                break;
            case "A2":
                rect = new Rectangle(boolOrientation == true ? PageSize.A2.Rotate() : PageSize.A2);
                break;
            case "A3":
                rect = new Rectangle(boolOrientation == true ? PageSize.A3.Rotate() : PageSize.A3);
                break;
            case "A4":
                rect = new Rectangle(boolOrientation == true ? PageSize.A4.Rotate() : PageSize.A4);
                break;
            default:
                rect = new Rectangle(boolOrientation == true ? PageSize.A4.Rotate() : PageSize.A4);
                break;
        }
        // 创建空白PDF文档
        Document pdfDoc = new Document(rect, marginLeft, marginRight, marginTop, marginBottom);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        // 添加主表及一对一相关表信息
        pdfDoc.Add(GenerateMainTable(dsMainTable));
        // 添加一对多相关表信息
    
        pdfDoc.Close();
        return pdfDoc;
    }
    private iTextSharp.text.Table GenerateMainTable(DataSet dsMainTable)
    {
        // 生成表格
        BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font22B = new Font(bfChinese, 22, iTextSharp.text.Font.BOLD);
        Font font22 = new Font(bfChinese, 22);
        Font font20B = new Font(bfChinese, 20, iTextSharp.text.Font.BOLD);
        Font font20 = new Font(bfChinese, 20);
        Font font19B = new Font(bfChinese, 19, iTextSharp.text.Font.BOLD);
        Font font19 = new Font(bfChinese, 19);
        Font font14B = new Font(bfChinese, 14, iTextSharp.text.Font.BOLD);
        Font font14 = new Font(bfChinese, 14);
        Font font13B = new Font(bfChinese, 13, iTextSharp.text.Font.BOLD);
        Font font13 = new Font(bfChinese, 13);
        Font font12B = new Font(bfChinese, 12, iTextSharp.text.Font.BOLD);
        Font font12 = new Font(bfChinese, 12);
        Font font11B = new Font(bfChinese, 11, iTextSharp.text.Font.BOLD);
        Font font11 = new Font(bfChinese, 11);
        Font font10B = new Font(bfChinese, 10, iTextSharp.text.Font.BOLD);
        Font font10 = new Font(bfChinese, 10);
        Font font9B = new Font(bfChinese, 9, iTextSharp.text.Font.BOLD);
        Font font9 = new Font(bfChinese, 9);
        Font font8B = new Font(bfChinese, 8, iTextSharp.text.Font.BOLD);
        Font font8 = new Font(bfChinese, 8);
        int intColumn = 0;
        
        intColumn += 4 + 4;
        intColumn += 4 + 4;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("报名信息", font19B));
        cellTitle.BorderWidth = 0;
        cellTitle.HorizontalAlignment = 1;
        cellTitle.VerticalAlignment = 1;
        cellTitle.Colspan = intColumn;
        itbOutput.AddCell(cellTitle);
          
        Cell cellTitleSpace = new Cell(new Paragraph(" ", font20B));
        cellTitleSpace.BorderWidth = 0;
        cellTitleSpace.HorizontalAlignment = 1;
        cellTitleSpace.VerticalAlignment = 1;
        cellTitleSpace.Colspan = intColumn;
        itbOutput.AddCell(cellTitleSpace);
        itbOutput.AddCell(cellTitleSpace);
        // 定义分割线
        Cell cellBorder = new Cell(new Paragraph("", font10B));
        cellBorder.BorderWidth = 0;
        cellBorder.BorderWidthBottom = 1;
        cellBorder.HorizontalAlignment = 1;
        cellBorder.VerticalAlignment = 1;
        cellBorder.Colspan = intColumn;
        if (dsMainTable.Tables.Count > 0)
        {
            foreach (DataRow drTemp in dsMainTable.Tables[0].Rows)
            {
                // 生成主表表格
            
                // 生成一对一相关表表格
            
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            
            }
        }
        return itbOutput;
    }    

    private iTextSharp.text.Table GenerateRelatedTable(DataSet dsMainTable, string strRelatedTableName, string strRelatedInfoName)
    {
        DataSet dsRelatedTable = new DataSet();
        // 生成表格
        BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font20B = new Font(bfChinese, 20, iTextSharp.text.Font.BOLD);
        Font font20 = new Font(bfChinese, 20);
        Font font14B = new Font(bfChinese, 14, iTextSharp.text.Font.BOLD);
        Font font14 = new Font(bfChinese, 14);
        Font font13B = new Font(bfChinese, 13, iTextSharp.text.Font.BOLD);
        Font font13 = new Font(bfChinese, 13);
        Font font12B = new Font(bfChinese, 12, iTextSharp.text.Font.BOLD);
        Font font12 = new Font(bfChinese, 12);
        Font font11B = new Font(bfChinese, 11, iTextSharp.text.Font.BOLD);
        Font font11 = new Font(bfChinese, 11);
        Font font10B = new Font(bfChinese, 10, iTextSharp.text.Font.BOLD);
        Font font10 = new Font(bfChinese, 10);
        Font font9B = new Font(bfChinese, 9, iTextSharp.text.Font.BOLD);
        Font font9 = new Font(bfChinese, 9);
        Font font8B = new Font(bfChinese, 8, iTextSharp.text.Font.BOLD);
        Font font8 = new Font(bfChinese, 8);
        int intColumn = 0;
        
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        if (dsMainTable.Tables.Count > 0)
        {
            if (dsMainTable.Tables[0].Rows.Count > 0)
            {
                // 加入表头信息
                Cell cellTitle = new Cell(new Paragraph(strRelatedInfoName, font11B));
                
                cellTitle.BorderWidth = 0.5F;
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // 加入相关表字段名称
                
                // 加入相关表数据
                if (dsRelatedTable.Tables.Count > 0)
                {
                    string strTempValue = string.Empty;
                    foreach (DataRow drTemp in dsRelatedTable.Tables[0].Rows)
                    {
                    
                    }
                }
            }
        }
        return itbOutput;
    }

    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// 相关表排序分类处理
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        Repeater rptTemp = (Repeater)sender;

    }

}

