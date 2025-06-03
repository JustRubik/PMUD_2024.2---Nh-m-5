using System.Windows;

namespace LoginDemo
{
	public partial class ForgotPasswordWindow : Window
	{
		public ForgotPasswordWindow()
		{
			InitializeComponent();
		}
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Viết logic ở đây
            MessageBox.Show("Bạn đã nhấn GỬI!");
        }
    }
}