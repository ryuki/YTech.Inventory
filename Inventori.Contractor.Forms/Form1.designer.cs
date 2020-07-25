namespace Inventori.Contractor.Forms
{
	partial class Form1
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
			this.wrkPrimeNumbers = new System.ComponentModel.BackgroundWorker();
			this.lblLimit = new System.Windows.Forms.Label();
			this.nupLimit = new System.Windows.Forms.NumericUpDown();
			this.btnStartStop = new System.Windows.Forms.Button();
			this.pgbTestedNumbers = new System.Windows.Forms.ProgressBar();
			this.trbNumbersFound = new System.Windows.Forms.RichTextBox();
			this.chxShowControls = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nupLimit)).BeginInit();
			this.SuspendLayout();
			// 
			// wrkPrimeNumbers
			// 
			this.wrkPrimeNumbers.WorkerReportsProgress = true;
			this.wrkPrimeNumbers.WorkerSupportsCancellation = true;
			this.wrkPrimeNumbers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wrkPrimeNumbers_DoWork);
			this.wrkPrimeNumbers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wrkPrimeNumbers_RunWorkerCompleted);
			this.wrkPrimeNumbers.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wrkPrimeNumbers_ProgressChanged);
			// 
			// lblLimit
			// 
			this.lblLimit.AutoSize = true;
			this.lblLimit.Location = new System.Drawing.Point(12, 9);
			this.lblLimit.Name = "lblLimit";
			this.lblLimit.Size = new System.Drawing.Size(94, 13);
			this.lblLimit.TabIndex = 0;
			this.lblLimit.Text = "Max number (limit):";
			// 
			// nupLimit
			// 
			this.nupLimit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nupLimit.Location = new System.Drawing.Point(112, 7);
			this.nupLimit.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.nupLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nupLimit.Name = "nupLimit";
			this.nupLimit.Size = new System.Drawing.Size(120, 20);
			this.nupLimit.TabIndex = 1;
			this.nupLimit.ThousandsSeparator = true;
			this.nupLimit.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			// 
			// btnStartStop
			// 
			this.btnStartStop.Location = new System.Drawing.Point(238, 4);
			this.btnStartStop.Name = "btnStartStop";
			this.btnStartStop.Size = new System.Drawing.Size(75, 23);
			this.btnStartStop.TabIndex = 2;
			this.btnStartStop.Text = "Start / Stop";
			this.btnStartStop.UseVisualStyleBackColor = true;
			this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
			// 
			// pgbTestedNumbers
			// 
			this.pgbTestedNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pgbTestedNumbers.Location = new System.Drawing.Point(15, 33);
			this.pgbTestedNumbers.Name = "pgbTestedNumbers";
			this.pgbTestedNumbers.Size = new System.Drawing.Size(397, 23);
			this.pgbTestedNumbers.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pgbTestedNumbers.TabIndex = 4;
			// 
			// trbNumbersFound
			// 
			this.trbNumbersFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.trbNumbersFound.DetectUrls = false;
			this.trbNumbersFound.Location = new System.Drawing.Point(12, 62);
			this.trbNumbersFound.Name = "trbNumbersFound";
			this.trbNumbersFound.Size = new System.Drawing.Size(400, 309);
			this.trbNumbersFound.TabIndex = 5;
			this.trbNumbersFound.Text = "";
			// 
			// chxShowControls
			// 
			this.chxShowControls.AutoSize = true;
			this.chxShowControls.Location = new System.Drawing.Point(319, 8);
			this.chxShowControls.Name = "chxShowControls";
			this.chxShowControls.Size = new System.Drawing.Size(98, 17);
			this.chxShowControls.TabIndex = 3;
			this.chxShowControls.Text = "Show Numbers";
			this.chxShowControls.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 383);
			this.Controls.Add(this.chxShowControls);
			this.Controls.Add(this.trbNumbersFound);
			this.Controls.Add(this.pgbTestedNumbers);
			this.Controls.Add(this.btnStartStop);
			this.Controls.Add(this.nupLimit);
			this.Controls.Add(this.lblLimit);
			this.Name = "Form1";
			this.Text = "Find Prime Numbers";
			((System.ComponentModel.ISupportInitialize)(this.nupLimit)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker wrkPrimeNumbers;
		private System.Windows.Forms.Label lblLimit;
		private System.Windows.Forms.NumericUpDown nupLimit;
		private System.Windows.Forms.Button btnStartStop;
		private System.Windows.Forms.ProgressBar pgbTestedNumbers;
		private System.Windows.Forms.RichTextBox trbNumbersFound;
		private System.Windows.Forms.CheckBox chxShowControls;
	}
}

