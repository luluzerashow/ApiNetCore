using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Models
{
    public class BaseModels
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Data Criação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
         public DateTime DataCriacao { get; set; }

        [DisplayName("Data Atualização")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
         public DateTime DataAtualizacao { get; set; }
    }
}