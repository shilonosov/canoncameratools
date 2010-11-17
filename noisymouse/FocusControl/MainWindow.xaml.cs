using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Source;
using EDSDKLib;

namespace FocusControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICameraNotifications
    {
        private CameraPool _cameraPool;
        private bool _isRecording = false;

        public MainWindow()
        {
            InitializeComponent();
            _cameraPool = new CameraPool(this, Dispatcher);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBox1.ItemsSource = _cameraPool.CameraList;
            foreach (ICameraInfo camera in _cameraPool.CameraList)
            {
                listBox1.Items.Add(camera);
            }
        }

        public void ShuttedDown()
        {
        }

        public void WillSoonShutDown(ICamera aCamera)
        {
            aCamera.KeepALive();
        }

        private void MoveFocus(uint howMuch)
        {
            foreach (Object o in listBox1.ItemsSource)
            {
                ICameraInfo cameraInfo = (ICameraInfo)o;
                _cameraPool.LockUI(cameraInfo);
                _cameraPool.MoveFocus(cameraInfo, howMuch);
                _cameraPool.UnlockUI(cameraInfo);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MoveFocus(EDSDK.EvfDriveLens_Far3);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MoveFocus(EDSDK.EvfDriveLens_Far2);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MoveFocus(EDSDK.EvfDriveLens_Far1);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MoveFocus(EDSDK.EvfDriveLens_Near3);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MoveFocus(EDSDK.EvfDriveLens_Near2);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            MoveFocus(EDSDK.EvfDriveLens_Near1);
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (_isRecording)
            {
                StopRecording();
            }
            else
            {
                StartRecordging();
            }
            _isRecording = !_isRecording;
        }

        private void StartRecordging()
        {
            foreach (Object o in listBox1.ItemsSource)
            {
                ICameraInfo cameraInfo = (ICameraInfo)o;

                //_cameraPool.LockUI(cameraInfo);
                _cameraPool.StartLiveView(cameraInfo, null);
                //camera.SendCommand((uint)EDSDK.EdsShutterButton.CameraCommand_ShutterButton_Completely);
            }
        }

        private void StopRecording()
        {
            foreach (Object o in listBox1.ItemsSource)
            {
                ICameraInfo cameraInfo = (ICameraInfo)o;

                //_cameraPool.UnlockUI(cameraInfo);
            }
        }


        public void ImageRecieved(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void CameraDone()
        {
            throw new NotImplementedException();
        }


        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}
