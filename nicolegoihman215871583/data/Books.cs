using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nicolegoihman215871583.data
{
    class Book
    {

        private int bookId;//
        private int numOfCopies;//
        private string author;//
        private string genre;//
        private string appropriateAge;//
        private string placeInLibrary;//
        private string publishing; /////maybe to do a table of publishing(contains name, authors that belong and the books that belong to it)
        private string numOfAvailableCopies; //
        private string bookName;//



        public int BookId
        {
            set
            {
                  bookId = value;
            }
            get
            {
                return bookId;
            }
        }
       
        public int NumOfCopies
        {
            set
            {
                //if (utilities.ValidationsUtilities.isPositiveNumber(value))
                    numOfCopies = value;
            }
            get
            {
                return numOfCopies;
            }
        }
        
        public string Author
        {
            set
            {
                author = value;
            }
            get
            {
                return author;
            }
        }
        
        public string Genre
        {
            set
            {
                genre = value;
            }
            get
            {
                return genre;
            }
        }
        
        public string AppropriateAge
        {
            set
            {
                //if (utilities.ValidationsUtilities.isPositiveNumber(value))
                    appropriateAge = value;
            }
            get
            {
                return appropriateAge;
            }
        }
        
        public string NumOfAvailableCopies
        {
            set
            {
                if (utilities.ValidationsUtilities.isPositiveNumber(value))
                    numOfAvailableCopies = value;
            }
            get
            {
                return numOfAvailableCopies;
            }
        }

        public string BookName
        {
            set
            {
                bookName = value;
            }
            get
            {
                return bookName;
            }
        }

        public string Publishing
        {
            set
            {
                publishing = value;
            }
            get
            {
                return publishing;
            }
        }

        public string PlaceInLibrary
        {
            set
            {
                placeInLibrary = value;
            }
            get
            {
                return placeInLibrary;
            }
        }
    }
}
