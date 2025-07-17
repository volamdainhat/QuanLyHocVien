using CodeGenerator.Models;

namespace CodeGenerator.Generator
{
    public static class FormGenerator
    {
        public static void Generate(string entity)
        {
            var properties = new List<string>
            {
                "int Id",
                "string FullName",
                "int ClassId",
                "string? PhoneNumber",
                "DateTime? DayOfBirth",
                "string Ranking",
                "DateTime EnlistmentDate",
                "float? AverageScore",
                "string Role",
                "string? FatherFullName",
                "string? FatherPhoneNumber",
                "string? MotherFullName",
                "string? MotherPhoneNumber"
            };

            string templateRoot = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.FullName;
            string template = File.ReadAllText(Path.Combine(templateRoot, "Templates", "Form.txt"));

            string assignments = string.Join(Environment.NewLine,
                properties.Where(p => !p.Contains("Id")).Select(p =>
                {
                    var parts = p.Split(" ");
                    var type = parts[0].Trim();
                    var name = parts[1].Trim();

                    string control = type.Contains("DateTime") ? $"dtp{name}" : $"txt{name}";
                    string value = type.Contains("DateTime") ? $"{control}.Value" : $"{control}.Text";

                    return $"    {name} = {value},";
                }));

            string bindings = string.Join(Environment.NewLine,
                properties.Where(p => !p.Contains("Id")).Select(p =>
                {
                    var name = p.Split(" ")[1].Trim();
                    string control = p.Contains("DateTime") ? $"dtp{name}" : $"txt{name}";
                    return $"    {control}.Text = row.Cells[\"{name}\"].Value?.ToString();";
                }));

            string output = template.Replace("{{Entity}}", entity)
                                    .Replace("{{PropertyAssignments}}", assignments)
                                    .Replace("{{BindToControls}}", bindings);

            string outputDir = Path.Combine(templateRoot, "Output");
            //Directory.CreateDirectory(outputDir);
            File.WriteAllText(Path.Combine(outputDir, $"{entity}Form.cs"), output);
        }

        public static void Generate(string entity, List<EntityProperty> properties)
        {
            string root = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            string formTemplate = File.ReadAllText(Path.Combine(root, "Templates", "Form.txt"));

            var assignments = string.Join(Environment.NewLine,
                properties.Where(p => p.Name != "Id").Select(p =>
                    $"    {p.Name} = {p.GetValueExpression()},"));

            var bindings = string.Join(Environment.NewLine,
                properties.Where(p => p.Name != "Id").Select(p =>
                    $"    {p.GetBindingExpression()}"));

            var result = formTemplate.Replace("{{Entity}}", entity)
                                     .Replace("{{PropertyAssignments}}", assignments)
                                     .Replace("{{BindToControls}}", bindings);

            string outputDir = Path.Combine(root, "Output");
            //Directory.CreateDirectory(outputDir);
            File.WriteAllText(Path.Combine(outputDir, $"{entity}Form.cs"), result);
        }
    }

}
