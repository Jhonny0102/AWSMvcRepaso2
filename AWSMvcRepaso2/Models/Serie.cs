using System.ComponentModel.DataAnnotations.Schema;

namespace AWSMvcRepaso2.Models
{
    public class Serie
    {
        public int IdSerie { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public int Anyo { get; set; }

    }
}
