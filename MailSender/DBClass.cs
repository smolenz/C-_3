using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class DBClass
    {
        //private EmailsDataContext emails = new EmailsDataContext();
        //public IQueryable<Emails> Emails
        //{
        //    get
        //    {
        //        return from c in emails.Emails select c;
        //    }
        //}

        private SqlLocalDbContext _сontext = new SqlLocalDbContext();

        public List<Email> Emails => _сontext.Emails.ToList();

    }
}
