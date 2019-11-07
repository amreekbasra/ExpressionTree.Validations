using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionTree.DbValidations.Sample.models
{
    
    public class DbSettings
    {
        public List<FeatureSettings> FeatureSettings { get; set; }
        public List<ValidationSettings> ValidationSettings { get; set; }
        public List<ValidationRangeSettings> ValidationRangeSettings { get; set; }
    }
    public class FeatureSettings
    {
        public int Id { get; set; }
        public string Feature { get; set; }
        public string SubFeature { get; set; }
        public string Section { get; set; }
        public bool? Allowed { get; set; }
        public int? Parent { get; set; }
    }
    public class ValidationSettings
    {
        public int FeatureId { get; set; }
        public string Property { get; set; }
        public string Type { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public int? Length { get; set; }
        public string Pattern { get; set; }
        public string DefaultValue { get; set; }
    }
    public class ValidationRangeSettings
    {
        public int FeatureId { get; set; }
        public string Property { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class Settings
    {
        public string Name { get; set; }
        public bool? Applicable { get; set; }
        public string Type { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public int? Length { get; set; }
        public string Pattern { get; set; }
        public string[] ValidValues { get; set; }
        public List<Settings> ChildSettings { get; set; }
    }

    public class ValidationTypes
    {
        private static readonly Dictionary<string, string> _list = new Dictionary<string, string>()
        {
            {"int", "System.Int32"},
            {"float", "System.Single"},
            {"int?", "System.Nullable`1[System.Int32]"},
            {"float?", "System.Nullable`1[System.Single]"},
            {"string", "System.String" },
            {"list", "System.String[]" }
        };

        public static Type GetType(string key)
        {
            if (_list.TryGetValue(key, out var valType))
                return Type.GetType(valType, false);
            else
                return null;
        }
    }
}
