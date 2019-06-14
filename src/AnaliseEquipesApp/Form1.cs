using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnaliseEquipesApp
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        private void CarregarToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialogArquivo = new OpenFileDialog();
            dialogArquivo.Filter = "Arquivos separados por vírgulas (*.csv)|*.csv|" +
                "Todos os arquivos (*.*)|*.*";
            DialogResult resultado = dialogArquivo.ShowDialog();
            if (resultado == DialogResult.OK) {
                string caminhoArquivo = dialogArquivo.FileName;
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
