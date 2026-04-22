using Microsoft.Maui.Controls;

namespace Practica2LuciaGarciaLopez;

public partial class Configuracion : ContentPage
{
	public Configuracion()
	{
		InitializeComponent();

        Application.Current.Resources["customFont"] = "AlteHaasGroteskRegular.ttf#AlteHaasGroteskRegular";
        Application.Current.Resources["TextoSize"] = 18.0;
    }

    /// <summary>
    /// Evento del slider de tamaño de texto, actualiza el recurso de tamaño de texto en la aplicación para que se refleje en todas las páginas que lo utilizan.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnSizeChanged(object sender, ValueChangedEventArgs e)
    {
        Application.Current.Resources["TextoSize"] = e.NewValue;
    }

    /// <summary>
    /// Evento del picker de fuentes, actualiza el recurso de fuente personalizada en la aplicación para que se refleje en todas las páginas que lo utilizan.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnFontChanged(object sender, EventArgs e)
    {
        if (fontPicker.SelectedIndex != -1)
        {
            string selectedFont = fontPicker.Items[fontPicker.SelectedIndex];
            Application.Current.Resources["customFont"] = selectedFont;
        }
    }

    /// <summary>
    /// Evento del switch de tema, actualiza el tema de la aplicación entre claro y oscuro según el valor del switch.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnThemeToggled(object sender, ToggledEventArgs e)
    {
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }
}