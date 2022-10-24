using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListAPI.Src.Modelos;

namespace ToDoListAPI.Src.Repositorios
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de tema</para>
    /// <para>Criado por: Felipe</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 24/10/2022</para>
    /// </summary>
    /// 
    public interface ILista
    {
        Task<List<Lista>> PegarTodaListaAsync();
        Task<Lista> PegarListaPeloIdAsync(int id);
        Task NovaListaAsync(Lista lista);
        Task AtualizarListaAsync(Lista lista);
        Task DeletarListaAsync(int id);

    }
}
