using Enigma.Logic.Definitions;

namespace Enigma.Logic
{
    public static class KnownMachines
    {
        public static MachineDefinition B => b.Value;

        public static MachineDefinition D => d.Value;

        public static MachineDefinition I => i.Value;

        public static MachineDefinition K => k.Value;

        public static MachineDefinition M3 => m3.Value;

        /// <summary>
        /// Railway K
        /// </summary>
        public static MachineDefinition RailwayK => railwayK.Value;

        private readonly static Lazy<MachineDefinition> b = new(() =>
            new MachineDefinition
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
                SlotCount = 3,
                HasPlugBoard = false
            });

        private readonly static Lazy<MachineDefinition> d = new(() =>
            new MachineDefinition
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
                SlotCount = 3,
                HasPlugBoard = false
            });

        private readonly static Lazy<MachineDefinition> i = new(() =>
            new MachineDefinition
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
                },
                SlotCount = 3,
                HasPlugBoard = true
            });

        private readonly static Lazy<MachineDefinition> k = new(() =>
            new MachineDefinition
            {
                Name = "K",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Inputs = new InputDefinition[]
                {
                    new ("ETW", "QWERTZUIOASDFGHJKPYXCVBNML")
                },
                Rotors = new RotorDefinition[]
                {
                    new ("I", "JGDQOXUSCAMIFRVTPNEWKBLZYH", "V"),
                    new ("II", "NTZPSFBOKMWRCJDIVLAEYUXHGQ", "M"),
                    new ("III", "JVIUBHTCDYAKEQZPOSGXNRMWFL", "G"),
                },
                Reflectors = new ReflectorDefinition[]
                {
                    new ("UKW", "QYHOGNECVPUZTFDJAXWMKISRBL", false)
                },
                SlotCount = 3,
                HasPlugBoard = false
            });

        // https://www.cryptomuseum.com/crypto/enigma/k/railway.htm
        // date 2 October 2023 — At present there seems to be confusion about the physical wiring of the UKW.
        // Altough the UKW wiring given in the table above was measured from the surviving machine with serial
        // number K438 [4], it differs from the wiring of a surviving Railway UKW with serial number K456 [5].
        // Although the internal wiring of the two reflectors is indentical, one of them is offset by 180°.
        // This means that either the ring setting was at 'N' or that one the UKWs was disassembled and the re-assembled the wrong way around.
        private readonly static Lazy<MachineDefinition> railwayK = new(() =>
            new MachineDefinition
            {
                Name = "K Railway",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Inputs = new InputDefinition[]
                    {
                        new ("ETW", "QWERTZUIOASDFGHJKPYXCVBNML")
                    },
                Rotors = new RotorDefinition[]
                    {
                        new ("I", "EVLPKUDJHTGSZFRABWYICOXNMQ", "G"),
                        new ("II", "HXMQKGJTSCZFLBERNAWYIDOVPU", "M"),
                        new ("III", "JHDBSKYPZNMVXURECLIGQOAWTF", "V")
                    },
                Reflectors = new ReflectorDefinition[]
                    {
                        new ("UKW", "DNSAJQIPGEXRWBVHFLCZYOMKUT", true)
                    },
                SlotCount = 3,
                HasPlugBoard = false
            });

        // https://www.cryptomuseum.com/crypto/enigma/m3/index.htm
        // https://en.wikipedia.org/wiki/Enigma_rotor_details
        private readonly static Lazy<MachineDefinition> m3 = new(() =>
            new MachineDefinition
            {
                Name = "M3",
                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                Inputs = new InputDefinition[]
                {
                    //new ("ETW", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
                    new ("ETW", "QWERTZUIOASDFGHJKPYXCVBNML")
                },
                Rotors = new RotorDefinition[]
                {
                    new("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", "Y"),
                    new("II", "AJDKSIRUXBLHWTMCQGZNPYFVOE", "M"),
                    new("III", "BDFHJLCPRTXVZNYEIWGAKMUSQO", "D"),
                    new("IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", "R"),
                    new("V", "VZBRGITYUPSDNHLXAWMJQOFECK", "H"),
                    new("VI", "JPGVOUMFYQBENHZRDKASXLICTW", "HU"),
                    new("VII", "NZJHGRCXMYSWBOUFAIVLPEKQDT", "HU"),
                    new("VIII", "FKQHTLXOCBJSPDZRAMEWNIUYGV", "HU"),
                },
                Reflectors = new ReflectorDefinition[] 
                { 
                    new ("UKW-B", "YRUHQSLDPXNGOKMIEBFZCWVJAT", true),
                    new ("UKW-C", "FVPJIAOYEDRZXWGCTKUQSBNMHL", true)
                },
                SlotCount = 3,
                HasPlugBoard = true
            }
        );
    }
}
