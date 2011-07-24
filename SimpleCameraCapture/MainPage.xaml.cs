using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;

namespace SimpleCameraCapture
{
	public partial class MainPage : PhoneApplicationPage
	{
		CameraCaptureTask camera = new CameraCaptureTask();

		public MainPage()
		{
			InitializeComponent();

			camera.Completed += new EventHandler<PhotoResult>(camera_Completed);
		}

		void camera_Completed(object sender, PhotoResult e)
		{
			switch (e.TaskResult)
			{
				case TaskResult.OK:
					BitmapImage bmp = new BitmapImage();
					bmp.SetSource(e.ChosenPhoto);
					takenPicture.Source = bmp;
					break;
				case TaskResult.Cancel:
					MessageBox.Show("User cancelled picture taking.");
					break;
				case TaskResult.None:
					MessageBox.Show("Picture capture unsuccessful.");
					break;
			}
		}

		private void takeThePic_Click(object sender, RoutedEventArgs e)
		{
			camera.Show();
		}
	}
}