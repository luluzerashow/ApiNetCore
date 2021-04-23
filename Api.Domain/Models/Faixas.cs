using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Models
{
    [Table("003_Faixas", Schema="App01")]
    public class Faixas : BaseModels
    {
        [DisplayName("Cor")]
        [Required(ErrorMessage="A cor é obrigatória!",AllowEmptyStrings=false)]
        public string Cor { get; set; }

        [DisplayName("Aulas Meta")]
        [Required(ErrorMessage="A Quantidade de aulas meta é obrigatória",AllowEmptyStrings=false)]
        public int Aulas_Meta { get; set; }
    }
}