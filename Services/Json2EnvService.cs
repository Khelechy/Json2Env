using Json2Env.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json2Env.Services
{
    public class Json2EnvService
    {
        private readonly string format = "{0}={1}";
        private readonly string folderName = @"c:\Json2Env";

        public async Task Process(string filePath, string seperator, string fileName = "", string nullable = "")
        {
            SeperatorEnum seperatorEnum;
            bool isNullable = false;
            if (string.IsNullOrEmpty(seperator) || seperator.ToLower() == "u")
            {
                seperatorEnum = SeperatorEnum.Underscore;
            }
            else
            {
                seperatorEnum = SeperatorEnum.Column;
            }

            if (string.IsNullOrEmpty(nullable) || nullable.ToLower() == "false")
            {
                isNullable = false;
            }else if(nullable.ToLower() == "true")
            {
                isNullable = true;
            }
            var data = await Convert(filePath, seperatorEnum, isNullable);
            Write2File(fileName, data);
        }
        private async Task<string> Convert(string filePath, SeperatorEnum seperator, bool nullable = false)
        {
            
            try
            {
                var builder = new ConfigurationBuilder();
                string result = string.Empty;

                string jsonString = File.ReadAllText(@filePath);
                var stream = new MemoryStream(jsonString.Length);
                var sw = new StreamWriter(stream);
                await sw.WriteAsync(jsonString);
                await sw.FlushAsync();
                stream.Position = 0;

                builder.AddJsonStream(stream);

                var configurationRoot = builder.Build();

                var sb = new StringBuilder();
                foreach ((string key, string? value) in configurationRoot.AsEnumerable()
                       .Where(pair => nullable || !string.IsNullOrEmpty(pair.Value))
                       .OrderBy(pair => pair.Key))
                {
                    string newKey = key;
                    if (seperator == SeperatorEnum.Underscore)
                    {
                        newKey = newKey.Replace(":", "__");
                    }
                    if (value != null && value.Contains(" "))
                    {
                        sb.AppendFormat(format, newKey, $"\'{value}\'");
                        sb.AppendLine();
                    }
                    else
                    {
                        sb.AppendFormat(format, newKey, value);
                        sb.AppendLine();
                    }  
                }

                result = sb.ToString();
                stream.Flush();

                return result;
            }catch (DirectoryNotFoundException)
            {
                Console.WriteLine($"Filepath: {filePath} does not exist");
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void Write2File(string fileName, string data)
        {

            string pathString = System.IO.Path.Combine(folderName, "output");

            System.IO.Directory.CreateDirectory(pathString);
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = ".env";
            }
            else
            {
                fileName = fileName + ".env";
            }
            pathString = System.IO.Path.Combine(pathString, fileName);

            File.WriteAllText(pathString, data);
            
        }


    }
}
