﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DemoAzureStorage.Infrastructure;
using DemoAzureStorage.Models;
using DemoAzureStorage.Util;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DemoAzureStorage.Controllers
{
    [RoutePrefix("api/upload")]
    public class UploadController : ApiController
    {
        private const string Container = "files";

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var accountName = ConfigurationManager.AppSettings["storage:account:name"];
            var accountKey = ConfigurationManager.AppSettings["storage:account:key"];
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer filesContainer = blobClient.GetContainerReference(Container);
            var provider = new AzureStorageMultipartFormDataStreamProvider(filesContainer);
            if (await filesContainer.CreateIfNotExistsAsync())
            {
                await filesContainer.SetPermissionsAsync(new
                   BlobContainerPermissions
                {
                    PublicAccess =
                   BlobContainerPublicAccessType.Blob
                });

            }
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error has occured. Details: {ex.Message}");
            }

            // Retrieve the filename of the file you have uploaded
            var filename = provider.FileData.FirstOrDefault()?.LocalFileName;
            if (string.IsNullOrEmpty(filename))
            {
                return BadRequest("An error has occured while uploading your file. Please try again.");
            }
            var uploadedFileName = provider.Contents.FirstOrDefault()?.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            var fileLog = new FileUploadLogItem()
            {
                Location = Request.RequestUri.AbsoluteUri,
                Size = Request.Content.Headers.ContentLength.HasValue ? Request.Content.Headers.ContentLength.Value : 0,
                FileExtension = Path.GetExtension(uploadedFileName),
                ContentType = provider.FileData.FirstOrDefault()?.Headers.ContentType.ToString(), 
                AzureFilePath = provider.UploadedPath,
                Name = filename,
                TimeStamp = DateTime.UtcNow
            };
            new TableManager(storageAccount).InsertEntity(fileLog);

            return Ok($"File: {filename} has successfully uploaded");
        }
    }
}
