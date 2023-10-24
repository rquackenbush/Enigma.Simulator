using Snork.AsciiTable;
using System.Reflection.PortableExecutable;

namespace Enigma.Logic.Tests
{
    public static class TableExtensions
    {
        public static string ToTable(this Machine machine, string title, bool includeRingSettings = false)
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

                rowItems.Add(machine.Alphabet.GetWheelPositionString(machine.Reflector.PositionIndex));

                for (var rotorIndex = 0; rotorIndex < machine.Rotors.Length; rotorIndex++)
                {
                    var positionIndex = machine.Rotors[rotorIndex].PositionIndex;

                    rowItems.Add(machine.Alphabet.GetWheelPositionString(positionIndex));
                }

                if (machine.Input != null)
                {
                    rowItems.Add(machine.Alphabet.GetWheelPositionString(machine.Input.PositionIndex));
                }

                table.Add(rowItems.ToArray());
            }

            //Ring Settings
            if (includeRingSettings)
            {
                var rowItems = new List<object>
                {
                    "Ring Setting"
                };

                //Reflector
                rowItems.Add(machine.Alphabet.GetWheelPositionString(machine.Reflector.RingSettingIndex));

                //Rotors
                for (var rotorIndex = 0; rotorIndex < machine.Rotors.Length; rotorIndex++)
                {
                    var ringSettingIndex = machine.Rotors[rotorIndex].RingSettingIndex;

                    rowItems.Add(machine.Alphabet.GetWheelPositionString(ringSettingIndex));
                }

                //Input
                if (machine.Input != null) 
                {
                    rowItems.Add(machine.Alphabet.GetWheelPositionString(machine.Input.RingSettingIndex));
                }

                table.Add(rowItems.ToArray());
            }


            return table.ToString();
        }

        public static string ToTable(this TypeLetterResult result)
        {
            var table = new AsciiTableGenerator($"{result.InputLetter} --> {result.OutputLetter}");

            var captions = new List<string>
            {
                "Name",
                "In",
                "Out",
                "Direction"
            };

            table.SetCaptions(captions.ToArray());

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

        public static string GetWheelPositionString(this Alphabet alphabet, int positionIndex)
        {
            return $"{positionIndex + 1:00} - {alphabet[positionIndex].Letter}";
        }
    }
}
