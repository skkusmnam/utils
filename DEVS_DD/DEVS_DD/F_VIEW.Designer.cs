namespace DEVS_DD
{
	partial class F_VIEW
	{
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
            this.V_LIST = new System.Windows.Forms.ListView();
            this.Header1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // V_LIST
            // 
            this.V_LIST.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Header1});
            this.V_LIST.Location = new System.Drawing.Point(12, 12);
            this.V_LIST.Name = "V_LIST";
            this.V_LIST.Size = new System.Drawing.Size(208, 322);
            this.V_LIST.TabIndex = 0;
            this.V_LIST.UseCompatibleStateImageBehavior = false;
            this.V_LIST.View = System.Windows.Forms.View.Details;
            this.V_LIST.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.V_LIST_ColumnClick);
            // 
            // Header1
            // 
            this.Header1.Text = "Model Name";
            this.Header1.Width = 200;
            // 
            // F_VIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 346);
            this.Controls.Add(this.V_LIST);
            this.Name = "F_VIEW";
            this.Text = "F_VIEW";
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ListView V_LIST;
        private System.Windows.Forms.ColumnHeader Header1;

    }
}