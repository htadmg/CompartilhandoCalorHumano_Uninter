using System.ComponentModel.DataAnnotations;

namespace CompartilhandoCalorHumano_Uninter.Models
{
    public class Cadastro
    {
        public Cadastro() { }
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        public string DataDeNascimento { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo Imagem é obrigatório.")]
        public string Imagem { get; set; }
    }
}
