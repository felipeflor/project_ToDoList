using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Src.Contextos;
using ToDoListAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;


namespace ToDoListAPI.Src.Repositorios.Implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar ILista</para>
    /// <para>Criado por: Felipe</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 24/10/2022</para>
    /// </summary>

    public class ListaRepositorio : ILista
    {
        #region Atributos

        private readonly ToDoListContexto _contexto;

        #endregion Atributos


        #region Construtores

        public ListaRepositorio(ToDoListContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion Construtores


        #region Métodos
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todas as listas</para>
        /// </summary>
        /// <return>Lista ListaModelo</return>
        
        public async Task<List<Lista>> PegarTodaListaAsync()
        {
            return await _contexto.Listas.ToListAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar uma lista pelo Id</para>
        /// </summary>
        /// <param name="id">Id da lista</param>
        /// <return>ListaModelo</return>
        /// <exception cref="Exception">Id não pode ser nulo</exception>

        public async Task<Lista> PegarListaPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("Id da lista não encontrado");
            return await _contexto.Listas.FirstOrDefaultAsync( l => l.Id == id);

            //funções auxiliares
            bool ExisteId(int id)
            {
                var auxiliar = _contexto.Listas.FirstOrDefault( u => u.Id == id);
                return auxiliar != null;
            }
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar uma nova lista</para>
        /// </summary>
        /// <para name="tema">Construtor para cadastrar lista</para>
        public async Task NovaListaAsync(Lista lista)
        {
            await _contexto.Listas.AddAsync(
                new Lista
                {
                    Task = lista.Task,
                    Status = lista.Status
                });
            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para atualizar uma postagem</para>
        /// </summary>
        /// <param name="postagem">Construtor para atualizar postagem</param>
        /// <exception cref="Exception">Id não pode ser nulo</exception>

        public async Task AtualizarListaAsync(Lista lista)
        {
            //implementar exception

            var listaExistente = await PegarListaPeloIdAsync(lista.Id);
            listaExistente.Task = lista.Task;
            listaExistente.Status = lista.Status;

            _contexto.Listas.Update(listaExistente);
            await _contexto.SaveChangesAsync();

            /*
            //funções auxiliares
            bool ExisteListaId(int id)
            {
                var auxiliar = _contexto.Listas.FirstOrDefault(l => l.Id == id);
                return auxiliar != null;
            }
            */

        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para deletar um tema</para>
        /// </summary>
        /// <param name="id">Id do tema</param>
        public async Task DeletarListaAsync(int id)
        {
            _contexto.Listas.Remove(await PegarListaPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }


        #endregion Métodos

    }
}
