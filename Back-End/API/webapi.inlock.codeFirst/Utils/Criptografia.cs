namespace webapi.inlock.codeFirst.Utils
{
    public static class Criptografia
    {
        /// <summary>
        /// Gera uma hash a partir de uma senha
        /// </summary>
        /// <param name="senha">Senha que receberá a hash</param>
        /// <returns>Senha criptografada</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
        /// <summary>
        /// Verifica se a hash da senha informada é igual a hash salva no banco
        /// </summary>
        /// <param name="senhaForm">Senha informada pelo usuário</param>
        /// <param name="senhaHash">Senha cadastrada no banco</param>
        /// <returns>True or False (senha verdadeira ?)</returns>
        public static bool CompararHash(string senhaForm, string senhaHash)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaHash);
        }
    }
}
