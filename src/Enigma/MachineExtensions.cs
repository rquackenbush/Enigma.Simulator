using System.Text;

namespace Enigma
{
    /// <summary>
    /// Extensions helpful for interacting with <see cref="Machine"/> instances.
    /// </summary>
    public static class MachineExtensions
    {
        /// <summary>
        /// Types a message and returns the crypted result.
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string TypeMessage(this Machine machine, string message)
        {
            var response = new StringBuilder();

            foreach (var inputChar in message)
            {
                var result = machine.TypeLetter(inputChar);

                response.Append(machine.Alphabet[result.OutputIndex]);
            }

            return response.ToString();
        }
    }
}
