﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();
            apiURL = "https://localhost:44363";
            httpClient = new HttpClient();

        }

        private async  void btnIniciar_Click(object sender, EventArgs e)
        {
            // await Thread.Sleep(5000);

            loadinggif.Visible = true;
            // await Task.Delay(5000);
            await Esperar();
            var nombre = txtInput.Text;
            try
            {
                var saludo =   ObtenerSaludo(nombre);
               // MessageBox.Show(saludo);
            }catch(HttpRequestException ex)
            {
                MessageBox.Show(ex.Message );
            }
            
            loadinggif.Visible = false;
        }

        private async Task Esperar()
        {
            await Task.Delay(0);
        }

        private async Task<string> ObtenerSaludo(string nombre)
        {
            using(var respuesta=await    httpClient.GetAsync($"{apiURL}/saludos4/{nombre}"))
            {
                respuesta.EnsureSuccessStatusCode();
                var saludo =await   respuesta.Content.ReadAsStringAsync();
                return saludo;
            }
        }
    }
}
