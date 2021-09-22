using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Sistema.Ponto.Model
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Seu loguin deve ter de 5 a 15 caracteres")]
        public string Loguin { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Sua senha deve ter mais de 5 caracteres")]
        public string Senha { get; set; }

        [Required]
        public int CPF { get; set; }
    }
   }
