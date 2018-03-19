using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }

    public class SqlLocalDbContext : DbContext
    {
        public SqlLocalDbContext() : base("MailsAndSendersConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SqlLocalDbContext>());
        }
        public virtual DbSet<Email> Emails { get; set; }
    }


}
