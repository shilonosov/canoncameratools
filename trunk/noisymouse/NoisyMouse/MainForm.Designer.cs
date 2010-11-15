using Source;

namespace NoisyMouse
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cameraInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.runButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cameraDisplayStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parametersDisplayStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.handlerDisplayStringDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.deleteParameterButton = new System.Windows.Forms.Button();
            this.clearImagesButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.parametersTabPage = new System.Windows.Forms.TabPage();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.refreshCameraListButton = new System.Windows.Forms.Button();
            this.cameraInfoListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saveToComboBox = new System.Windows.Forms.ComboBox();
            this.addABButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.addEBButton = new System.Windows.Forms.Button();
            this.outputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apertureComboBox = new System.Windows.Forms.ComboBox();
            this.setOutputDirButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.exposalComboBox = new System.Windows.Forms.ComboBox();
            this.isoComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addNewShoot = new System.Windows.Forms.Button();
            this.imageQualityComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.schedulerTabControl = new System.Windows.Forms.TabPage();
            this.schedulerPanel = new System.Windows.Forms.Panel();
            this.startSchedulerbutton = new System.Windows.Forms.Button();
            this.byStopTime = new System.Windows.Forms.RadioButton();
            this.stopSchedulerButton = new System.Windows.Forms.Button();
            this.byTotalShots = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.schedulerEnabled = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.stopTime = new System.Windows.Forms.DateTimePicker();
            this.interval = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.totalShotsCount = new System.Windows.Forms.NumericUpDown();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.cameraInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBindingSource)).BeginInit();
            this.tabControl.SuspendLayout();
            this.parametersTabPage.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.schedulerTabControl.SuspendLayout();
            this.schedulerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalShotsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraInfoBindingSource
            // 
            this.cameraInfoBindingSource.DataSource = typeof(Source.CameraInfo);
            this.cameraInfoBindingSource.CurrentItemChanged += new System.EventHandler(this.cameraBindingSource_CurrentChanged);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(145, 91);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(109, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cameraDisplayStringDataGridViewTextBoxColumn,
            this.parametersDisplayStringDataGridViewTextBoxColumn,
            this.handlerDisplayStringDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.imageBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 173);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(848, 177);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseClick);
            // 
            // cameraDisplayStringDataGridViewTextBoxColumn
            // 
            this.cameraDisplayStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cameraDisplayStringDataGridViewTextBoxColumn.DataPropertyName = "CameraDisplayString";
            this.cameraDisplayStringDataGridViewTextBoxColumn.HeaderText = "Camera";
            this.cameraDisplayStringDataGridViewTextBoxColumn.Name = "cameraDisplayStringDataGridViewTextBoxColumn";
            this.cameraDisplayStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.cameraDisplayStringDataGridViewTextBoxColumn.Width = 68;
            // 
            // parametersDisplayStringDataGridViewTextBoxColumn
            // 
            this.parametersDisplayStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.parametersDisplayStringDataGridViewTextBoxColumn.DataPropertyName = "ParametersDisplayString";
            this.parametersDisplayStringDataGridViewTextBoxColumn.HeaderText = "Parameters";
            this.parametersDisplayStringDataGridViewTextBoxColumn.Name = "parametersDisplayStringDataGridViewTextBoxColumn";
            this.parametersDisplayStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.parametersDisplayStringDataGridViewTextBoxColumn.Width = 85;
            // 
            // handlerDisplayStringDataGridViewTextBoxColumn
            // 
            this.handlerDisplayStringDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.handlerDisplayStringDataGridViewTextBoxColumn.DataPropertyName = "HandlerDisplayString";
            this.handlerDisplayStringDataGridViewTextBoxColumn.HeaderText = "What to do";
            this.handlerDisplayStringDataGridViewTextBoxColumn.Name = "handlerDisplayStringDataGridViewTextBoxColumn";
            this.handlerDisplayStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.handlerDisplayStringDataGridViewTextBoxColumn.Width = 85;
            // 
            // imageBindingSource
            // 
            this.imageBindingSource.DataSource = typeof(Source.Image);
            this.imageBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.imageBindingSource_ListChanged);
            // 
            // deleteParameterButton
            // 
            this.deleteParameterButton.Location = new System.Drawing.Point(12, 356);
            this.deleteParameterButton.Name = "deleteParameterButton";
            this.deleteParameterButton.Size = new System.Drawing.Size(109, 23);
            this.deleteParameterButton.TabIndex = 19;
            this.deleteParameterButton.Text = "Remove selected";
            this.deleteParameterButton.UseVisualStyleBackColor = true;
            this.deleteParameterButton.Click += new System.EventHandler(this.deleteParameterButton_Click);
            // 
            // clearImagesButton
            // 
            this.clearImagesButton.Location = new System.Drawing.Point(751, 356);
            this.clearImagesButton.Name = "clearImagesButton";
            this.clearImagesButton.Size = new System.Drawing.Size(109, 23);
            this.clearImagesButton.TabIndex = 22;
            this.clearImagesButton.Text = "Clear all";
            this.clearImagesButton.UseVisualStyleBackColor = true;
            this.clearImagesButton.Click += new System.EventHandler(this.clearImagesButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.parametersTabPage);
            this.tabControl.Controls.Add(this.schedulerTabControl);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(848, 155);
            this.tabControl.TabIndex = 26;
            // 
            // parametersTabPage
            // 
            this.parametersTabPage.Controls.Add(this.controlPanel);
            this.parametersTabPage.Location = new System.Drawing.Point(4, 22);
            this.parametersTabPage.Name = "parametersTabPage";
            this.parametersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.parametersTabPage.Size = new System.Drawing.Size(840, 129);
            this.parametersTabPage.TabIndex = 0;
            this.parametersTabPage.Text = "Shoot parameters";
            this.parametersTabPage.UseVisualStyleBackColor = true;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.refreshCameraListButton);
            this.controlPanel.Controls.Add(this.cameraInfoListBox);
            this.controlPanel.Controls.Add(this.label6);
            this.controlPanel.Controls.Add(this.saveToComboBox);
            this.controlPanel.Controls.Add(this.addABButton);
            this.controlPanel.Controls.Add(this.label4);
            this.controlPanel.Controls.Add(this.addEBButton);
            this.controlPanel.Controls.Add(this.outputDirectoryTextBox);
            this.controlPanel.Controls.Add(this.runButton);
            this.controlPanel.Controls.Add(this.label3);
            this.controlPanel.Controls.Add(this.apertureComboBox);
            this.controlPanel.Controls.Add(this.setOutputDirButton);
            this.controlPanel.Controls.Add(this.label5);
            this.controlPanel.Controls.Add(this.exposalComboBox);
            this.controlPanel.Controls.Add(this.isoComboBox);
            this.controlPanel.Controls.Add(this.label2);
            this.controlPanel.Controls.Add(this.addNewShoot);
            this.controlPanel.Controls.Add(this.imageQualityComboBox);
            this.controlPanel.Controls.Add(this.label1);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlPanel.Enabled = false;
            this.controlPanel.Location = new System.Drawing.Point(3, 3);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(834, 123);
            this.controlPanel.TabIndex = 27;
            // 
            // refreshCameraListButton
            // 
            this.refreshCameraListButton.Location = new System.Drawing.Point(4, 91);
            this.refreshCameraListButton.Name = "refreshCameraListButton";
            this.refreshCameraListButton.Size = new System.Drawing.Size(109, 23);
            this.refreshCameraListButton.TabIndex = 43;
            this.refreshCameraListButton.Text = "Refresh";
            this.refreshCameraListButton.UseVisualStyleBackColor = true;
            this.refreshCameraListButton.Click += new System.EventHandler(this.refreshCameraListButton_Click);
            // 
            // cameraInfoListBox
            // 
            this.cameraInfoListBox.DataSource = this.cameraInfoBindingSource;
            this.cameraInfoListBox.FormattingEnabled = true;
            this.cameraInfoListBox.Location = new System.Drawing.Point(4, 3);
            this.cameraInfoListBox.Name = "cameraInfoListBox";
            this.cameraInfoListBox.Size = new System.Drawing.Size(250, 82);
            this.cameraInfoListBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(517, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Output directory";
            // 
            // saveToComboBox
            // 
            this.saveToComboBox.FormattingEnabled = true;
            this.saveToComboBox.Location = new System.Drawing.Point(605, 3);
            this.saveToComboBox.Name = "saveToComboBox";
            this.saveToComboBox.Size = new System.Drawing.Size(219, 21);
            this.saveToComboBox.TabIndex = 5;
            // 
            // addABButton
            // 
            this.addABButton.Location = new System.Drawing.Point(380, 1);
            this.addABButton.Name = "addABButton";
            this.addABButton.Size = new System.Drawing.Size(131, 23);
            this.addABButton.TabIndex = 41;
            this.addABButton.Text = "Add Aperture Bracketing";
            this.addABButton.UseVisualStyleBackColor = true;
            this.addABButton.Click += new System.EventHandler(this.addABButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Save to";
            // 
            // addEBButton
            // 
            this.addEBButton.Location = new System.Drawing.Point(380, 28);
            this.addEBButton.Name = "addEBButton";
            this.addEBButton.Size = new System.Drawing.Size(131, 23);
            this.addEBButton.TabIndex = 40;
            this.addEBButton.Text = "Add Exposal Bracketing";
            this.addEBButton.UseVisualStyleBackColor = true;
            this.addEBButton.Click += new System.EventHandler(this.AddEBButton_Click);
            // 
            // outputDirectoryTextBox
            // 
            this.outputDirectoryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::NoisyMouse.Properties.Settings.Default, "dir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outputDirectoryTextBox.Location = new System.Drawing.Point(605, 30);
            this.outputDirectoryTextBox.Name = "outputDirectoryTextBox";
            this.outputDirectoryTextBox.Size = new System.Drawing.Size(128, 20);
            this.outputDirectoryTextBox.TabIndex = 6;
            this.outputDirectoryTextBox.Text = global::NoisyMouse.Properties.Settings.Default.dir;
            this.outputDirectoryTextBox.TextChanged += new System.EventHandler(this.outputDirectoryTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tv";
            // 
            // apertureComboBox
            // 
            this.apertureComboBox.FormattingEnabled = true;
            this.apertureComboBox.Location = new System.Drawing.Point(299, 3);
            this.apertureComboBox.Name = "apertureComboBox";
            this.apertureComboBox.Size = new System.Drawing.Size(75, 21);
            this.apertureComboBox.TabIndex = 1;
            // 
            // setOutputDirButton
            // 
            this.setOutputDirButton.Location = new System.Drawing.Point(739, 28);
            this.setOutputDirButton.Name = "setOutputDirButton";
            this.setOutputDirButton.Size = new System.Drawing.Size(85, 23);
            this.setOutputDirButton.TabIndex = 7;
            this.setOutputDirButton.Text = "Set output dir";
            this.setOutputDirButton.UseVisualStyleBackColor = true;
            this.setOutputDirButton.Click += new System.EventHandler(this.setOutputDirButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Image quality";
            // 
            // exposalComboBox
            // 
            this.exposalComboBox.FormattingEnabled = true;
            this.exposalComboBox.Location = new System.Drawing.Point(299, 30);
            this.exposalComboBox.Name = "exposalComboBox";
            this.exposalComboBox.Size = new System.Drawing.Size(75, 21);
            this.exposalComboBox.TabIndex = 2;
            // 
            // isoComboBox
            // 
            this.isoComboBox.FormattingEnabled = true;
            this.isoComboBox.Location = new System.Drawing.Point(299, 57);
            this.isoComboBox.Name = "isoComboBox";
            this.isoComboBox.Size = new System.Drawing.Size(75, 21);
            this.isoComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Av";
            // 
            // addNewShoot
            // 
            this.addNewShoot.Location = new System.Drawing.Point(605, 55);
            this.addNewShoot.Name = "addNewShoot";
            this.addNewShoot.Size = new System.Drawing.Size(219, 23);
            this.addNewShoot.TabIndex = 8;
            this.addNewShoot.Text = "Add new shoot parameters";
            this.addNewShoot.UseVisualStyleBackColor = true;
            this.addNewShoot.Click += new System.EventHandler(this.addNewShoot_Click);
            // 
            // imageQualityComboBox
            // 
            this.imageQualityComboBox.FormattingEnabled = true;
            this.imageQualityComboBox.Location = new System.Drawing.Point(455, 57);
            this.imageQualityComboBox.Name = "imageQualityComboBox";
            this.imageQualityComboBox.Size = new System.Drawing.Size(56, 21);
            this.imageQualityComboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ISO";
            // 
            // schedulerTabControl
            // 
            this.schedulerTabControl.Controls.Add(this.schedulerPanel);
            this.schedulerTabControl.Location = new System.Drawing.Point(4, 22);
            this.schedulerTabControl.Name = "schedulerTabControl";
            this.schedulerTabControl.Padding = new System.Windows.Forms.Padding(3);
            this.schedulerTabControl.Size = new System.Drawing.Size(840, 129);
            this.schedulerTabControl.TabIndex = 1;
            this.schedulerTabControl.Text = "Scheduler";
            this.schedulerTabControl.UseVisualStyleBackColor = true;
            // 
            // schedulerPanel
            // 
            this.schedulerPanel.Controls.Add(this.startSchedulerbutton);
            this.schedulerPanel.Controls.Add(this.byStopTime);
            this.schedulerPanel.Controls.Add(this.stopSchedulerButton);
            this.schedulerPanel.Controls.Add(this.byTotalShots);
            this.schedulerPanel.Controls.Add(this.label7);
            this.schedulerPanel.Controls.Add(this.schedulerEnabled);
            this.schedulerPanel.Controls.Add(this.label8);
            this.schedulerPanel.Controls.Add(this.stopTime);
            this.schedulerPanel.Controls.Add(this.interval);
            this.schedulerPanel.Controls.Add(this.label10);
            this.schedulerPanel.Controls.Add(this.totalShotsCount);
            this.schedulerPanel.Controls.Add(this.startTime);
            this.schedulerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerPanel.Enabled = false;
            this.schedulerPanel.Location = new System.Drawing.Point(3, 3);
            this.schedulerPanel.Name = "schedulerPanel";
            this.schedulerPanel.Size = new System.Drawing.Size(834, 123);
            this.schedulerPanel.TabIndex = 18;
            // 
            // startSchedulerbutton
            // 
            this.startSchedulerbutton.Location = new System.Drawing.Point(3, 100);
            this.startSchedulerbutton.Name = "startSchedulerbutton";
            this.startSchedulerbutton.Size = new System.Drawing.Size(106, 23);
            this.startSchedulerbutton.TabIndex = 2;
            this.startSchedulerbutton.Text = "Start scheduler";
            this.startSchedulerbutton.UseVisualStyleBackColor = true;
            this.startSchedulerbutton.Click += new System.EventHandler(this.startSchedulerbutton_Click);
            // 
            // byStopTime
            // 
            this.byStopTime.AutoSize = true;
            this.byStopTime.Location = new System.Drawing.Point(192, 75);
            this.byStopTime.Name = "byStopTime";
            this.byStopTime.Size = new System.Drawing.Size(70, 17);
            this.byStopTime.TabIndex = 17;
            this.byStopTime.Text = "stop time:";
            this.byStopTime.UseVisualStyleBackColor = true;
            // 
            // stopSchedulerButton
            // 
            this.stopSchedulerButton.Location = new System.Drawing.Point(157, 100);
            this.stopSchedulerButton.Name = "stopSchedulerButton";
            this.stopSchedulerButton.Size = new System.Drawing.Size(106, 23);
            this.stopSchedulerButton.TabIndex = 3;
            this.stopSchedulerButton.Text = "Stop scheduler";
            this.stopSchedulerButton.UseVisualStyleBackColor = true;
            this.stopSchedulerButton.Click += new System.EventHandler(this.stopSchedulerButton_Click);
            // 
            // byTotalShots
            // 
            this.byTotalShots.AutoSize = true;
            this.byTotalShots.Checked = true;
            this.byTotalShots.Location = new System.Drawing.Point(192, 52);
            this.byTotalShots.Name = "byTotalShots";
            this.byTotalShots.Size = new System.Drawing.Size(76, 17);
            this.byTotalShots.TabIndex = 16;
            this.byTotalShots.TabStop = true;
            this.byTotalShots.Text = "total shots:";
            this.byTotalShots.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Interval:";
            // 
            // schedulerEnabled
            // 
            this.schedulerEnabled.AutoSize = true;
            this.schedulerEnabled.Location = new System.Drawing.Point(6, 27);
            this.schedulerEnabled.Name = "schedulerEnabled";
            this.schedulerEnabled.Size = new System.Drawing.Size(108, 17);
            this.schedulerEnabled.TabIndex = 15;
            this.schedulerEnabled.Text = "Enable scheduler";
            this.schedulerEnabled.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "seconds";
            // 
            // stopTime
            // 
            this.stopTime.CustomFormat = "MM.dd.yyyy hh:mm:ss";
            this.stopTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stopTime.Location = new System.Drawing.Point(274, 76);
            this.stopTime.Name = "stopTime";
            this.stopTime.Size = new System.Drawing.Size(126, 20);
            this.stopTime.TabIndex = 13;
            this.stopTime.ValueChanged += new System.EventHandler(this.schedulerParametersChanged);
            // 
            // interval
            // 
            this.interval.Location = new System.Drawing.Point(77, 1);
            this.interval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.interval.Name = "interval";
            this.interval.Size = new System.Drawing.Size(72, 20);
            this.interval.TabIndex = 0;
            this.interval.ThousandsSeparator = true;
            this.interval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.interval.ValueChanged += new System.EventHandler(this.schedulerParametersChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Start time";
            // 
            // totalShotsCount
            // 
            this.totalShotsCount.Location = new System.Drawing.Point(274, 50);
            this.totalShotsCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.totalShotsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.totalShotsCount.Name = "totalShotsCount";
            this.totalShotsCount.Size = new System.Drawing.Size(72, 20);
            this.totalShotsCount.TabIndex = 1;
            this.totalShotsCount.ThousandsSeparator = true;
            this.totalShotsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.totalShotsCount.ValueChanged += new System.EventHandler(this.schedulerParametersChanged);
            // 
            // startTime
            // 
            this.startTime.CustomFormat = "MM.dd.yyyy hh:mm:ss";
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(60, 50);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(126, 20);
            this.startTime.TabIndex = 11;
            this.startTime.ValueChanged += new System.EventHandler(this.schedulerParametersChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 391);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.clearImagesButton);
            this.Controls.Add(this.deleteParameterButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "MainForm";
            this.Text = "Noisy mouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cameraInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBindingSource)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.parametersTabPage.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.schedulerTabControl.ResumeLayout(false);
            this.schedulerPanel.ResumeLayout(false);
            this.schedulerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalShotsCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button deleteParameterButton;
        private System.Windows.Forms.Button clearImagesButton;
        private System.Windows.Forms.BindingSource imageBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn cameraDisplayStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parametersDisplayStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handlerDisplayStringDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cameraInfoBindingSource;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage parametersTabPage;
        private System.Windows.Forms.TabPage schedulerTabControl;
        private System.Windows.Forms.Button refreshCameraListButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addABButton;
        private System.Windows.Forms.Button addEBButton;
        private System.Windows.Forms.ComboBox apertureComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox isoComboBox;
        private System.Windows.Forms.Button addNewShoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox imageQualityComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox exposalComboBox;
        private System.Windows.Forms.Button setOutputDirButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox outputDirectoryTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox saveToComboBox;
        private System.Windows.Forms.ListBox cameraInfoListBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown interval;
        private System.Windows.Forms.Button stopSchedulerButton;
        private System.Windows.Forms.Button startSchedulerbutton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown totalShotsCount;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker stopTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox schedulerEnabled;
        private System.Windows.Forms.RadioButton byStopTime;
        private System.Windows.Forms.RadioButton byTotalShots;
        private System.Windows.Forms.Panel schedulerPanel;
        private System.Windows.Forms.Panel controlPanel;
    }
}

