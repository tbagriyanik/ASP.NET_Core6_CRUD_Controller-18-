using System.ComponentModel.DataAnnotations;

namespace veritabaniCRUD2.Models
{
    public class birTablo
    {
        [Key]
        public int Id { get; set; }
        public string? isim { get; set; }
        public float ucret { get; set; }
    }
}
