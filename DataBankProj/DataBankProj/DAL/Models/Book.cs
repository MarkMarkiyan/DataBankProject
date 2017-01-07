using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataBankProj.DAL.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int size { get; set; }

        public DateTime PublishDate { get; set; }
    }
}