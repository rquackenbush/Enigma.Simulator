using Enigma.Logic.Configuration;

namespace Enigma.Logic.Tests
{
    public class MessageTests
    {
        [Fact]
        public void TuringsTreatise1940()
        {
            const string encryptedMessage = "QSZVI DVMPN EXACM RWWXU IYOTY NGVVX DZ";
            const string expectedDecryptedMessage = "DEUTS QETRU PPENS INDJE TZTIN ENGLA ND";

            var machineConfiguration = new MachineConfiguration
            {
                InputName = "ETW",
                WheelOrder = new string[]
                {
                    "III",
                    "I",
                    "II"
                },
                ReflectorName = "UKW",
                RingPositions = new int[]
                {
                    26,
                    17,
                    16,
                    13
                }
            };
            
            //MessageKey: JEZA
            var machine = MachineBuilder.BuildMachine(KnownMachines.K, machineConfiguration);

            var decryptedMessage = machine.TypeMessage(encryptedMessage.Replace(" ", ""));

            decryptedMessage.ShouldBe(expectedDecryptedMessage.Replace(" ", ""));
        }
    }
}
//        [Fact]
//        public void Message1()
//        {
//            //const string sourceMessage = "DEUTS QETRU PPENS INDJE TZTIN ENGLA ND";
//            //const string expectedEncryptedMessage = "QSZVI DVMPN EXACM RWWXU IYOTY NGVVX DZ";

//            var machineDefinition = new EnigmaMachineDefinition
//            {
//                Name = "T",
//                Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
//                Inputs = new InputDefinition[]
//                {
//                    new InputDefinition("ETW", "KZROUQHYAIGBLWVSTDXFPNMCJE")
//                },
//                Rotors = new EnigmaRotorDefinition[]
//                {
//                    new EnigmaRotorDefinition("I", "KPTYUELOCVGRFQDANJMBSWHZXI", "EHMSY"),
//                    new EnigmaRotorDefinition("II", "UPHZLWEQMTDJXCAKSOIGVBYFNR", "EHNTZ"),
//                    new EnigmaRotorDefinition("III", "QUDLYRFEKONVZAXWHMGPJBSICT", "EHMSY"),
//                    new EnigmaRotorDefinition("IV", "CIWTBKXNRESPFLYDAGVHQUOJZM", "EHNTZ"),
//                    new EnigmaRotorDefinition("V", "UAXGISNJBVERDYLFZWTPCKOHMQ", "GKNSZ"),
//                    new EnigmaRotorDefinition("VI", "XFUZGALVHCNYSEWQTDMRBKPIOJ", "FMQUY"),
//                    new EnigmaRotorDefinition("VII", "BJVFTXPLNAYOZIKWGDQERUCHSM", "GKNSZ"),
//                    new EnigmaRotorDefinition("VIII", "YMTPNZHWKODAJXELUQVGCBISFR", "FMQUY")
//                },
//                Reflectors = new ReflectorDefinition[]
//                {
//                    new ReflectorDefinition("UKW", "GEKPBTAUMOCNILJDXZYFHWVQSR")
//                }
//            };

//            var machine = EnigmaBuilder.BuildMachine(machineDefinition);

//            var machineInstanceDefinition = new EnigmaMachineInstanceDefinition
//            {
//                Machine = machine,
//                InputName = "ETW",
//                RotorNames = new[] { "VI", "IV", "VII" },
//                ReflectorName = "UKW",
//                InitialRotorPositions = new[] { 06, 17, 03, 20 }
//            };

//            var machineInstance = EnigmaBuilder.BuildMachineInstance(machineInstanceDefinition);

//            machineInstance.TypeLetter('D').ShouldBe('Q');
//        }
//    }
//}
