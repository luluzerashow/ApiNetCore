using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Models
{
    [Table("002_Usuario", Schema="App01")]
    public class Usuario : BaseModels
    {
        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Usuario")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "O usuario deve ter 7 caracteres.")]
        public string User { get; set; }

        [DisplayName("Senha")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O usuario deve ter 6 caracteres.")]
        [Required(ErrorMessage = "A senha é obrigatório", AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [DisplayName("Perfil")]
        [Required(ErrorMessage = "O perfil é obrigatório", AllowEmptyStrings = false)]
        public int PerfilId { get; set; }

        [ForeignKey("PerfilId")]
        public virtual Perfil Perfil { get; set; }
    }
}