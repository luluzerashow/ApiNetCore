using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Models
{
    [Table("001_Perfil", Schema="App01")]
    public class Perfil : BaseModels
    {
        [DisplayName("Perfil")]
        [Required(ErrorMessage="O nome é obrigatório",AllowEmptyStrings=false)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage="A descrição é obrigatório",AllowEmptyStrings=false)]
        public string Descricao { get; set; }
    }
}