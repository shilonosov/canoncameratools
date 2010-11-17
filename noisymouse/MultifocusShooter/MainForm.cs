using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonUI;
using Source;
using Source.Utils;
using EDSDKLib;
using System.Windows.Threading;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace MultifocusShooter
{
    public partial class MainForm : Form, ICameraNotifications, IImageHandler
    {
        private readonly ICameraPool _cameraPool;
        private readonly LiveViewThread _liveViewThread;

        private ICameraInfo CameraInfo
        {
            get
            {
                return (ICameraInfo)cameraInfoListBox.SelectedItem;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            _cameraPool = new CameraPool(this, Dispatcher.CurrentDispatcher);
            _liveViewThread = new LiveViewThread(_cameraPool, OnImageRecieved);
        }

        protected void OnImageRecieved(IntPtr imagePointer, uint size)
        {
            Byte[] data = new byte[size];
            Marshal.Copy(imagePointer, data, 0, (int)size);
            MemoryStream memStream = new MemoryStream(data);

            pictureBox.Image = new Bitmap(memStream);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cameraInfoBindingSource.DataSource = _cameraPool.CameraList;
            _liveViewThread.Start(CameraInfo);
        }

        public void ShuttedDown()
        {
        }

        public void WillSoonShutDown(ICamera aCamera)
        {
            aCamera.KeepALive();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _liveViewThread.Stop();
            Settings.Default.Save();
        }

        private ShootParameters CurrentShootParameters
        {
            get
            {
                return new ShootParameters(CameraInfo.CurrentIsoSpeed, CameraInfo.CurrentAperture, CameraInfo.CurrentExposal);
            }
        }

        private Source.Image CurrentImage
        {
            get
            {
                return NewImageFrom(CurrentShootParameters);
            }
        }

        private Source.Image NewImageFrom(IShootParameters aParameters)
        {
            return new Source.Image(CameraInfo, aParameters, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _cameraPool.StartLiveView(CameraInfo, Shoot);
        }

        private uint GetSpeed()
        {
            if (forwardRadioButton.Checked) {
                if (slowRadioButton.Checked) return EDSDK.EvfDriveLens_Far1;
                if (moderateRadioButton.Checked) return EDSDK.EvfDriveLens_Far2;
                if (fastRadioButton.Checked) return EDSDK.EvfDriveLens_Far3;
                throw new ApplicationException("Impossible!!!");
            } else
            if (backwardRadioButton.Checked)
            {
                if (slowRadioButton.Checked) return EDSDK.EvfDriveLens_Near1;
                if (moderateRadioButton.Checked) return EDSDK.EvfDriveLens_Near2;
                if (fastRadioButton.Checked) return EDSDK.EvfDriveLens_Near3;
                throw new ApplicationException("Impossible!!!");
            }
            throw new ApplicationException("Impossible!!!");
        }

        private void Shoot(uint parameter)
        {
            Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
            {
                int steps = Convert.ToInt32(stepsNumericUpDown.Value);
                int pause = Convert.ToInt32(pauseNumericUpDown.Value);
                while (steps > 0)
                {

                    CurrentImage.PressShutterButton(_cameraPool);
                    Thread.Sleep(CurrentImage.CameraInfo.CurrentExposal.GetDelay() + 2000);

                    MoveFocus();
                    steps--;
                }

                _cameraPool.StopLiveView(CameraInfo);
            }));
        }

        private void MoveFocus()
        {
            for (int j = 0; j < multiplierNumericUpDown.Value; ++j)
            {
                _cameraPool.MoveFocus(CurrentImage.CameraInfo, this.GetSpeed());
            }
        }


        public void CameraDone()
        {
        }


        public string DisplayString
        {
            get { return ""; }
        }

        void IImageHandler.Handle(ImageFile anImageFile)
        {
        }


        public void Log(string message)
        {
            logTichTextBox.Text += message + "\n";
        }
    }
}
