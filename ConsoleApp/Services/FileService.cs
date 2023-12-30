using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Interfaces;


namespace ConsoleApp.Services;


public class FileService () : IFileService 
{

    
    public bool SaveContentToFile(string content, string filepath) // save content to file uses two parameters content and filepath
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {                
                sw.WriteLine(content);
                return true;
            }
        } 
        catch (Exception ex) {Debug.WriteLine(ex.Message); }
        return false;
    }
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    return sr.ReadToEnd();

                }
            }
           
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


}


