using FormularioABCC.EntidadesDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FormularioABCC
{
    public partial class Form1 : Form
    {
        private static readonly string url = "https://localhost:7095/api/Productos";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indiceDep = comboBox1.SelectedIndex + 1;
            int indiceClas = comboBox2.SelectedIndex + 1;
            int indiceFam = comboBox3.SelectedIndex + 1;

            ProductosCreacionDTO prodFrm = new ProductosCreacionDTO();
            prodFrm.Sku = int.Parse(textBox1.Text);
            prodFrm.NombreArticulo = textBox2.Text;
            prodFrm.Marca = textBox3.Text;
            prodFrm.Modelo = textBox4.Text;
            prodFrm.DepartamentoId = indiceDep;
            prodFrm.ClaseId = indiceClas;
            prodFrm.FamiliaId = indiceFam;
            prodFrm.Stock = int.Parse(textBox5.Text);
            prodFrm.Cantidad = 0;
            prodFrm.FechaDeAlta = new DateTime();
            prodFrm.FechaDeBaja = new DateTime(1900, 01, 01);     
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            bool stateCheck = false;

            string sku = textBox1.Text;

            var responce = await GetHttp(sku);
            //string respuesta = await GetHttp();
            ProductosDTO prod = JsonConvert.DeserializeObject<ProductosDTO>(responce);

            if (prod.Descontinuado == 1) stateCheck = true;
            else if (prod.Descontinuado == 0) stateCheck = false;

            textBox1.Text = sku;
            textBox2.Text = prod.NombreArticulo;
            textBox3.Text = prod.Marca;
            textBox4.Text = prod.Modelo;
            comboBox1.SelectedIndex = prod.DepartamentoId - 1;
            comboBox2.SelectedIndex = prod.ClaseId - 1;
            comboBox3.SelectedIndex = prod.FamiliaId - 1;
            textBox5.Text = prod.Stock.ToString();
            textBox6.Text = prod.Cantidad.ToString();
            dateTimePicker1.Value = prod.FechaDeAlta;
            dateTimePicker2.Value = prod.FechaDeBaja;
            checkBox1.ThreeState = stateCheck;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string sku = textBox1.Text;

            var responce = await DeleteHttp(sku);
        }

        private async Task<string> GetHttp(string sku)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url + "/" + sku))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
                return string.Empty;
            }
        }

        /*private async Task<string> PostHttp()
        {
            //HttpContent input = (HttpContent)ProductosCreacionDTO();
            //var input = new ProductosCreacionDTO()
            //{
                
            //};
            
            //var input = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(url + "/CrearProducto", (HttpContent)input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
                return string.Empty;
            }
        }*/

        private async Task<string> DeleteHttp(string sku)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(url + "/" + sku))
                {
                    
                    using (HttpContent content = res.Content)
                    {
                        MessageBox.Show(((int)res.StatusCode).ToString() + "-" + res.StatusCode.ToString());
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
                return string.Empty;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

