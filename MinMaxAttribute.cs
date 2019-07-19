using System;

namespace func_swagger_test
{
        [AttributeUsage(AttributeTargets.Property, AllowMultiple=true, Inherited=true)]
    internal sealed class MinMax :Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public MinMax(string name, string value)
        {
            Name = name;
            Value = value;
        }        
        
    }
}