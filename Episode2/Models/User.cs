using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Episode2.Models
{
    public class User
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public decimal Founds {get; private set;}

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
        }
        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is incorrect");
            }
            if(Email == email)  // sprawdzenie niekonieczne, napisane ponieważ na końcu metody aktualizujemy pole "UpdatedAt" w metodzie "Update()"
            {
                return;
            }
            Email = email;
            Update();
        }
        public void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is incorrect");
            }
            if(Password == password)  // sprawdzenie niekonieczne, napisane ponieważ na końcu metody aktualizujemy pole "UpdatedAt" w metodzie "Update()"
            {
                return;
            }
            Password = password;
            Update();
        }
        public void SetAge(int age)
        {
            if(age<13)
            {
                throw new Exception("Age must be gfreater or equal 13");
            }
            if(Age == age)  // sprawdzenie niekonieczne, napisane ponieważ na końcu metody aktualizujemy pole "UpdatedAt" w metodzie "Update()"
            {
                return;
            }
            Age = age;
            Update();
        }
        public void Activate()
        {
            if(IsActive)   // to samo co if(IsActive == true)
            {
                return;
            }
            IsActive = true;
            Update();
        }
        public void Deactivate()
        {
            if(!IsActive)   // to samo co if(IsActive == false)
            {
                return;
            }
            IsActive = false;
            Update();
        }

        public void PurchaseOrder(Order order)
        {
            if(!IsActive)
            {
            throw new Exception("Only active user can purchase an order.");
            }
            decimal orderPrice = order.TotalPrice;
            if(Founds - orderPrice < 0)
            {
                throw new Exception("You dont have enough money.");
            }
            order.Purchase();
            Founds -= orderPrice;
            Update();
        }
        private void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }

    }


}