namespace SirmaSolutionTask.FileService
{
    using System.Collections.Generic;
    using System.IO;
    using System;
    public static class FileReader
    {
        public static List<string> Read(String filePath)
        {
            List<string> content = new List<string>();

            try {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        content.Add(line);
                    }
                }
            } 
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return content;
        }
    }
}
