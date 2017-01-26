using System;
using System.Collections;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;


namespace Asg2_dxj120030
{
    /*
     * Controller
     * This class handles all business requirements
     * with respect to how they should interfere with
     * the save file (through the TechnicalServices
     * class). It exists to support the expected RebateForm
     * functionalities by dictating the order and parameters
     * of TechnicalService functions called.
     */
    public class Controller
    {
        private TechnicalServices services; // services is a reference to a TechnicalServices object used to interact with the save file
        private ArrayList customers;        // the Controller maintains a list in memory of all currently saved customers
        private string[] stateCodes = { "AL", "AK", "AS",           // a list of all state/territory codes for validation of state codes
            "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA",
            "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA",
            "ME", "MD", "MH", "MA", "MI", "FM", "MN", "MS", "MO",
            "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND",
            "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "VI", "WA", "WV",
            "WI", "WY" };

        /*
         * Controller
         * Instantiate a controller object as well as a
         * TechnicalServices object in order to interface
         * with the savefile. Then populate the customers
         * array with all customers already contained in
         * the savefile. If an error occurs while parsing
         * the data file, initialize with an empty list.
         */
        public Controller ()
        {
            services = new TechnicalServices();
            try { customers = services.readFile(); }
            catch (Exception e) { customers = new ArrayList(); throw e; }
        }

        /* 
         * getlist
         * returns a series of ListViewItems
         * to be inserted into the rebateForm
         * ListView of customers.
         */
        public ListViewItem [] getList ()
        {
            ListViewItem[] listItems = new ListViewItem [customers.Count];

            // for each customer, create a list view item
            for (int i = 0; i < customers.Count; i++)
            {
                Customer c = ((Customer)customers[i]);
                if (c.mInit != ' ') listItems[i] = new ListViewItem(c.fName + " " + c.mInit + " " + c.lName);
                else listItems[i] = new ListViewItem(c.fName + " " + c.lName);
                listItems[i].SubItems.Add(c.phone);
                listItems[i].SubItems.Add(c.fName);
                listItems[i].SubItems.Add(c.mInit.ToString());
                listItems[i].SubItems.Add(c.lName);

            }
            return listItems;
        }

        /*
         * getCustomer
         * Retrieves a specific customer object based on
         * the inputted first and last name and middle
         * initial. Since all customers have a unique
         * first name/middle initial/last name combination,
         * these three parameters should be satisfactory for
         * finding a single customer.
         */
        public Customer getCustomer (string fName, char mInit, string lName)
        {
            foreach (Customer c in customers)
                if (c.fName.Equals(fName) && c.mInit == mInit && c.lName.Equals(lName))
                    return c;

            return null;
        }

        /*
         * deleteCustomer
         * Removes a single customer specified by first name, last name,
         * and middle initial, from both the customers array in memory
         * as well as the savefile
         */
        public bool deleteCustomer (string fName, char mInit, string lName)
        {
            bool found = false;
            for (int i = 0; i < customers.Count; i++)
            {
                Customer existingCustomer = (Customer)customers[i];

                // find the specified customer and remove him/her
                if (existingCustomer.fName.ToLower().Equals(fName.ToLower()) &&
                    existingCustomer.mInit.ToString().ToLower().Equals(mInit.ToString().ToLower()) &&
                    existingCustomer.lName.ToLower().Equals(lName.ToLower()))
                {
                    found = true;
                    customers.RemoveAt(i);
                    break;
                }
            }

            if (found)
            {
                services.clearFile();
                foreach (Customer c in customers)
                    services.writeToFile(c);
            }
            return true;
        }

