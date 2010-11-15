using System;
using System.Reflection;
using System.Windows.Forms;
using NoisyMouse.Properties;
using Source;
using System.Collections;
using System.Drawing;
using Source.Utils;
using Image=Source.Image;
using CommonUI;
using System.Windows.Threading;
using System.Data.Linq;
using System.Collections.Generic;

namespace NoisyMouse
{
    public partial class MainForm : Form, ICameraNotifications, IControllable
    {
        private readonly object _canShootSyncObject = new object();

        private readonly SaveToFolderImageFileHandler _saveToFolderImageFileHandler;
        private readonly CameraPool _cameraPool;
        private readonly Scheduler _scheduler;
        private readonly LinkedList<Image> _imagesQueue;
        

        private ICameraInfo CameraInfo
        {
            get
            {
                return (ICameraInfo)cameraInfoListBox.SelectedItem;
            }
        }

        private IsoSpeed SelectedIsoSpeedValue
        {
            get { return (IsoSpeed)isoComboBox.SelectedItem; }
        }

        private Aperture SelectedApertureValue
        {
            get { return (Aperture)apertureComboBox.SelectedItem; }
        }

        private Exposal SelectedExposalValue
        {
            get { return (Exposal)exposalComboBox.SelectedItem; }
        }

        private SaveTo SelectedSaveToMethodValue
        {
            get { return (SaveTo) saveToComboBox.SelectedItem; }
        }

        private ImageQuality SelectedImageQualityValue
        {
            get { return (ImageQuality) imageQualityComboBox.SelectedItem; }
        }

        private ShootParameters CurrentShootParameters
        {
            get
            {
                return new ShootParameters(
                    SelectedIsoSpeedValue,
                    SelectedApertureValue,
                    SelectedExposalValue,
                    SelectedSaveToMethodValue,
                    SelectedImageQualityValue);
            }
        }

        private Image CurrentImage
        {
            get
            {
                return NewImageFrom(CurrentShootParameters);
            }
        }

        private Image NewImageFrom(IShootParameters aParameters)
        {
            return new Image(CameraInfo, aParameters, NewSaveImageHandler());
        }

        private static string GetCaption()
        {
            Assembly current = Assembly.GetExecutingAssembly();
            AssemblyInformationalVersionAttribute versionInformation =
                (AssemblyInformationalVersionAttribute) current.GetCustomAttributes(typeof (AssemblyInformationalVersionAttribute), false)[0];

            return string.Format("Noisy mouse {0}", versionInformation.InformationalVersion);
        }

        public MainForm()
        {
            InitializeComponent();
            Text = GetCaption();
            _cameraPool = new CameraPool(this, Dispatcher.CurrentDispatcher);
            _saveToFolderImageFileHandler = NewSaveImageHandler();

            _scheduler = new Scheduler(this, Dispatcher.CurrentDispatcher);
            _imagesQueue = new LinkedList<Image>();
        }

        private SaveToFolderImageFileHandler NewSaveImageHandler()
        {
            return new SaveToFolderImageFileHandler(new Folder(folderBrowserDialog));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cameraInfoBindingSource.DataSource = _cameraPool.CameraList;

            if (outputDirectoryTextBox.Text == string.Empty)
            {
                outputDirectoryTextBox.Text = TemporaryFolder.CurrentDirectory;
            }
            outputDirectoryTextBox_TextChanged(this, new EventArgs());
        }

        private void RefreshCameraProcessorList()
        {
            _cameraPool.RefreshList();
            cameraInfoBindingSource.DataSource = _cameraPool.CameraList;
        }


        private void SetControlsEnabled(bool aEnabled)
        {
            controlPanel.Enabled = aEnabled;
            schedulerPanel.Enabled = aEnabled;
        }

        private void StartShooting()
        {
            BuildImagesQueue();
            CameraDone();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            StartShooting();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            _cameraPool.Dispose();

            base.Dispose(disposing);
        }

        private void AddImage(Image anImage)
        {
            imageBindingSource.Add(anImage);
        }


