namespace CaterpillarSystem.utils
{
    internal class LogHelper
    {

        public void WriteToLogger(string data)
        {
            try
            {

                Console.WriteLine("Writting to log file");
                string filePath = "D:\\Kithome\\Coding hub\\CaterpillarSystem\\CaterpillarSystem\\utils\\log.txt";
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"LOGGING  DATA......{DateTime.Now:yyyy-MM-dd HH:mm:ss}:  for {data}\n\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while logging: {ex.Message}");
            }
        }

     
    }
}

