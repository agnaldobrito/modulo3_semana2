using modulo3_semana2_ex4.Data;

namespace modulo3_semana2_ex4.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BasicAuthContext _authContext;

        public UsuarioService(BasicAuthContext authContext)
        {
            _authContext = authContext;
        }

        public bool AutenticarUsuario(string nomeUsuario, string senha)
        {
            var usuario = _authContext.Usuarios.FirstOrDefault(x => x.NomeUsuario == nomeUsuario);
            if (usuario == null) return false;
            var check = usuario.Senha.Equals(senha);
            return check;
        }
    }
}
