using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Episode2.Models
{
    public interface IEmialSender
    {
        void SendMessage(string receiver, string title, string message);
    }
    public class EmailSender : IEmialSender
    {
        public void SendMessage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }
    public interface IDatabase
    {
        bool IsConnected { get;}
        void Connect();
        User GetUser(string email); // typ który zwróci metoda to "User"
        Order GetOrder(int id); // typ który zwróci metoda to "Order"
        void SaveChanges();
    }
}