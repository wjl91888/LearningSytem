/****************************************************** 
FileName:T_BM_KCXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_KCXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_KCXXWebUIDetail : RICH.Common.BM.T_BM_KCXX.T_BM_KCXXWebUI
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
        appData = new T_BM_KCXXApplicationData();
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
                strMessageParam[1] = "�γ���Ϣ";
                strMessageParam[2] = drTemp["KCMC"].ToString();
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
        appData = new T_BM_KCXXApplicationData();
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
            
                    // ��ʾ�γ̱�ű���
                    TableCell tcKCBHTitle = new TableCell();
                    tcKCBHTitle.Text = "�γ̱��";
                    tcKCBHTitle.ColumnSpan = 4;
                    tcKCBHTitle.RowSpan = 1;
                    tcKCBHTitle.CssClass = "fieldname";
                    tcKCBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCBHTitle);
                    
                    // ��ʾ�γ̱��ֵ
                    TableCell tcKCBHContent = new TableCell();
                      
                    tcKCBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCBH")).InnerHtml = "";
                    tcKCBHContent.ColumnSpan = 4;
                    tcKCBHContent.RowSpan = 1;
                    tcKCBHContent.CssClass = "fieldinput";
                    tcKCBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcKCBHContent);
              
                    // ��ʾ�γ����Ʊ���
                    TableCell tcKCMCTitle = new TableCell();
                    tcKCMCTitle.Text = "�γ�����";
                    tcKCMCTitle.ColumnSpan = 4;
                    tcKCMCTitle.RowSpan = 1;
                    tcKCMCTitle.CssClass = "fieldname";
                    tcKCMCTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCMCTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCMCTitle);
                    
                    // ��ʾ�γ�����ֵ
                    TableCell tcKCMCContent = new TableCell();
                      
                    tcKCMCContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCMC")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCMC")).InnerHtml = "";
                    tcKCMCContent.ColumnSpan = 4;
                    tcKCMCContent.RowSpan = 1;
                    tcKCMCContent.CssClass = "fieldinput";
                    tcKCMCContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCMCContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCMCContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCMCContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCMCContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCMCContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcKCMCContent);
              
                    // ��ʾ�γ�ϵ�б���
                    TableCell tcKCXLBHTitle = new TableCell();
                    tcKCXLBHTitle.Text = "�γ�ϵ��";
                    tcKCXLBHTitle.ColumnSpan = 4;
                    tcKCXLBHTitle.RowSpan = 1;
                    tcKCXLBHTitle.CssClass = "fieldname";
                    tcKCXLBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCXLBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcKCXLBHTitle);
                    
                    // ��ʾ�γ�ϵ��ֵ
                    TableCell tcKCXLBHContent = new TableCell();
                      
                    tcKCXLBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCXLBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCXLBH")).InnerHtml = "";
                    tcKCXLBHContent.ColumnSpan = 12;
                    tcKCXLBHContent.RowSpan = 1;
                    tcKCXLBHContent.CssClass = "fieldinput";
                    tcKCXLBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKCXLBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCXLBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcKCXLBHContent);
              
                    // ��ʾ�γ�ͼƬ����
                    TableCell tcKCTPTitle = new TableCell();
                    tcKCTPTitle.Text = "�γ�ͼƬ";
                    tcKCTPTitle.ColumnSpan = 4;
                    tcKCTPTitle.RowSpan = 1;
                    tcKCTPTitle.CssClass = "fieldname";
                    tcKCTPTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCTPTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcKCTPTitle);
                    
                    // ��ʾ�γ�ͼƬֵ
                    TableCell tcKCTPContent = new TableCell();
                      
                    tcKCTPContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCTP")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCTP")).InnerHtml = "";
                    tcKCTPContent.ColumnSpan = 12;
                    tcKCTPContent.RowSpan = 1;
                    tcKCTPContent.CssClass = "fieldinput";
                    tcKCTPContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKCTPContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCTPContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCTPContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCTPContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCTPContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcKCTPContent);
              
                    // ��ʾ�γ̼�����
                    TableCell tcKCNRTitle = new TableCell();
                    tcKCNRTitle.Text = "�γ̼��";
                    tcKCNRTitle.ColumnSpan = 4;
                    tcKCNRTitle.RowSpan = 1;
                    tcKCNRTitle.CssClass = "fieldname";
                    tcKCNRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCNRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcKCNRTitle);
                    
                    // ��ʾ�γ̼��ֵ
                    TableCell tcKCNRContent = new TableCell();
                      
                    tcKCNRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCNR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCNR")).InnerHtml = "";
                    tcKCNRContent.ColumnSpan = 12;
                    tcKCNRContent.RowSpan = 1;
                    tcKCNRContent.CssClass = "fieldinput";
                    tcKCNRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKCNRContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCNRContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCNRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCNRContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCNRContent.Style.Add("text-align", "left");
                    tDetailView.Rows[4].Cells.Add(tcKCNRContent);
              
                    // ��ʾ����ʱ�����
                    TableCell tcKCKKSJTitle = new TableCell();
                    tcKCKKSJTitle.Text = "����ʱ��";
                    tcKCKKSJTitle.ColumnSpan = 4;
                    tcKCKKSJTitle.RowSpan = 1;
                    tcKCKKSJTitle.CssClass = "fieldname";
                    tcKCKKSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCKKSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcKCKKSJTitle);
                    
                    // ��ʾ����ʱ��ֵ
                    TableCell tcKCKKSJContent = new TableCell();
                      
                    tcKCKKSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCKKSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCKKSJ")).InnerHtml = "";
                    tcKCKKSJContent.ColumnSpan = 4;
                    tcKCKKSJContent.RowSpan = 1;
                    tcKCKKSJContent.CssClass = "fieldinput";
                    tcKCKKSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCKKSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCKKSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCKKSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCKKSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCKKSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcKCKKSJContent);
              
                    // ��ʾ��ʱ������
                    TableCell tcKSSTitle = new TableCell();
                    tcKSSTitle.Text = "��ʱ��";
                    tcKSSTitle.ColumnSpan = 4;
                    tcKSSTitle.RowSpan = 1;
                    tcKSSTitle.CssClass = "fieldname";
                    tcKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcKSSTitle);
                    
                    // ��ʾ��ʱ��ֵ
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
        Cell cellTitle = new Cell(new Paragraph("�γ���Ϣ", font19B));
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

