using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAuto.Models
{
    [Table("Vehiculo")]
    public class Auto
    {
        
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Marca { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Modelo { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Color { get; set; }

        [Column(name:"Money")]
        public double Precio { get; set; }
    }
}
