using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AnaliseEquipesApp
{
    public partial class Form1 : Form
    {
        readonly string titloGraficoPizza = "Quantidade de jogadores por idade";

        public Form1() {
            InitializeComponent();
            chrAlturas.Palette = ChartColorPalette.BrightPastel;
            chrAlturas.Titles.Add("Média de altura dos times");
            chrAlturas.ChartAreas[0].AxisY.Maximum = 2;

            chrIdades.Legends.Clear();
            chrIdades.Legends.Add("Legenda");
            chrIdades.Legends[0].Title = titloGraficoPizza;
            chrIdades.Series.Clear();
            chrIdades.Series.Add(titloGraficoPizza);
            chrIdades.Series[titloGraficoPizza].ChartType = SeriesChartType.Pie;
        }

        private void CarregarToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dialogArquivo = new OpenFileDialog();
            dialogArquivo.Filter = "Arquivos separados por vírgulas (*.csv)|*.csv|" +
                "Todos os arquivos (*.*)|*.*";
            DialogResult resultado = dialogArquivo.ShowDialog();
            if (resultado == DialogResult.OK) {
                string caminhoArquivo = dialogArquivo.FileName;
                try {
                    // Processa os dados do arquivo e transforma em uma lista de jogadores.
                    List<Jogador> jogadores = CarregarJogadores(caminhoArquivo);
                    AtualizarGraficoAlturas(jogadores);
                    AtualizarGraficoIdades(jogadores);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AtualizarGraficoIdades(List<Jogador> jogadores) {
            chrIdades.Series.Clear();
            chrIdades.Series.Add(titloGraficoPizza);
            chrIdades.Series[titloGraficoPizza].ChartType = SeriesChartType.Pie;
            var resultados = jogadores.GroupBy(j => new { Idade = Math.Floor(j.Idade) })
                .Select(j => new {
                    j.Key.Idade,
                    Quantidade = j.Count()
                })
                .OrderBy(j => j.Idade)
                .ToList();
            foreach (var resultado in resultados) {
                chrIdades.Series[titloGraficoPizza].Points.AddXY(resultado.Idade, resultado.Quantidade);
            }
        }

        private void AtualizarGraficoAlturas(List<Jogador> jogadores) {
            chrAlturas.Series.Clear();
            var resultados = jogadores.GroupBy(j => new { j.Equipe })
                .Select(j => new {
                    j.Key.Equipe,
                    AlturaMedia = j.Average(n => n.Altura)
                })
                .OrderBy(j => j.Equipe)
                .ToList();
            foreach (var resultado in resultados) {
                Series series = chrAlturas.Series.Add(resultado.Equipe);
                series.Points.Add(resultado.AlturaMedia);
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private List<Jogador> CarregarJogadores(string caminhoArquivoDados) {
            List<Jogador> jogadores = new List<Jogador>();
            if (string.IsNullOrEmpty(caminhoArquivoDados)) {
                throw new ArgumentNullException(nameof(caminhoArquivoDados));
            }
            if (!File.Exists(caminhoArquivoDados)) {
                throw new FileNotFoundException("O arquivo com os dados dos jogadores não foi encontrado.", caminhoArquivoDados);
            }
            using (StreamReader sr = File.OpenText(caminhoArquivoDados)) {
                string linha = sr.ReadLine(); // Consome a primeira linha do arquivo, que é o cabeçalho
                while (sr.Peek() >= 0) {
                    linha = sr.ReadLine();
                    string[] elementosLinha = linha.Split(';');
                    if (elementosLinha.Length < 6) {
                        throw new FileLoadException("Os dados no arquivo de jogadores estão em um formato inválido.");
                    }
                    Jogador jogador = new Jogador() {
                        Nome = elementosLinha[0],
                        Equipe = elementosLinha[1],
                        Posicao = elementosLinha[2],
                        Altura = float.Parse(elementosLinha[3], CultureInfo.InvariantCulture.NumberFormat) * 0.0254f,
                        Peso = float.Parse(elementosLinha[4], CultureInfo.InvariantCulture.NumberFormat) * 0.453592f,
                        Idade = float.Parse(elementosLinha[5], CultureInfo.InvariantCulture.NumberFormat)
                    };
                    jogadores.Add(jogador);
                }
            }
            return jogadores;
        }
    }
}
