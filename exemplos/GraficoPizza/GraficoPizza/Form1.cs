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

namespace GraficoPizza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DesenhaGraficoPizza();
        }

        private void DesenhaGraficoPizza()
        {
            //reset your chart series and legends
            chart1.Series.Clear();
            chart1.Legends.Clear();

            //Add a new Legend(if needed) and do some formating
            chart1.Legends.Add("MyLegend");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].Title = "Estados";
            chart1.Legends[0].BorderColor = Color.Black;

            string seriesname = "Votação do candidato hipotético";

            chart1.Series.Add(seriesname);
            //set the chart-type to "Pie"
            chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

            //add some datapoints so the series. in this case you can pass the values to this method
            ListaEstados lista = new ListaEstados();
            foreach (Estado estado in lista.Estados)
            {
                chart1.Series[seriesname].Points.AddXY(estado.Sigla, estado.Votacao);
            }
        }
    }
}
