
using System;

namespace Model
{
    public class User
    {
        private int Code { get; set; }
        private string Name { get; set; }
                 
        public User(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
