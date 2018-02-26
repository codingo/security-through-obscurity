using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/***
 * CrackMe Challenge made for CrikeyCon 2018
 * Created by @codingo_
 * 
 * Please compile using the debug manifest to ensure 'string' text is included within the binary.
 * No dependancies besides .net installed need to be present.
 ***/

namespace crikey.random
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Use this to produce a new flag. Make sure the outputted result is added to the flag output
            //var encryptedString = Crypto.EncryptStringAES("flag{7h3_f0rc3_15_w17h_y0u}", "73 65 63 74 61 6c 6b 73");
            //Console.WriteLine($"New flag string: {encryptedString}");
            //Console.ReadKey();

            // use to produce a new passphrase. Ensure in lower case as input is lowered in routine.
            //var passphrase = Crypto.EncryptStringAES("flag{n3v3r61v3y0uup}", "73 65 63 74 61 6c 6b 73");
            //Console.WriteLine($"New passphrase: {passphrase}");
            //Console.WriteLine($"Success! Flag: {Crypto.DecryptStringAES("EAAAAGcvCdDaWNa0HB773QCthNnrHoKLqW5pnLrVXr5H9fhqZtd5/WjAMriKVWNWS9benw==")}!");
            //Console.ReadKey();

            // pointless string inclusion to show up if strings is used to reverse binary or when loaded in immunity
            const string pointless = "flag{Not a real flag. Strings would be too easy";
            Debug.WriteLine(pointless);

            Program.PrintBanner();

            var guesses = 5;

            while (true)
            {
                if (guesses < 1) PrintGameOver();

                PrintTimer(3);
                PrintGuesses(guesses);

                Console.Write("Enter your flag guess to continue: ");
                var input = Console.ReadLine();

                var password =
                Crypto.DecryptStringAES("EAAAAGcvCdDaWNa0HB773QCthNnrHoKLqW5pnLrVXr5H9fhqZtd5/WjAMriKVWNWS9benw==");

                if(input.Length > 20)
                {
                    Console.WriteLine("Please wait... Processing.");
                    SuperMario();
                    Console.WriteLine("Flag rejected! That line was so long you used up all of your guesses! Good bye.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                if (input != null && input.ToLower().Equals(password))
                {
                    Console.WriteLine($"Depending how you solved this, this may be your flag: {password}");

                    StarWars();
                    Environment.Exit(0);
                }

                guesses--;

                Console.WriteLine($"Incorrect! Please wait to try again.");

                Console.Beep(350, 250);
                Console.Beep(300, 500);
            }
        }

        public static void PrintBanner()
        {
            Console.WriteLine("\n");
            Console.WriteLine(".... - - .--. ... ---... -..-. -..-. .-- .-- .-- .-.-.- -.-- --- ..- -" +
                                " ..- -... . .-.-.- -.-. --- -- -..-. .-- .- - -.-. .... ..--.. ...- -.." +
                                ".- -.. --.- .-- ....- .-- ----. .-- --. -..- -.-. --.-");
        }

        private static void PrintGameOver()
        {
            Console.WriteLine("      _____          __  __ ______    ______      ________ _____  _ ");
            Console.WriteLine("     / ____|   /\\   |  \\/  |  ____|  / __ \\ \\    / /  ____|  __ \\| |");
            Console.WriteLine("    | |  __   /  \\  | \\  / | |__    | |  | \\ \\  / /| |__  | |__) | |");
            Console.WriteLine("    | | |_ | / /\\ \\ | |\\/| |  __|   | |  | |\\ \\/ / |  __| |  _  /| |");
            Console.WriteLine("    | |__| |/ ____ \\| |  | | |____  | |__| | \\  /  | |____| | \\ \\|_|");
            Console.WriteLine("     \\_____/_/    \\_\\_|  |_|______|  \\____/   \\/   |______|_|  \\_(_)");
            Console.WriteLine(" ________________________________________________________________________ ");
            Console.WriteLine("|________________________________________________________________________|");

            Mario();

            Environment.Exit(0);
        }

        public static void PrintTimer(int seconds)
        {
            for (var i = seconds; i >= 0; --i)
            {
                var originalLeft = Console.CursorLeft;
                var originalTop = Console.CursorTop;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.CursorLeft = 0;
                Console.CursorTop = 0;

                Console.Write("You can make another guess in: {0}", i);

                Console.CursorLeft = originalLeft;
                Console.CursorTop = originalTop;

                Thread.Sleep(1000);
            }
        }

        public static void PrintGuesses(int remainingGuesses)
        {
            var originalLeft = Console.CursorLeft;
            var originalTop = Console.CursorTop;

            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.ForegroundColor = ConsoleColor.White;

            if (remainingGuesses == 1)
            {
                var originalColour = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"You only have one guess remaining!");
                Console.BackgroundColor = originalColour;
            }
            else
            {
                Console.Write($"You have {remainingGuesses}/5 guesses remaining!!");
            }
            
            Console.CursorLeft = originalLeft;
            Console.CursorTop = originalTop;
        }

        private static void StarWars()
        {
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
        }

        private static void Mario()
        {
            Console.Beep(659, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(659, 125);
            Thread.Sleep(167);
            Console.Beep(523, 125);
            Console.Beep(659, 125);
            Thread.Sleep(125);
            Console.Beep(784, 125);
            Thread.Sleep(375);
            Console.Beep(392, 125);
        }

        private static void SuperMario()
        {
            Console.Beep(480, 200);
            Console.Beep(1568, 200);
            Console.Beep(1568, 200);
            Console.Beep(1568, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(369, 200);
            Console.Beep(392, 200);
            Console.Beep(369, 200);
            Console.Beep(392, 200);
            Console.Beep(392, 400);
            Console.Beep(196, 400);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(739, 200);
            Console.Beep(83, 200);
            Console.Beep(880, 200);
            Console.Beep(830, 200);
            Console.Beep(880, 200);
            Console.Beep(987, 400);
            Console.Beep(880, 200);
            Console.Beep(783, 200);
            Console.Beep(698, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(880, 200);
            Console.Beep(830, 200);
            Console.Beep(880, 200);
            Console.Beep(987, 400);
            Thread.Sleep(200);
            Console.Beep(1108, 10);
            Console.Beep(1174, 200);
            Console.Beep(1480, 10);
            Console.Beep(1568, 200);
            Thread.Sleep(200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(783, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(880, 200);
            Console.Beep(830, 200);
            Console.Beep(880, 200);
            Console.Beep(987, 400);
            Console.Beep(880, 200);
            Console.Beep(783, 200);
            Console.Beep(698, 200);
            Console.Beep(659, 200);
            Console.Beep(698, 200);
            Console.Beep(784, 200);
            Console.Beep(880, 400);
            Console.Beep(784, 200);
            Console.Beep(698, 200);
            Console.Beep(659, 200);
            Console.Beep(587, 200);
            Console.Beep(659, 200);
            Console.Beep(698, 200);
            Console.Beep(784, 400);
            Console.Beep(698, 200);
            Console.Beep(659, 200);
            Console.Beep(587, 200);
            Console.Beep(523, 200);
            Console.Beep(587, 200);
            Console.Beep(659, 200);
            Console.Beep(698, 400);
            Console.Beep(659, 200);
            Console.Beep(587, 200);
            Console.Beep(493, 200);
            Console.Beep(523, 200);
            Thread.Sleep(400);
            Console.Beep(349, 400);
            Console.Beep(392, 200);
            Console.Beep(329, 200);
            Console.Beep(523, 200);
            Console.Beep(493, 200);
            Console.Beep(466, 200);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(523, 200);
            Console.Beep(880, 200);
            Console.Beep(493, 200);
            Console.Beep(880, 200);
            Console.Beep(1760, 200);
            Console.Beep(440, 200);
            Console.Beep(392, 200);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(783, 200);
            Console.Beep(440, 200);
            Console.Beep(783, 200);
            Console.Beep(1568, 200);
            Console.Beep(392, 200);
            Console.Beep(349, 200);
            Console.Beep(392, 200);
            Console.Beep(440, 200);
            Console.Beep(698, 200);
            Console.Beep(415, 200);
            Console.Beep(698, 200);
            Console.Beep(1396, 200);
            Console.Beep(349, 200);
            Console.Beep(329, 200);
            Console.Beep(311, 200);
            Console.Beep(329, 200);
            Console.Beep(659, 200);
            Console.Beep(698, 400);
            Console.Beep(783, 400);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(523, 200);
            Console.Beep(880, 200);
            Console.Beep(493, 200);
            Console.Beep(880, 200);
            Console.Beep(1760, 200);
            Console.Beep(440, 200);
            Console.Beep(392, 200);
            Console.Beep(440, 200);
            Console.Beep(493, 200);
            Console.Beep(783, 200);
            Console.Beep(440, 200);
            Console.Beep(783, 200);
            Console.Beep(1568, 200);
            Console.Beep(392, 200);
            Console.Beep(349, 200);
            Console.Beep(392, 200);
            Console.Beep(698, 200);
            Console.Beep(659, 200);
            Console.Beep(698, 200);
            Console.Beep(739, 200);
            Console.Beep(783, 200);
            Console.Beep(392, 200);
            Console.Beep(392, 200);
            Console.Beep(392, 200);
            Console.Beep(392, 200);
            Console.Beep(196, 200);
            Console.Beep(196, 200);
            Console.Beep(196, 200);
            Console.Beep(185, 200);
            Console.Beep(196, 200);
            Console.Beep(185, 200);
            Console.Beep(196, 200);
            Console.Beep(207, 200);
            Console.Beep(220, 200);
            Console.Beep(233, 200);
        }
    }
}
