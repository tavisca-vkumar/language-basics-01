using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        public static int FindDigit(string equation)
        {
            // Add your code here.
            int starIndex = -1, questionIndex = -1, equalIndex = -1, bug = 1, ans = -1;
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '?')
                {
                    questionIndex = i;
                    if (starIndex <= 0)
                        bug = 1;
                    else if (equalIndex <= 0)
                        bug = 2;
                    else
                        bug = 3;
                }

                if (equation[i] == '*')
                    starIndex = i;
                if (equation[i] == '=')
                    equalIndex = i;
                //Console.WriteLine(equation[i]);
            }

            for (int i = 0; i <= 9; i++)
            {

                if (i == 0 && (questionIndex == 0 || questionIndex == starIndex + 1 || questionIndex == equalIndex + 1))
                    continue;
                string str = equation.Substring(0, questionIndex) + Convert.ToString(i) + equation.Substring(questionIndex + 1);
                //Console.WriteLine(str);

                if (Convert.ToInt32(str.Substring(0, starIndex)) * Convert.ToInt32(str.Substring(starIndex + 1, equalIndex - starIndex - 1)) == Convert.ToInt32(str.Substring(equalIndex + 1)))
                {
                    ans = i;
                    break;
                }
                //Console.WriteLine("--{0}--", i);
            }
            return ans;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            //Console.WriteLine(Convert.ToString(FindDigit(Console.Read())));
            Console.ReadKey(true);
        }
        
        private static void Test(string args, int expected)
        {
            var result = FixMultiplication.FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
    }

   
}
