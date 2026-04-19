namespace Practica2LuciaGarciaLopez;

public partial class Configuracion : ContentPage
{
	public Configuracion()
	{
		InitializeComponent();

        Application.Current.Resources["customFont"] = "AlteHaasGroteskRegular.ttf#AlteHaasGroteskRegular";
        Application.Current.Resources["TextoSize"] = 18.0;
    }

    void OnFontPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        if (fontPicker.SelectedIndex != -1)
        {
            string selectedFont = fontPicker.Items[fontPicker.SelectedIndex];
            Application.Current.Resources["customFont"] = selectedFont;
        }
    }
    void OnFontSizeSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        double fontSize = e.NewValue;
        Application.Current.Resources["TextoSize"] = fontSize;
        Application.Current.Resources["TituloSize"] = fontSize*2;        
    }
}