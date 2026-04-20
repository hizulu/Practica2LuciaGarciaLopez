using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace Practica2LuciaGarciaLopez
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            Application.Current.Resources["customFont"] = "AlteHaasGroteskRegular.ttf#AlteHaasGroteskRegular";
            Application.Current.Resources["TextoSize"] = 18.0;
            Application.Current.Resources["TituloSize"] = 18.0*2;
            Application.Current.UserAppTheme = AppTheme.Light;
        }

        string userInputText = string.Empty;
        string passwordInputText = string.Empty;

        bool isUserValid = false;
        bool isPasswordValid = false;
        bool isPasswordEmpty = true;

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
                isPasswordEmpty = false;
            }
            else if (passwordInputText == "")
            {
                isPasswordEmpty = true;
            }
            else
            {
                isPasswordValid = false;
                isPasswordEmpty = false;
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
            else if (isUserValid == false || isPasswordEmpty == true)
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
        private async void OnHuellaClicked(object sender, EventArgs e)
        {
            var request = new AuthenticationRequestConfiguration("Autenticación", "Autenticar con huella");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (result.Authenticated)
                await DisplayAlert("Acceso", "Acceso concedido", "Cerrar");
            else
                await DisplayAlert("Acceso", "Acceso denegado", "Cerrar");
        }

    }
}
