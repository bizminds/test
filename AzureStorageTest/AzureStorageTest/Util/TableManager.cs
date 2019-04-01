using DemoAzureStorage.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAzureStorage.Util
{
    public class TableManager
    {
        // private property  
        private CloudTable table;

        // Constructor   
        public TableManager(CloudStorageAccount storageAccount)
        {
            if (storageAccount == null)
            {
                throw new ArgumentNullException("StorageAccount", "Storage account can't be null");
            }
            try
            {               
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                table = tableClient.GetTableReference("FileUploadLog");
                table.CreateIfNotExists();
            }
            catch (StorageException StorageExceptionObj)
            {
                throw StorageExceptionObj;
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }

        public void InsertEntity(FileUploadLogItem entity)
        {
            try
            {
                entity.RowKey = Guid.NewGuid().ToString();
                entity.PartitionKey = entity.FileExtension;
                entity.Timestamp = DateTime.Now;
                var insertOperation = TableOperation.Insert(entity);
                table.Execute(insertOperation);
            }
            catch (Exception ExceptionObj)
            {
                throw ExceptionObj;
            }
        }
    }
}