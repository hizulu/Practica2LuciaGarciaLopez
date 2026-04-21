using static Practica2LuciaGarciaLopez.DatosAnimales;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Controls.Shapes;

namespace Practica2LuciaGarciaLopez;

public partial class Galeria : ContentPage
{
	public Galeria()
	{
		InitializeComponent();

        Application.Current.Resources["customFont"] = "AlteHaasGroteskRegular.ttf#AlteHaasGroteskRegular";
        Application.Current.Resources["TituloSize"] = 18.0 * 2;
        Application.Current.UserAppTheme = AppTheme.Light;
    }

    /// <summary>
    /// Evento del botón de cada animal, obtiene los datos del animal seleccionado y muestra una nueva página con la información detallada del animal.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnCounterClicked(object sender, EventArgs e)
    {
        ImageButton imageButton = sender as ImageButton;
        string animal = imageButton.CommandParameter.ToString();

        Datos data = new Datos();
        AnimalData animalData = data.GetAnimalData(animal);

        // Creación de la nueva página con la información del animal
        var image = new Image
        {
            Aspect = Aspect.AspectFit,
            HeightRequest = 400,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start
        };
        image.SetBinding(Image.SourceProperty, "imagen");

        var nombre = new Label
        {
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
        };
        nombre.SetBinding(Label.TextProperty, "nombre");
        nombre.SetDynamicResource(Label.FontSizeProperty, "TituloSize");

        var nombreCientifico = new Label { HorizontalOptions = LayoutOptions.Center };
        nombreCientifico.SetBinding(Label.TextProperty, "nombreCientifico");
        nombreCientifico.SetDynamicResource(Label.FontSizeProperty, "TextoSize");

        var familia = new Label { HorizontalOptions = LayoutOptions.Center };
        familia.SetBinding(Label.TextProperty, "familia");
        familia.SetDynamicResource(Label.FontSizeProperty, "TextoSize");

        // Layout para organizar los elementos en la página
        var layout = new VerticalStackLayout
        {
            Padding = 0,
            Spacing = 20,
            Children = { image, nombre, nombreCientifico, familia }
        };

        // Creación de la página y navegación a ella
        var page = new ContentPage
        {
            Title = animal,
            Padding = new Thickness(20),
            BindingContext = animalData,
            Content = new ScrollView { Content = layout }
        };

        page.SetDynamicResource(VisualElement.BackgroundColorProperty, "AppBackgroundColorLight");

        Navigation.PushAsync(page);
    }
}