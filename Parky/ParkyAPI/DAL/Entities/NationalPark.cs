using System;
using System.ComponentModel.DataAnnotations;

namespace ParkyAPI.DAL.Entities
{
    public class NationalPark
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Established { get; set; }
    }
}
