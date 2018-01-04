using System;
using Model;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User(1, "Player 1");
            var chat = new Chat(user);

            Console.WriteLine(" Type quit to quit chat.");
            Console.WriteLine(" Enter text to send.");

            chat.SetMessage(Console.ReadLine());

            while (!chat.Exit)
            {
                ChatConnection.Publish(chat);
                chat.SetMessage(Console.ReadLine());
            }

        }
    }
}
