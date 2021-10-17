using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("667a7c56-01b0-43d2-aaba-2ea0c7243274"), new Jogo{Id = Guid.Parse("667a7c56-01b0-43d2-aaba-2ea0c7243274"), Nome = "Fifa 21", Produtora = "EA", Preco = 200} },
            {Guid.Parse("0832ad86-2025-48b9-8899-1671345c7fac"), new Jogo{Id = Guid.Parse("0832ad86-2025-48b9-8899-1671345c7fac"), Nome = "Fifa 20", Produtora = "EA", Preco = 190} },
            {Guid.Parse("f954e7d1-f3e4-47dd-a6e5-ebf54a15fee9"), new Jogo{Id = Guid.Parse("f954e7d1-f3e4-47dd-a6e5-ebf54a15fee9"), Nome = "Fifa 19", Produtora = "EA", Preco = 180} },
            {Guid.Parse("7583e864-9780-4cff-81eb-37e131c3006a"), new Jogo{Id = Guid.Parse("7583e864-9780-4cff-81eb-37e131c3006a"), Nome = "Fifa 18", Produtora = "EA", Preco = 170} },
            {Guid.Parse("60085408-0331-4bf1-a7f9-6afcd28d8293"), new Jogo{Id = Guid.Parse("60085408-0331-4bf1-a7f9-6afcd28d8293"), Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80} },
            {Guid.Parse("a219c21d-8ba6-41a9-89b3-b5bdcf240fbe"), new Jogo{Id = Guid.Parse("a219c21d-8ba6-41a9-89b3-b5bdcf240fbe"), Nome = "Grand Theaft Auto V", Produtora = "Rockstar", Preco = 190} }     
        };
        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
           //não implementada
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
            {
                return null;
            }
            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                {
                    retorno.Add(jogo);
                }
            }
            return Task.FromResult(retorno);
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }
    }
}
