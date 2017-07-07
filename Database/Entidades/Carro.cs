using SQLite;

namespace Database.Entidades
{
    public class Carro
    {
        [PrimaryKey, AutoIncrement]
        public int car_id { get; set; }
        public string car_nome { get; set; }        
        public int cor_id { get; set; }

        public Carro() { }
        public Carro(string nome, int cor)
        {
            this.car_nome = nome;
            this.cor_id = cor;
        }
    }
}
