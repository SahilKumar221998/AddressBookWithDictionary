using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWithDictionary
{
   public interface IAdressBookService
    {
        void dictionaryIntializers();
        void addPerson();
        void editPerson();
        void removePerson();
        void showUserDetails();
        string userCredentialsCheck(string name);

        void searchOnTheBasisOfCity();
        void searchOnTheBasisOfState();
    }
}
