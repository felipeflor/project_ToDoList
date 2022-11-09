using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Src.Contextos;
using ToDoListAPI.Src.Modelos;
using Microsoft.EntityFrameworkCore;

using ToDoListAPI.Src.Contextos;

namespace ToDoListAPI.Src.Repositorios.Implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IUsuario</para>
    /// <para>Criado por: Felipe Flor</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 09/11/2022</para>
    /// </summary>
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos

        private readonly ToDoListContexto _contexto;

        #endregion

        #region Construtores

        public UsuarioRepositorio(ToDoListContexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar um usuario pelo email</para>
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <return>UsuarioModelo</return>
        public async Task<Usuario> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo usuario</para>
        /// </summary>
        /// <param name="usuario">Construtor para cadastrar usuario</param>
        public async Task NovoUsuarioAsync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(
                new Usuario
                {
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha
                });
            await _contexto.SaveChangesAsync();
        }
        #endregion
    }
}
