using Snork.AsciiTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.Logic.Tests
{
    public static class MachineExtensions
    {
        public static string ToTable(this Machine machine, string title)
        {
            var table = new AsciiTableGenerator(title);

            var captions = new List<string>
            {
                "Header",
                "Reflector"
            };

            for(var rotorIndex = 0; rotorIndex < machine.Rotors.Length; rotorIndex++)
            {
                captions.Add($"Rotor {rotorIndex + 1}");
            }

            if (machine.Input != null)
            {
                captions.Add("Input");
            }

            table.SetCaptions(captions.ToArray());

            //Names of the items
            {
                var rowItems = new List<object>
                {
                    "Name"
                };

                rowItems.Add(machine.Reflector.Name);

                for (var rotorIndex = 0; rotorIndex < machine.Rotors.Length; rotorIndex++)
                {
                    rowItems.Add(machine.Rotors[rotorIndex].Name);
                }

                if (machine.Input != null)
                {
                    rowItems.Add(machine.Input.Name);
                }


                table.Add(rowItems.ToArray());
            }

            // Positions
            {
                var rowItems = new List<object>
                {
                    "Position"
                };

                rowItems.Add("");

                for (var rotorIndex = 0; rotorIndex < machine.Rotors.Length; rotorIndex++)
                {
                    var positionIndex = machine.Rotors[rotorIndex].PositionIndex;

                    rowItems.Add($"{positionIndex + 1:00} - {machine.Alphabet[positionIndex].Letter}");
                }

                if (machine.Input != null)
                {
                    rowItems.Add("");
                }

                table.Add(rowItems.ToArray());
            }

            //Ring?


            return table.ToString();
        }

        public static string ToTable(this TypeLetterResult result)
        {
            var table = new AsciiTableGenerator($"{result.InputLetter} --> {result.OutputLetter}");

            var captions = new List<string>
            {
                "Name",
                "Input",
                "Output",
                "Direction"
            };

            foreach(var operation in result.Operations)
            {
                table.Add(
                    operation.Name,
                    result.Machine.Alphabet[operation.InputIndex].Letter,
                    result.Machine.Alphabet[operation.OutputIndex].Letter,
                    operation.Direction);
            }

            return table.ToString();
        }
    }
}
