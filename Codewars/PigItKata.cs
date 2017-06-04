using System;

namespace Codewars
{
	public class PigItKata
	{
		/*
            Move the first letter of each word to the end of it, then add 'ay' to the end of the word.
            Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
         */
		public static string PigIt(string str)
		{
            var words = str.Split(' ');
            var result = string.Empty;
            foreach(var w in words) {                
                var newWord = w.Substring(1) + w[0] + "ay";
                result += newWord + ' ';
            }

            return result.TrimEnd();
		}
	}
}
