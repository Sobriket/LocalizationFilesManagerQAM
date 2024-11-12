using System.Windows;

namespace LocalizationFilesManager
{
    /// <summary>
    /// Logique d'interaction pour WindowDialogBox.xaml
    /// </summary>
    public partial class WindowDialogBox : Window
    {
        public WindowDialogBox()
        {
            InitializeComponent();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }

        public string Answer
        {
            get { return txtAnswer.Text; }
        }

    }
}