using modulo3_semana2_ex4.Models;

namespace modulo3_semana2_ex4.Seeds
{
    public static class UserSeeds
    {
        public static List<Usuario> usuarioSeed { get; set; } = new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                NomeUsuario = "Mithrandir",
                Senha = "mellon"
            }
        };
    }
}
