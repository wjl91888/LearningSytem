namespace DataModelApplication
{
    partial class CustomOperateConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCustomOperateConfig = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.CustomOperateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentPermission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedPermission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateParamOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateParamTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateParamThree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomOperateConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 7);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomOperateConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(721, 224);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvCustomOperateConfig
            // 
            this.dgvCustomOperateConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomOperateConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomOperateName,
            this.CurrentPermission,
            this.RelatedPermission,
            this.CustomOperateFile,
            this.CustomOperateParamOne,
            this.CustomOperateParamTwo,
            this.CustomOperateParamThree});
            this.dgvCustomOperateConfig.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomOperateConfig.Name = "dgvCustomOperateConfig";
            this.dgvCustomOperateConfig.RowTemplate.Height = 23;
            this.dgvCustomOperateConfig.Size = new System.Drawing.Size(715, 165);
            this.dgvCustomOperateConfig.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(341, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomOperateName
            // 
            this.CustomOperateName.Frozen = true;
            this.CustomOperateName.HeaderText = "操作名称";
            this.CustomOperateName.Name = "CustomOperateName";
            // 
            // CurrentPermission
            // 
            this.CurrentPermission.HeaderText = "当前权限";
            this.CurrentPermission.Name = "CurrentPermission";
            // 
            // RelatedPermission
            // 
            this.RelatedPermission.HeaderText = "关联权限";
            this.RelatedPermission.Name = "RelatedPermission";
            // 
            // CustomOperateFile
            // 
            this.CustomOperateFile.HeaderText = "操作链接文件";
            this.CustomOperateFile.Name = "CustomOperateFile";
            this.CustomOperateFile.Width = 150;
            // 
            // CustomOperateParamOne
            // 
            this.CustomOperateParamOne.HeaderText = "传入参数一";
            this.CustomOperateParamOne.Name = "CustomOperateParamOne";
            // 
            // CustomOperateParamTwo
            // 
            this.CustomOperateParamTwo.HeaderText = "传入参数二";
            this.CustomOperateParamTwo.Name = "CustomOperateParamTwo";
            // 
            // CustomOperateParamThree
            // 
            this.CustomOperateParamThree.HeaderText = "传入参数三";
            this.CustomOperateParamThree.Name = "CustomOperateParamThree";
            // 
            // CustomOperateConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 236);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomOperateConfigForm";
            this.Text = "配置自定义操作";
            this.Load += new System.EventHandler(this.CustomOperateConfigForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomOperateConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCustomOperateConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedPermission;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateParamOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateParamTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateParamThree;
    }
}