        private void deleteParameterButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                imageBindingSource.Remove(row.DataBoundItem);
            }
            Refresh();
        }

        private Bitmap DrawHistogram(int[] histogram, Size aSize)
        {
            Bitmap result = new Bitmap(aSize.Width, aSize.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.FillRectangle(Brushes.Black, 0, 0, result.Width, result.Height);

                float xStep = (float)result.Width / histogram.Length;

                Point maxValueAndIndex = MaxValueAndIndex(histogram);
                if (maxValueAndIndex.X > 0)
                {
                    for (int i = 0; i < histogram.Length; ++i)
                    {
                        int value = (int) ((((float) histogram[i])/maxValueAndIndex.X)*result.Height);
                        int x1 = (int) ((float) i*xStep);
                        int x2 = (int) ((float) (i + 1)*xStep);
                        g.FillRectangle(Brushes.White, new Rectangle(x1, result.Height - value, x2 - x1, result.Height));
                    }
                }

                g.DrawLine(Pens.Red, new Point((int)(maxValueAndIndex.Y * xStep) + (int)(xStep / 2), 0), new Point((int)(maxValueAndIndex.Y * xStep) + (int)(xStep / 2), result.Height));
            }
            return result;
        }

        public Point MaxValueAndIndex(int[] anArray)
        {
            Point result = new Point();
            for (int i = 0; i < anArray.Length; ++i)
            {
                if (result.X < anArray[i])
                {
                    result.X = anArray[i];
                    result.Y = i;
                }
            }
            return result;
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                Image image = ((Image)dataGridView.SelectedRows[0].DataBoundItem);
                //pictureBox.Image = shootParameters.Preview;
                //histogramBox.Image = DrawHistogram(shootParameters.Histogram.Values, histogramBox.Size);
            }

        }

        private void clearImagesButton_Click(object sender, EventArgs e)
        {
            imageBindingSource.Clear();
            Refresh();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        public void ShuttedDown()
        {
            RefreshCameraProcessorList();
            Refresh();
        }

        public void WillSoonShutDown(ICamera aCamera)
        {
            aCamera.KeepALive();
        }

        private void imageBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            runButton.Enabled = imageBindingSource.Count > 0;
        }

        private void cameraBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ICameraInfo cameraInfo = CameraInfo;
            
            if (cameraInfo != null)
            {
                SetControlsEnabled(true);

                UIHelper.FillComboBoxWith(isoComboBox, cameraInfo.AvailableIsoSpeeds, cameraInfo.CurrentIsoSpeed);
                UIHelper.FillComboBoxWith(apertureComboBox, cameraInfo.AvailableApertures, cameraInfo.CurrentAperture);
                UIHelper.FillComboBoxWith(exposalComboBox, cameraInfo.AvailableExposals, cameraInfo.CurrentExposal);
                UIHelper.FillComboBoxWith(saveToComboBox, SaveTo.SaveToValues, SaveTo.With(SaveToEnum.Save_by_downloading_to_a_host_computer));
                UIHelper.FillComboBoxWith(imageQualityComboBox, cameraInfo.AvailableImageQualities, cameraInfo.CurrentImageQuality);
            }
            else
            {
                SetControlsEnabled(false);
            }
        }

        private void outputDirectoryTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.dir = outputDirectoryTextBox.Text;
            folderBrowserDialog.SelectedPath = Settings.Default.dir;
            _saveToFolderImageFileHandler.SetPath(Settings.Default.dir);
        }

        private void setOutputDirButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = outputDirectoryTextBox.Text;
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void AddEBButton_Click(object sender, EventArgs e)
        {
            SelectExposalBracketingParameters dialog = new SelectExposalBracketingParameters();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                throw new NotImplementedException();

/*              _cameraPool.CreateExposalBracketing(CameraInfo.Id, dialog.Step, dialog.Count, CurrentShootParameters,
                    delegate(IShootParameters[] bracketing)
                    {
                        Array.ForEach(bracketing, parameters => AddImage(NewImageFrom(parameters)));
                    });
*/
//                IShootParameters[] bracketing = _cameraPool.GetCamera(CameraInfo.Id).CreateExposalBracketing(dialog.Step, dialog.Count, CurrentShootParameters);
//                Array.ForEach(bracketing, parameters => AddImage(NewImageFrom(parameters)));
            }
        }

        private void refreshCameraListButton_Click(object sender, EventArgs e)
        {
            RefreshCameraProcessorList();
            Refresh();
        }

        private void addABButton_Click(object sender, EventArgs e)
        {
            SelectApertureValuesForBrecketing dialog = new SelectApertureValuesForBrecketing(CameraInfo.AvailableApertures);
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                throw new NotImplementedException();              
//                IShootParameters[] bracketing = _cameraPool.GetCamera(CameraInfo.Id).CreateApertureBracketing(CurrentShootParameters, dialog.Apertures);
//                Array.ForEach(bracketing, parameters => AddImage(NewImageFrom(parameters)));
            }
        }

        private void addNewShoot_Click(object sender, EventArgs e)
        {
            AddImage(CurrentImage);
        }


        private void startSchedulerbutton_Click(object sender, EventArgs e)
        {
            _scheduler.Start(Convert.ToInt32(interval.Value), (int) totalShotsCount.Value);
        }

        private void stopSchedulerButton_Click(object sender, EventArgs e)
        {
            _scheduler.Stop();
        }

        private void schedulerParametersChanged(object sender, EventArgs e)
        {
            if (byTotalShots.Checked)
            {
                stopTime.Value = startTime.Value + new TimeSpan(0, 0, 0, (int) (interval.Value*totalShotsCount.Value));
            }
            if (byStopTime.Checked)
            {
                totalShotsCount.Value = Convert.ToInt32((stopTime.Value - startTime.Value).TotalSeconds / (double)interval.Value);
            }
        }

        public void CameraDone()
        {
            lock (_canShootSyncObject)
            {
                if (_imagesQueue.Count > 0)
                {
                    this.BeginInvoke(new Action(MakeAShoot));
                }
            }
        }

        public void BuildImagesQueue()
        {
            lock (_canShootSyncObject)
            {
                foreach (Image image in imageBindingSource)
                {
                    _imagesQueue.AddLast(image);
                }
            }
        }
        
        public void MakeAShoot()
        {
            lock (_canShootSyncObject)
            {
                _imagesQueue.Last.Value.Make(_cameraPool);
                _imagesQueue.RemoveLast();
            }
        }


        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}