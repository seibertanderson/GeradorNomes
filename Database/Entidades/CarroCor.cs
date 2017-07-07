using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entidades
{
    public class CarroCor
    {
        [PrimaryKey, AutoIncrement]
        public int cor_id { get; set; }
        public string cor_nome { get; set; }

        public CarroCor() { }
        public CarroCor(string nome) {
            this.cor_nome = nome;
        }

    }
}
