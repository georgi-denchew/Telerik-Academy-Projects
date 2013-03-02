using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Globalization;

//Task 11: Create a [Version] attribute that can be applied to structures,
//classes, interfaces, enumerations and methods and holds a version in the
//format major.minor (e.g. 2.11). Apply the version attribute to a sample 
//class and display its version at runtime.

namespace _11.VersionAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Class
        | AttributeTargets.Enum | AttributeTargets.Interface
        | AttributeTargets.Method, AllowMultiple = true)]

    public class VersionAttribute : System.Attribute
    {
        public double Version { get; private set; }

        public VersionAttribute(double version)
        {
            this.Version = version;
        }
    }

    [Version(1.23)]
    [Version(5.66)]

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Type type = typeof(Program);
            object[] versions = type.GetCustomAttributes(false);

            foreach (VersionAttribute version in versions)
            {
                Console.WriteLine("Version: {0}", version.Version);
            }
        }
    }
}
