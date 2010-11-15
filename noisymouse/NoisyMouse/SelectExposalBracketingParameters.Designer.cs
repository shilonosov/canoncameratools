namespace NoisyMouse
{
    partial class SelectExposalBracketingParameters
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
            this.label1 = new System.Windows.Forms.Label();
            this.stepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.countNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Step";
            // 
            // stepNumericUpDown
            // 
            this.stepNumericUpDown.Location = new System.Drawing.Point(101, 7);
            this.stepNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.stepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepNumericUpDown.Name = "stepNumericUpDown";
            this.stepNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.stepNumericUpDown.TabIndex = 0;
            this.stepNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // countNumericUpDown
            // 
            this.countNumericUpDown.Location = new System.Drawing.Point(101, 33);
            this.countNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.countNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countNumericUpDown.Name = "countNumericUpDown";
            this.countNumericUpDown.Size = new System.Drawing.Size(94, 20);
            this.countNumericUpDown.TabIndex = 1;
            this.countNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total count";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(15, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(120, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SelectExposalBracketingParameters
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(207, 105);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.countNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stepNumericUpDown);
            this.Controls.Add(this.label1);
            this.Name = "SelectExposalBracketingParameters";
            this.Text = "Exposal bracketing parameters";
            ((System.ComponentModel.ISupportInitialize)(this.stepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown stepNumericUpDown;
        private System.Windows.Forms.NumericUpDown countNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}