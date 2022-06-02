using System;
using System.ComponentModel.DataAnnotations;

namespace ParkyAPI.DTOs
{
    public class NationalParkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Established { get; set; }
    }
}
