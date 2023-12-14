using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masteringlinqc
{
    internal class Person2
    {
        public string Name, Email;

        public Person2(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    internal class Record
    {
        public string Mail, SkypeId;

        public Record(string mail, string skypeId)
        {
            Mail = mail;
            SkypeId = skypeId;
        }
    }
}