using System;

namespace DataBankProj.DAL.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Size { get; set; }

        public string PublishDate { get; set; }
    }
}