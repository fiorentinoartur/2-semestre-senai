namespace webapi.Filmes.manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Boolean Permissao { get; set; }
    }
}
