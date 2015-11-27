using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpinLogic
{
    public class RandomGenerator : IRandomGenerator
    {
        public string GameId(int length)
        {
            char[] allowedChars = { 'a', 'b', 'c', 'd', 'e', 'f','g','h','j','k','m','n','p','q','r','u','x','y','z','2','3','4','5','6','7','8','9' };
            StringBuilder gameId = new StringBuilder();

            Random random = new Random();
            for (int idPos = 0; idPos < length; idPos++)
            {
                var randomCharIndex = random.Next(0, allowedChars.Length - 1);
                //var randomCharIndex = 2;
                gameId.Append(allowedChars[randomCharIndex]);
            }

            return gameId.ToString();
        }

        public int RandomNumber(int from, int to)
        {
            System.Random random = new System.Random();
            return random.Next(from, to);
        }
    }
}
