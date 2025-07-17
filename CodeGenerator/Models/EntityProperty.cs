namespace CodeGenerator.Models
{
    public class EntityProperty
    {
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public bool IsNullable { get; set; }
        public bool IsRequired { get; set; }

        public string ControlName => GetControlPrefix() + Name;

        public string GetControlPrefix() =>
            Type.Contains("DateTime") ? "dtp" :
            Type == "bool" ? "chk" : "txt";

        public string GetValueExpression() =>
            Type.Contains("DateTime") ? $"{ControlName}.Value" : $"{ControlName}.Text";

        public string GetBindingExpression() =>
            $"{ControlName}.Text = row.Cells[\"{Name}\"].Value?.ToString();";
    }

}
