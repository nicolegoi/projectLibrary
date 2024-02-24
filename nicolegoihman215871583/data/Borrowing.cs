using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nicolegoihman215871583.data
{
    class Borrowing
    {

        private string borrowingID;//
        private string borrowDate;//
        private string expectedReturnDate;//
        private string custID;//
        private string workerId;//



        public string BorrowingID
        {
            set
            {
                borrowingID = value;
            }
        }
        public string BorrowDate
        {
            set
            {
                borrowDate = value;
            }
        }
        public string ExpectedReturnDate
        {
            set
            {
                expectedReturnDate = value;
            }
        }
        public string CustID
        {
            set
            {
                if (utilities.ValidationsUtilities.LegalId(value))
                    custID = value;
            }
        }
        public string WorkerId
        {
            set
            {
                if (utilities.ValidationsUtilities.LegalId(value))
                    workerId = value;
            }
        }

    }
}
