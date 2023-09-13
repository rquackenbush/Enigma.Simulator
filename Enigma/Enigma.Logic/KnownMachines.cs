using Enigma.Logic.Definitions;

namespace Enigma.Logic
{
    public static class KnownMachines
    {
        public static MachineDefinition B { get; }

        public static MachineDefinition D { get; }

        public static MachineDefinition I { get; }

        static KnownMachines()
        {
            B = new MachineDefinition
            {
                Name = "B",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖ",
                Inputs = new InputDefinition[]
                {
                    new InputDefinition("ETW", "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖ")
                },
                Rotors = new RotorDefinition[]
                {
                    new RotorDefinition("I", "PSBGÖXQJDHOÄUCFRTEZVÅINLYMKA", "G"),
                    new RotorDefinition("II", "CHNSYÖADMOTRZXBÄIGÅEKQUPFLVJ", "G"),
                    new RotorDefinition("III", "ÅVQIAÄXRJBÖZSPCFYUNTHDOMEKGL", "G")
                },
                Reflectors = new ReflectorDefinition[]
                {
                    new ReflectorDefinition("UKW", "LDGBÄNCPSKJAVFZHXUIÅRMQÖOTEY", false)
                },
                HasPlugBoard = false
            };

            D = new MachineDefinition
            {
                Name = "D",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Inputs = new InputDefinition[]
                {
                    new InputDefinition("ETW", "QWERTZUIOASDFGHJKPYXCVBNML")
                },
                Rotors = new RotorDefinition[]
                {
                    new ("I", "LPGSZMHAEOQKVXRFYBUTNICJDW", "G"),
                    new ("II", "SLVGBTFXJQOHEWIRZYAMKPCNDU", "M"),
                    new ("III", "CJGDPSHKTURAWZXFMYNQOBVLIE", "V"),
                },
                Reflectors = new ReflectorDefinition[]
                {
                    new ("UKW", "IMETCGFRAYSQBZXWLHKDVUPOJN", false)
                },
                HasPlugBoard = true
            };

            I = new MachineDefinition
            {
                Name = "I",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Inputs = new InputDefinition[]
                {
                    new InputDefinition("ETW", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                },
                Rotors = new RotorDefinition[]
                {
                    new ("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Y"),
                    new ("II", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "M"),
                    new ("III", "BDFHJLCPRTXVZNYEIWGAKMUSQO", "D"),
                    new ("IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", "R"),
                    new ("V", "VZBRGITYUPSDNHLXAWMJQOFECK", "H"),
                },
                Reflectors = new ReflectorDefinition[]
                {
                    new ("UKW-A", "EJMZALYXVBWFCRQUONTSPIKHGD", true),
                    new ("UKW-B", "YRUHQSLDPXNGOKMIEBFZCWVJAT", true),
                    new ("UKW-C", "FVPJIAOYEDRZXWGCTKUQSBNMHL", true),
                }

            };
        }
    }
}
