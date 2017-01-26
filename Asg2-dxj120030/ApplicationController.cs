using System;
using System.Collections;
using System.Linq;
using System.Net.Mail;

namespace Asg2_dxj120030
{
    public static class ApplicationController
    {
        private static ArrayList customers = new ArrayList();
        private static string [] stateCodes = { "AL", "AK", "AS",
            "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA",
            "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA",
            "ME", "MD", "MH", "MA", "MI", "FM", "MN", "MS", "MO",
            "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND",
            "MP", "OH", "OK", "OR", "PW", "PA", "PR", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "VI", "WA", "WV",
            "WI", "WY" };

        public static bool saveCustomer (string fName, char mInit, string lName,
            string addr1, string addr2, string city, string state, string zip, string phone,
            string email, bool proofAttached, DateTime received, DateTime started, DateTime modified)
        {
            if (validateForm(fName, mInit, lName, addr1, city, state, zip, phone, email)) { }
            return true;
        }

        private static bool validateForm (string fName, char mInit, string lName,
            string addr1, string city, string state, string zip, string phone, string email)
        {
            if (fName.Trim().Equals("") || fName.Any(c => char.IsDigit(c)))
                return false;

            if (mInit != ' ' || !Char.IsLetter(mInit))
                return false;

            if (lName.Trim().Equals("") || lName.Any(c => char.IsDigit(c)))
                return false;

            if (addr1.Trim().Equals("") || city.Trim().Equals("") || stateCodes.Contains(state.Trim()))
                return false;

            zip = zip.Trim();
            if (zip.Any(c => !char.IsDigit(c)) || zip.Length != 5 || zip.Length != 9)
                return false;

            phone = phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            if (phone.Any(c => !char.IsDigit(c) && (c != 'x' && c != 'X')))
                return false;

            try { new MailAddress(email); }
            catch (Exception) { return false; }

            return true;
        }
    }
}
