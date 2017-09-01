using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PassMgr.Models
{
    public class PasswdContext : DbContext{

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./passwd.db");
        }

        public DbSet<Password> Passwords {get; set;}

    }
    public class Password
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Ip {get; set; }

        public string Domain { get; set; }

        [Required]
        public string Service { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public string Passwd { get; set; }

        public string Url {get; set;}

        public string Status {get; set;}

        public DateTime DateCreated { get; set; }
    }
}