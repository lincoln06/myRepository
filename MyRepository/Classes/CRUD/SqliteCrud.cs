using Microsoft.Data.Sqlite;
using MyRepository.Classes.Model;
using MyRepository.Interfaces;
using System;

namespace MyRepository.Classes.CRUD
{
    public class SqliteCrud : ICrud
    {
        private SqliteConnection _connection = new("Data-Source=Service.db");
        public void AddABook(Book book)
        {
            _connection.Open();
            var command = _connection.CreateCommand();
            command.CommandText = @"insert into Books(FirstName,LastName,Title,Genre,Year) values('" + book.FirstName + "','" + book.LastName + "','" + book.Title + "','" + book.Genre + "','" + book.Year + "')";
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void AddUser(User user)
        {
            _connection.Open();
            var command = _connection.CreateCommand();
            command.CommandText = @"insert into Users(FirstName,LastName,Email,Password) values('" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.Password + "')";
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public Book FindBook(string title)
        {
            _connection.Open();
            var command =  _connection.CreateCommand();
            command.CommandText = @"select * from Books where Title='" + title + "'";
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) return null;
            Book book = new(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), ushort.Parse(reader.GetString(4)));
            _connection.Close();
            return book;
        }

        public User FindUser(string email, string password)
        {
            _connection.Open();
            var command = _connection.CreateCommand();
            command.CommandText = @"select * from Users where Email='" + email + "' and Password='" + password + "'";
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows) return null;
            User user = new(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            _connection.Close();
            return user;
        }
    }
}
