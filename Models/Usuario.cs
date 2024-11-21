﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MercadoIGL.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
