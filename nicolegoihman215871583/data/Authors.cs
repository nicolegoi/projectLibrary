using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nicolegoihman215871583.data
{
    class Author
    {

        private string fullName;//
        private string authorId;
        private string birthday;
        private string linkToInfo;


        public string FullName
        {
            set
            {
                //if (utilities.ValidationsUtilities.IsLegalName(value))
                    fullName = value;
            }

            get
            {
                return fullName;
            }
        }

        public string AuthorId
        {
            set
            {
                if (utilities.ValidationsUtilities.isPositiveNumber(value))
                authorId = value;
            }
            get
            {
                return authorId;
            }
        }

        public string Birthday
        {
            set
            {
                //if(utilities.ValidationsUtilities.IsValidDate(value))
                birthday = value;
            }
            get
            {
                return birthday;
            }
        }

        public string LinkToInfo
        {
            set
            {
                linkToInfo = value;
            }
            get
            {
                return linkToInfo;
            }
        }

    }
}
