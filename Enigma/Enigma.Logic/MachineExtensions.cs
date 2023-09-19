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
    }
}
