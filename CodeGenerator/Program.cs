class Program
{
    static void Main(string[] args)
    {
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string templatePath = Path.Combine(projectRoot, "Templates");
        string outputPath = Path.Combine(projectRoot, "Output");

        Console.Write("Input Entity name (e.g: Trainee): ");
        var entity = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(entity))
        {
            Console.WriteLine("Invalid Entity name!");
            return;
        }

        string[] templates = {
            "IRepository.txt",
            "Repository.txt",
            "Dto.txt"
        };

        foreach (var file in templates)
        {
            var filePath = Path.Combine(templatePath, file);
            var content = File.ReadAllText(filePath);

            var result = content.Replace("{{Entity}}", entity);
            var outName = file.Replace(".txt", "").Replace("{{Entity}}", entity);
            File.WriteAllText(Path.Combine(outputPath, $"{entity}{outName}.cs"), result);
        }

        Console.WriteLine("✅ Generate template code successful.");
    }
}
