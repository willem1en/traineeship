using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace NSClient
{
    public partial class Form1 : Form
    {
        List<Station> stationList;
        HttpClient client = new HttpClient { BaseAddress = new Uri("https://xanderwemmers.nl/api/ns/") };
        
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string data = await client.GetStringAsync("");

            stationList = JsonConvert.DeserializeObject<List<Station>>(data);
            var sortedStationList = from st in stationList
                        orderby st.Name
                        where st.Country == "NL"
                        select st;

            lstbxStations.DataSource = sortedStationList.ToList();
        }

        private void lstbxStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selectedStation = lstbxStations.SelectedItem as Station;

            string data = client.GetStringAsync(selectedStation.Code).Result;

            var departureTimes = JsonConvert.DeserializeObject<List<DepartureTime>>(data);
            dgvStations.DataSource = departureTimes;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var newStationList = from st in stationList
                                 where st.Name.ToLower().Contains(txtSearch.Text.ToLower())
                                 select st;
            lstbxStations.DataSource = newStationList.ToList();
        }
    }
}
