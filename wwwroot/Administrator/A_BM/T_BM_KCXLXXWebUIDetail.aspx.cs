/****************************************************** 
FileName:T_BM_KCXLXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_KCXLXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_KCXLXXWebUIDetail : RICH.Common.BM.T_BM_KCXLXX.T_BM_KCXLXXWebUI
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
    /// ���س�ʼ������
    /// </summary>
    //=====================================================================
   protected override void Initalize()
    {
        // �����ʼ��
        // ��ʼ����ӡҳ���С
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A4", "A4"));
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A3", "A3"));
        // ��ʼ����ӡҳ�淽���С
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("����", "portrait"));
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("����", "landscape"));

        // ��ȡ��¼��ϸ����
        appData = new T_BM_KCXLXXApplicationData();
        appData.ObjectID = ObjectID;
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        QueryRecord();
        Header.DataBind();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        // ��ť��ʼ��

        if (IsPostBack != true)
        {
            foreach (DataRow drTemp in appData.ResultSet.Tables[0].Rows)
            {
                //��¼��־��ʼ
                string strLogTypeID = "A10";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "�γ�ϵ����Ϣ";
                strMessageParam[2] = drTemp["KCXLMC"].ToString();
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                //��¼��־����
            }
        }
    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// ����ExportToFile
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new T_BM_KCXLXXApplicationData();
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
            // �����������������
            System.Web.UI.WebControls.Table tDetailView = new System.Web.UI.WebControls.Table();
            tDetailView.CssClass = "detailtable";
            tDetailView.CellPadding = 0;
            tDetailView.CellSpacing = 0;
            tDetailView.BorderColor = System.Drawing.Color.Black;
            tDetailView.BorderWidth = 0;
            tDetailView.Width = 615;
            // �������
            int intColumn = 0;
            
            intColumn += 4 + 4;
            intColumn += 4 + 4;
            // �������
            int intLength = 0;
    
            intLength = 5;
            intLength++;
            // ������
            for (int i = 0; i < intLength; i++)
            {
                TableRow trTemp = new TableRow();
                tDetailView.Rows.Add(trTemp);
            }
            // �õ�ֵ����ؼ�
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                hcTemp = tcTemp.FindControl("divvaluearea");
                if (hcTemp != null)
                {
                    // ���ɱ��
                    // ����������
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
            
                    // ��ʾ�γ�ϵ�б�ű���
                    TableCell tcKCXLBHTitle = new TableCell();
                    tcKCXLBHTitle.Text = "�γ�ϵ�б��";
                    tcKCXLBHTitle.ColumnSpan = 4;
                    tcKCXLBHTitle.RowSpan = 1;
                    tcKCXLBHTitle.CssClass = "fieldname";
                    tcKCXLBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCXLBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCXLBHTitle);
                    
                    // ��ʾ�γ�ϵ�б��ֵ
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
              
                    // ��ʾ�γ�ϵ�����Ʊ���
                    TableCell tcKCXLMCTitle = new TableCell();
                    tcKCXLMCTitle.Text = "�γ�ϵ������";
                    tcKCXLMCTitle.ColumnSpan = 4;
                    tcKCXLMCTitle.RowSpan = 1;
                    tcKCXLMCTitle.CssClass = "fieldname";
                    tcKCXLMCTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCXLMCTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCXLMCTitle);
                    
                    // ��ʾ�γ�ϵ������ֵ
                    TableCell tcKCXLMCContent = new TableCell();
                      
                    tcKCXLMCContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCXLMC")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCXLMC")).InnerHtml = "";
                    tcKCXLMCContent.ColumnSpan = 4;
                    tcKCXLMCContent.RowSpan = 1;
                    tcKCXLMCContent.CssClass = "fieldinput";
                    tcKCXLMCContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCXLMCContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCXLMCContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCXLMCContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCXLMCContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCXLMCContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcKCXLMCContent);
              
                    // ��ʾ����������
                    TableCell tcKCXLSJBHTitle = new TableCell();
                    tcKCXLSJBHTitle.Text = "�������";
                    tcKCXLSJBHTitle.ColumnSpan = 4;
                    tcKCXLSJBHTitle.RowSpan = 1;
                    tcKCXLSJBHTitle.CssClass = "fieldname";
                    tcKCXLSJBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCXLSJBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcKCXLSJBHTitle);
                    
                    // ��ʾ�������ֵ
                    TableCell tcKCXLSJBHContent = new TableCell();
                      
                    tcKCXLSJBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCXLSJBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCXLSJBH")).InnerHtml = "";
                    tcKCXLSJBHContent.ColumnSpan = 12;
                    tcKCXLSJBHContent.RowSpan = 1;
                    tcKCXLSJBHContent.CssClass = "fieldinput";
                    tcKCXLSJBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKCXLSJBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCXLSJBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCXLSJBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCXLSJBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCXLSJBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcKCXLSJBHContent);
              
                    // ��ʾϵ��ͼƬ����
                    TableCell tcKCXLTPTitle = new TableCell();
                    tcKCXLTPTitle.Text = "ϵ��ͼƬ";
                    tcKCXLTPTitle.ColumnSpan = 4;
                    tcKCXLTPTitle.RowSpan = 1;
                    tcKCXLTPTitle.CssClass = "fieldname";
                    tcKCXLTPTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCXLTPTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcKCXLTPTitle);
                    
                    // ��ʾϵ��ͼƬֵ
                    TableCell tcKCXLTPContent = new TableCell();
                      
                    tcKCXLTPContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCXLTP")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCXLTP")).InnerHtml = "";
                    tcKCXLTPContent.ColumnSpan = 12;
                    tcKCXLTPContent.RowSpan = 1;
                    tcKCXLTPContent.CssClass = "fieldinput";
                    tcKCXLTPContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKCXLTPContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCXLTPContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCXLTPContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCXLTPContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCXLTPContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcKCXLTPContent);
              
                    // ��ʾ�γ�ϵ�м�����
                    TableCell tcKCXLJJTitle = new TableCell();
                    tcKCXLJJTitle.Text = "�γ�ϵ�м��";
                    tcKCXLJJTitle.ColumnSpan = 4;
                    tcKCXLJJTitle.RowSpan = 1;
                    tcKCXLJJTitle.CssClass = "fieldname";
                    tcKCXLJJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCXLJJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcKCXLJJTitle);
                    
                    // ��ʾ�γ�ϵ�м��ֵ
                    TableCell tcKCXLJJContent = new TableCell();
                      
                    tcKCXLJJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCXLJJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCXLJJ")).InnerHtml = "";
                    tcKCXLJJContent.ColumnSpan = 12;
                    tcKCXLJJContent.RowSpan = 1;
                    tcKCXLJJContent.CssClass = "fieldinput";
                    tcKCXLJJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKCXLJJContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCXLJJContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCXLJJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCXLJJContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCXLJJContent.Style.Add("text-align", "left");
                    tDetailView.Rows[4].Cells.Add(tcKCXLJJContent);
              
                    // ��ʾ����α���
                    TableCell tcNLDTitle = new TableCell();
                    tcNLDTitle.Text = "�����";
                    tcNLDTitle.ColumnSpan = 4;
                    tcNLDTitle.RowSpan = 1;
                    tcNLDTitle.CssClass = "fieldname";
                    tcNLDTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcNLDTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcNLDTitle);
                    
                    // ��ʾ�����ֵ
                    TableCell tcNLDContent = new TableCell();
                      
                    tcNLDContent.Text = ((HtmlContainerControl)hcTemp.FindControl("NLD")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("NLD")).InnerHtml = "";
                    tcNLDContent.ColumnSpan = 4;
                    tcNLDContent.RowSpan = 1;
                    tcNLDContent.CssClass = "fieldinput";
                    tcNLDContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcNLDContent.Style.Add("border-top", "1px black solid");
                        
                    tcNLDContent.Style.Add("border-left", "1px black solid");
                        
                    tcNLDContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcNLDContent.Style.Add("border-right", "1px black solid");
                        
                    tcNLDContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcNLDContent);
              
                    // ��ʾ��ʱ��������
                    TableCell tcKSSTitle = new TableCell();
                    tcKSSTitle.Text = "��ʱ����";
                    tcKSSTitle.ColumnSpan = 4;
                    tcKSSTitle.RowSpan = 1;
                    tcKSSTitle.CssClass = "fieldname";
                    tcKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcKSSTitle);
                    
                    // ��ʾ��ʱ����ֵ
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
                    tDetailView.Rows[5].Cells.Add(tcKSSContent);
              
                    // ����һ��һ��ر���
            
                    break;
                }
            }
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                // ����������Ϣ
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
        // �����հ�PDF�ĵ�
        Document pdfDoc = new Document(rect, marginLeft, marginRight, marginTop, marginBottom);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        // �������һ��һ��ر���Ϣ
        pdfDoc.Add(GenerateMainTable(dsMainTable));
        // ���һ�Զ���ر���Ϣ
    
        pdfDoc.Close();
        return pdfDoc;
    }
    private iTextSharp.text.Table GenerateMainTable(DataSet dsMainTable)
    {
        // ���ɱ��
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
        
        // �����ͷ��Ϣ
        Cell cellTitle = new Cell(new Paragraph("�γ�ϵ����Ϣ", font19B));
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
        // ����ָ���
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
                // ����������
            
                // ����һ��һ��ر���
            
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            
            }
        }
        return itbOutput;
    }    

    private iTextSharp.text.Table GenerateRelatedTable(DataSet dsMainTable, string strRelatedTableName, string strRelatedInfoName)
    {
        DataSet dsRelatedTable = new DataSet();
        // ���ɱ��
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
                // �����ͷ��Ϣ
                Cell cellTitle = new Cell(new Paragraph(strRelatedInfoName, font11B));
                
                cellTitle.BorderWidth = 0.5F;
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // ������ر��ֶ�����
                
                // ������ر�����
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
    /// ��ر�������ദ��
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        Repeater rptTemp = (Repeater)sender;

    }

}

