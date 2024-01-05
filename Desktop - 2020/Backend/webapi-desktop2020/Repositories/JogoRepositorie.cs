using webapi_desktop2020.Contexts;
using webapi_desktop2020.Domains;
using webapi_desktop2020.Interfaces;
using webapi_desktop2020.ViewModel;

namespace webapi_desktop2020.Repositories
{
    public class JogoRepositorie : IJogos
    {
        DesktopContext ctx = new DesktopContext();

        public void Cadastrar()
        {
            DateTime novaRodada = CriarNovaRodada();


            Rodada novaRodadaBanco = new Rodada { DataInicio = novaRodada };

            ctx.Rodadas.Add(novaRodadaBanco);
     
            ctx.SaveChanges();


            var times = ctx.Selecoes.Select(t => t.Id).ToList();


            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
            var ids = ctx.Jogos.ToList();

            int id = ids.OrderByDescending(t => t.Id).Select(t => t.Id).FirstOrDefault();

                int timeCasa = random.Next(times.Count);
                int timeVisitante = random.Next(times.Count);

                while (timeCasa == timeVisitante)
                {
                    timeVisitante = random.Next(times.Count);
                }

                var jogo = new Jogo()
                {
                Id = id + 1,
                    RodadaId = novaRodadaBanco.Id,
                    SelecaoCasaId = times[timeCasa],
                    SelecaoVisitanteId = times[timeVisitante],
                    PlacarCasa = random.Next(0, 5),
                    PlacarVisitante = random.Next(0, 5),
                    Data = i < 4 ? novaRodada : novaRodada.AddDays(1)

                };
              

            
            ctx.Jogos.Add(jogo);

            ctx.SaveChanges();
            }




        }


        private DateTime CriarNovaRodada()
        {
            var rodadas = ctx.Rodadas.ToList();
            DateTime novaRodada = rodadas.OrderByDescending(r => r.DataInicio).Select(r => r.DataInicio).FirstOrDefault().AddDays(8);


            return novaRodada;
        }

        public List<JogosViewModel> Listar(int rodada)
        {
            TimeSpan horarioJogoBase = new TimeSpan(8, 0, 0);


            var jogos = ctx.Jogos
                .Where(x => x.RodadaId == rodada)
                .Select(x => new JogosViewModel
                {
                    Id = x.Id,
                    SelecaoCasaId = x.SelecaoCasaId,
                    PlacarCasa = x.PlacarCasa,
                    SelecaoVisitanteId = x.SelecaoVisitanteId,
                    PlacarVisitante = x.PlacarVisitante,
                    Data = x.Data,
                    RodadaId = x.RodadaId,
                    DataTerminoRodada = x.Rodada.DataInicio.AddDays(1),

                    HorarioJogo = horarioJogoBase.Add(new TimeSpan(2 * ((x.Id - 1) % 4), 0, 0)),

                    NomeSelecaoCasa = x.SelecaoCasa.Nome,
                    NomeSelecaoVisitante = x.SelecaoVisitante.Nome,
                    InicioRodada = x.Rodada.DataInicio
                })
                .ToList();

            return jogos;
        }

        public void atulizarPlacar(int jogo, AtualizarPlacar placar)
        {
           var jogoBuscado = ctx.Jogos.FirstOrDefault(x => x.Id == jogo);

            if (jogoBuscado != null)
            {
                jogoBuscado.PlacarCasa = placar.PlacarCasa;
                jogoBuscado.PlacarVisitante = placar.PlacarVisitante;
            }



            ctx.Jogos.Update(jogoBuscado);
            ctx.SaveChanges();
        }
    }
}


