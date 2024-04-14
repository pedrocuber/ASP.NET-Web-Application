using System.ComponentModel.DataAnnotations;

namespace Assessment.Models {
    public class Estado {
        [Key]
        public int EstadosId { get; set; }
        public string EstadosNome { get; set; }
        public string EstadoImagem { get; set; }
        public Pais Pais { get; set; }
    }
}
