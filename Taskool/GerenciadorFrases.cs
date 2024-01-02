using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Taskool
{
    public class GerenciadorFrases
    {
        private List<Frases> frases;

        public GerenciadorFrases()
        {
            CarregarFrases();
        }

        public Frases CarregarFrases()
        {
            string caminhoArquivo = Path.Combine(@"C:\Users\Artur Fiorentino\OneDrive\Área de Trabalho\Olimpiadas\Taskool\obj\Debug\mensagens.json");

            if (File.Exists(caminhoArquivo))
            {
                string conteudoJson = File.ReadAllText(caminhoArquivo);
                frases = JsonConvert.DeserializeObject<List<Frases>>(conteudoJson);
            }
            else
            {
                // Se o arquivo não existir, inicializa a lista de frases vazia
                frases = new List<Frases>();
            }

            if (frases.Count > 0)
            {
                Random random = new Random();
                int indiceAleatorio = random.Next(frases.Count);
                return frases[indiceAleatorio];
            }
            else
            {
                return new Frases { Mensagem = "Sem frases disponíveis.", Autor = "" };
            }
        }

    }

}
