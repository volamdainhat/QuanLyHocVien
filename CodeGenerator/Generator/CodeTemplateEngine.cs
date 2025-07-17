namespace Generator;

public static class CodeTemplateEngine
{
    public static void Generate(string entity, string[] templates)
    {
        string root = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string templateDir = Path.Combine(root, "Templates");
        string outputDir = Path.Combine(root, "Output");
        Directory.CreateDirectory(outputDir);

        foreach (var tpl in templates)
        {
            var content = File.ReadAllText(Path.Combine(templateDir, $"{tpl}.txt"));
            content = content.Replace("{{Entity}}", entity);
            File.WriteAllText(Path.Combine(outputDir, $"{entity}{tpl}.cs"), content);
        }
    }
}
