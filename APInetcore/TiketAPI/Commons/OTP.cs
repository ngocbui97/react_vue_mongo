using System;

namespace TiketAPI.Commons
{
    public class OTP
    {
        private static int otpLeght = 6;
        private static string[] characters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        public static string Generate()
        {
            string otp = String.Empty;
            string tempCharacter = String.Empty;
            Random rand = new Random();

            for (int i = 0; i < otpLeght; i++)
            {
                int p = rand.Next(0, characters.Length);
                tempCharacter = characters[rand.Next(0, characters.Length)];
                otp += tempCharacter;
            }
            return otp;
        }
    }
}
