using APICinema.Model;

namespace APICinema.DTOS
{
    public class UsuarioCreateDto
    {
     public UsuarioCreateDto()
        {
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }
            public string NomeCompleto { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; } 
            public string Cpf { get; set; }
            public string Apelido { get; set; }
            public string DataNascimento { get; set; }
            public string Celular { get; set; }
            public string Genero { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public EnderecoDto Endereco { get; set; }
        }
    }
