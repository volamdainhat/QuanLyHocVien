using CodeGenerator.Models;

namespace CodeGenerator.Generator
{
    public static class EntityParser
    {
        public static (string className, List<EntityProperty>) ParseFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var properties = new List<EntityProperty>();
            string className = "";

            foreach (var line in lines)
            {
                if (line.Trim().StartsWith("public class"))
                {
                    className = line.Trim().Split(" ")[2];
                }

                if (!line.Trim().StartsWith("public")) continue;
                if (!line.Contains("{ get; set; }")) continue;

                var cleaned = line.Replace("{ get; set; }", "").Replace(";", "").Trim();
                var parts = cleaned.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 2) continue;

                var required = cleaned.Contains("required");
                string? type;
                string? name;
                bool nullable;

                if (required)
                {
                    type = parts[2].Replace("?", "");
                    nullable = parts[2].EndsWith("?");
                    name = parts[3];
                }
                else
                {
                    type = parts[1].Replace("?", "");
                    nullable = parts[1].EndsWith("?");
                    name = parts[2];
                }

                properties.Add(new EntityProperty
                {
                    Type = type,
                    Name = name,
                    IsNullable = nullable,
                    IsRequired = required
                });
            }

            return (className, properties);
        }
    }

}
