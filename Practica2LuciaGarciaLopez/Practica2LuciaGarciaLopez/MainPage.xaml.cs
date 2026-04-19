namespace Practica2LuciaGarciaLopez
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        string userInputText = string.Empty;
        string passwordInputText = string.Empty;

        bool isUserValid = false;
        bool isPasswordValid = false;

        void OnUserEntryCompleted(object sender, EventArgs e)
        {
            userInputText = ((Entry)sender).Text;

            if (userInputText == "User1")
            {
                isUserValid = true;
            }
            else
            {
                isUserValid = false;
            }
            CanLogin();
        }

        void OnPasswordEntryCompleted(object sender, EventArgs e)
        {
            passwordInputText = ((Entry)sender).Text;
            if (passwordInputText == "Password1")
            {
                isPasswordValid = true;
            }
            else
            {
                isPasswordValid = false;
            }
            CanLogin();
        }

        void CanLogin()
        {
            if (isUserValid == true && isPasswordValid == true)
            {
                var appshell = Application.Current.MainPage as AppShell;
                if (appshell != null)
                    appshell.FlyoutBehavior = FlyoutBehavior.Flyout;

                DisplayAlert("Login Exitoso", "Bienvenido " + userInputText, "Aceptar");
            }
            //Para evitar que se muestre el mensaje de error antes de que el usuario haya ingresado ambos campos
            else if (isUserValid == false)
            {
                return;
            }
            else
            {
                var appshell = Application.Current.MainPage as AppShell;
                if (appshell != null)
                    appshell.FlyoutBehavior = FlyoutBehavior.Disabled;
                DisplayAlert("Login Fallido", "Usuario o contraseña incorrectos", "Aceptar");
            }
        }
    }
}
