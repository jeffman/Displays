using CommandLine;
using Displays.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.IO;

namespace Displays
{
    class Program
    {
        private const int ExitCodeOk = 0;
        private const int ExitCodeError = 1;

        private const char AbbreviationDisplayFile = 'd';
        private const string OptionDisplayFile = "display-file";

        [Verb("record", HelpText = "Record current Windows display configuration to file")]
        private class RecordOptions
        {
            [Option(AbbreviationDisplayFile, OptionDisplayFile, Required = true, HelpText = "Record display configuration to this file (JSON)")]
            public string OutputFile { get; set; } = string.Empty;
        }

        [Verb("restore", HelpText = "Restore Windows display configuration from file")]
        private class RestoreOptions
        {
            [Option(AbbreviationDisplayFile, OptionDisplayFile, Required = true, HelpText = "Read display configuration from this file (JSON)")]
            public string InputFile { get; set; } = string.Empty;
        }

        private static int Main(string[] args)
        {
            var program = new Program();
            return program.Run(args);
        }

        private int Run(string[] args)
        {
            using var parser = new Parser(settings =>
            {
                settings.HelpWriter = Console.Error;
            });

            try
            {
                return parser.ParseArguments<RecordOptions, RestoreOptions>(args)
                    .MapResult(
                        (RecordOptions r) => Record(r),
                        (RestoreOptions s) => Restore(s),
                        errors => ExitCodeError);
            }
            catch (Win32Exception windowsException)
            {
                Console.WriteLine($"Encountered a Windows error: 0x{windowsException.ErrorCode:X} ({windowsException.NativeErrorCode}) {windowsException.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Encountered an error: {exception.Message}");
            }
            return ExitCodeError;
        }

        private int Record(RecordOptions options)
        {
            var currentConfig = Api.QueryDisplayConfig(QueryDisplayConfigFlags.OnlyActivePaths);
            string json = JsonConvert.SerializeObject(currentConfig, CreateJsonSettings());
            string fullPath = Path.GetFullPath(options.OutputFile);
            File.WriteAllText(fullPath, json);
            Console.WriteLine($"Recorded current display configuration to {fullPath}");
            return ExitCodeOk;
        }

        private int Restore(RestoreOptions options)
        {
            string fullPath = Path.GetFullPath(options.InputFile);
            string json = File.ReadAllText(fullPath);
            var inputConfig = JsonConvert.DeserializeObject<DisplayConfigInfo>(json, CreateJsonSettings());
            Api.SetDisplayConfig(inputConfig!, SetDisplayConfigFlags.Apply | SetDisplayConfigFlags.UseSuppliedDisplayConfig);
            Console.WriteLine($"Restored display configuration from {fullPath}");
            return ExitCodeOk;
        }

        private JsonSerializerSettings CreateJsonSettings()
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.Converters.Add(new StringEnumConverter());
            return settings;
        }
    }
}
