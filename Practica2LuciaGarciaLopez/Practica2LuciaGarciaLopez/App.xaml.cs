namespace Practica2LuciaGarciaLopez
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            //Para que la aplicación se inicie con el modo claro
            this.UserAppTheme = AppTheme.Light;
        }
    }
}
