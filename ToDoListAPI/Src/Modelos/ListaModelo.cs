using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Src.Modelos
{

    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_list no banco.</para>
    /// <para>Criado por: Felipe Flor</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/10/2022</para>
    /// </summary>

    [Table("tb_lists")]
    public class Lista
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Task { get; set; }
        public bool Status { get; set; }

        [ForeignKey("fk_usuario")]
        public Usuario Criador { get; set; }

        #endregion

    }
}
