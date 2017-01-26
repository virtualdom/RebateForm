using System;
using System.Linq;

namespace Asg2_dxj120030
{
    /*
     * Customer class
     * This represents a single customer who has
     * submitted a rebate application and needs
     * to be stored in our "database" 
     */
    public class Customer
    {
        public string fName { get; set; }           // first name
        public char mInit { get; set; }             // middle initial (optional)
        public string lName { get; set; }           // last name
        public string addr1 { get; set; }           // address line 1
        public string addr2 { get; set; }           // address line 2 (optional)
        public string city { get; set; }            // address city
        public string state { get; set; }           // address state
        public string zip { get; set; }             // ZIP code (basic or ZIP+4)
        public string phone { get; set; }           // phone number
        public string email { get; set; }           // email address
        public bool proofAttached { get; set; }     // whether or not proof of purchase is attached
        public DateTime received { get; set; }      // date received
        public DateTime started { get; }            // time application was started for this customer
        public DateTime modified { get; set; }      // time this customer's application was last modified

        /*
         * Constructor
         * This is the only provided constructor 
         * and it assigns each member variable a
         * value. If no middle initial is provided,
         * it will be provided as a space character.
         * If no address line 2 is provided, it will
         * be the empty string.
         */
        public Customer (string fName, char mInit, string lName, 
            string addr1, string addr2, string city, string state,
            string zip, string phone, string email, bool proofAttached,
            DateTime received, DateTime started, DateTime modified)
        {
            this.fName         = nameify(fName.Trim().ToLower());
            this.mInit         = initify(mInit.ToString());
            this.lName         = nameify(lName.Trim().ToLower());
            this.addr1         = nameify(addr1.Trim());
            this.addr2         = nameify(addr2.Trim());
            this.city          = nameify(city.Trim().ToLower());
            this.state         = state.ToUpper();
            this.zip           = zip;
            this.phone         = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
            this.email         = email.ToLower();
            this.proofAttached = proofAttached;
            this.received      = received;
            this.started       = started;
            this.modified      = modified;
        }

        /*
         * Initify
         * Take a string and return the first
         * character if it exists. Otherwise
         * return a space. This is useful for
         * taking a middle initial string and
         * turning it into the appropriate
         * character
         */
         public static char initify (string mInit) { return mInit.Trim().Length == 0 ? ' ' : mInit.Trim().ToUpper()[0];}

        /*
         * Nameify
         * Capitalize the first letter of each word in a
         * string and return the modified string
         */
        public static string nameify (string name) {
            if (name.Trim().Length == 0) return "";

            String[] nameParts = name.Split(' ');
            String stringBuilt = "";

            foreach (String part in nameParts)
            {
                stringBuilt += (part.First().ToString().ToUpper() + String.Join("", part.ToLower().Skip(1)) + " ");
            }

            return stringBuilt.Trim();
        }

        /* 
         * ToString
         * Custom output for a customer.
         * This function can be used to dump
         * customer information into the database/file.
         */
        public override string ToString() {
            return fName + "\t" + lName + "\t" + (mInit == ' ' ? "" : mInit.ToString()) + "\t" +
                addr1 + "\t" + addr2 + "\t" + city + "\t" + state + "\t" + zip + "\t" +
                phone + "\t" + email + "\t" + proofAttached + "\t" + received + "\t" +
                started.ToString("HH:mm:ss") + "\t" + modified.ToString("HH:mm:ss") +
                Environment.NewLine;
        }
    }
}
