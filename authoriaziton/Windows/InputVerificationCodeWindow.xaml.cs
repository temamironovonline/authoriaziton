using System;
using System.Windows;
using System.Windows.Threading;

namespace authoriaziton
{
    public partial class InputVerificationCodeWindow : Window
    {
        private int _enteredVerificationCode = 0;
        

        private int _createdVerificationCode;

        public InputVerificationCodeWindow(int createdVerificationCode)
        {
            InitializeComponent();

            CreateTimer();

            _createdVerificationCode = createdVerificationCode;
        }

        private void CreateTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0,0,10);
            timer.Tick += new System.EventHandler(Timer_Tick);
            timer.Start();
        }

        private int _errorCode;

        private void Timer_Tick(object sender, EventArgs e)
        {
           // MessageBox.Show("Время вышло", "Внимание");
            _errorCode = 2;
            this.Close();
        }

        private void checkVerificationCode_Click(object sender, RoutedEventArgs e)
        {
            //_enteredVerificationCode = inputVerificationCode.Text;
            if (_createdVerificationCode == _enteredVerificationCode)
            {
                _errorCode = 0;
            }
            else
            {
                _errorCode = 1;
            }
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

        public int ReturnErrorCode
        {
            get { return _errorCode; }
        }
    }
}
