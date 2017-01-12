using System.ComponentModel.DataAnnotations;

namespace DataBankProj.Models
{
    public class DataInfo
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public object Data { get; set; }
    }
}