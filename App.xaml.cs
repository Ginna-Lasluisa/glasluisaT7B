using glasluisaS6B.Views;

namespace glasluisaS6B
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new vEstudiante());
        }
    }
}
