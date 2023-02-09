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
        private int _countErrorLogin = 0;

        private void CheckCode()
        {
            Random createRandomDigit = new Random();

            int randomDigit = createRandomDigit.Next(10000, 100000);

            CreateVerificationCodeWindow createCode = new CreateVerificationCodeWindow(randomDigit);
            createCode.ShowDialog();

            InputVerificationCodeWindow inputCode = new InputVerificationCodeWindow(randomDigit);
            inputCode.ShowDialog();

            if (inputCode.ReturnErrorCode == 0)
            {
                MessageBox.Show("Поздравляем!", "Ура");
                getNewCode.IsEnabled = false;
            }
            else
            {
                if (_countErrorLogin < 1)
                {
                    _countErrorLogin++;

                    if (inputCode.ReturnErrorCode == 1)
                    {
                        MessageBox.Show("Код неверный!", "Ошибка");
                    }
                    else
                    {
                        MessageBox.Show("Время вышло!", "Ошибка");
                    }
                    signIn.IsEnabled = false;
                    inputLogin.IsEnabled = false;
                    inputPassword.IsEnabled = false;
                    newCodeTimer.Visibility = Visibility.Visible;
                    newCodeTimer.Text = $"Получить новый код можно через {_counterTime} секунд";
                    _timer.Interval = new TimeSpan(0, 0, 1);
                    _timer.Tick += new EventHandler(Timer_Tick);
                    _timer.Start();
                }
                else
                {
                    _countErrorLogin = 0;
                    for (int i = 0; i<2;i++)
                    {
                        CapthcaFieldWindow captchaField = new CapthcaFieldWindow();
                        captchaField.ShowDialog();
                        if (captchaField.ReturnErrorCode == 1)
                        {
                            MessageBox.Show("Неверный ввод!", "Ошибка");
                            _countErrorLogin++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (_countErrorLogin == 2)
                    {
                        MessageBox.Show("Серьезно?");
                        MessageBox.Show("-_-");
                        MessageBox.Show("До свидания");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Добро пожаловать!", "Удачный вход");
                        getNewCode.IsEnabled = false;
                    }
                    
                }
            }
        }

        private void signIn_Click(object sender, RoutedEventArgs e)
        {
            if (inputLogin.Text == _userLogin && inputPassword.Password.ToString() == _userPassword)
            {
                CheckCode();
            }
            else
            {
                MessageBox.Show("Введены неверные данные", "Ошибка");
            }
        }

        private void getNewCode_Click(object sender, RoutedEventArgs e)
        {
            CheckCode();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_counterTime != 0)
            {
                _counterTime--;
                _timer.Start();
                newCodeTimer.Text = $"Получить новый код можно через {_counterTime} секунд";
            }
            else
            {
                newCodeTimer.Visibility = Visibility.Collapsed;
                getNewCode.Visibility = Visibility.Visible;
                _timer.Stop();
            }
        }
    }
}
