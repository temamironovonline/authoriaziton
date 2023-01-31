using System;
using System.Windows;

namespace authoriaziton
{
    public partial class MainWindow : Window
    {
        private const string _userLogin = "123";
        private const string _userPassword = "123";

        public MainWindow()
        {
            InitializeComponent();
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
                else
                {
                    MessageBox.Show("Код неверный!");
                }
            }
            else
            {
                MessageBox.Show("Введены неверные данные");
            }
        }
    }
}
