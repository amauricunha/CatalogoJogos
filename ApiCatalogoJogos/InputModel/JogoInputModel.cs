﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Classe utilizada para tratamento de entrada de dados

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        //Principio Failfast validation: tentar fazer uma requisição inválida o mais rápido possível
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }
        [Required]
        [Range(1,1000, ErrorMessage = "O preço deve ser de no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }
    }
}
