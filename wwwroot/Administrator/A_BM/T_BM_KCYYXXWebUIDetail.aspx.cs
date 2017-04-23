/****************************************************** 
FileName:T_BM_KCYYXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_KCYYXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_KCYYXXWebUIDetail : RICH.Common.BM.T_BM_KCYYXX.T_BM_KCYYXXWebUI
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
        appData = new T_BM_KCYYXXApplicationData();
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
                strMessageParam[1] = "�γ�ԤԼ��Ϣ";
                strMessageParam[2] = drTemp["KCBBH"].ToString();
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
        appData = new T_BM_KCYYXXApplicationData();
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
    
            intLength = 7;
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
            
                    // ��ʾ�γ�ԤԼ��ű���
                    TableCell tcKCYYBHTitle = new TableCell();
                    tcKCYYBHTitle.Text = "�γ�ԤԼ���";
                    tcKCYYBHTitle.ColumnSpan = 4;
                    tcKCYYBHTitle.RowSpan = 1;
                    tcKCYYBHTitle.CssClass = "fieldname";
                    tcKCYYBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCYYBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCYYBHTitle);
                    
                    // ��ʾ�γ�ԤԼ���ֵ
                    TableCell tcKCYYBHContent = new TableCell();
                      
                    tcKCYYBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KCYYBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KCYYBH")).InnerHtml = "";
                    tcKCYYBHContent.ColumnSpan = 4;
                    tcKCYYBHContent.RowSpan = 1;
                    tcKCYYBHContent.CssClass = "fieldinput";
                    tcKCYYBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKCYYBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcKCYYBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcKCYYBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKCYYBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcKCYYBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcKCYYBHContent);
              
                    // ��ʾ�γ̱��ű���
                    TableCell tcKCBBHTitle = new TableCell();
                    tcKCBBHTitle.Text = "�γ̱���";
                    tcKCBBHTitle.ColumnSpan = 4;
                    tcKCBBHTitle.RowSpan = 1;
                    tcKCBBHTitle.CssClass = "fieldname";
                    tcKCBBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKCBBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcKCBBHTitle);
                    
                    // ��ʾ�γ̱���ֵ
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
              
                    // ��ʾ��Ա��ű���
                    TableCell tcHYBHTitle = new TableCell();
                    tcHYBHTitle.Text = "��Ա���";
                    tcHYBHTitle.ColumnSpan = 4;
                    tcHYBHTitle.RowSpan = 1;
                    tcHYBHTitle.CssClass = "fieldname";
                    tcHYBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcHYBHTitle);
                    
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
                    tDetailView.Rows[2].Cells.Add(tcHYBHContent);
              
                    // ��ʾԤԼʱ�����
                    TableCell tcYYSJTitle = new TableCell();
                    tcYYSJTitle.Text = "ԤԼʱ��";
                    tcYYSJTitle.ColumnSpan = 4;
                    tcYYSJTitle.RowSpan = 1;
                    tcYYSJTitle.CssClass = "fieldname";
                    tcYYSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYYSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcYYSJTitle);
                    
                    // ��ʾԤԼʱ��ֵ
                    TableCell tcYYSJContent = new TableCell();
                      
                    tcYYSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YYSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YYSJ")).InnerHtml = "";
                    tcYYSJContent.ColumnSpan = 4;
                    tcYYSJContent.RowSpan = 1;
                    tcYYSJContent.CssClass = "fieldinput";
                    tcYYSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYYSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcYYSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcYYSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYYSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcYYSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcYYSJContent);
              
                    // ��ʾԤԼ��ע����
                    TableCell tcYYBZTitle = new TableCell();
                    tcYYBZTitle.Text = "ԤԼ��ע";
                    tcYYBZTitle.ColumnSpan = 4;
                    tcYYBZTitle.RowSpan = 1;
                    tcYYBZTitle.CssClass = "fieldname";
                    tcYYBZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYYBZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcYYBZTitle);
                    
                    // ��ʾԤԼ��עֵ
                    TableCell tcYYBZContent = new TableCell();
                      
                    tcYYBZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YYBZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YYBZ")).InnerHtml = "";
                    tcYYBZContent.ColumnSpan = 12;
                    tcYYBZContent.RowSpan = 1;
                    tcYYBZContent.CssClass = "fieldinput";
                    tcYYBZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcYYBZContent.Style.Add("border-top", "1px black solid");
                        
                    tcYYBZContent.Style.Add("border-left", "1px black solid");
                        
                    tcYYBZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYYBZContent.Style.Add("border-right", "1px black solid");
                        
                    tcYYBZContent.Style.Add("text-align", "left");
                    tDetailView.Rows[3].Cells.Add(tcYYBZContent);
              
                    // ��ʾ�Ͽ�״̬����
                    TableCell tcSKZTTitle = new TableCell();
                    tcSKZTTitle.Text = "�Ͽ�״̬";
                    tcSKZTTitle.ColumnSpan = 4;
                    tcSKZTTitle.RowSpan = 1;
                    tcSKZTTitle.CssClass = "fieldname";
                    tcSKZTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSKZTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSKZTTitle);
                    
                    // ��ʾ�Ͽ�״ֵ̬
                    TableCell tcSKZTContent = new TableCell();
                      
                    tcSKZTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SKZT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SKZT")).InnerHtml = "";
                    tcSKZTContent.ColumnSpan = 4;
                    tcSKZTContent.RowSpan = 1;
                    tcSKZTContent.CssClass = "fieldinput";
                    tcSKZTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSKZTContent.Style.Add("border-top", "1px black solid");
                        
                    tcSKZTContent.Style.Add("border-left", "1px black solid");
                        
                    tcSKZTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSKZTContent.Style.Add("border-right", "1px black solid");
                        
                    tcSKZTContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSKZTContent);
              
                    // ��ʾ���Ŀ�ʱ����
                    TableCell tcXHKSTitle = new TableCell();
                    tcXHKSTitle.Text = "���Ŀ�ʱ";
                    tcXHKSTitle.ColumnSpan = 4;
                    tcXHKSTitle.RowSpan = 1;
                    tcXHKSTitle.CssClass = "fieldname";
                    tcXHKSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXHKSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcXHKSTitle);
                    
                    // ��ʾ���Ŀ�ʱֵ
                    TableCell tcXHKSContent = new TableCell();
                      
                    tcXHKSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XHKS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XHKS")).InnerHtml = "";
                    tcXHKSContent.ColumnSpan = 4;
                    tcXHKSContent.RowSpan = 1;
                    tcXHKSContent.CssClass = "fieldinput";
                    tcXHKSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcXHKSContent.Style.Add("border-top", "1px black solid");
                        
                    tcXHKSContent.Style.Add("border-left", "1px black solid");
                        
                    tcXHKSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXHKSContent.Style.Add("border-right", "1px black solid");
                        
                    tcXHKSContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcXHKSContent);
              
                    // ��ʾ������Ƭ����
                    TableCell tcKTZPTitle = new TableCell();
                    tcKTZPTitle.Text = "������Ƭ";
                    tcKTZPTitle.ColumnSpan = 4;
                    tcKTZPTitle.RowSpan = 1;
                    tcKTZPTitle.CssClass = "fieldname";
                    tcKTZPTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKTZPTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcKTZPTitle);
                    
                    // ��ʾ������Ƭֵ
                    TableCell tcKTZPContent = new TableCell();
                      
                    tcKTZPContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KTZP")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KTZP")).InnerHtml = "";
                    tcKTZPContent.ColumnSpan = 12;
                    tcKTZPContent.RowSpan = 1;
                    tcKTZPContent.CssClass = "fieldinput";
                    tcKTZPContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcKTZPContent.Style.Add("border-top", "1px black solid");
                        
                    tcKTZPContent.Style.Add("border-left", "1px black solid");
                        
                    tcKTZPContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKTZPContent.Style.Add("border-right", "1px black solid");
                        
                    tcKTZPContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcKTZPContent);
              
                    // ��ʾ��ʦ���۱���
                    TableCell tcJSPJTitle = new TableCell();
                    tcJSPJTitle.Text = "��ʦ����";
                    tcJSPJTitle.ColumnSpan = 4;
                    tcJSPJTitle.RowSpan = 1;
                    tcJSPJTitle.CssClass = "fieldname";
                    tcJSPJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJSPJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcJSPJTitle);
                    
                    // ��ʾ��ʦ����ֵ
                    TableCell tcJSPJContent = new TableCell();
                      
                    tcJSPJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JSPJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JSPJ")).InnerHtml = "";
                    tcJSPJContent.ColumnSpan = 12;
                    tcJSPJContent.RowSpan = 1;
                    tcJSPJContent.CssClass = "fieldinput";
                    tcJSPJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcJSPJContent.Style.Add("border-top", "1px black solid");
                        
                    tcJSPJContent.Style.Add("border-left", "1px black solid");
                        
                    tcJSPJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJSPJContent.Style.Add("border-right", "1px black solid");
                        
                    tcJSPJContent.Style.Add("text-align", "left");
                    tDetailView.Rows[6].Cells.Add(tcJSPJContent);
              
                    // ��ʾ�����˱���
                    TableCell tcPJRTitle = new TableCell();
                    tcPJRTitle.Text = "������";
                    tcPJRTitle.ColumnSpan = 4;
                    tcPJRTitle.RowSpan = 1;
                    tcPJRTitle.CssClass = "fieldname";
                    tcPJRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcPJRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcPJRTitle);
                    
                    // ��ʾ������ֵ
                    TableCell tcPJRContent = new TableCell();
                      
                    tcPJRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("PJR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("PJR")).InnerHtml = "";
                    tcPJRContent.ColumnSpan = 4;
                    tcPJRContent.RowSpan = 1;
                    tcPJRContent.CssClass = "fieldinput";
                    tcPJRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcPJRContent.Style.Add("border-top", "1px black solid");
                        
                    tcPJRContent.Style.Add("border-left", "1px black solid");
                        
                    tcPJRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcPJRContent.Style.Add("border-right", "1px black solid");
                        
                    tcPJRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[7].Cells.Add(tcPJRContent);
              
                    // ��ʾ����ʱ�����
                    TableCell tcPJSJTitle = new TableCell();
                    tcPJSJTitle.Text = "����ʱ��";
                    tcPJSJTitle.ColumnSpan = 4;
                    tcPJSJTitle.RowSpan = 1;
                    tcPJSJTitle.CssClass = "fieldname";
                    tcPJSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcPJSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcPJSJTitle);
                    
                    // ��ʾ����ʱ��ֵ
                    TableCell tcPJSJContent = new TableCell();
                      
                    tcPJSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("PJSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("PJSJ")).InnerHtml = "";
                    tcPJSJContent.ColumnSpan = 4;
                    tcPJSJContent.RowSpan = 1;
                    tcPJSJContent.CssClass = "fieldinput";
                    tcPJSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcPJSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcPJSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcPJSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcPJSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcPJSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[7].Cells.Add(tcPJSJContent);
              
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
        Cell cellTitle = new Cell(new Paragraph("�γ�ԤԼ��Ϣ", font19B));
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

