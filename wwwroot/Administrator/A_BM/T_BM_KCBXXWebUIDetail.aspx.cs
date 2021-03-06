/****************************************************** 
FileName:T_BM_KCBXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_KCBXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_KCBXXWebUIDetail : RICH.Common.BM.T_BM_KCBXX.T_BM_KCBXXWebUI
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
        appData = new T_BM_KCBXXApplicationData();
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
                strMessageParam[1] = "课程表";
                strMessageParam[2] = drTemp["KCBH"].ToString();
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
        appData = new T_BM_KCBXXApplicationData();
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
    
            intLength = 4;
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
            
                    // 显示编号标题
                    TableCell tcKCBBHTitle = new TableCell();
                    tcKCBBHTitle.Text = "编号";
                    tcKCBBHTitle.ColumnSpan = 4;
                    tcKCBBHTitle.RowSpan = 1;
                    tcKCBBHTitle.CssClass = "fieldname";
                    tcKCBBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCBBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCBBHTitle);
                    
                    // 显示编号值
                    TableCell tcKCBBHContent = new TableCell();
                      
                    tcKCBBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCBBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCBBH")).InnerHtml = "";
                    tcKCBBHContent.ColumnSpan = 4;
                    tcKCBBHContent.RowSpan = 1;
                    tcKCBBHContent.CssClass = "fieldinput";
                    tcKCBBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCBBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCBBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCBBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCBBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCBBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcKCBBHContent);
              
                    // 显示课程系列标题
                    TableCell tcKCXLBHTitle = new TableCell();
                    tcKCXLBHTitle.Text = "课程系列";
                    tcKCXLBHTitle.ColumnSpan = 4;
                    tcKCXLBHTitle.RowSpan = 1;
                    tcKCXLBHTitle.CssClass = "fieldname";
                    tcKCXLBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCXLBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCXLBHTitle);
                    
                    // 显示课程系列值
                    TableCell tcKCXLBHContent = new TableCell();
                      
                    tcKCXLBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCXLBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCXLBH")).InnerHtml = "";
                    tcKCXLBHContent.ColumnSpan = 4;
                    tcKCXLBHContent.RowSpan = 1;
                    tcKCXLBHContent.CssClass = "fieldinput";
                    tcKCXLBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCXLBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcKCXLBHContent);
              
                    // 显示课程标题
                    TableCell tcKCBHTitle = new TableCell();
                    tcKCBHTitle.Text = "课程";
                    tcKCBHTitle.ColumnSpan = 4;
                    tcKCBHTitle.RowSpan = 1;
                    tcKCBHTitle.CssClass = "fieldname";
                    tcKCBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcKCBHTitle);
                    
                    // 显示课程值
                    TableCell tcKCBHContent = new TableCell();
                      
                    tcKCBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCBH")).InnerHtml = "";
                    tcKCBHContent.ColumnSpan = 12;
                    tcKCBHContent.RowSpan = 1;
                    tcKCBHContent.CssClass = "fieldinput";
                    tcKCBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKCBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcKCBHContent);
              
                    // 显示上课时间标题
                    TableCell tcKCSJTitle = new TableCell();
                    tcKCSJTitle.Text = "上课时间";
                    tcKCSJTitle.ColumnSpan = 4;
                    tcKCSJTitle.RowSpan = 1;
                    tcKCSJTitle.CssClass = "fieldname";
                    tcKCSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcKCSJTitle);
                    
                    // 显示上课时间值
                    TableCell tcKCSJContent = new TableCell();
                      
                    tcKCSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCSJ")).InnerHtml = "";
                    tcKCSJContent.ColumnSpan = 4;
                    tcKCSJContent.RowSpan = 1;
                    tcKCSJContent.CssClass = "fieldinput";
                    tcKCSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcKCSJContent);
              
                    // 显示课时数标题
                    TableCell tcKSSTitle = new TableCell();
                    tcKSSTitle.Text = "课时数";
                    tcKSSTitle.ColumnSpan = 4;
                    tcKSSTitle.RowSpan = 1;
                    tcKSSTitle.CssClass = "fieldname";
                    tcKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcKSSTitle);
                    
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
                    tDetailView.Rows[3].Cells.Add(tcKSSContent);
              
                    // 显示教师标题
                    TableCell tcSKJSTitle = new TableCell();
                    tcSKJSTitle.Text = "教师";
                    tcSKJSTitle.ColumnSpan = 4;
                    tcSKJSTitle.RowSpan = 1;
                    tcSKJSTitle.CssClass = "fieldname";
                    tcSKJSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSKJSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSKJSTitle);
                    
                    // 显示教师值
                    TableCell tcSKJSContent = new TableCell();
                      
                    tcSKJSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SKJS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SKJS")).InnerHtml = "";
                    tcSKJSContent.ColumnSpan = 4;
                    tcSKJSContent.RowSpan = 1;
                    tcSKJSContent.CssClass = "fieldinput";
                    tcSKJSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSKJSContent.Style.Add("border-top", "1px black solid");
                        
                    tcSKJSContent.Style.Add("border-left", "1px black solid");
                        
                    tcSKJSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSKJSContent.Style.Add("border-right", "1px black solid");
                        
                    tcSKJSContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSKJSContent);
              
                    // 显示教室标题
                    TableCell tcSKFJTitle = new TableCell();
                    tcSKFJTitle.Text = "教室";
                    tcSKFJTitle.ColumnSpan = 4;
                    tcSKFJTitle.RowSpan = 1;
                    tcSKFJTitle.CssClass = "fieldname";
                    tcSKFJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSKFJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSKFJTitle);
                    
                    // 显示教室值
                    TableCell tcSKFJContent = new TableCell();
                      
                    tcSKFJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SKFJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SKFJ")).InnerHtml = "";
                    tcSKFJContent.ColumnSpan = 4;
                    tcSKFJContent.RowSpan = 1;
                    tcSKFJContent.CssClass = "fieldinput";
                    tcSKFJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSKFJContent.Style.Add("border-top", "1px black solid");
                        
                    tcSKFJContent.Style.Add("border-left", "1px black solid");
                        
                    tcSKFJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSKFJContent.Style.Add("border-right", "1px black solid");
                        
                    tcSKFJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSKFJContent);
              
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
        Cell cellTitle = new Cell(new Paragraph("课程表", font19B));
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

