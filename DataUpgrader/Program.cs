namespace DataUpgrader
{
    public class Program
    {
        /*
         * Brief version history:
         * v1.1: changed the question number to a question name. Need to convert number -> Q[number]
         */
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new string[2];
                Console.WriteLine("Input version to convert from in the format \"1.3\", without the patch.");
                Console.Write(">>> ");
                args[0] = Console.ReadLine() ?? "1.0";
                Console.WriteLine("Input version to convert to.");
                Console.Write(">>> ");
                args[1] = Console.ReadLine() ?? "1.1";
            }
            float startVersion = 0;
            float endVersion = 0;
            if (float.TryParse(args[0], out startVersion) && float.TryParse(args[1], out endVersion)) // Successfully parsed version numbers to doubles for comparison
            {
                if (startVersion >= endVersion) return;
                string currentXml = "";
                using (StreamReader reader = new StreamReader("Data.xml"))
                {
                    currentXml = reader.ReadToEnd();
                }

                double currentVersion = startVersion;
                if (currentVersion < 1.1)
                {
                    currentXml = Version1Dot1.Convert(currentXml);
                    currentVersion = 1.1;
                    Console.WriteLine("Converted from 1.0 to 1.1");
                }

                using (StreamWriter writer = new StreamWriter("Data.xml"))
                {
                    writer.Write(currentXml);
                }
            }
        }
    }
}
