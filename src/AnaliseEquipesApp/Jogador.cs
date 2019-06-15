using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseEquipesApp
{
    /// <summary>
    /// Define a classe de domínio que representa um jogador
    /// </summary>
    public class Jogador
    {
        public string Nome { get; set; }
        public string Equipe { get; set; }
        public string Posicao { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public float Idade { get; set; }
    }
}
