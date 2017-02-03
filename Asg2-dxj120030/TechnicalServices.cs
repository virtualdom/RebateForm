using System;
using System.Collections;
using System.Globalization;
using System.IO;


namespace Asg2_dxj120030
{
    /*
     * TechnicalServices class
     * This class is strictly for dealing with
     * file input/output. The included functions
     * include creating, writing to, reading from,
     * and clearing a "database" file.
     */
    public class TechnicalServices
    {
        private static String fileName = "CS6326Asg2.txt";                  // Filename stored in its own variable for easy customization in a later iteration
        private static String filePath = Directory.GetCurrentDirectory() +  // Filepath built using previously stored filename
            @"\" + fileName;

        /*
         * Constructor
         * This is the only supported constructor.
         * It creates a text file at the specified
         * filepath stored in the filePath variable
         * if one does not already exist.
         */
        public TechnicalServices()
        {
            try { if (!File.Exists(filePath)) File.Create(filePath).Close(); }
            catch (Exception) { throw new Exception("Urgent! We weren't able to connect to the server to save rebate information. Please contact your administrator."); }
        }

        /*
         * writeToFile
         * This function takes a customer object,
         * serializes it, and writes it to the
         * file at the specified filePath.
         * It returns true in case it is used
         * in an if-condition or some other conditional
         * statement.
         */
        public bool writeToFile (Customer customer)
        {
            try { File.AppendAllText(filePath, customer.ToString()); }
            catch (Exception) { throw new Exception("You are not connected to the server. Please restart the program or contact your administrator."); }
            return true;
        }

        /*
         * clearFile
         * This function clears the storage file
         * at the specified filePath. It returns
         * true in case this file is used
         * in some sort of conditional statement
         */
        public bool clearFile ()
        {
            try { File.WriteAllText(filePath, string.Empty); }
            catch (Exception) { throw new Exception("You are not connected to the server. Please restart the program or contact your administrator."); }
            return true;
        }

        /*
         * readFile
         * This function reads the file at the specified
         * filePath and attempts to parse each row in the
         * file into a Customer object. After parsing, it
         * will return an ArrayList containing Customer
         * objects, one for each row in the file. If the
         * file cannot be parsed correctly, the old text
         * file is cached (cached-CS6326Asg2.txt) in the
         * directory of the specified filePath so an admin
         * can later recover and correct the file contents.
         */
        public ArrayList readFile ()
        {
            ArrayList customers = new ArrayList();

            try
            {
                string[] lines = File.ReadAllLines(filePath); // split file into an array, one entry for each row
                foreach (string line in lines)                // iterate over each row (aka each customer)
                {
                    string[] split = line.Split('\t');        // customer information is tab-delimited
                    string firstName = split[0];
                    string lastName = split[1];
                    char mInit = Customer.initify(split[2]); // middle initial is stored as a single character, so it must be converted from a string
                    string addr1 = split[3];
                    string addr2 = split[4];
                    string city = split[5];
                    string state = split[6];
                    string zip = split[7];
                    string phone = split[8];
                    string email = split[9];
                    bool proofAttached = split[10][0] == 'T' || split[10][0] == 't';
                    DateTime received = Convert.ToDateTime(split[11]);

                    // started and modified are stored as "HH:mm:ss", which doesn't contain the date information.
                    // As such, they have to be converted into DateTime objects by parsing the "HH:mm:ss" string.
                    DateTime started = DateTime.ParseExact(split[12], "HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime modified = DateTime.ParseExact(split[13], "HH:mm:ss", CultureInfo.InvariantCulture);
                    customers.Add(new Customer(firstName, mInit, lastName, addr1, addr2, city, state, zip, phone, email, proofAttached, received, started, modified));
                }
            }
            catch (Exception)
            {
                // If the file parsing fails, cache the contents
                // and create a new file
                File.Move(filePath, Directory.GetCurrentDirectory() + @"\cached-" + fileName);
                File.Create(filePath);
                throw new Exception("We weren't able to import previously saved data. " +
                    "We've cached the old malformed data for recovery and are starting you from scratch. " +
                    "Please contact an administrator immediately to recover data.");
            }

            return customers;
        }

    }
}
