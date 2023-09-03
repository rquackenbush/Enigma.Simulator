namespace Enigma.Logic
{
    public static class KnownMachines
    {
        public static EnigmaMachine B { get; }

        public static EnigmaMachine D { get; }

        public static EnigmaMachine I { get; }

        static KnownMachines()
        {
            B = new EnigmaMachineDefinition
            {
                Name = "B",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖ",
                Inputs = new InputDefinition[]
                {
                    new InputDefinition("ETW", "ABCDEFGHIJKLMNOPQRSTUVXYZÅÄÖ")
                },
                Rotors = new EnigmaRotorDefinition[]
                {
                    new EnigmaRotorDefinition("I", "PSBGÖXQJDHOÄUCFRTEZVÅINLYMKA", "G"),
                    new EnigmaRotorDefinition("II", "CHNSYÖADMOTRZXBÄIGÅEKQUPFLVJ", "G"),
                    new EnigmaRotorDefinition("III", "ÅVQIAÄXRJBÖZSPCFYUNTHDOMEKGL", "G")
                },
                Reflectors = new ReflectorDefinition[]
                {
                    new ReflectorDefinition("UKW", "LDGBÄNCPSKJAVFZHXUIÅRMQÖOTEY")
                }
            }.BuildMachine();

            D = new EnigmaMachineDefinition
            {
                Name = "D",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Inputs = new InputDefinition[]
                {
                    new InputDefinition("ETW", "QWERTZUIOASDFGHJKPYXCVBNML")
                },
                Rotors = new EnigmaRotorDefinition[]
                {
                    new EnigmaRotorDefinition("I", "LPGSZMHAEOQKVXRFYBUTNICJDW", "G"),
                    new EnigmaRotorDefinition("II", "SLVGBTFXJQOHEWIRZYAMKPCNDU", "M"),
                    new EnigmaRotorDefinition("III", "CJGDPSHKTURAWZXFMYNQOBVLIE", "V"),
                },
                Reflectors = new ReflectorDefinition[]
                {
                    new ReflectorDefinition("UKW", "IMETCGFRAYSQBZXWLHKDVUPOJN")
                }
            }.BuildMachine();

            I = new EnigmaMachineDefinition
            {
                Name = "I",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Inputs = new InputDefinition[]
                {
                    new InputDefinition("ETW", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                },
                Rotors = new EnigmaRotorDefinition[]
                {
                    new EnigmaRotorDefinition("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Y"),
                    new EnigmaRotorDefinition("II", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "M"),
                    new EnigmaRotorDefinition("III", "BDFHJLCPRTXVZNYEIWGAKMUSQO", "D"),
                    new EnigmaRotorDefinition("IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", "R"),
                    new EnigmaRotorDefinition("V", "VZBRGITYUPSDNHLXAWMJQOFECK", "H"),
                },
                Reflectors = new ReflectorDefinition[]
                {
                    new ReflectorDefinition("UKW-A", "EJMZALYXVBWFCRQUONTSPIKHGD"),
                    new ReflectorDefinition("UKW-B", "YRUHQSLDPXNGOKMIEBFZCWVJAT"),
                    new ReflectorDefinition("UKW-C", "FVPJIAOYEDRZXWGCTKUQSBNMHL"),
                }

            }.BuildMachine();
        }
    }
}
