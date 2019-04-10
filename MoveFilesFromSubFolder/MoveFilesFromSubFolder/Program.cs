using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MoveFilesFromSubFolder
{
    static class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            string outputPath;
            bool detailedLogging;
            bool move;

            switch (args.Length)
            {
                case 0:
                    inputPath = Environment.CurrentDirectory;

                    Console.WriteLine("Not Outputpath specified, please input one now:");

                    outputPath = Console.ReadLine();
                    detailedLogging = false;
                    move = false;
                    break;
                case 1:
                    inputPath = args[0];

                    Console.WriteLine("Not Outputpath specified, please input one now:");

                    outputPath = Console.ReadLine();
                    detailedLogging = false;
                    move = false;
                    break;
                case 2:
                    inputPath = args[0];
                    outputPath = args[1];

                    detailedLogging = false;
                    move = false;
                    break;
                case 3:
                    inputPath = args[0];
                    outputPath = args[1];
                    bool.TryParse(args[2], out detailedLogging);

                    move = false;
                    break;
                case 4:
                    inputPath = args[0];
                    outputPath = args[1];
                    bool.TryParse(args[2], out detailedLogging);
                    bool.TryParse(args[3], out move);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(@"Too many arguments");
            }

            List<FileInfo> inputFiles = MoveAllFiles(inputPath);

            foreach (FileInfo inputFile in inputFiles)
            {
                try
                {
                    if (move)
                    {
                        File.Move(inputFile.FullName, Path.Combine(outputPath, inputFile.Name));
                    }
                    else
                    {
                        File.Copy(inputFile.FullName, Path.Combine(outputPath, inputFile.Name), true);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }

                string filename = detailedLogging ? inputFile.FullName : inputFile.Name;
                string movedOrCopied = move ? "moved" : "copied";
                Console.WriteLine($"File {filename} {movedOrCopied}");
            }
        }

        private static List<FileInfo> MoveAllFiles(string inputPath)
        {
            var outputFiles = new List<FileInfo>();
            var directories = Directory.GetDirectories(inputPath);
            foreach (string directory in directories)
            {
                outputFiles.AddRange(MoveAllFiles(directory));
            }

            outputFiles.AddRange(Directory.GetFiles(inputPath).Select(file => new FileInfo(file)));

            return outputFiles;
        }
    }
}
