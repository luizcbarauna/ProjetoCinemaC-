using APICinema.Model;

namespace APICinema.DTOS
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Apelido { get; set; }
        public string Celular { get; set; }
        public string Genero { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
