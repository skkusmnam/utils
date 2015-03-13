namespace DEVS_DD
{
	partial class F_CLIENT
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
			this.BT_CREATE = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.BT_SENDING = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BT_CREATE
			// 
			this.BT_CREATE.Location = new System.Drawing.Point(60, 134);
			this.BT_CREATE.Name = "BT_CREATE";
			this.BT_CREATE.Size = new System.Drawing.Size(79, 82);
			this.BT_CREATE.TabIndex = 0;
			this.BT_CREATE.Text = "Create Form";
			this.BT_CREATE.UseVisualStyleBackColor = true;
			this.BT_CREATE.Click += new System.EventHandler(this.BT_CREATE_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(60, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(180, 21);
			this.textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(60, 39);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(180, 89);
			this.textBox2.TabIndex = 1;
			// 
			// BT_SENDING
			// 
			this.BT_SENDING.Location = new System.Drawing.Point(161, 134);
			this.BT_SENDING.Name = "BT_SENDING";
			this.BT_SENDING.Size = new System.Drawing.Size(79, 82);
			this.BT_SENDING.TabIndex = 2;
			this.BT_SENDING.Text = "Send Message";
			this.BT_SENDING.UseVisualStyleBackColor = true;
			this.BT_SENDING.Click += new System.EventHandler(this.BT_SENDING_Click);
			// 
			// F_CLIENT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.BT_SENDING);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.BT_CREATE);
			this.Name = "F_CLIENT";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button BT_CREATE;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button BT_SENDING;
	}
}