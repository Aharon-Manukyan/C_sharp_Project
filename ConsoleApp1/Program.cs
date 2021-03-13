using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ClassLibraryDLL;
using System.Reflection;


namespace ConsoleApp1
{
    class Program
    {    
        static void Main(string[] args)
        {
            try
            {
                string text = File.ReadAllText(@"C:\\Users\\User\\Desktop\\C#\\input.txt", Encoding.Default);
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                
                ClassDll classDll = new ClassDll();           
                MethodInfo meth = classDll.GetType().GetMethod("ChangeText", BindingFlags.NonPublic | BindingFlags.Instance);
                
                var returnValue =  meth.Invoke(classDll, new object[] {text});
                var dict = (Dictionary<string,int>)returnValue;

                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "C#\\output.txt")))
                {
                    foreach (var d in dict)
                    {
                        if ((d.Key != ""))
                        {
                            outputFile.WriteLine(d.Key + "  " + d.Value);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
