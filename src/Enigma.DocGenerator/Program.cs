using Enigma.DocGenerator.Factories;
using Scriban;

var templateSource = File.ReadAllText("../../../Templates/knownMachines.scriban");

var template = Template.Parse(templateSource);

var machinesModel = KnownMachinesFactory.CreateModel();

var result = template.Render(machinesModel);

const string directory = "../../../../../docs";

Directory.CreateDirectory(directory);

File.WriteAllText(Path.Combine(directory, "known-machines.md"), result);