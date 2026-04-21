using Microsoft.Maui.Controls;

namespace Practica2LuciaGarciaLopez;

public partial class Configuracion : ContentPage
{
	public Configuracion()
	{
		InitializeComponent();

        Application.Current.Resources["customFont"] = "AlteHaasGroteskRegular.ttf#AlteHaasGroteskRegular";
        Application.Current.Resources["TextoSize"] = 18.0;
        Application.Current.UserAppTheme = AppTheme.Light;
    }

    private void OnSizeChanged(object sender, ValueChangedEventArgs e)
    {
        Application.Current.Resources["TextoSize"] = e.NewValue;
    }

    private void OnFontChanged(object sender, EventArgs e)
    {
        if (fontPicker.SelectedIndex != -1)
        {
            string selectedFont = fontPicker.Items[fontPicker.SelectedIndex];
            Application.Current.Resources["customFont"] = selectedFont;
        }
    }

    private void OnThemeToggled(object sender, ToggledEventArgs e)
    {
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }
}