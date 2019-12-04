using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
namespace Utilities
{
    public class FileFinder
    {
        public static String GetFileName(String dirName, String fileName)
        {
            String path;
            // Czy da się odnaleźć plik korzystając ze zmiennej środowiskowej OOZINOZ?
            String oozinozBase = Environment.GetEnvironmentVariable("OOZINOZ");
            if (oozinozBase != null) 
            {
                path = Path.Combine(Path.Combine(oozinozBase, dirName), fileName);
                if (File.Exists(path))
                {
                    return path;
                }
            }
            // A może względem podkatalogu WzorceProjektowe-ten z solucją?
            Assembly a = Assembly.GetAssembly(typeof(FileFinder));
            DirectoryInfo thisDir = Directory.GetParent(a.Location);
            DirectoryInfo mediumDir = Directory.GetParent(thisDir.FullName);
            DirectoryInfo parentDir = Directory.GetParent(mediumDir.FullName);
            path = Path.Combine(
                parentDir.FullName, 
                dirName + Path.DirectorySeparatorChar + fileName);
            if (File.Exists(path))
            {
                return path;
            }
            // No dobra, to może pod katalogiem głównym?
            path = Path.Combine(Path.Combine(@"\WzorceProjektowe", dirName), fileName);
            if (File.Exists(path))
            {
                return path;
            }
            // Guzik
            throw new Exception("FileFinder.GetFileName() nie może znaleźć " + fileName + " w katalogu " + dirName);

        }
    }

     public class Set
    {
        private Hashtable h = new Hashtable();
        /// <summary>
        /// Zwraca enumerator dla zbioru.
        /// </summary>
        /// <returns>enumerator dla tego zbioru</returns>
        public IEnumerator GetEnumerator()
        {
            return h.Keys.GetEnumerator();
        }
        /// <summary>
        /// Dodaje wskazany obiekt do zbioru.
        /// </summary>
        /// <param name="o">dodawany obiekt</param>
        public void Add(Object o)
        {
            h[o] = null;
        }
        /// <summary>
        /// Zwraca true jeśli zbiór zawiera zadany obiekt.
        /// </summary>
        /// <param name="o">szukany obiekt</param>
        /// <returns>true jeśli zbiór zawiera zadany obiekt</returns>
        public bool Contains(Object o)
        {
            return h.Contains(o);
        }
    }
}
