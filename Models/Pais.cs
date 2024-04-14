namespace Assessment.Models {
    public class Pais {
        public int PaisId { get; set; }
        public string PaisNome { get; set; }
        public string PaisImagem { get; set; }
        public List<Estado> EstadosLista { get; set; }
    }
}
