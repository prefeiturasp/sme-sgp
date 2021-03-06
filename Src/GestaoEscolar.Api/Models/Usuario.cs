﻿using System;
using System.Collections.Generic;

namespace GestaoEscolar.Api.Models
{
    public class Usuario
    {
        public string login { get; set; }
        public string senha { get; set; }
        public Guid entidade { get; set; }
    }
    public class UsuarioLogado
    {
        public string nome { get; set; }
        public string grupo { get; set; }
        public bool docente { get; set; }
        public string token { get; set; }
    }
}