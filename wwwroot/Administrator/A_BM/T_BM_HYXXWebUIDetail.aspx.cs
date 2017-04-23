/****************************************************** 
FileName:T_BM_HYXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_HYXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_HYXXWebUIDetail : RICH.Common.BM.T_BM_HYXX.T_BM_HYXXWebUI
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
        appData = new T_BM_HYXXApplicationData();
        appData.ObjectID = ObjectID;
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        QueryRecord();
        Header.DataBind();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        // ��ť��ʼ��

        btn.Attributes.Add("onclick", "window.location='T_BM_BMXXWebUIAdd.aspx?a=a{0}HYBH={1}{0}p=';".FormatInvariantCulture(AndChar, appData.ResultSet.Tables[0].Rows[0]["HYBH"]));

        if (IsPostBack != true)
        {
            foreach (DataRow drTemp in appData.ResultSet.Tables[0].Rows)
            {
                //��¼��־��ʼ
                string strLogTypeID = "A10";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "��Ա��Ϣ";
                strMessageParam[2] = drTemp["HYXM"].ToString();
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
        appData = new T_BM_HYXXApplicationData();
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
              
                    // ��ʾ��������
                    TableCell tcHYXMTitle = new TableCell();
                    tcHYXMTitle.Text = "����";
                    tcHYXMTitle.ColumnSpan = 4;
                    tcHYXMTitle.RowSpan = 1;
                    tcHYXMTitle.CssClass = "fieldname";
                    tcHYXMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYXMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcHYXMTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcHYXMContent = new TableCell();
                      
                    tcHYXMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HYXM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HYXM")).InnerHtml = "";
                    tcHYXMContent.ColumnSpan = 4;
                    tcHYXMContent.RowSpan = 1;
                    tcHYXMContent.CssClass = "fieldinput";
                    tcHYXMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHYXMContent.Style.Add("border-top", "1px black solid");
                        
                    tcHYXMContent.Style.Add("border-left", "1px black solid");
                        
                    tcHYXMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHYXMContent.Style.Add("border-right", "1px black solid");
                        
                    tcHYXMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcHYXMContent);
              
                    // ��ʾ�ǳƱ���
                    TableCell tcHYNCTitle = new TableCell();
                    tcHYNCTitle.Text = "�ǳ�";
                    tcHYNCTitle.ColumnSpan = 4;
                    tcHYNCTitle.RowSpan = 1;
                    tcHYNCTitle.CssClass = "fieldname";
                    tcHYNCTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYNCTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcHYNCTitle);
                    
                    // ��ʾ�ǳ�ֵ
                    TableCell tcHYNCContent = new TableCell();
                      
                    tcHYNCContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HYNC")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HYNC")).InnerHtml = "";
                    tcHYNCContent.ColumnSpan = 4;
                    tcHYNCContent.RowSpan = 1;
                    tcHYNCContent.CssClass = "fieldinput";
                    tcHYNCContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHYNCContent.Style.Add("border-top", "1px black solid");
                        
                    tcHYNCContent.Style.Add("border-left", "1px black solid");
                        
                    tcHYNCContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHYNCContent.Style.Add("border-right", "1px black solid");
                        
                    tcHYNCContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcHYNCContent);
              
                    // ��ʾ���ձ���
                    TableCell tcHYSRTitle = new TableCell();
                    tcHYSRTitle.Text = "����";
                    tcHYSRTitle.ColumnSpan = 4;
                    tcHYSRTitle.RowSpan = 1;
                    tcHYSRTitle.CssClass = "fieldname";
                    tcHYSRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYSRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcHYSRTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcHYSRContent = new TableCell();
                      
                    tcHYSRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HYSR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HYSR")).InnerHtml = "";
                    tcHYSRContent.ColumnSpan = 4;
                    tcHYSRContent.RowSpan = 1;
                    tcHYSRContent.CssClass = "fieldinput";
                    tcHYSRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHYSRContent.Style.Add("border-top", "1px black solid");
                        
                    tcHYSRContent.Style.Add("border-left", "1px black solid");
                        
                    tcHYSRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHYSRContent.Style.Add("border-right", "1px black solid");
                        
                    tcHYSRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcHYSRContent);
              
                    // ��ʾѧУ����
                    TableCell tcHYXXTitle = new TableCell();
                    tcHYXXTitle.Text = "ѧУ";
                    tcHYXXTitle.ColumnSpan = 4;
                    tcHYXXTitle.RowSpan = 1;
                    tcHYXXTitle.CssClass = "fieldname";
                    tcHYXXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYXXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcHYXXTitle);
                    
                    // ��ʾѧУֵ
                    TableCell tcHYXXContent = new TableCell();
                      
                    tcHYXXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HYXX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HYXX")).InnerHtml = "";
                    tcHYXXContent.ColumnSpan = 4;
                    tcHYXXContent.RowSpan = 1;
                    tcHYXXContent.CssClass = "fieldinput";
                    tcHYXXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHYXXContent.Style.Add("border-top", "1px black solid");
                        
                    tcHYXXContent.Style.Add("border-left", "1px black solid");
                        
                    tcHYXXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHYXXContent.Style.Add("border-right", "1px black solid");
                        
                    tcHYXXContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcHYXXContent);
              
                    // ��ʾ�༶����
                    TableCell tcHYBJTitle = new TableCell();
                    tcHYBJTitle.Text = "�༶";
                    tcHYBJTitle.ColumnSpan = 4;
                    tcHYBJTitle.RowSpan = 1;
                    tcHYBJTitle.CssClass = "fieldname";
                    tcHYBJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHYBJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcHYBJTitle);
                    
                    // ��ʾ�༶ֵ
                    TableCell tcHYBJContent = new TableCell();
                      
                    tcHYBJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HYBJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HYBJ")).InnerHtml = "";
                    tcHYBJContent.ColumnSpan = 4;
                    tcHYBJContent.RowSpan = 1;
                    tcHYBJContent.CssClass = "fieldinput";
                    tcHYBJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHYBJContent.Style.Add("border-top", "1px black solid");
                        
                    tcHYBJContent.Style.Add("border-left", "1px black solid");
                        
                    tcHYBJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHYBJContent.Style.Add("border-right", "1px black solid");
                        
                    tcHYBJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcHYBJContent);
              
                    // ��ʾ�ҳ���������
                    TableCell tcJZXMTitle = new TableCell();
                    tcJZXMTitle.Text = "�ҳ�����";
                    tcJZXMTitle.ColumnSpan = 4;
                    tcJZXMTitle.RowSpan = 1;
                    tcJZXMTitle.CssClass = "fieldname";
                    tcJZXMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJZXMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJZXMTitle);
                    
                    // ��ʾ�ҳ�����ֵ
                    TableCell tcJZXMContent = new TableCell();
                      
                    tcJZXMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JZXM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JZXM")).InnerHtml = "";
                    tcJZXMContent.ColumnSpan = 4;
                    tcJZXMContent.RowSpan = 1;
                    tcJZXMContent.CssClass = "fieldinput";
                    tcJZXMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJZXMContent.Style.Add("border-top", "1px black solid");
                        
                    tcJZXMContent.Style.Add("border-left", "1px black solid");
                        
                    tcJZXMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJZXMContent.Style.Add("border-right", "1px black solid");
                        
                    tcJZXMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcJZXMContent);
              
                    // ��ʾ�ҳ��绰����
                    TableCell tcJZDHTitle = new TableCell();
                    tcJZDHTitle.Text = "�ҳ��绰";
                    tcJZDHTitle.ColumnSpan = 4;
                    tcJZDHTitle.RowSpan = 1;
                    tcJZDHTitle.CssClass = "fieldname";
                    tcJZDHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJZDHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJZDHTitle);
                    
                    // ��ʾ�ҳ��绰ֵ
                    TableCell tcJZDHContent = new TableCell();
                      
                    tcJZDHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JZDH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JZDH")).InnerHtml = "";
                    tcJZDHContent.ColumnSpan = 4;
                    tcJZDHContent.RowSpan = 1;
                    tcJZDHContent.CssClass = "fieldinput";
                    tcJZDHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJZDHContent.Style.Add("border-top", "1px black solid");
                        
                    tcJZDHContent.Style.Add("border-left", "1px black solid");
                        
                    tcJZDHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJZDHContent.Style.Add("border-right", "1px black solid");
                        
                    tcJZDHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcJZDHContent);
              
                    // ��ʾע��ʱ�����
                    TableCell tcZCSJTitle = new TableCell();
                    tcZCSJTitle.Text = "ע��ʱ��";
                    tcZCSJTitle.ColumnSpan = 4;
                    tcZCSJTitle.RowSpan = 1;
                    tcZCSJTitle.CssClass = "fieldname";
                    tcZCSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcZCSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcZCSJTitle);
                    
                    // ��ʾע��ʱ��ֵ
                    TableCell tcZCSJContent = new TableCell();
                      
                    tcZCSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("ZCSJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("ZCSJ")).InnerHtml = "";
                    tcZCSJContent.ColumnSpan = 4;
                    tcZCSJContent.RowSpan = 1;
                    tcZCSJContent.CssClass = "fieldinput";
                    tcZCSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcZCSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcZCSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcZCSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcZCSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcZCSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcZCSJContent);
              
                    // ��ʾ��ʱ��������
                    TableCell tcZKSSTitle = new TableCell();
                    tcZKSSTitle.Text = "��ʱ����";
                    tcZKSSTitle.ColumnSpan = 4;
                    tcZKSSTitle.RowSpan = 1;
                    tcZKSSTitle.CssClass = "fieldname";
                    tcZKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcZKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcZKSSTitle);
                    
                    // ��ʾ��ʱ����ֵ
                    TableCell tcZKSSContent = new TableCell();
                      
                    tcZKSSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("ZKSS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("ZKSS")).InnerHtml = "";
                    tcZKSSContent.ColumnSpan = 4;
                    tcZKSSContent.RowSpan = 1;
                    tcZKSSContent.CssClass = "fieldinput";
                    tcZKSSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcZKSSContent.Style.Add("border-top", "1px black solid");
                        
                    tcZKSSContent.Style.Add("border-left", "1px black solid");
                        
                    tcZKSSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcZKSSContent.Style.Add("border-right", "1px black solid");
                        
                    tcZKSSContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcZKSSContent);
              
                    // ��ʾ���Ŀ�ʱ����
                    TableCell tcXHKSSTitle = new TableCell();
                    tcXHKSSTitle.Text = "���Ŀ�ʱ";
                    tcXHKSSTitle.ColumnSpan = 4;
                    tcXHKSSTitle.RowSpan = 1;
                    tcXHKSSTitle.CssClass = "fieldname";
                    tcXHKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXHKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcXHKSSTitle);
                    
                    // ��ʾ���Ŀ�ʱֵ
                    TableCell tcXHKSSContent = new TableCell();
                      
                    tcXHKSSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XHKSS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XHKSS")).InnerHtml = "";
                    tcXHKSSContent.ColumnSpan = 4;
                    tcXHKSSContent.RowSpan = 1;
                    tcXHKSSContent.CssClass = "fieldinput";
                    tcXHKSSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcXHKSSContent.Style.Add("border-top", "1px black solid");
                        
                    tcXHKSSContent.Style.Add("border-left", "1px black solid");
                        
                    tcXHKSSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXHKSSContent.Style.Add("border-right", "1px black solid");
                        
                    tcXHKSSContent.Style.Add("text-align", "center");
                    tDetailView.Rows[6].Cells.Add(tcXHKSSContent);
              
                    // ��ʾʣ���ʱ����
                    TableCell tcSYKSSTitle = new TableCell();
                    tcSYKSSTitle.Text = "ʣ���ʱ";
                    tcSYKSSTitle.ColumnSpan = 4;
                    tcSYKSSTitle.RowSpan = 1;
                    tcSYKSSTitle.CssClass = "fieldname";
                    tcSYKSSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSYKSSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcSYKSSTitle);
                    
                    // ��ʾʣ���ʱֵ
                    TableCell tcSYKSSContent = new TableCell();
                      
                    tcSYKSSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SYKSS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SYKSS")).InnerHtml = "";
                    tcSYKSSContent.ColumnSpan = 4;
                    tcSYKSSContent.RowSpan = 1;
                    tcSYKSSContent.CssClass = "fieldinput";
                    tcSYKSSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSYKSSContent.Style.Add("border-top", "1px black solid");
                        
                    tcSYKSSContent.Style.Add("border-left", "1px black solid");
                        
                    tcSYKSSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSYKSSContent.Style.Add("border-right", "1px black solid");
                        
                    tcSYKSSContent.Style.Add("text-align", "center");
                    tDetailView.Rows[6].Cells.Add(tcSYKSSContent);
              
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
    
                // ��ʾ������Ϣ����
                hcTemp = tcTemp.FindControl("relatedtable_1");
                if (hcTemp != null)
                {
                    ((HtmlControl)hcTemp).Style["display"] = "block";
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
    
        // ������Ϣһ�Զ���ر�
        pdfDoc.Add(GenerateRelatedTable(dsMainTable, "T_BM_BMXX", "������Ϣ"));
      
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
        Cell cellTitle = new Cell(new Paragraph("��Ա��Ϣ", font19B));
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
        
        if ("T_BM_BMXX" == strRelatedTableName)
        {
              
            intColumn += 1;
        }
        if ("T_BM_BMXX" == strRelatedTableName)
        {
              
            intColumn += 1;
        }
        if ("T_BM_BMXX" == strRelatedTableName)
        {
              
            intColumn += 1;
        }
        if ("T_BM_BMXX" == strRelatedTableName)
        {
              
            intColumn += 1;
        }
        if ("T_BM_BMXX" == strRelatedTableName)
        {
              
            intColumn += 1;
        }
        if ("T_BM_BMXX" == strRelatedTableName)
        {
              
            intColumn += 1;
        }
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
                
                if ("T_BM_BMXX" == strRelatedTableName)
                {
                    dsRelatedTable = GetT_BM_BMXX(dsMainTable.Tables[0].Rows[0]["HYBH"]);
                  
                      cellTitle = new Cell(new Paragraph("", font11B));
                  
                }
                cellTitle.BorderWidth = 0.5F;
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // ������ر��ֶ�����
                
                if ("T_BM_BMXX" == strRelatedTableName)
                {
                    iTextSharp.text.Cell cellHYBH_T_BM_BMXX_BMBHTitle = new Cell(new Paragraph("�������", font11B));
                    cellHYBH_T_BM_BMXX_BMBHTitle.Rowspan = 1;
                    cellHYBH_T_BM_BMXX_BMBHTitle.Colspan = 1;
                    cellHYBH_T_BM_BMXX_BMBHTitle.Width = 100 / intColumn;
                    
                    cellHYBH_T_BM_BMXX_BMBHTitle.HorizontalAlignment = 1;
                    cellHYBH_T_BM_BMXX_BMBHTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    
                    cellHYBH_T_BM_BMXX_BMBHTitle.BorderWidth = 0.5F;
                    itbOutput.AddCell(cellHYBH_T_BM_BMXX_BMBHTitle);                      
                }
                if ("T_BM_BMXX" == strRelatedTableName)
                {
                    iTextSharp.text.Cell cellHYBH_T_BM_BMXX_KCJGTitle = new Cell(new Paragraph("�۸�", font11B));
                    cellHYBH_T_BM_BMXX_KCJGTitle.Rowspan = 1;
                    cellHYBH_T_BM_BMXX_KCJGTitle.Colspan = 1;
                    cellHYBH_T_BM_BMXX_KCJGTitle.Width = 100 / intColumn;
                    
                    cellHYBH_T_BM_BMXX_KCJGTitle.HorizontalAlignment = 1;
                    cellHYBH_T_BM_BMXX_KCJGTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    
                    cellHYBH_T_BM_BMXX_KCJGTitle.BorderWidth = 0.5F;
                    itbOutput.AddCell(cellHYBH_T_BM_BMXX_KCJGTitle);                      
                }
                if ("T_BM_BMXX" == strRelatedTableName)
                {
                    iTextSharp.text.Cell cellHYBH_T_BM_BMXX_KSSTitle = new Cell(new Paragraph("��ʱ��", font11B));
                    cellHYBH_T_BM_BMXX_KSSTitle.Rowspan = 1;
                    cellHYBH_T_BM_BMXX_KSSTitle.Colspan = 1;
                    cellHYBH_T_BM_BMXX_KSSTitle.Width = 100 / intColumn;
                    
                    cellHYBH_T_BM_BMXX_KSSTitle.HorizontalAlignment = 1;
                    cellHYBH_T_BM_BMXX_KSSTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    
                    cellHYBH_T_BM_BMXX_KSSTitle.BorderWidth = 0.5F;
                    itbOutput.AddCell(cellHYBH_T_BM_BMXX_KSSTitle);                      
                }
                if ("T_BM_BMXX" == strRelatedTableName)
                {
                    iTextSharp.text.Cell cellHYBH_T_BM_BMXX_KCZKTitle = new Cell(new Paragraph("�ۿ�", font11B));
                    cellHYBH_T_BM_BMXX_KCZKTitle.Rowspan = 1;
                    cellHYBH_T_BM_BMXX_KCZKTitle.Colspan = 1;
                    cellHYBH_T_BM_BMXX_KCZKTitle.Width = 100 / intColumn;
                    
                    cellHYBH_T_BM_BMXX_KCZKTitle.HorizontalAlignment = 1;
                    cellHYBH_T_BM_BMXX_KCZKTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    
                    cellHYBH_T_BM_BMXX_KCZKTitle.BorderWidth = 0.5F;
                    itbOutput.AddCell(cellHYBH_T_BM_BMXX_KCZKTitle);                      
                }
                if ("T_BM_BMXX" == strRelatedTableName)
                {
                    iTextSharp.text.Cell cellHYBH_T_BM_BMXX_SJJGTitle = new Cell(new Paragraph("ʵ���տ�", font11B));
                    cellHYBH_T_BM_BMXX_SJJGTitle.Rowspan = 1;
                    cellHYBH_T_BM_BMXX_SJJGTitle.Colspan = 1;
                    cellHYBH_T_BM_BMXX_SJJGTitle.Width = 100 / intColumn;
                    
                    cellHYBH_T_BM_BMXX_SJJGTitle.HorizontalAlignment = 1;
                    cellHYBH_T_BM_BMXX_SJJGTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    
                    cellHYBH_T_BM_BMXX_SJJGTitle.BorderWidth = 0.5F;
                    itbOutput.AddCell(cellHYBH_T_BM_BMXX_SJJGTitle);                      
                }
                if ("T_BM_BMXX" == strRelatedTableName)
                {
                    iTextSharp.text.Cell cellHYBH_T_BM_BMXX_BMSJTitle = new Cell(new Paragraph("����ʱ��", font11B));
                    cellHYBH_T_BM_BMXX_BMSJTitle.Rowspan = 1;
                    cellHYBH_T_BM_BMXX_BMSJTitle.Colspan = 1;
                    cellHYBH_T_BM_BMXX_BMSJTitle.Width = 100 / intColumn;
                    
                    cellHYBH_T_BM_BMXX_BMSJTitle.HorizontalAlignment = 1;
                    cellHYBH_T_BM_BMXX_BMSJTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    
                    cellHYBH_T_BM_BMXX_BMSJTitle.BorderWidth = 0.5F;
                    itbOutput.AddCell(cellHYBH_T_BM_BMXX_BMSJTitle);                      
                }
                // ������ر�����
                if (dsRelatedTable.Tables.Count > 0)
                {
                    string strTempValue = string.Empty;
                    foreach (DataRow drTemp in dsRelatedTable.Tables[0].Rows)
                    {
                    
                        if ("T_BM_BMXX" == strRelatedTableName)
                        {
                            
                            iTextSharp.text.Cell cellHYBH_T_BM_BMXX_BMBHContent = new Cell(new Paragraph(GetValue(drTemp["BMBH"]), font10));
                            
                            cellHYBH_T_BM_BMXX_BMBHContent.Rowspan = 1;
                            cellHYBH_T_BM_BMXX_BMBHContent.Colspan = 1;
                            cellHYBH_T_BM_BMXX_BMBHContent.Width = 100 / intColumn;
                            
                            cellHYBH_T_BM_BMXX_BMBHContent.HorizontalAlignment = 1;
                            cellHYBH_T_BM_BMXX_BMBHContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                            
                            cellHYBH_T_BM_BMXX_BMBHContent.BorderWidth = 0.5F;
                            itbOutput.AddCell(cellHYBH_T_BM_BMXX_BMBHContent);                     
                        }
                        if ("T_BM_BMXX" == strRelatedTableName)
                        {
                            
                            iTextSharp.text.Cell cellHYBH_T_BM_BMXX_KCJGContent = new Cell(new Paragraph(GetValue(drTemp["KCJG"]), font10));
                            
                            cellHYBH_T_BM_BMXX_KCJGContent.Rowspan = 1;
                            cellHYBH_T_BM_BMXX_KCJGContent.Colspan = 1;
                            cellHYBH_T_BM_BMXX_KCJGContent.Width = 100 / intColumn;
                            
                            cellHYBH_T_BM_BMXX_KCJGContent.HorizontalAlignment = 1;
                            cellHYBH_T_BM_BMXX_KCJGContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                            
                            cellHYBH_T_BM_BMXX_KCJGContent.BorderWidth = 0.5F;
                            itbOutput.AddCell(cellHYBH_T_BM_BMXX_KCJGContent);                     
                        }
                        if ("T_BM_BMXX" == strRelatedTableName)
                        {
                            
                            iTextSharp.text.Cell cellHYBH_T_BM_BMXX_KSSContent = new Cell(new Paragraph(GetValue(drTemp["KSS"]), font10));
                            
                            cellHYBH_T_BM_BMXX_KSSContent.Rowspan = 1;
                            cellHYBH_T_BM_BMXX_KSSContent.Colspan = 1;
                            cellHYBH_T_BM_BMXX_KSSContent.Width = 100 / intColumn;
                            
                            cellHYBH_T_BM_BMXX_KSSContent.HorizontalAlignment = 1;
                            cellHYBH_T_BM_BMXX_KSSContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                            
                            cellHYBH_T_BM_BMXX_KSSContent.BorderWidth = 0.5F;
                            itbOutput.AddCell(cellHYBH_T_BM_BMXX_KSSContent);                     
                        }
                        if ("T_BM_BMXX" == strRelatedTableName)
                        {
                            
                            iTextSharp.text.Cell cellHYBH_T_BM_BMXX_KCZKContent = new Cell(new Paragraph(GetValue(drTemp["KCZK"]), font10));
                            
                            cellHYBH_T_BM_BMXX_KCZKContent.Rowspan = 1;
                            cellHYBH_T_BM_BMXX_KCZKContent.Colspan = 1;
                            cellHYBH_T_BM_BMXX_KCZKContent.Width = 100 / intColumn;
                            
                            cellHYBH_T_BM_BMXX_KCZKContent.HorizontalAlignment = 1;
                            cellHYBH_T_BM_BMXX_KCZKContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                            
                            cellHYBH_T_BM_BMXX_KCZKContent.BorderWidth = 0.5F;
                            itbOutput.AddCell(cellHYBH_T_BM_BMXX_KCZKContent);                     
                        }
                        if ("T_BM_BMXX" == strRelatedTableName)
                        {
                            
                            iTextSharp.text.Cell cellHYBH_T_BM_BMXX_SJJGContent = new Cell(new Paragraph(GetValue(drTemp["SJJG"]), font10));
                            
                            cellHYBH_T_BM_BMXX_SJJGContent.Rowspan = 1;
                            cellHYBH_T_BM_BMXX_SJJGContent.Colspan = 1;
                            cellHYBH_T_BM_BMXX_SJJGContent.Width = 100 / intColumn;
                            
                            cellHYBH_T_BM_BMXX_SJJGContent.HorizontalAlignment = 1;
                            cellHYBH_T_BM_BMXX_SJJGContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                            
                            cellHYBH_T_BM_BMXX_SJJGContent.BorderWidth = 0.5F;
                            itbOutput.AddCell(cellHYBH_T_BM_BMXX_SJJGContent);                     
                        }
                        if ("T_BM_BMXX" == strRelatedTableName)
                        {
                            
                            iTextSharp.text.Cell cellHYBH_T_BM_BMXX_BMSJContent = new Cell(new Paragraph(GetValue(drTemp["BMSJ"]), font10));
                            
                            cellHYBH_T_BM_BMXX_BMSJContent.Rowspan = 1;
                            cellHYBH_T_BM_BMXX_BMSJContent.Colspan = 1;
                            cellHYBH_T_BM_BMXX_BMSJContent.Width = 100 / intColumn;
                            
                            cellHYBH_T_BM_BMXX_BMSJContent.HorizontalAlignment = 1;
                            cellHYBH_T_BM_BMXX_BMSJContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                            
                            cellHYBH_T_BM_BMXX_BMSJContent.BorderWidth = 0.5F;
                            itbOutput.AddCell(cellHYBH_T_BM_BMXX_BMSJContent);                     
                        }
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

        if (rptTemp.ID == "rptT_BM_BMXX")
        {
            foreach (RepeaterItem gvr in rptTemp.Items)
            {
                if (gvr.ItemType == ListItemType.Item || gvr.ItemType == ListItemType.AlternatingItem)
                {
                    string strItemMenu = string.Empty;
                    string strObjectID = string.Empty;
                    HtmlTableRow htrTemp;
                    htrTemp = (HtmlTableRow)gvr.FindControl("row");
                    strObjectID = ((HtmlInputHidden)gvr.FindControl("ObjectID")).Value;
                    strItemMenu = ((HtmlContainerControl)gvr.FindControl("itemMenu")).ClientID;
                    htrTemp.Attributes.Add("onmouseover", "overColor(this);");
                    htrTemp.Attributes.Add("onmouseout", "outColor(this);");
                    htrTemp.Attributes.Add("ondblclick", "OpenWindow('T_BM_BMXXWebUIDetail.aspx?ObjectID=" + strObjectID + "',770,600,window);return false;");
                    htrTemp.Attributes.Add("oncontextmenu", "showMenu('" + strItemMenu + "');");
                }
            }
        }
  
    }

}

