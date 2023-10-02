using System.Text;

namespace Enigma.Logic
{
    public static class MachineExtensions
    {
        public static string TypeMessage(this Machine machine, string message)
        {
            var response = new StringBuilder();

            foreach(var inputChar in message)
            {
                response.Append(machine.TypeLetter(inputChar));
            }

            return response.ToString();
        }

        /// <summary>
        /// Converts an array of 1 based letter numbers to the actual letters.
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="letterNumbers">An array of 1 based indicies of the letters.</param>
        /// <returns></returns>
        public static string FromOneBased(this Alphabet alphabet, int[] letterNumbers)
        {
            var letters = "";

            foreach(var letterNumber in letterNumbers)
            {
                letters += alphabet[letterNumber - 1].Letter;
            }

            return letters;
        }
    }
}
