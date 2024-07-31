namespace Pa.Api.Services
{
    public class LogService
    {
        public async Task LogToFile(string logFilePath, string log)
        {
            var logDirectory = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            await using var streamWriter = new StreamWriter(logFilePath, append: true);
            await streamWriter.WriteLineAsync($"{DateTime.UtcNow}: {log}");
            await streamWriter.WriteLineAsync(new string('-', 50));
        }
    }
}
