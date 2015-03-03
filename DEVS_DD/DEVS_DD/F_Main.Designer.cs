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
			// F_MAIN
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 320);
			this.Controls.Add(this.DG_VIEW);
			this.Controls.Add(this.BT_LOAD);
			this.Controls.Add(this.BT_PLAY);
			this.Controls.Add(this.BT_STEP);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "F_MAIN";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main";
			((System.ComponentModel.ISupportInitialize)(this.DG_VIEW)).EndInit();
			this.ResumeLayout(false);

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
    }
}

