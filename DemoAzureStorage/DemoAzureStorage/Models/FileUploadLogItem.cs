using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAzureStorage.Models
{
    public class FileUploadLogItem : TableEntity
    {
        public string Name { get; set; }

        public decimal Size { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public string Location { get; set; }

        public DateTime TimeStamp { get; set; }
        public string AzureFilePath { get; set; }        
    }
}