using System;

namespace DataBankProj.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int Total
        {
            get { return DateTime.Now.Minute; }
        }
    }
}