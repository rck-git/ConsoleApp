using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests;

public class FileService_Test
{
    [Fact]
    public void SaveContentToFile_ShouldSaveContentToFileThen_ReturnTrue()
    {
        // ARRANGE
        var filepath = @"C:\temp\fileservicetestcontent.json";
        var contet = "Test content";
        FileService fileservice = new FileService();

        // ACT 
        var result = fileservice.SaveContentToFile(contet, filepath);
        fileservice.SaveContentToFile(contet, filepath);

        // ASSERT
        Assert.True(result);

    }
    [Fact]
    public void GetContentFromFile_ShouldGetContentFromFileThen_AssertNotEmptyAndEqual()
    {
        // ARRANGE
        var filepath = @"C:\temp\fileservicetestcontent.json";
        
        FileService fileservice = new FileService();

        // ACT 
        var result = fileservice.GetContentFromFile(filepath);
        

        // ASSERT
        Assert.NotEmpty(result);
        Assert.Equal("Test content\r\n", result);

    }
}
