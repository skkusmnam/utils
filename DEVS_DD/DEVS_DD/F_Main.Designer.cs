namespace DEVS_DD {
    partial class F_MAIN {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.BT_STEP = new System.Windows.Forms.Button();
			this.BT_PLAY = new System.Windows.Forms.Button();
			this.BT_LOAD = new System.Windows.Forms.Button();
			this.DG_VIEW = new System.Windows.Forms.DataGridView();
			this.col0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.V_LIST = new System.Windows.Forms.ListView();
			this.Header1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TB_LOG = new System.Windows.Forms.TextBox();
			this.TB_MSG = new System.Windows.Forms.TextBox();
			this.BT_PACKET = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DG_VIEW)).BeginInit();
			this.SuspendLayout();
			// 
			// BT_STEP
			// 
			this.BT_STEP.Location = new System.Drawing.Point(423, 16);
			this.BT_STEP.Name = "BT_STEP";
			this.BT_STEP.Size = new System.Drawing.Size(75, 48);
			this.BT_STEP.TabIndex = 1;
			this.BT_STEP.Text = "Step";
			this.BT_STEP.UseVisualStyleBackColor = true;
			this.BT_STEP.Click += new System.EventHandler(this.BT_STEP_Click);
			// 
			// BT_PLAY
			// 
			this.BT_PLAY.Location = new System.Drawing.Point(342, 16);
			this.BT_PLAY.Name = "BT_PLAY";
			this.BT_PLAY.Size = new System.Drawing.Size(75, 48);
			this.BT_PLAY.TabIndex = 2;
			this.BT_PLAY.Text = "Play";
			this.BT_PLAY.UseVisualStyleBackColor = true;
			this.BT_PLAY.Visible = false;
			this.BT_PLAY.Click += new System.EventHandler(this.BT_PLAY_Click);
			// 
			// BT_LOAD
			// 
			this.BT_LOAD.Location = new System.Drawing.Point(13, 12);
			this.BT_LOAD.Name = "BT_LOAD";
			this.BT_LOAD.Size = new System.Drawing.Size(75, 47);
			this.BT_LOAD.TabIndex = 3;
			this.BT_LOAD.Text = "Load";
			this.BT_LOAD.UseVisualStyleBackColor = true;
			this.BT_LOAD.Click += new System.EventHandler(this.BT_LOAD_Click);
			// 
			// DG_VIEW
			// 
			this.DG_VIEW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DG_VIEW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col0,
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6});
			this.DG_VIEW.Location = new System.Drawing.Point(13, 70);
			this.DG_VIEW.Name = "DG_VIEW";
			this.DG_VIEW.RowTemplate.Height = 23;
			this.DG_VIEW.Size = new System.Drawing.Size(485, 238);
			this.DG_VIEW.TabIndex = 4;
			// 
			// col0
			// 
			this.col0.HeaderText = "col0";
			this.col0.Name = "col0";
			// 
			// col1
			// 
			this.col1.HeaderText = "col1";
			this.col1.Name = "col1";
			// 
			// col2
			// 
			this.col2.HeaderText = "col2";
			this.col2.Name = "col2";
			// 
			// col3
			// 
			this.col3.HeaderText = "col3";
			this.col3.Name = "col3";
			// 
			// col4
			// 
			this.col4.HeaderText = "col4";
			this.col4.Name = "col4";
			// 
			// col5
			// 
			this.col5.HeaderText = "col5";
			this.col5.Name = "col5";
			// 
			// col6
			// 
			this.col6.HeaderText = "col6";
			this.col6.Name = "col6";
			// 
			// V_LIST
			// 
			this.V_LIST.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Header1});
			this.V_LIST.Location = new System.Drawing.Point(504, 12);
			this.V_LIST.Name = "V_LIST";
			this.V_LIST.Size = new System.Drawing.Size(208, 296);
			this.V_LIST.TabIndex = 5;
			this.V_LIST.UseCompatibleStateImageBehavior = false;
			this.V_LIST.View = System.Windows.Forms.View.Details;
			this.V_LIST.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.V_LIST_ColumnClick);
			this.V_LIST.DoubleClick += new System.EventHandler(this.V_LIST_DoubleClick);
			// 
			// Header1
			// 
			this.Header1.Text = "Model Name";
			this.Header1.Width = 200;
			// 
			// TB_LOG
			// 
			this.TB_LOG.Location = new System.Drawing.Point(204, 180);
			this.TB_LOG.Multiline = true;
			this.TB_LOG.Name = "TB_LOG";
			this.TB_LOG.Size = new System.Drawing.Size(283, 103);
			this.TB_LOG.TabIndex = 6;
			// 
			// TB_MSG
			// 
			this.TB_MSG.Location = new System.Drawing.Point(204, 122);
			this.TB_MSG.Multiline = true;
			this.TB_MSG.Name = "TB_MSG";
			this.TB_MSG.Size = new System.Drawing.Size(283, 52);
			this.TB_MSG.TabIndex = 7;
			// 
			// BT_PACKET
			// 
			this.BT_PACKET.Location = new System.Drawing.Point(402, 245);
			this.BT_PACKET.Name = "BT_PACKET";
			this.BT_PACKET.Size = new System.Drawing.Size(75, 28);
			this.BT_PACKET.TabIndex = 8;
			this.BT_PACKET.Text = "PACKET";
			this.BT_PACKET.UseVisualStyleBackColor = true;
			this.BT_PACKET.Click += new System.EventHandler(this.BT_PACKET_Click);
			// 
			// F_MAIN
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 320);
			this.Controls.Add(this.BT_PACKET);
			this.Controls.Add(this.TB_MSG);
			this.Controls.Add(this.TB_LOG);
			this.Controls.Add(this.V_LIST);
			this.Controls.Add(this.DG_VIEW);
			this.Controls.Add(this.BT_LOAD);
			this.Controls.Add(this.BT_PLAY);
			this.Controls.Add(this.BT_STEP);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "F_MAIN";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DEVS Diagram Display";
			this.Load += new System.EventHandler(this.F_MAIN_Load);
			((System.ComponentModel.ISupportInitialize)(this.DG_VIEW)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_STEP;
        private System.Windows.Forms.Button BT_PLAY;
        private System.Windows.Forms.Button BT_LOAD;
		private System.Windows.Forms.DataGridView DG_VIEW;
		private System.Windows.Forms.DataGridViewTextBoxColumn col0;
		private System.Windows.Forms.DataGridViewTextBoxColumn col1;
		private System.Windows.Forms.DataGridViewTextBoxColumn col2;
		private System.Windows.Forms.DataGridViewTextBoxColumn col3;
		private System.Windows.Forms.DataGridViewTextBoxColumn col4;
		private System.Windows.Forms.DataGridViewTextBoxColumn col5;
		private System.Windows.Forms.DataGridViewTextBoxColumn col6;
        private System.Windows.Forms.ListView V_LIST;
        private System.Windows.Forms.ColumnHeader Header1;
        private System.Windows.Forms.TextBox TB_LOG;
        private System.Windows.Forms.TextBox TB_MSG;
		private System.Windows.Forms.Button BT_PACKET;
    }
}

