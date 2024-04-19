namespace ClimaTempoSarah;

public partial class MainPage : ContentPage
{
	int count = 0;
	Results results = new Results();

	public MainPage()
	{
		InitializeComponent();
		TestaLayout();
		PreencherTela();
	}
	void PreencherTela()
	{
		LabelTemperatura.Text=results.temp.ToString();
		LabelChuva.Text=results.rain.ToString();
		LabelUmidade.Text=results.humidity.ToString();
		LabelAmanhecer.Text=results.sunrise;
		LabelAnoitecer.Text=results.sunset;
		LabelForça.Text=results.wind_speedy;
		LabelDireção.Text=results.wind_direction.ToString();
		LabelFaseDaLua.Text=results.moon_phase;
		LabelDescrição.Text=results.description;
		LabelCidade.Text=results.city;

		if (results.currently=="dia")
		{
			if (results.rain>=2)
			ImagemDeFundo.Source="diachuvoso.jpg";
			else if (results.cloudiness>=1)
			ImagemDeFundo.Source="dianublado.jpg";
			else
			ImagemDeFundo.Source="diaensolarado.jpg";

		}
		else
		{
			if (results.rain>=5)
			ImagemDeFundo.Source="noitechuvosa.jpg";
			else if (results.cloudiness>=7)
			ImagemDeFundo.Source="noitenublada.jpg";
			else
			ImagemDeFundo.Source="noitelimpa.jpg";
		}
	}

	void TestaLayout()
	{
		results.temp=25;
		results.description="Tempo Nublado";
		results.condition_code="28";
		results.img_id="28";
		results.city="Apucarana,PR";
		results.rain=5;
		results.cloudiness=2;
		results.humidity=90;
		results.sunrise="06:15";
		results.sunset="18:25";
		results.wind_speedy="4,99 km/h";
		results.wind_direction=40;
		results.moon_phase="Crescente";
		results.currently="noite";

	}
}

