using Avalonia.Controls;

namespace AvaloniaRisovaviti
{
    public partial class RegistrationPage : UserControl
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Regist_Click(object? obj, Avalonia.Interactivity.RoutedEventArgs routedEvent)
        {
            this.Content = new MainPage();
        }
    }
}
