using System;
using System.Collections.Generic;
using System.Linq;

namespace InsecureWebsite.Models
{
    public class FakeSystem
    {
        /** Basically a class to emulate
         * shell commands without actually
         * calling shell commands.
         */

        private readonly Dictionary<string, string> _fakeFiles = new()
        {
            ["flag.txt"] = "oh_no_youve_captured_my_flag",
            ["readme.txt"] = "Welcome Traveller..."
        };

        public string Run(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Error: no host provided.";

            var parts = input.Split(
                new[] { "&&" },
                StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
            );

            var output = new List<string>
            {
                FakePing(parts[0])
            };

            for (int i = 1; i < parts.Length; i++)
            {
                output.Add(RunFakeCommand(parts[i]));
            }

            return string.Join("\n\n", output);
        }

        private string FakePing(string host)
        {
            return $"""
            Pinging {host} with 32 bytes of data:
            Reply from {host}: bytes=32 time<1ms TTL=128
            Ping statistics for {host}:
                Packets: Sent = 1, Received = 1, Lost = 0
            """;
        }

        private string RunFakeCommand(string commandLine)
        {
            var tokens = commandLine.Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );

            if (tokens.Length == 0)
                return "";

            var command = tokens[0].ToLowerInvariant();
            var args = tokens.Skip(1).ToArray();

            return command switch
            {
                "whoami" => "sandbox\\webuser",

                "echo" => string.Join(" ", args),

                "dir" => """
                         Directory of C:\sandbox

                         01/01/2026 12:00 AM   <DIR>     .
                         01/01/2026 12:00 AM   <DIR>     ..
                         01/01/2026 12:00 AM              42 flag.txt
                         01/01/2026 12:00 AM              35 readme.txt
                         """,

                "ls" => "flag.txt\nreadme.txt",

                "cat" => FakeCat(args),

                _ => $"'{command}' is not recognized in this sandbox."
            };
        }

        private string FakeCat(string[] args)
        {
            if (args.Length == 0)
                return "cat: missing file operand";

            var fileName = args[0];

            if (_fakeFiles.TryGetValue(fileName, out var contents))
                return contents;

            return $"cat: {fileName}: No such file or directory";
        }
    }
}