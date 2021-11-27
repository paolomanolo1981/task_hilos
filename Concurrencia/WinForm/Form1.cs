using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async  void btnIniciar_Click(object sender, EventArgs e)
        {
            // await Thread.Sleep(5000);

            loadinggif.Visible = true;
            // await Task.Delay(5000);
            await Esperar();
            MessageBox.Show("  han ppasado 5 segundos");
            loadinggif.Visible = false;
        }

        public async Task Esperar()
        {
            await Task.Delay(5000);
        }
    }
}
