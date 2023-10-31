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
                var result = machine.TypeLetter(inputChar);

                response.Append(machine.Alphabet[result.OutputIndex]);
            }

            return response.ToString();
        }
    }
}
