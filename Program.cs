// See https://aka.ms/new-console-template for more information
using Json2Env.Services;
using System.CommandLine;

var engine = new Json2EnvService();

var jsonFilePath = new Argument<String>("filepath", "Filepath to the Json Config");

var seperator = new Option<string>("--s", "Seperator for Keys and Values");
seperator.IsRequired = false;
seperator.AddAlias("--s");

var output = new Option<string>("--output", "Output file name");
output.IsRequired = false;
output.AddAlias("--output");

var cmd = new RootCommand();
cmd.AddArgument(jsonFilePath);
cmd.AddOption(seperator);
cmd.AddOption(output);
 

cmd.SetHandler(async (filepath, seperator, output) =>
{
    await engine.Process(filepath, seperator, output, "");
}, 
jsonFilePath, seperator, output);    

return cmd.InvokeAsync(args).Result;