using Enigma.Simulator.DocGenerator.Models;

namespace Enigma.Simulator.DocGenerator.Factories
{
    public static class KnownMachinesFactory
    {
        public static KnownMachinesModel CreateModel()
        {
            var machineModels = new List<KnownMachineModel>();

            foreach (var machine in KnownMachines.GetAll())
            {
                var rotors = new List<RotorModel>();

                if (machine.Inputs != null)
                {
                    foreach (var input in machine.Inputs)
                    {
                        rotors.Add(new RotorModel(input.Name, input.Wiring, "", ""));
                    }
                }

                foreach (var rotor in machine.Rotors)
                {
                    rotors.Add(new RotorModel(rotor.Name, rotor.Wiring, rotor.Notches, ""));
                }

                foreach (var reflector in machine.Reflectors)
                {
                    rotors.Add(new RotorModel(reflector.Name, reflector.Wiring, "", ""));
                }


                machineModels.Add(new KnownMachineModel(machine.Name, machine.Alphabet, rotors.ToArray()));

            }

            return new KnownMachinesModel(machineModels.ToArray());
        }
    }
}
