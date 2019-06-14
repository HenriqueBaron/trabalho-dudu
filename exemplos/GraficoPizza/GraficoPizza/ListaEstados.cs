using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficoPizza
{
    class ListaEstados
    {

        private List<Estado> estados;

        public ListaEstados()
        {
            estados = new List<Estado>();
            Estado e = new Estado("RS", 1734);
            estados.Add(e);
            e = new Estado("SC", 713);
            estados.Add(e);
            e = new Estado("PR", 928);
            estados.Add(e);

            // ou

            AdicionaEstado(new Estado("MG", 567));

        }

        public void AdicionaEstado(Estado e)
        {
            estados.Add(e);
        }

        internal List<Estado> Estados { get => estados; private set => estados = value; }
    }
}
