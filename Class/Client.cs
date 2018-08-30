using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    public sealed class Client : Personne
    {
        public string Email { get; set; }

        public Client(string email)
        {
            Email = email;
        }
    }
}
