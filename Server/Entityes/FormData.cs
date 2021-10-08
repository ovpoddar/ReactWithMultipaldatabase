using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Entityes
{
    public class FormData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string MobileNumber { get; set; }
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        [Required]
        [Range(000000, 999999)]
        public int Pincode { get; set; }
    }
}
