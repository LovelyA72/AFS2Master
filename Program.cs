using System;
using System.Collections.Generic;
using System.IO;

namespace afs2master
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] fileBytes = { };
            List<Byte> outBytes = new List<byte>();
            int startIndex = -1;
            if (args.Length != 1) {
                Console.WriteLine("AFS2M@STER: Starlit Season v0.5");
                Console.WriteLine("Copyright (c)2021 LovelyA72 - licensed under the MIT license");
                Console.WriteLine("Simple cuesheet AFS2 stripper");
                Console.WriteLine("");
                Console.WriteLine("Usage: afs2master <file_in>");
                return;
            }
            fileBytes = File.ReadAllBytes(args[0]);
            for (int i = 0; i < fileBytes.Length-5; i++)
            {
                if (fileBytes[i]=='A' &&
                    fileBytes[i+1] == 'F' &&
                    fileBytes[i+2] == 'S' &&
                    fileBytes[i+3] == '2' &&
                    startIndex ==-1)
                {
                    startIndex = i;
                }
            }
            if (startIndex != -1)
            {
                for (int i = startIndex; i < fileBytes.Length; i++)
                {
                    outBytes.Add(fileBytes[i]);
                }
                File.WriteAllBytes(args[0] + ".awb", outBytes.ToArray());
            }
            else {
                Console.WriteLine("AFS2 header not found! Is this a valid Starlit Season cue sheet that includes an AFS2 file?");
            }
        }
    }
}
