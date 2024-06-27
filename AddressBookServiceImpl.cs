using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookWithDictionary
{
    public class AddressBookServiceImpl : IAdressBookService
    {
        string firstName;
        string lastName;
        string address;
        string city;
        string state;
        long phone_Number;
        string email;
        bool isPresent;
        int zip;
        string pattern;
        string temp;
        string message = "";
        Regex regex;
        Dictionary<char,List<ContactPerson>> dictionary=new Dictionary<char,List<ContactPerson>>(); 
        
        public void dictionaryIntializers()
        {
            for(int i = 0;i<26;i++)
            {
                char ch= (char)(i+65);
                dictionary.Add(ch, new List<ContactPerson>());
            }
        }
        public void addPerson()
        { 
            Console.WriteLine("Enter the firstName");
            firstName=Console.ReadLine();
            message = "Ex:-Sahil";
            pattern = "([A-Z]{1})([a-z]){3,20}$";
            regex = new Regex(pattern);
            firstName = userCredentialsCheck(firstName);
            while (true)
            {
                isPresent = false;
                foreach (var ch in dictionary)
                {
                    List<ContactPerson> list = ch.Value;
                    foreach (var person in list)
                    {
                        if (person.FirstName.Equals(firstName))
                        {
                            isPresent = true;
                            try
                            {
                                throw new InvalidUserException("!!!!INVALID USER!!!!!!!");
                            }
                            catch (Exception ex) { Console.WriteLine(ex.ToString); }
                        }
                    }
                }
                if (isPresent == false)
                    break;
                Console.WriteLine("Enter your firstName :-");
                firstName = Console.ReadLine();
            }
            Console.WriteLine("Enter your lastName :- ");
            lastName = Console.ReadLine();
            message = "Ex:-Kumar";
            lastName = userCredentialsCheck(lastName);

            Console.WriteLine("Enter your address :- ");
            address = Console.ReadLine();
            message = "Ex:-Banglore,Karnataka,zip-421101";
            pattern = @"[\w][^\w]*$";
            regex = new Regex(pattern);
            address = userCredentialsCheck(address);


            Console.WriteLine("Enter your city :- ");
            city = Console.ReadLine();
            message = "Ex:-Banglore";
            pattern = @"[\w\W]{4,16}";
            regex = new Regex(pattern);
            city = userCredentialsCheck(city);

            Console.WriteLine("Enter your state :- ");
            state = Console.ReadLine();
            pattern = @"[\w\W]*";
            message = "Ex-Karnataka";
            regex = new Regex(pattern);
            state = userCredentialsCheck(state);

            Console.WriteLine("Enter six Digit Zip Code :- ");
            zip = Convert.ToInt32(Console.ReadLine());
            message = "Ex:-112345";
            pattern = @"[1-9]{1}[0-9]{5}$";
            regex = new Regex(pattern);
            temp = zip.ToString();
            temp = userCredentialsCheck(temp);
            zip = Convert.ToInt32(temp);

            Console.WriteLine("Eneter the phone_Number :- ");
            phone_Number = long.Parse(Console.ReadLine());
            message = "Ex:-7788901122";
            pattern = @"[6-9][0-9]{9}$";
            regex = new Regex(pattern);
            temp = phone_Number.ToString();
            temp = userCredentialsCheck(temp);
            phone_Number = long.Parse(temp);


            Console.WriteLine("Enter the email_Id :- ");
            email = Console.ReadLine();
            message = "Ex:-Sahilja@gmail.com";
            pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            regex = new Regex(pattern);
            email = userCredentialsCheck(email);
            ContactPerson contactPerson=new ContactPerson(firstName, lastName, address,city,state,zip,phone_Number,email);
            dictionary[firstName[0]].Add(contactPerson);
            //foreach(var key in dictionary)
            //{
            //    if (dictionary.ContainsKey(contactPerson.FirstName[0]))
            //    {
            //       List<ContactPerson> listPerson = key.Value;
            //        listPerson.Add(contactPerson); 
            //    }
            //}
            Console.WriteLine(contactPerson.ToString());
            Console.WriteLine("________________________________________________");
            Console.WriteLine("Added Successfully");
        }

        public void editPerson()
        {
            Console.WriteLine("Enter the firstname");
            string name=Console.ReadLine();
            if (!dictionary.ContainsKey(name[0]))
            {
                try
                {
                    throw new InvalidUserException("!!!!!!!!Invalid User!!!!!!!!");
                }
                catch(Exception e) { Console.WriteLine(e.ToString()); }
            }
                 List<ContactPerson> persons = dictionary[name[0]];
            foreach (var contact in persons)
            {
                if (contact.FirstName.Equals(name))
                {
                    Console.WriteLine("Select from Options to Update:-");
                    Console.WriteLine("1.FirstName\n2.LastName\n3.Address\n4.City\n5.State\n6.Zip\n7.Phone_Nmumber\n8.Email\n9.LogOut");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the firstName");
                            firstName = Console.ReadLine();
                            message = "Ex:-Sahil";
                            pattern = "([A-Z]{1})([a-z]){3,20}$";
                            regex = new Regex(pattern);
                            firstName = userCredentialsCheck(firstName);
                            while (true)
                            {
                                isPresent = false;
                                foreach (var ch in dictionary)
                                {
                                    List<ContactPerson> list = ch.Value;
                                    foreach (var per in list)
                                    {
                                        if (per.FirstName.Equals(firstName))
                                        {
                                            isPresent = true;
                                            try
                                            {
                                                throw new InvalidUserException("!!!!INVALID USER!!!!!!!");
                                            }
                                            catch (Exception ex) { Console.WriteLine(ex.ToString); }
                                        }
                                    }
                                }
                                if (isPresent == false)
                                    break;
                                Console.WriteLine("Enter your firstName :-");
                                firstName = Console.ReadLine();
                            }
                            contact.FirstName = firstName;
                            break;
                        case 2:
                            Console.WriteLine("Enter your lastName :- ");
                            lastName = Console.ReadLine();
                            message = "Ex:-Kumar";
                            contact.LastName= userCredentialsCheck(lastName);
                            break;
                        case 3:
                            Console.WriteLine("Enter your address :- ");
                            address = Console.ReadLine();
                            message = "Ex:-Banglore,Karnataka,zip-421101";
                            pattern = @"[\w][^\w]*$";
                            regex = new Regex(pattern);
                            contact.Address= userCredentialsCheck(address);
                            break;
                        case 4:
                            Console.WriteLine("Enter your city :- ");
                            city = Console.ReadLine();
                            message = "Ex:-Banglore";
                            pattern = @"[\w\W]{4,16}";
                            regex = new Regex(pattern);
                            contact.City= userCredentialsCheck(city);
                            break;
                        case 5:
                            Console.WriteLine("Enter your state :- ");
                            state = Console.ReadLine();
                            pattern = @"[\w\W]*";
                            message = "Ex-Karnataka";
                            regex = new Regex(pattern);
                            contact.State= userCredentialsCheck(state);
                            break;
                        case 6:
                            Console.WriteLine("Enter six Digit Zip Code :- ");
                            zip = Convert.ToInt32(Console.ReadLine());
                            message = "Ex:-112345";
                            pattern = @"[1-9]{1}[0-9]{5}$";
                            regex = new Regex(pattern);
                            temp = zip.ToString();
                            temp = userCredentialsCheck(temp);
                            contact.Zip = Convert.ToInt32(temp);
                            break;
                        case 7:
                            Console.WriteLine("Eneter the phone_Number :- ");
                            phone_Number = long.Parse(Console.ReadLine());
                            message = "Ex:-7788901122";
                            pattern = @"[6-9][0-9]{9}$";
                            regex = new Regex(pattern);
                            temp = phone_Number.ToString();
                            temp = userCredentialsCheck(temp);
                            contact.Phone_Number = long.Parse(temp);
                            break;
                        case 8:
                            Console.WriteLine("Enter the email_Id :- ");
                            email = Console.ReadLine();
                            message = "Ex:-Sahilja@gmail.com";
                            pattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
                            regex = new Regex(pattern);
                            contact.Email= userCredentialsCheck(email);
                            break;
                        case 9:
                            break;

                    }
                    Console.WriteLine(contact.ToString());
                    return;

                }

            }
                Console.WriteLine("Updated Succesfully");
                Console.WriteLine("_______________________________________");
            
            
        }

        public void removePerson()
        {
            Console.WriteLine("Enter your FirstName");
            string name=Console.ReadLine();
            if (!dictionary.ContainsKey(name[0]))
                if (!dictionary.ContainsKey(name[0]))
                {
                    try
                    {
                        throw new InvalidUserException("!!!!!!!!Invalid User!!!!!!!!");
                    }
                    catch (Exception e) { Console.WriteLine(e.ToString()); }
                }
            List<ContactPerson> persons = dictionary[name[0]];
            ContactPerson contactPersonRemove= null;
            foreach (var contact in persons)
            {
                if (contact.FirstName.Equals(name))
                {
                   contactPersonRemove = contact;
                    break;
                }

            }
            if(contactPersonRemove != null) {
                persons.Remove(contactPersonRemove);
                Console.WriteLine("Removed Sucessfully");
            }
            else
            {
                try
                {
                    throw new InvalidUserException($"!!INVALID USER!!||{message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void showUserDetails()
        {
            foreach(var item in dictionary)
            {
                Console.WriteLine(item.Key);
                List<ContactPerson> list = item.Value;
                foreach (var contact in list) { 
                  Console.WriteLine(contact.ToString()); 
                }
            }
        }

        public string userCredentialsCheck(string name)
        {
            bool isPresent = true;
            while (true)
            {
                isPresent = false;
                if (!(regex.IsMatch(name)))
                {

                    isPresent = true;
                    try
                    {
                        throw new InvalidUserException($"!!INVALID USER!!||{message}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                if (isPresent == false)
                    break;
                Console.WriteLine("Enter Again with Correct Credentials :-");
                name = Console.ReadLine();
            }
            return name;
        }
       public void searchOnTheBasisOfCity()
        {
            Console.WriteLine("Enter the name of City");
            string city=Console.ReadLine();
            foreach(var contact in dictionary)
            {
                List<ContactPerson> list= contact.Value;    
                foreach (var contactPerson in list)
                {
                    if(contactPerson.City.Equals(city))
                        Console.WriteLine(contactPerson.ToString());

                }
            }
        }
       public void searchOnTheBasisOfState()
        {
            Console.WriteLine("Enter the name of State");
            string state = Console.ReadLine();
            foreach (var contact in dictionary)
            {
                List<ContactPerson> list = contact.Value;
                foreach (var contactPerson in list)
                {
                    if (contactPerson.State.Equals(state))
                        Console.WriteLine(contactPerson.ToString());

                }
            }
        }
    }
}
