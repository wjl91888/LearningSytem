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
        appData = new T_BM_BMXXApplicationData();
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
                strMessageParam[1] = "������Ϣ";
                strMessageParam[2] = drTemp["HYBH"].ToString();
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
    
            intLength = 6;
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
            
                    // ��ʾ������ű���
                    TableCell tcBMBHTitle = new TableCell();
                    tcBMBHTitle.Text = "�������";
                    tcBMBHTitle.ColumnSpan = 4;
                    tcBMBHTitle.RowSpan = 1;
                    tcBMBHTitle.CssClass = "fieldname";
                    tcBMBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBMBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcBMBHTitle);
                    
                    // ��ʾ�������ֵ
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
              
                    // ��ʾ��Ա��ű���
                    TableCell tcHYBHTitle = new TableCell();
                    tcHYBHTitle.Text = "��Ա���";
                    tcHYBHTitle.ColumnSpan = 4;
                    tcHYBHTitle.RowSpan = 1;
                    tcHYBHTitle.CssClass = "fieldname";
                    tcHYBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcHYBHTitle);
                    
                    // ��ʾ��Ա���ֵ
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
              
                    // ��ʾ�۸����
                    TableCell tcKCJGTitle = new TableCell();
                    tcKCJGTitle.Text = "�۸�";
                    tcKCJGTitle.ColumnSpan = 4;
                    tcKCJGTitle.RowSpan = 1;
                    tcKCJGTitle.CssClass = "fieldname";
                    tcKCJGTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCJGTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcKCJGTitle);
                    
                    // ��ʾ�۸�ֵ
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
              
                    // ��ʾ��ʱ������
                    TableCell tcKSSTitle = new TableCell();
                    tcKSSTitle.Text = "��ʱ��";
                    tcKSSTitle.ColumnSpan = 4;
                    tcKSSTitle.RowSpan = 1;
                    tcKSSTitle.CssClass = "fieldname";
                    tcKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcKSSTitle);
                    
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
                    tDetailView.Rows[2].Cells.Add(tcKSSContent);
              
                    // ��ʾ�ۿ۱���
                    TableCell tcKCZKTitle = new TableCell();
                    tcKCZKTitle.Text = "�ۿ�";
                    tcKCZKTitle.ColumnSpan = 4;
                    tcKCZKTitle.RowSpan = 1;
                    tcKCZKTitle.CssClass = "fieldname";
                    tcKCZKTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCZKTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcKCZKTitle);
                    
                    // ��ʾ�ۿ�ֵ
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
              
                    // ��ʾʵ���տ����
                    TableCell tcSJJGTitle = new TableCell();
                    tcSJJGTitle.Text = "ʵ���տ�";
                    tcSJJGTitle.ColumnSpan = 4;
                    tcSJJGTitle.RowSpan = 1;
                    tcSJJGTitle.CssClass = "fieldname";
                    tcSJJGTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSJJGTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcSJJGTitle);
                    
                    // ��ʾʵ���տ�ֵ
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
              
                    // ��ʾ�տ��˱���
                    TableCell tcSKRTitle = new TableCell();
                    tcSKRTitle.Text = "�տ���";
                    tcSKRTitle.ColumnSpan = 4;
                    tcSKRTitle.RowSpan = 1;
                    tcSKRTitle.CssClass = "fieldname";
                    tcSKRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSKRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSKRTitle);
                    
                    // ��ʾ�տ���ֵ
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
              
                    // ��ʾ����ʱ�����
                    TableCell tcBMSJTitle = new TableCell();
                    tcBMSJTitle.Text = "����ʱ��";
                    tcBMSJTitle.ColumnSpan = 4;
                    tcBMSJTitle.RowSpan = 1;
                    tcBMSJTitle.CssClass = "fieldname";
                    tcBMSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBMSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcBMSJTitle);
                    
                    // ��ʾ����ʱ��ֵ
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
              
                    // ��ʾ��ע����
                    TableCell tcBZTitle = new TableCell();
                    tcBZTitle.Text = "��ע";
                    tcBZTitle.ColumnSpan = 4;
                    tcBZTitle.RowSpan = 1;
                    tcBZTitle.CssClass = "fieldname";
                    tcBZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcBZTitle);
                    
                    // ��ʾ��עֵ
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
              
                    // ��ʾ�Ǽ��˱���
                    TableCell tcLRRTitle = new TableCell();
                    tcLRRTitle.Text = "�Ǽ���";
                    tcLRRTitle.ColumnSpan = 4;
                    tcLRRTitle.RowSpan = 1;
                    tcLRRTitle.CssClass = "fieldname";
                    tcLRRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLRRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcLRRTitle);
                    
                    // ��ʾ�Ǽ���ֵ
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
              
                    // ��ʾ�Ǽ�ʱ�����
                    TableCell tcLRSJTitle = new TableCell();
                    tcLRSJTitle.Text = "�Ǽ�ʱ��";
                    tcLRSJTitle.ColumnSpan = 4;
                    tcLRSJTitle.RowSpan = 1;
                    tcLRSJTitle.CssClass = "fieldname";
                    tcLRSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcLRSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcLRSJTitle);
                    
                    // ��ʾ�Ǽ�ʱ��ֵ
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
        Cell cellTitle = new Cell(new Paragraph("������Ϣ", font19B));
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

