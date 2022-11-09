using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Src.Modelos;

namespace ToDoListAPI.Src.Contextos
{

    /// <summary>
    /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Felipe Flor</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/10/2022</para>
    /// </summary>

    public class ToDoListContexto : DbContext
    {
        #region Atributos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lista> Listas { get; set; }

        #endregion


        #region Construtores
        public ToDoListContexto(DbContextOptions<ToDoListContexto> opt) : base(opt)
        {

        }

        #endregion

    }
}
