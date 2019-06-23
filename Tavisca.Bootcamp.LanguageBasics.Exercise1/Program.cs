using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }
        
        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            int star = -1, question = -1, equal = -1, bug=1, ans = -1; 
            for(int i=0; i<equation.Length; i++)
            {
                if (equation[i] == '?')
                {
                    question = i;
                    if (star <= 0)
                        bug = 1;
                    else if (equal <= 0)
                        bug = 2;
                    else
                        bug = 3;
                }

                if (equation[i] == '*')
                     star = i;
                if (equation[i] == '=')
                    equal = i;
                //Console.WriteLine(equation[i]);
            }
            
            for(int i=0; i<=9; i++)
            {

                if (i == 0 && (question == 0 || question == star + 1 || question == equal + 1))
                    continue;
                string str = equation.Substring(0, question) + Convert.ToString(i) + equation.Substring(question + 1);
                //Console.WriteLine(str);
                
                if (Convert.ToInt32(str.Substring(0, star)) * Convert.ToInt32(str.Substring(star + 1, equal - star - 1)) == Convert.ToInt32(str.Substring(equal + 1)))
                {
                    ans = i;
                    break;
                }
                //Console.WriteLine("--{0}--", i);
            }
            return ans;
            throw new NotImplementedException();
        }
    }
}
