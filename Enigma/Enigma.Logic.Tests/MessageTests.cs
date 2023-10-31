using Enigma.Logic.Definitions;
using System.Text;
using Xunit.Abstractions;

namespace Enigma.Logic.Tests
{
    public class MessageTests
    {
        private readonly ITestOutputHelper output;

        public MessageTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        private void Crypt(MachineDefinition machineDefnition, MachineConfiguration machineConfiguration, string input, string output)
        {
            input = input.Replace(" ", "");
            output = output.Replace(" ", "");

            input.Length.ShouldBe(output.Length);

            //Forward
            {
                var machine = EnigmaBuilder.BuildMachine(machineDefnition, machineConfiguration);

                this.output.WriteLine(machine.ToTable("Initial", true));

                var decryptedMessage = new StringBuilder();

                foreach(var inputLetter in input)
                {
                    var result = machine.TypeLetter(inputLetter);

                    var outputLetter = machineDefnition.Alphabet[result.OutputIndex];

                    decryptedMessage.Append(outputLetter);

                    this.output.WriteLine(machine.ToTable($"{inputLetter} -> {outputLetter}" ));

                    this.output.WriteLine(result.ToTable(machineDefnition.Alphabet));
                }

                decryptedMessage.ToString().ShouldBe(output);
            }

            //Reverse
            {
                var machine = EnigmaBuilder.BuildMachine(machineDefnition, machineConfiguration);

                var decryptedMessage = machine.TypeMessage(output);

                decryptedMessage.ShouldBe(input);
            }
        }

        [Fact]
        public void TuringsTreatise1940()
        {
            /*
            
            http://wiki.franklinheath.co.uk/index.php/Enigma/Sample_Messages
            
            Machine Settings for Enigma K Railway
            Wheel order:     III I II
            Ring positions:  26 17 16 13
            Message key:     JEZA
            
             */

            const string encryptedMessage = "QSZVI DVMPN EXACM RWWXU IYOTY NGVVX DZ";
            const string decryptedMessage = "DEUTS QETRU PPENS INDJE TZTIN ENGLA ND";

            var machineconfiguration = new MachineConfiguration
            {
                InputName = "ETW",
                WheelOrder = new string[]
                {
                    "III",
                    "I",
                    "II"
                },
                ReflectorName = "UKW",

                InitialWheelPositions = new NumbersOrLetters("JEZA"),
                RingSettings = new NumbersOrLetters(new [] { 26, 17, 16, 13 })
            };

            Crypt(KnownMachines.K, machineconfiguration, encryptedMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("OPGN DXCF WEVT NRSD ULTP", "THIS IS A SECRET MESSAGE")]
        public void Madlab1(string input, string expected)
        {
            // http://www.madlab.org/guides/enigma.html
            var configuration = new MachineConfiguration
            {
                WheelOrder = new string[] { "I", "II", "III" },
                RingSettings = new NumbersOrLetters(new int[] { 1, 1, 1 }),
                InitialWheelPositions = new NumbersOrLetters("AAA"),
                ReflectorName = "UKW-B"
            };

            Crypt(KnownMachines.M3, configuration, input, expected);
        }

        [Theory]
        [InlineData("ZUZB PCBG EOGY TRPB VUXG QTIX AWHT ZDZV ITOA", "ENIGMA WAS USED DURING THE SECOND WORLD WAR")]
        public void Madlab2(string input, string expected)
        {
            // Encoded with rotors 7, 1, 3 and reflector C

            // http://www.madlab.org/guides/enigma.html
            var configuration = new MachineConfiguration
            {
                WheelOrder = new string[] { "VII", "I", "III" },
                RingSettings = new NumbersOrLetters(new int[] { 1, 1, 1 }),
                InitialWheelPositions = new NumbersOrLetters("AAA"),
                ReflectorName = "UKW-C"
            };

            Crypt(KnownMachines.M3, configuration, input, expected);
        }

        [Theory]
        [InlineData("A", "AAZ", "U")]
        [InlineData("A", "AAA", "B")]
        [InlineData("A", "AAB", "D")]
        [InlineData("TESTING", "AAZ", "FFXHQCZ")]
        [InlineData("THISI SANAM AZING MESSA GEFOO L", "AAZ", "FIOPQ BWRXO TYXTZ ANUNP DYCHA G")]
        [InlineData("THISI SANAM AZING MESSA GEFOO L", "AAZ", "DYMPV BYHGO PIJTZ LIUTM KXCHL F", "TN IY DK QE AL")]
        [InlineData("THISI SANAM AZING MESSA GEFOO L", "AAZ", "VTMWU EGEPO OEOEJ NQPZD EBZND E", null, "HBC")]

        [InlineData("TANYA", "ABZ", "BEDQB", null, "RAZ", "III|II|IV")]
        public void M3(string input, string initialWheelPositions, string expected, string? plugboard = null, string ringSettings = "AAA", string wheelOrder = "I|II|III")
        {
            var parsedWheelOrder = wheelOrder.Split("|");

            // https://www.101computing.net/enigma-machine-emulator/   - shows steps
            // https://cryptii.com/pipes/enigma-machine                - slick interface but doesn't show steps

            // http://www.madlab.org/guides/enigma.html
            var configuration = new MachineConfiguration
            {
                //InputName = "ETW",
                WheelOrder = parsedWheelOrder,
                RingSettings = new NumbersOrLetters(ringSettings),
                InitialWheelPositions = new NumbersOrLetters(initialWheelPositions),
                ReflectorName = "UKW-B",
                Plugboard = plugboard
            };

            Crypt(KnownMachines.M3, configuration, input, expected);
        }

        [Theory]
        [InlineData("P", "G")]
        [InlineData("G", "P")]
        public void Example(string input, string expected)
        {
            // https://www.codesandciphers.org.uk/enigma/example1.htm
            var configuration = new MachineConfiguration
            {
                WheelOrder = new string[] { "I", "II", "III" },
                RingSettings = new NumbersOrLetters(new int[] { 1, 1, 1 }),
                InitialWheelPositions = new NumbersOrLetters("AAZ"),
                ReflectorName = "UKW-B",
            };

            Crypt(KnownMachines.I, configuration, input, expected);
        }

        [Theory]
        [InlineData(
            "YKAE NZAP MSCH ZBFO CUVM RMDP YCOF HADZ IZME FXTH FLOL PZLF GGBO TGOX GRET DWTJ IQHL MXVJ WKZU ASTR",
            "STEUE REJTA NAFJO RDJAN STAND ORTQU AAACC CVIER NEUNN EUNZW OFAHR TZWON ULSMX XSCHA RNHOR STHCO")]
        public void Scharnhorst(string input, string expected)
        {
            /*
            Machine Settings for Enigma M3
            Reflector:       B
            Wheel order:     III VI VIII
            Ring positions:  01 08 13
            Plug pairs:	     AN EZ HK IJ LR MQ OT PV SW UX
            Message key:     UZV
            */

            var configuration = new MachineConfiguration
            {
                InputName = "ETW",
                WheelOrder = new string[] { "III", "VI", "VIII" },
                ReflectorName = "UKW-B",
                RingSettings = new NumbersOrLetters(new[] { 01, 08, 13 }),
                InitialWheelPositions = new NumbersOrLetters("UZV"),
                Plugboard = "AN EZ HK IJ LR MQ OT PV SW UX"
            };

            Crypt(KnownMachines.M3, configuration, input, expected);
        }

        
    }
}

