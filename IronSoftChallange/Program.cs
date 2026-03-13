using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;

namespace IronSoftChallange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IronSoftChallenge.MobileKey.OldPhonePad("33#"));
            Console.WriteLine(IronSoftChallenge.MobileKey.OldPhonePad("227*#"));
            Console.WriteLine(IronSoftChallenge.MobileKey.OldPhonePad("4433555 555666#"));
            Console.WriteLine(IronSoftChallenge.MobileKey.OldPhonePad("8 88777444666*664#"));

            pushinput();
        }


        static void pushinput()
        {
            Console.WriteLine("Please enter the Mobilekey input: ");
            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input is null");

            }
            string text = IronSoftChallenge.MobileKey.OldPhonePad(input.Trim());
            Console.WriteLine(text);
        a: Console.WriteLine("Press S to Continue: ");
            string confirm = Console.ReadLine();
            if (String.IsNullOrEmpty(confirm))
            {
                Console.WriteLine("Input is null");
                return;
            }
            if (confirm.Trim().ToUpper() == "S")
            {
                pushinput();
            }
            else
            {
                Console.WriteLine("Press S to Continue: ");
                goto a;
            }
        }


    }
}
