using Api.Domain.Models;

namespace Api.Domain.ViewModels
{
    public class UsuarioView : BaseModels
    {
        public string User { get; set; }
        
        public string Nome { get; set; }

        public string Senha { get; set; }

        public int PerfilId { get; set; }
    }
}