using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Chat
    {
        public int Code { get; set; }
        private string Message { get; set; }
        public bool Exit { get; set; } = false;

        public List<User> Users { get; set; }

        public Chat(User user)
        {
            if (Users != null)
            {
                Users.Add(user);
            }
            else
            {
                Users = new List<User>();
                Users.Add(user);
            }
        }

        public void SetMessage(string message)
        {
            if (message == "quit")
            {
                Exit = true;
            }
            else
            {
                Message = message;
            }

        }

        public string GetMessage()
        {
            return String.Format("TEste say {0}",  Message);
        }

    }
}
