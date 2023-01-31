using System;
using System.Windows;
using System.Windows.Threading;

namespace authoriaziton
{
    public partial class InputVerificationCodeWindow : Window
    {
        private string _EnteredVerificationCode = "";

        public InputVerificationCodeWindow()
        {
            InitializeComponent();

            CreateTimer();
        }

        private void CreateTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0,0,10);
            timer.Tick += new System.EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Время вышло", "Внимание");
            this.Close();
        }

        private void checkVerificationCode_Click(object sender, RoutedEventArgs e)
        {
            _EnteredVerificationCode = inputVerificationCode.Text;
            this.Close();
        }

        private void inputVerificationCode_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (inputVerificationCode.Text.Length == 5)
            {
                checkVerificationCode.IsEnabled = true;
            }
            else
            {
                checkVerificationCode.IsEnabled = false;
            }
        }

        public string EnteredVerificationCode
        {
            get { return _EnteredVerificationCode; }
        }
    }
}
