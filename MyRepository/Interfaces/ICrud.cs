using MyRepository.Classes;
using MyRepository.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepository.Interfaces
{
    public interface ICrud
    {
        public Book FindBook(string title);
        public void AddABook(Book book);
        public User FindUser(string email, string password);
        public void AddUser(User user);

    }
}
