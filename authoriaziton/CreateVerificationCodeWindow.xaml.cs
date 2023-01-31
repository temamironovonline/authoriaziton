using System.Windows;

namespace authoriaziton
{
    public partial class CreateVerificationCodeWindow : Window
    {
        public CreateVerificationCodeWindow(int verificationCode)
        {
            InitializeComponent();
            
            verificationCodeText.Text = verificationCode.ToString();
        }
    }
}
