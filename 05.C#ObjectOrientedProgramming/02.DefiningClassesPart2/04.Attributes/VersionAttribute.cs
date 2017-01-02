namespace _04.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class | 
                    AttributeTargets.Struct | 
                    AttributeTargets.Enum | 
                    AttributeTargets.Interface | 
                    AttributeTargets.Method, 
                    AllowMultiple = false)]

    public class VersionAttribute : Attribute
    {
        // Properties.
        public string MajorVersion
        {
            get;
            private set;
        }
        public string MinorVersion
        {
            get;
            private set;
        }

        // Constructor
        public VersionAttribute(string majorVersion, string minorVersion)
        {
            this.MajorVersion = majorVersion;
            this.MinorVersion = minorVersion;
        }
        public override string ToString()
        {
            return MajorVersion + "." + MinorVersion;
        }
    }
}
