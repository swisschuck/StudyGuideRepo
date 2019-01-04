using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Cryptography
{
    public class SecureStringExample
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public SecureString ToSecureString(char[] stringToSecure)
        {
            SecureString SS = new SecureString();

            // append each character onto the secure string
            Array.ForEach(stringToSecure, SS.AppendChar);

            return SS;
        }

        public char[] CharacterData(SecureString SS)
        {
            char[] bytes;
            IntPtr ptr = IntPtr.Zero;

            try
            {
                // Allocate a BSTR and copy the contents of SecureString into it
                ptr = Marshal.SecureStringToBSTR(SS);
                bytes = new char[SS.Length];

                // Copy data from unmanaged memory into a managed char array
                Marshal.Copy(ptr, bytes, 0, SS.Length);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    // Free unmanaged memory
                    Marshal.ZeroFreeBSTR(ptr);
                }
            }

            return bytes;
        }

        public string ConvertToUnsecureString(SecureString SS)
        {
            if (SS == null)
            {
                throw new ArgumentNullException("secure string was null on entry");
            }

            IntPtr unmanagedString = IntPtr.Zero;

            try
            {
                // copy the contents of the secure string to unmanaged memory
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(SS);

                // Allocate a managed string and copy the contents of the managed string data into it
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // free the unmanaged string pointer in memory
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
