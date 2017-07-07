using SQLite;

namespace Database.Entidades
{
    public class Estado
    {
        public int est_id { get; set; }
        public int pse_id { get; set; }
        public string est_descricao { get; set; }
        public string est_sigla { get; set; }
        public bool est_status { get; set; }
        [MaxLength(20)]
        public string est_codigocno { get; set; }
        public int? est_relacaoicms { get; set; }
        [MaxLength(20)]
        public string est_formatotelefone { get; set; }
    }
}
