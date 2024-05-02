using System.Text.Json;
using Microsoft.UI.Xaml.Automation.Peers;


namespace ClimaTempoSarah;

public partial class MainPage : ContentPage
{
	

	 const string Url="https://api.hgbrasil.com/weather?woeid=455927&key=99374e61";
	Resposta resposta;

	public MainPage()
	{
		InitializeComponent();
		AtualizaTempo();
	}
	

	async void AtualizaTempo()
	{
		try
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(Url);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(content);
			}
			PreencherTela();
		}
		catch (Exception e)
		{
			//erro
		}
	}

	void PreencherTela()
	{
		LabelTemperatura.Text=resposta.results.temp.ToString();
		LabelChuva.Text=resposta.results.rain.ToString();
		LabelUmidade.Text=resposta.results.humidity.ToString();
		LabelAmanhecer.Text=resposta.results.sunrise;
		LabelAnoitecer.Text=resposta.results.sunset;
		LabelForça.Text=resposta.results.wind_speedy;
		LabelDireção.Text=resposta.results.wind_direction.ToString();
		LabelFaseDaLua.Text=resposta.results.moon_phase;
		LabelDescrição.Text=resposta.results.description;
		LabelCidade.Text=resposta.results.city;

		if (resposta.results.moon_phase=="full")
			LabelFaseDaLua.Text = "Cheia";
		else if (resposta.results.moon_phase=="new")
			LabelFaseDaLua.Text = "Nova";
		else if (resposta.results.moon_phase=="growing")
			LabelFaseDaLua.Text = "Crescente";
		else if (resposta.results.moon_phase=="waning_gibbous")
			LabelFaseDaLua.Text = "Minguante";

		if (resposta.results.currently=="dia")
		{
			if (resposta.results.rain>=2)
				ImagemDeFundo.Source="diachuvoso.jpg";
			else if (resposta.results.cloudiness>=1)
				ImagemDeFundo.Source="dianublado.jpg";
			else
				ImagemDeFundo.Source="diaensolarado.jpg";

		}
		else
		{
			if (resposta.results.rain>=5)
				ImagemDeFundo.Source="noitechuvosa.jpg";
			else if (resposta.results.cloudiness>=7)
				ImagemDeFundo.Source="noitenublada.jpg";
			else
				ImagemDeFundo.Source="noitelimpa.jpg";
		}

		listaForecast.ItemsSource = resposta.results.forecast;
	}
}

