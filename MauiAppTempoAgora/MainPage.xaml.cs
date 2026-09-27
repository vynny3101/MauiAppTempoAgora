using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if(t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"latitude: {t.lat} \n" +
                                         $"Longitude: {t.lon} \n" +
                                         $"Nascer do Sol: {t.nascerdosol} \n" +
                                         $"Por do Sol; {t.prdosol} \n" +
                                         $"Temperatura Máxima: {t.temp_max} \n" +
                                         $"Temperatura Minima: {t.temp_min} \n";


                        lbl_res.Text = dados_previsao;

                    } else
                    {
                        lbl_res.Text = "Sem dados de Previsão.";

                    }
                }
                else
                {
                    lbl_res.Text = "Preencha a cidade.";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Ok"); 
            }
        }
    }
}
