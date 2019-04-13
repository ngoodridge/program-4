/*Grading ID: A7272
 * Class: CIS 199-01
 * Program 4
 * Due: December 5th, 2017
 * Description: This program has a Class (LibraryBooks) That has 5 objects (Books) with variious properties about the books.  The Class LibraryTest
   Then prints the books available, Makes adjustments to Books properties and checks out (method) 2 books, prints the books again to reflect the new information,
   then returns the books to the shelf (method) and prints the books a final time.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4
{
    class LibraryTest
    {
        public static void Main(string[] args)
        {
            LibraryBook Book1 = new LibraryBook("To Catch a Mocking Bird", "Harper Lee", "J. B. Lippincott & Co.", 1960, "1234"); //Creates a new object in the class LibraryBook
            LibraryBook Book2 = new LibraryBook("The Things They Carried", "Tim O'Brien", "Houghton Mifflin", 1990, "5678"); //Creates a new object in the class LibraryBook
            LibraryBook Book3 = new LibraryBook("Night", "Elie Wiesel", "MacGibbon & Kee", 1960, "9123"); //Creates a new object in the class LibraryBook
            LibraryBook Book4 = new LibraryBook("The Great Gatsby", "F. Scott Fitzgerald", "Charles Scribner's Sons", 1925, "4567"); //Creates a new object in the class LibraryBook
            LibraryBook Book5 = new LibraryBook("Adventures of Huckleberry Finn", "Mark Twain", "Chatto & Windus", 1885, "8912"); //Creates a new object in the class LibraryBook

            LibraryBook[] Books = { Book1, Book2, Book3, Book4, Book5 };  //Stores the LibraryBook objects into an array

            Console.WriteLine("Books in The Library:\n");

            ShowBooks(Books); //Method that Prints the objects and there properties to the console

            Console.WriteLine("**********Adjustments made to books and books checked out**********\n");

            Book1.publisher = "Goodridge Publishing"; //Changes the Books publisher property
            Book2.callNumber = "8473"; //Changes the Books callNumber property
            Book3.copyrightYear = -1960; //Changes the Books CopyrightYear property and tests the pre conditon of a non negative int
            Book4.CheckOut();  //Call the CheckOut method to change the checkout status of the book to true
            Book5.CheckOut(); //Call the CheckOut method to change the checkout status of the book to true

            ShowBooks(Books); //Method that Prints the objects and there properties to the console

            Console.WriteLine("**********Books being returned**********\n");

            Book4.ReturnToShelf(); //Call the ReturnToShelf method to change the checkout status of the book to false
            Book5.ReturnToShelf();//Call the ReturnToShelf method to change the checkout status of the book to false

            ShowBooks(Books); //Method that Prints the objects and there properties to the console
        }

        public static void ShowBooks(LibraryBook[] Books) //Method that Prints the objects and there properties to the console
        {

            foreach (LibraryBook element in Books)
            {
                Console.WriteLine(element.ToString());
            }
        }


    }

    class LibraryBook
    {
        private int copyrightYearBack; //Backing field for the copyrightYear property
        private bool checkedOut;  //property that holds the statuse of whether a book is checked out
        private int thisYear = 2017;  //Variable that holds the current year to be used as a default year in the copyright property

        //Pre Condition: None
        //Post Conditon: reutrns the title and sets it to the value
        public string title { get; set; } //Title of the book

        //Pre Condition: None
        //Post Conditon: reutrns the author and sets it to the value
        public string author { get; set; } //Name of the books author

        //Pre Condition: None
        //Post Conditon: reutrns the publisher and sets it to the the value
        public string publisher { get; set; } //Name of the book's publisher

        //Pre Condition: copy right year is a non negative int
        //Post Conditon: reutrns the copyrightYear and sets it to the value or a default value of 2017
        public int copyrightYear //Year that the book was copyrighted
        {
            get
            {
                return copyrightYearBack;
            }
            set
            {
                if (value >= 0)
                {
                    copyrightYearBack = value;
                }
                else
                    copyrightYearBack = thisYear;
            }
        }

        //Pre Condition: None
        //Post Conditon: reutrns the callNumber and sets it to the the value
        public string callNumber { get; set; }//Call number of the book
       


        //Pre Condition: None
        //Post Condition: Initalizes the properties title, author, publisher, CopyrightYeat, adn CallNumber
        public LibraryBook(string Title, string Author, string Publisher, int CopyrightYear, string CallNumber)
        {
            title = Title;
            author = Author;
            publisher = Publisher;
            copyrightYear = CopyrightYear;
            callNumber = CallNumber;
        }

        //Precondition: None
        //Post Condition: Sets a books checkedout status to true
        public void CheckOut()
        {
            checkedOut = true;
        }

        //Precondition: None
        //Post Condition: Sets a books checkedout status to false
        public void ReturnToShelf()
        {
            checkedOut = false;
        }

        //Precondition: None
        //Post Condition: returns a books checked out status
        public bool IsCheckedOut()
        {
            return checkedOut;
        }

        //pre Condition: none
        //Post Condition: Returns a string with the books property information
        public override string ToString()
        {
            return "Title: " + title + Environment.NewLine
                   + "Author: " + author + Environment.NewLine
                   + "Publisher: " + publisher + Environment.NewLine
                   + "Copyright Year: " + copyrightYearBack + Environment.NewLine
                   + "Call Number: " + callNumber + Environment.NewLine
                   + "Checked Out: " + IsCheckedOut() + Environment.NewLine;

        }
    }
}
