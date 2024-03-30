namespace Domain.Attribute
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class EnumStringAttribute : Attribute
    {
        public string StringValue { get; protected set; }

        public EnumStringAttribute(string value)
        {
            this.StringValue = value;
        }
    }



    public static class EnumString
    {
        public static string? GetStringValue(this Enum value)
        {
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());

            if (fieldInfo == null) 
                return null;

            var attribs = fieldInfo.GetCustomAttributes(typeof(EnumStringAttribute), false) as EnumStringAttribute[];

            return attribs?.Length > 0 ? attribs[0].StringValue : null;

        }
    }
}