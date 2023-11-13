# enigma-net
Enigma Machine Simulation Engine

# Quick Start

```c#
var configuration = new MachineConfiguration
{
    WheelOrder = new string[] { "I", "II", "III" }
    RingSettings = new LettersOrNumbers("AAA"),
    InitialWheelPositions = new NumbersOrLetters("AAZ"),
    ReflectorName = "UKW-B"
};

var machine = enigmaBuilder.BuildMachine(KnownMachines.M3, configuration);

Console.WriteLine(machine.TypeMessage("TESTING"));
```

Should yield:

```
FFXHQCZ
```

# Documentation

[Known Machines](docs/known-machines.md)

# Resources

| Source | Description |
|---|---|
|https://www.cryptomuseum.com/crypto/enigma/wiring.htm | Wiring |
|http://wiki.franklinheath.co.uk/index.php/Enigma/Sample_Messages| Sample Messages|