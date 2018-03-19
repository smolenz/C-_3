using System;
using System.Collections.Generic;

namespace MailSender
{
    public static class VariablesClass
    {
        public static Dictionary<string, string> Senders
        {
            get { return dicSenders; }
        }

        public static Dictionary<string, int> Smtp
        {
            get { return dicSmtp; }
        }

        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
         { "test@ksergey.ru","qwerty2018"},
         { "sok74@yandex.ru",";liq34tjk" }
        };

        private static Dictionary<string, int> dicSmtp = new Dictionary<string, int>()
        {
         { "smtp@yandex.ru",25 },
         { "smtp@mail.ru",25 }
        };
    }
}
