using System;
using System.Globalization;

namespace Library.LibraryBook
{
    public class BorrowedBookForm
    {
        public BorrowedBookForm(Book borrowedBook)
        {
            BorrowedBook = borrowedBook;
            BorrowDate = DateTime.Today;
        }

        public Book BorrowedBook { get; }
        public DateTime BorrowDate { get; set; }
        public bool BookReturnedOnTime => (DateTime.Today - BorrowDate).TotalDays <= LibraryApplicationConstants.TWO_WEEKS_IN_DAYS;
        public double DelayedReturnFee { get; private set; }

        public void CalculateDelayedReturnFee()
        {
            TimeSpan timeSinceBorrowing = DateTime.Today - BorrowDate;

            if (!BookReturnedOnTime)
            {
                double delayedDays = timeSinceBorrowing.TotalDays - LibraryApplicationConstants.TWO_WEEKS_IN_DAYS;
                // formula used: 1% * Book's price * numbers of days overdue
                DelayedReturnFee = LibraryApplicationConstants.DELAYED_RETURN_FEE_PERCENT *
                                   BorrowedBook.PriceOfReturnDelay * delayedDays;
                return;
            }

            DelayedReturnFee = 0.0;
        }
        
        public string GetDisplayMessageBasedOnTheFee()
        {
            if (BookReturnedOnTime)
            {
                return "Congrats! You returned the book on time!";
            }

            return $"Sorry, you'll be charged {DelayedReturnFee} lei from your account.\nIf you think this is a mistake, please contact us!";
        }

        #region Equality

        public override bool Equals(object obj) => Equals(obj as BorrowedBookForm);

        private bool Equals(BorrowedBookForm other)
        {
            return Equals(BorrowedBook, other.BorrowedBook);
        }

        public override int GetHashCode()
        {
            return BorrowedBook != null ? BorrowedBook.GetHashCode() : 0;
        }

        #endregion
        
        public override string ToString()
        {
            return $"{BorrowDate.Date.ToString(CultureInfo.InvariantCulture)} - {BorrowedBook}";
        }
    }
}