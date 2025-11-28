using APICinema.Model;

namespace APICinema.DTOS
{
    public class UsuarioDto
    {
        public UsuarioDto(DateTime dataAtualizacao)
        {
            DataAtualizacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string NomeCompleto { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Genero { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
