using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace POCfrontend
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            Task.Run(() => PollZoneStatus());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialisation si nécessaire
        }

        private async Task PollZoneStatus()
        {
            while (true)
            {
                await UpdateZoneLabels();
                await Task.Delay(2000); // Poll every 2 seconds
            }
        }

        private async Task UpdateZoneLabels()
        {
            try
            {
                string url = "http://10.1.11.24:5000/api/status"; // Assurez-vous que l'IP et le port correspondent à ceux de votre Raspberry Pi et Flask
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var status = JsonConvert.DeserializeObject<ZoneStatus>(content);

                    lblZone1.BackColor = status.EtatZone1 == "ON" ? Color.Red : Color.White;
                    lblZone2.BackColor = status.EtatZone2 == "ON" ? Color.Red : Color.White;
                    lblZone3.BackColor = status.EtatZone3 == "ON" ? Color.Red : Color.White;
                    lblZone4.BackColor = status.EtatZone4 == "ON" ? Color.Red : Color.White;
                }
                else
                {
                    MessageBox.Show("Échec de la récupération de l'état des zones. Code d'erreur: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la communication avec le Raspberry Pi: " + ex.Message);
            }
        }

        public class ZoneStatus
        {
            public string EtatZone1 { get; set; }
            public string EtatZone2 { get; set; }
            public string EtatZone3 { get; set; }
            public string EtatZone4 { get; set; }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "http://10.1.11.24:5000/api/method/activate"; // Assurez-vous que l'IP et le port correspondent à ceux de votre Raspberry Pi et Flask
                HttpResponseMessage response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Activation réussie.");
                    await UpdateZoneLabels();
                }
                else
                {
                    MessageBox.Show("Échec de l'activation. Code d'erreur: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la communication avec le Raspberry Pi: " + ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "http://10.1.11.24:5000/api/method/deactivate"; // Assurez-vous que l'IP et le port correspondent à ceux de votre Raspberry Pi et Flask
                HttpResponseMessage response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Désactivation réussie.");
                    lblZone1.BackColor = Color.White;
                    lblZone2.BackColor = Color.White;
                    lblZone3.BackColor = Color.White;
                    lblZone4.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("Échec de la désactivation. Code d'erreur: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la communication avec le Raspberry Pi: " + ex.Message);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "http://10.1.11.24:5000/api/method/reset"; // Assurez-vous que l'IP et le port correspondent à ceux de votre Raspberry Pi et Flask
                HttpResponseMessage response = await _httpClient.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Réinitialisation réussie.");
                    lblZone1.BackColor = Color.White;
                    lblZone2.BackColor = Color.White;
                    lblZone3.BackColor = Color.White;
                    lblZone4.BackColor = Color.White;
                }
                else
                {
                    MessageBox.Show("Échec de la réinitialisation. Code d'erreur: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la communication avec le Raspberry Pi: " + ex.Message);
            }
        }
    }
}