using _10_GenericTypesCollections.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace _10_GenericTypesCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 CI HISSE
            Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
            Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
            Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new Book(4, "Ağ Gemi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new Book(5, "Qırıq Budaq", "Elçin", 1998, 350);

            book1.DisplayInfo();
            book2.DisplayInfo();
            book3.DisplayInfo();
            book4.DisplayInfo();
            book5.DisplayInfo();

            Console.WriteLine("---------------------------------------------------------------");

            // 2 ci hisse
            Library<Book> library = new Library<Book>("Milli Kitabxana");
            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);
            library.FindByIndex(0).DisplayInfo();
            library.FindByIndex(2).DisplayInfo();
            foreach (var item in library.GetAll())
            {
                item.DisplayInfo();
            }

            Console.WriteLine("---------------------------------------------------------------");

            //3 cu hisse
            List<Member> members = new List<Member>();
            Member member1 = new Member(1, "Ali Məmmədov", "ali@mail.com");
            Member member2 = new Member(2, "Leyla Həsənova", "leyla@mail.com");
            Member member3 = new Member(3, "Vüqar Əliyev", "vuqar@mail.com");
            members.Add(member1);
            members.Add(member2);
            members.Add(member3);
            member1.BorrowBook(book1);
            member1.BorrowBook(book2);
            member1.DisplayBorrowedBooks();
            member1.ReturnBook(1);
            member1.DisplayBorrowedBooks();
            member1.BorrowBook(book3);
            member1.BorrowBook(book4);
            member1.BorrowBook(book5);

            Console.WriteLine("---------------------------------------------------------------");

            //4 cu hisse
            BookManager bookManager = new BookManager();
            bookManager.AddBook(book1);
            bookManager.AddBook(book2);
            bookManager.AddBook(book3);
            bookManager.AddBook(book4);
            bookManager.AddBook(book5);


            List<Book> orwellBooks = bookManager.GetBooksByAuthor("George Orwell");
            Console.WriteLine("George Orwell -in kitabları:");
            foreach (var book in orwellBooks)
            {
                book.DisplayInfo();
            }


            List<Book> aytmatovBooks = bookManager.GetBooksByAuthor("Cingiz Aytmatov");
            Console.WriteLine("Cingiz Aytmatov -un kitabları:");
            foreach (var book in aytmatovBooks)
            {
                book.DisplayInfo();
            }


            List<Book> londonBooks = bookManager.GetBooksByAuthor("Jack London");
            Console.WriteLine("Jack London -un kitabları:");
            foreach (var book in londonBooks)
            {
                book.DisplayInfo();
            }


            List<Book> dostoyevskiBooks = bookManager.GetBooksByAuthor("Dostoyevski");
            Console.WriteLine("Dostoyevski -un kitabları:");
            foreach (var book in dostoyevskiBooks)
            {
                book.DisplayInfo();
            }

            Console.WriteLine("---------------------------------------------------------------");
            //5 ci hisse
            bookManager.AddToWaitingQueue("Nigar");
            bookManager.AddToWaitingQueue("Reşad");
            bookManager.AddToWaitingQueue("Sebine");
            Console.WriteLine($"Novbede olanlarin sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmet olunur: {bookManager.ServeNextInQueue()}");
            Console.WriteLine($"Novbede olanlarin sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmet olunur: {bookManager.ServeNextInQueue()}");
            Console.WriteLine($"Novbede olanlarin sayi: {bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Xidmet olunur: {bookManager.ServeNextInQueue()}");
            Console.WriteLine($"Novbede olanlarin sayi: {bookManager.WaitingQueue.Count}");

            Console.WriteLine("---------------------------------------------------------------");

            //6 ci hisse
            bookManager.ReturnBook(book1);
            bookManager.ReturnBook(book2);
            bookManager.ReturnBook(book3);
            Console.WriteLine($"Qebul olunan kitab sayi: {bookManager.RecentlyReturned.Count}");
            bookManager.GetLastReturnedBook().DisplayInfo();
            bookManager.RecentlyReturned.Pop();
            Console.WriteLine($"Qebul olunan kitab sayi: {bookManager.RecentlyReturned.Count}");
            bookManager.GetLastReturnedBook().DisplayInfo();

            Console.WriteLine("---------------------------------------------------------------");

            //7 ci hisse
            bookManager.SearchByTitle("1984").DisplayInfo();
            if (bookManager.SearchByTitle("Harry Potter") == null)
            {
                Console.WriteLine("Axtarilan kitab tapilmadi");
            }

            Console.WriteLine("---------------------------------------------------------------");

            //8 ci hisse
            Console.WriteLine($"Umumi kitab sayi: {bookManager.Books.Count}");
            Console.WriteLine($"Umumi uzv sayi: {members.Count}");
            Console.WriteLine($"Novbede nefer sayi:{bookManager.WaitingQueue.Count}");
            Console.WriteLine($"Stack-da kitab sayi: {bookManager.RecentlyReturned.Count}");

            int minYear = bookManager.Books[0].Year;
            int maxYear = bookManager.Books[0].Year;

            foreach (var book in bookManager.Books)
            {
                if (book.Year < minYear)
                {
                    minYear = book.Year;
                }
                if (book.Year > maxYear)
                {
                    maxYear = book.Year;
                }
            }
            Console.WriteLine($"En kohne kitabin ili: {minYear}");
            Console.WriteLine($"En yeni kitabin ili: {maxYear}");

        }
    }
}
