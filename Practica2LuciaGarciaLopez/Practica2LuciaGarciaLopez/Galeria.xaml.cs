using static Practica2LuciaGarciaLopez.DatosAnimales;
using Microsoft.Maui.Devices;

namespace Practica2LuciaGarciaLopez;

public partial class Galeria : ContentPage
{
	public Galeria()
	{
		InitializeComponent();

        Application.Current.Resources["customFont"] = "AlteHaasGroteskRegular.ttf#AlteHaasGroteskRegular";
        Application.Current.Resources["TituloSize"] = 18.0 * 2;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        ImageButton imageButton = sender as ImageButton;
        string animal = imageButton.CommandParameter.ToString();

        Datos data = new Datos();
        AnimalData animalData = data.GetAnimalData(animal);

        var image = new Image
        {
            Aspect = Aspect.Center,
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Start
        };
        image.SetBinding(Image.SourceProperty, "imagen");

        var nombre = new Label
        {            
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        nombre.SetBinding(Label.TextProperty, "nombre");

        var nombreCientifico = new Label
        {
            HorizontalOptions = LayoutOptions.Center
        };
        nombreCientifico.SetBinding(Label.TextProperty, "nombreCientifico");

        var familia = new Label
        {
            HorizontalOptions = LayoutOptions.Center
        };
        familia.SetBinding(Label.TextProperty, "familia");

        var layout = new VerticalStackLayout
        {
            Padding = 20,
            Spacing = 20,
            Children =
        {
            image,
            nombre,
            nombreCientifico,
            familia
        }
        };

        var page = new ContentPage
        {
            BindingContext = animalData,
            Content = new ScrollView { Content = layout }
        };

        Navigation.PushAsync(page);
    }
}