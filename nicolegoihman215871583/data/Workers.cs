using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nicolegoihman215871583.data
{
    class Worker
    {

        private string id;//
        private string firstName;//
        private string sureName;//
        private string rank;//
        private string salery;//
        private string bankAccount;
        private string phoneNum;//
        private string email; //


        public string Email
        {
            set
            {
                if (utilities.ValidationsUtilities.Email(value))
                {
                    email = value;
                }
            }
        }
        public string FirstName
        {
            set
            {
                firstName = value;
            }
        }
        public string SureName
        {
            set
            {
                sureName = value;
            }
        }
        public string PhoneNumber
        {
            set
            {
                if (utilities.ValidationsUtilities.IsPhoneNum(value))
                    phoneNum = value;
            }
        }
        public string Id
        {
            set
            {
                if (utilities.ValidationsUtilities.LegalId(value))
                    id = value;
            }
        }
        public string Rank
        {
            set
            {
                rank = value;
            }
        }
        public string Salery
        {
            set
            {
                if (utilities.ValidationsUtilities.isPositiveNumber(value))
                    salery = value;
            }
        }
        public string BankAccount
        {
            set
            {
                if (utilities.ValidationsUtilities.isPositiveNumber(value))
                    bankAccount = value;
            }
        }

    }
}
