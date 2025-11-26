using APICinema.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace APICinema.Model
{
    public class Usuario
    {
        public Usuario()
        {
           
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeCompleto { get; set; }
        [Required]
        [StringLength(100)]
        public string Senha { get; set; }
        [StringLength(20)]
        public string Apelido { get; set; }
        [Required]
        [StringLength(12)]
        public string DataNascimento { get; set; }
        public string Celular { get; set; }
        public Genero Genero { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public Endereco Endereco { get; set; }


    }
}