        /*
         * modifyCustomer
         * This function takes several new properties
         * as well as customer identifying information
         * (first name, middle initial, last name) and
         * assigns the new properties to the specified
         * customer. If the customer's new name is the
         * exact same as an existing customer, the
         * changes do not take place and an error is thrown
         */
        public bool modifyCustomer (string oldFName, char oldMInit, string oldLName, string newFName, char newMInit, string newLName,
            string addr1, string addr2, string city, string state, string zip, string phone,
            string email, bool proofAttached, DateTime received)
        {
            // if the name is changing, check to see if
            // someone with the new name exists. If they
            // do, throw an exception
            if (!oldFName.Equals(newFName) || oldMInit != newMInit || !oldLName.Equals(newLName))
            {
                bool duplicate = false;
                foreach (Customer oldCust in customers)
                {
                    if (newMInit == oldCust.mInit && 
                        Customer.nameify(newFName).Equals(Customer.nameify(oldCust.fName)) && 
                        Customer.nameify(newLName).Equals(Customer.nameify(oldCust.lName)))
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate) throw new Exception("A customer with this first name, middle initial, and last name already exists. " +
                    "Please rename the current customer or delete the old customer with the same name.");
            }

            // if the information is valid, find the specified customer and update properties
            try
            {
                if (validateForm(newFName, newMInit, newLName, addr1, city, state, zip, phone, email))
                {
                    int editIndex = -1;
                    for (int i = 0; i < customers.Count; i++)
                    {
                        Customer currentCustomer = (Customer)customers[i];
                        if (currentCustomer.fName.Equals(oldFName) && currentCustomer.mInit == oldMInit && currentCustomer.lName.Equals(oldLName))
                        {
                            editIndex = i;
                            currentCustomer.fName = Customer.nameify(newFName.Trim());
                            currentCustomer.mInit = newMInit.ToString().ToUpper()[0];
                            currentCustomer.lName = Customer.nameify(newLName.Trim());
                            currentCustomer.addr1 = addr1.Trim();
                            currentCustomer.addr2 = addr2.Trim();
                            currentCustomer.city = Customer.nameify(city.Trim());
                            currentCustomer.state = state.ToUpper();
                            currentCustomer.zip = zip;
                            currentCustomer.phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
                            currentCustomer.email = email.ToLower();
                            currentCustomer.proofAttached = proofAttached;
                            currentCustomer.received = received;
                        }
                    }

                    // now that the customer has been updated,
                    // clear the file and write out the entire
                    // customer array
                    services.clearFile();
                    foreach (Customer c in customers)
                        services.writeToFile(c);
                }
            }
            catch (Exception)
            { throw new Exception("Something failed as we tried to save this customer. Please recheck your entry or restart the program."); }
            return true;
        }

        /*
         * addCustomer
         * Takes several properties, validates them as proper customer properties,
         * and (if they are valid and the name isn't already used by a different customer)
         * creates a customer object with them and writes the new customer to the file.
         */
        public bool addCustomer (string fName, char mInit, string lName,
            string addr1, string addr2, string city, string state, string zip, string phone,
            string email, bool proofAttached, DateTime received, DateTime started, DateTime modified)
        {
            if (validateForm(fName, mInit, lName, addr1, city, state, zip, phone, email))
            {
                Customer newCust = new Customer(fName, mInit, lName, addr1, addr2, city, state, zip, phone, email, proofAttached, received, started, modified);
                bool duplicate = false;

                // test to see if the name has already been used by another customer
                foreach (Customer oldCust in customers)
                {
                    if (newCust.mInit == oldCust.mInit && newCust.fName.Equals(oldCust.fName) && newCust.lName.Equals(oldCust.lName))
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate) throw new Exception("A customer with this first name, middle initial, and last name already exists. " +
                    "Please rename the current customer or delete the old customer with the same name.");

                // add new customer to the customer array and write to the list
                customers.Add(newCust);
                services.writeToFile(newCust);
            }

            return true;
        }

        /*
         * validateForm
         * This is used to validate form elements
         * used to modify an existing customer.
         */
        public bool validateForm (string fName, char mInit, string lName,
            string addr1, string city, string state, string zip, string phone, string email)
        {
            if (fName.Trim().Equals("") || fName.Any(c => char.IsDigit(c)))
                return false;

            if (mInit != ' ' && !Char.IsLetter(mInit))
                return false;

            if (lName.Trim().Equals("") || lName.Any(c => char.IsDigit(c)))
                return false;

            if (addr1.Trim().Equals("") || city.Trim().Equals("") || !stateCodes.Contains(state.Trim().ToUpper()))
                return false;

            zip = zip.Trim();
            if (zip.Any(c => !char.IsDigit(c)) || (zip.Length != 5 && zip.Length != 9))
                return false;

            phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
            if (phone == "" || phone.Any(c => !char.IsDigit(c) && (c != 'x' && c != 'X')))
                return false;

            try { new MailAddress(email); }
            catch (Exception) { return false; }

            return true;
        }
    }
}
