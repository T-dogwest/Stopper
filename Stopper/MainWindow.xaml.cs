using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Stopper
{
    public partial class MainWindow : Window
    {

        private DateTime startTime;
        private DateTime currentTime;
        private TimeSpan elapsedTime;
        private List<TimeSpan> lapTimes;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            lapTimes = new List<TimeSpan>();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);

            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTime = DateTime.Now;
            elapsedTime = currentTime - startTime;

            if (startButton.Content.ToString() == "Start")
            {
                stopperTextBlock.Text = elapsedTime.ToString(@"hh\:mm\:ss\.fff");
            }
            else
            {
                stopperTextBlock.Text = (currentTime - startTime).ToString(@"hh\:mm\:ss\.fff");
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (startButton.Content.ToString() == "Start")
            {
                startTime = DateTime.Now;
                timer.Start();
                startButton.Content = "Stop";
                lapButton.Content = "Lap";
            }
            else
            {
                timer.Stop();
                startButton.Content = "Start";
                lapButton.Content = "Reset";
            }
        }

        private void lapButton_Click(object sender, RoutedEventArgs e)
        {
            if (lapButton.Content.ToString() == "Lap")
            {
                lapTimes.Add(elapsedTime);
                lapListBox.Items.Add(elapsedTime.ToString(@"hh\:mm\:ss\.fff"));
            }
            else
            {
                startTime = DateTime.Now;
                lapTimes.Clear();
                lapListBox.Items.Clear();
                stopperTextBlock.Text = "00:00:00.000";
            }
        }
    }
   
}
