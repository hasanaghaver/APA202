using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _10_GenericTypesCollections.Models
{
    
    internal class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count < 3)
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"Kitab goturuldu: {book.Title}");
            }
            else
            {
                Console.WriteLine("Maksimum 3 kitab goture bilersiniz!");
            }
        }
        public void ReturnBook(int bookId)
        {
            Book exsist = null;
            foreach (var book in BorrowedBooks)
            {
                if (book.Id == bookId)
                {
                    exsist = book;
                    break;
                }
            }
            if (exsist == null)
            {
                Console.WriteLine("Axtarilan id uzre kitab tapilmadi");
            }
            else
            {
                BorrowedBooks.Remove(exsist);
                Console.WriteLine($"Kitab qaytarıldı: {exsist.Title}");
            }
        }
        public void DisplayBorrowedBooks()
        {
            if(BorrowedBooks.Count > 0)
            {
                foreach (var item in BorrowedBooks)
                {
                    item.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("Borc kitab yoxdur");
            }
        }
    }
}
