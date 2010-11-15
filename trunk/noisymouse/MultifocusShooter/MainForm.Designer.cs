namespace MultifocusShooter
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cameraInfoListBox = new System.Windows.Forms.ListBox();
            this.cameraInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.multiplierNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.stepsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.moderateRadioButton = new System.Windows.Forms.RadioButton();
            this.fastRadioButton = new System.Windows.Forms.RadioButton();
            this.slowRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.backwardRadioButton = new System.Windows.Forms.RadioButton();
            this.forwardRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pauseNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.logTichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraInfoBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiplierNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pauseNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cameraInfoListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera";
            // 
            // cameraInfoListBox
            // 
            this.cameraInfoListBox.DataSource = this.cameraInfoBindingSource;
            this.cameraInfoListBox.FormattingEnabled = true;
            this.cameraInfoListBox.Location = new System.Drawing.Point(6, 19);
            this.cameraInfoListBox.Name = "cameraInfoListBox";
            this.cameraInfoListBox.Size = new System.Drawing.Size(284, 82);
            this.cameraInfoListBox.TabIndex = 0;
            // 
            // cameraInfoBindingSource
            // 
            this.cameraInfoBindingSource.DataSource = typeof(Source.CameraInfo);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pauseNumericUpDown);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.multiplierNumericUpDown);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.stepsNumericUpDown);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(130, 91);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // multiplierNumericUpDown
            // 
            this.multiplierNumericUpDown.Location = new System.Drawing.Point(71, 40);
            this.multiplierNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.multiplierNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.multiplierNumericUpDown.Name = "multiplierNumericUpDown";
            this.multiplierNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.multiplierNumericUpDown.TabIndex = 4;
            this.multiplierNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Multiplier";
            // 
            // stepsNumericUpDown
            // 
            this.stepsNumericUpDown.Location = new System.Drawing.Point(71, 14);
            this.stepsNumericUpDown.Name = "stepsNumericUpDown";
            this.stepsNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.stepsNumericUpDown.TabIndex = 1;
            this.stepsNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steps";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.moderateRadioButton);
            this.groupBox3.Controls.Add(this.fastRadioButton);
            this.groupBox3.Controls.Add(this.slowRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(148, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(79, 91);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Speed";
            // 
            // moderateRadioButton
            // 
            this.moderateRadioButton.AutoSize = true;
            this.moderateRadioButton.Checked = true;
            this.moderateRadioButton.Location = new System.Drawing.Point(6, 42);
            this.moderateRadioButton.Name = "moderateRadioButton";
            this.moderateRadioButton.Size = new System.Drawing.Size(70, 17);
            this.moderateRadioButton.TabIndex = 2;
            this.moderateRadioButton.TabStop = true;
            this.moderateRadioButton.Text = "Moderate";
            this.moderateRadioButton.UseVisualStyleBackColor = true;
            // 
            // fastRadioButton
            // 
            this.fastRadioButton.AutoSize = true;
            this.fastRadioButton.Location = new System.Drawing.Point(6, 65);
            this.fastRadioButton.Name = "fastRadioButton";
            this.fastRadioButton.Size = new System.Drawing.Size(45, 17);
            this.fastRadioButton.TabIndex = 1;
            this.fastRadioButton.Text = "Fast";
            this.fastRadioButton.UseVisualStyleBackColor = true;
            // 
            // slowRadioButton
            // 
            this.slowRadioButton.AutoSize = true;
            this.slowRadioButton.Location = new System.Drawing.Point(6, 19);
            this.slowRadioButton.Name = "slowRadioButton";
            this.slowRadioButton.Size = new System.Drawing.Size(48, 17);
            this.slowRadioButton.TabIndex = 0;
            this.slowRadioButton.Text = "Slow";
            this.slowRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.backwardRadioButton);
            this.groupBox4.Controls.Add(this.forwardRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(233, 129);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(79, 91);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Direction";
            // 
            // backwardRadioButton
            // 
            this.backwardRadioButton.AutoSize = true;
            this.backwardRadioButton.Location = new System.Drawing.Point(6, 42);
            this.backwardRadioButton.Name = "backwardRadioButton";
            this.backwardRadioButton.Size = new System.Drawing.Size(73, 17);
            this.backwardRadioButton.TabIndex = 1;
            this.backwardRadioButton.Text = "Backward";
            this.backwardRadioButton.UseVisualStyleBackColor = true;
            // 
            // forwardRadioButton
            // 
            this.forwardRadioButton.AutoSize = true;
            this.forwardRadioButton.Checked = true;
            this.forwardRadioButton.Location = new System.Drawing.Point(6, 19);
            this.forwardRadioButton.Name = "forwardRadioButton";
            this.forwardRadioButton.Size = new System.Drawing.Size(63, 17);
            this.forwardRadioButton.TabIndex = 0;
            this.forwardRadioButton.TabStop = true;
            this.forwardRadioButton.Text = "Forward";
            this.forwardRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.logTichTextBox);
            this.groupBox5.Location = new System.Drawing.Point(318, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(581, 237);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Preview";
            // 
            // pauseNumericUpDown
            // 
            this.pauseNumericUpDown.Location = new System.Drawing.Point(71, 66);
            this.pauseNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pauseNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.pauseNumericUpDown.Name = "pauseNumericUpDown";
            this.pauseNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.pauseNumericUpDown.TabIndex = 6;
            this.pauseNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pause (ms)";
            // 
            // logTichTextBox
            // 
            this.logTichTextBox.Location = new System.Drawing.Point(6, 19);
            this.logTichTextBox.Name = "logTichTextBox";
            this.logTichTextBox.Size = new System.Drawing.Size(569, 212);
            this.logTichTextBox.TabIndex = 0;
            this.logTichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 255);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SuperPuperMacroStackShooter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cameraInfoBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiplierNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pauseNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox cameraInfoListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown stepsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource cameraInfoBindingSource;
        private System.Windows.Forms.NumericUpDown multiplierNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton moderateRadioButton;
        private System.Windows.Forms.RadioButton fastRadioButton;
        private System.Windows.Forms.RadioButton slowRadioButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton backwardRadioButton;
        private System.Windows.Forms.RadioButton forwardRadioButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown pauseNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox logTichTextBox;

    }
}

