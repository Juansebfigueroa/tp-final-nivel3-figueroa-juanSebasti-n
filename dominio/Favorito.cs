﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Favorito
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdArticulo { get; set; }

        public Favorito(int IdUser, int IdArticulo)
        {
            this.IdUser = IdUser;
            this.IdArticulo = IdArticulo;
        }
    }
}
