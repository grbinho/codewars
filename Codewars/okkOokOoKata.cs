using System;
namespace Codewars
{
    public class okkOokOoKata
    {
		/*  8 charactera. o or k
		 *  ! => end of message
		 *  ? => end of word
		 * 
		 *  Ok, Ook, Ooo => H (72 in ASCII)
		 *  01  001  000
		 *  64 + 8  => 72
		 * 
		 *  Okk, Okkkk
		 *  011  01111 = 1 + 2 + 4 + 8 + (16) + 32 + 64 => 111 => o
		 * 
		 */

		public static string okkOokOo(string okkOookk)
		{
            //Take the string up to !
            //Split the stirng with ? as the divider.
            //Translate "O" & "k" into ASCII
            var result = String.Empty;

            var message = okkOookk.Substring(0, okkOookk.IndexOf('!') + 1);
            var tokens = message.Split('?');

            foreach(var token in tokens) {                            
                int asciiCode = 0;
                int j = token.Length - 1;
                int i = 0;
                for (; j >= 0; j--)
                {
					//If it's k => calculate and move
					//If it's O || o => move
					if(token[j] == 'k')
                    {
                        asciiCode += (int)Math.Pow(2, i);
                        i++;
                    }
                    else if (token[j] == 'O' || token[j] == 'o')
                    {
                        i++;
                    }
                }

                result += Convert.ToChar(asciiCode);
            }


            return result;
		}
    }
}
