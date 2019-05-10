using System;

namespace FieldNameAtrributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,
        AllowMultiple = false, Inherited = false)]
    public class FieldNameAtrribute : Attribute
    {
        public string FieldName { get; }

        public FieldNameAtrribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}