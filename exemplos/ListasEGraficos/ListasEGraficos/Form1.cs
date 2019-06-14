using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ListasEGraficos
{
    public partial class Form1 : Form
    {

        private string[] seriesArray = { "Cerveja", "Vinho", "Vodka", "Cachaça", "Qualquer um!" };
        
        public Form1()
        {
            InitializeComponent();
            label1.Text = seriesArray[0];
            label2.Text = seriesArray[1];
            label3.Text = seriesArray[2];
            label4.Text = seriesArray[3];
            label5.Text = seriesArray[4];
            
            // Set palette
            this.chart1.Palette = ChartColorPalette.EarthTones;

            // Set title
            this.chart1.Titles.Add("Bebidas preferidas");

            // Limita em 100
            this.chart1.ChartAreas[0].AxisY.Maximum = 100;

            CarregaGrafico(PointsArray());
        }

        private int[] PointsArray()
        {
            List<int> lista = new List<int>();
            lista.Clear();
            lista.Add((int) numericUpDown1.Value);
            lista.Add((int) numericUpDown2.Value);
            lista.Add((int) numericUpDown3.Value);
            lista.Add((int) numericUpDown4.Value);
            lista.Add((int) numericUpDown5.Value);
            return lista.ToArray();
        }

        public void CarregaGrafico(int[] pointsArray)
        {
            this.chart1.Series.Clear();

            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CarregaGrafico(PointsArray());
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CarregaGrafico(PointsArray());
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            CarregaGrafico(PointsArray());
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            CarregaGrafico(PointsArray());
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            CarregaGrafico(PointsArray());
        }
    }
}
