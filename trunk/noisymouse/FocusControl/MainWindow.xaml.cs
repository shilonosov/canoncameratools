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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Windows.Interop;

namespace FocusControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICameraNotifications, INotifyPropertyChanged
    {
        private CameraPool _cameraPool;
        private ICameraInfo _selectedCamera;
        private bool _isInLiveView;
        private LiveViewThread _lvThread;
        

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion

        public ImageSource LiveViewImage { get; private set; }

        public bool IsInLiveView
        {
            get { return _isInLiveView; }
            set
            {
                _isInLiveView = value;
                NotifyPropertyChanged("IsInLiveView");
            }
        }

        public ICameraInfo[] CameraList
        {
            get
            {
                return _cameraPool.CameraList;
            }
        }

        public ICameraInfo SelectedCamera
        {
            set
            {
                _selectedCamera = value;
                NotifyPropertyChanged("SelectedCamera");
            }
            get
            {
                return _selectedCamera;
            }
        }

        public MainWindow()
        {
            this.DataContext = this;
            _cameraPool = new CameraPool(this, Dispatcher);
            _lvThread = new LiveViewThread(_cameraPool, OnImageRecieved);
            InitializeComponent();
            NotifyPropertyChanged("IsInLiveView");
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
            //_lvThread.Pause((code)=>DoMoveFocus(howMuch));
            DoMoveFocus(howMuch);
        }

        private void DoMoveFocus(uint howMuch)
        {
            foreach (Object o in listBox1.ItemsSource)
            {
                ICameraInfo cameraInfo = (ICameraInfo)o;
                _cameraPool.MoveFocus(cameraInfo, howMuch);
            }
            //_lvThread.Resume();
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

        public void ImageRecieved(ImageFile imageFile)
        {
        }

        public void CameraDone()
        {
        }


        public void Log(string message)
        {
        }

        private void buttonAttach_Click(object sender, RoutedEventArgs e)
        {
            IsInLiveView = true;
            LiveViewCameraChanged((ICameraInfo)listBox1.SelectedItem);
        }

        private void buttonRelease_Click(object sender, RoutedEventArgs e)
        {
            IsInLiveView = false;
            StopLiveView();
        }

        private void OnImageRecieved(MemoryStream memoryStream, uint size)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                LiveViewImage = BitmapFrame.Create(memoryStream, BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.None);
                NotifyPropertyChanged("LiveViewImage");
            }));
        }


        ImageSource CreateResizedImage(ImageSource source, int width, int height)
        {
            // Target Rect for the resize operation
            Rect rect = new Rect(0, 0, width, height);

            // Create a DrawingVisual/Context to render with
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(source, rect);
            }

            // Use RenderTargetBitmap to resize the original image
            RenderTargetBitmap resizedImage = new RenderTargetBitmap(
                (int)rect.Width, (int)rect.Height,  // Resized dimensions
                96, 96,                             // Default DPI values
                PixelFormats.Default);              // Default pixel format
            resizedImage.Render(drawingVisual);

            // Return the resized image
            return resizedImage;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LiveViewCameraChanged((ICameraInfo)listBox1.SelectedItem);
        }

        private void LiveViewCameraChanged(ICameraInfo cameraInfo)
        {
            if (IsInLiveView)
            {
                SelectedCamera = cameraInfo;
                StartLiveView();
            }
        }

        private void StartLiveView()
        {
            _lvThread.Stop();
            if (SelectedCamera != null)
            {
                _lvThread.Start(SelectedCamera);
            }
        }

        private void StopLiveView()
        {
            _lvThread.Stop();
        }
    }
}
