﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoListAPI.Src.Modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_usuarios no banco.</para>
    /// <para>Criado por: Felipe Flor</para>
    /// <para>Versão: 1.0</para>
    [Table("tb_usuarios")]
    public class Usuario
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [JsonIgnore, InverseProperty("Criador")]
        public List<Lista> MinhasListas { get; set; }
        #endregion
    }
}
