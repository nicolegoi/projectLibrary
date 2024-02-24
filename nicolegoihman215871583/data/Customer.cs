using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nicolegoihman215871583.data
{
    class Customer
    {
        private string id;//
        private string name;//
        private string sureName;//
        private string adress;//
        private string city;//
        private string phone;//
        private string gmail;//
        private string birthDay;//

        public string Id
        {
            set
            {
                id = value;
            }
        }
        public string SureName
        {
            set
            {
                sureName = value;
            }
        }
        public string Adress
        {
            set
            {
                adress = value;
            }
        }
        public string Gmail
        {
            set
            {
                if (utilities.ValidationsUtilities.Email(value))
                {
                    gmail = value;
                }
            }
        }
        public string Name
        {
            set
            {
                name = value;
            }
        }
        public string Phone
        {
            set
            {
                if (utilities.ValidationsUtilities.IsPhoneNum(value))
                    phone = value;
            }
        }
        public string City
        {
            set
            {
                city = value;
            }
        }
        public string Birthday
        {
            set
            {
                birthDay = value;
            }
        }
    
}
}
