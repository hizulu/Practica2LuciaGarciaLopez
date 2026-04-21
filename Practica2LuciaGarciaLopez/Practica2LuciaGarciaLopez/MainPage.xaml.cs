using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace Practica2LuciaGarciaLopez
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Application.Current.Resources["customFont"] = "AlteHaasGroteskRegular";
            Application.Current.Resources["TextoSize"] = 18.0;
            Application.Current.Resources["TituloSize"] = 36.0;
        }

        /// <summary>
        /// Función para entrar a la aplicación después de un login exitoso, ya sea manual o biométrico
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        private async Task EntrarApp(string nombreUsuario)
        {
            var appshell = Application.Current.MainPage as AppShell;
            if (appshell != null)
            {
                appshell.FlyoutBehavior = FlyoutBehavior.Flyout;

                await DisplayAlert("Login Exitoso", $"Bienvenido {nombreUsuario}", "Aceptar");

                await Shell.Current.GoToAsync("//Galeria");
            }
        }

        /// <summary>
        /// Evento del botón de login, verifica las credenciales y llama a la función para entrar a la aplicación si son correctas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string user = userEntry.Text;
            string pass = passwordEntry.Text;

            if (user == "User1" && pass == "Password1")
            {
                await EntrarApp(user);
            }
            else
            {
                await DisplayAlert("Login Fallido", "Usuario o contraseña incorrectos", "Aceptar");
            }
        }

        /// <summary>
        /// Evento del botón de huella, utiliza el plugin de huella para autenticar al usuario y llama a la función para entrar a la aplicación si la autenticación es exitosa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnHuellaClicked(object sender, EventArgs e)
        {
            var request = new AuthenticationRequestConfiguration("Autenticación", "Accede a tu galería");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                await EntrarApp("Usuario Biométrico");
            }
            else
            {
                await DisplayAlert("Acceso", "No se pudo reconocer la huella", "Cerrar");
            }
        }
    }
}