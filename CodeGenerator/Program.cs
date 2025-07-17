using CodeGenerator.Generator;
using Generator;

class Program
{
    static void Main(string[] args)
    {
        string projectRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string templatePath = Path.Combine(projectRoot, "Templates");
        string outputPath = Path.Combine(projectRoot, "Output");

        Console.Write("Nhập đường dẫn đến file entity (.cs): ");
        string path = Console.ReadLine()!;
        var (entityName, props) = EntityParser.ParseFromFile(path);

        //FormGenerator.Generate(entityName, props); // truyền danh sách property
        CodeTemplateEngine.Generate(entityName, new[] { "IRepository", "Repository", "Dto" });

        Console.WriteLine("✅ Generate template code successful.");
    }
}
