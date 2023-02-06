using System;
using System.Windows;
using System.Windows.Threading;

namespace authoriaziton
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string _userLogin = "123";
        private const string _userPassword = "123";

        private DispatcherTimer _timer = new DispatcherTimer();
        private int _counterTime = 60;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_counterTime != 0)
            {
                _counterTime--;
            }
            newCodeTimer.Text = $"Получить новый код можно через {_counterTime} секунд";

        }

        private void signIn_Click(object sender, RoutedEventArgs e)
        {
            if (inputLogin.Text == _userLogin && inputPassword.Password.ToString() == _userPassword)
            {
                Random createRandomDigit = new Random();

                int randomDigit = createRandomDigit.Next(10000, 100000);

                CreateVerificationCodeWindow createCode = new CreateVerificationCodeWindow(randomDigit);
                createCode.ShowDialog();

                InputVerificationCodeWindow inputCode = new InputVerificationCodeWindow();
                inputCode.ShowDialog();

                if (String.Equals(inputCode.EnteredVerificationCode, randomDigit.ToString()))
                {
                    MessageBox.Show("Поздравляем!", "Ура");
                }
                else if (inputCode.EnteredVerificationCode != "")
                {
                    MessageBox.Show("Код неверный!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введены неверные данные", "Ошибка");
            }
        }
    }
}
