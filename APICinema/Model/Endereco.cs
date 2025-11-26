using System.ComponentModel.DataAnnotations;

namespace APICinema.Model
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; } 

        [StringLength(100)]
        public string Logradouro { get; set; }

        [StringLength(10)]
        public string Numero { get; set; }

        [StringLength(20)]
        public string Bairro { get; set; }

        [StringLength(20)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Estado { get; set; }

        [StringLength(3)]
        public string Pais { get; set; }

        [StringLength(8)]
        public string Cep { get; set; }

        [StringLength(50)]
        public string? Complemento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}