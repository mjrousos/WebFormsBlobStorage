using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.Configuration;

namespace WebApp
{
    public static class BlobHelper
    {
        public static BlobContainerClient GetBlobContainerClient()
        {
            var client = new BlobServiceClient(
                new Uri(ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString),
                new DefaultAzureCredential());

            return client.GetBlobContainerClient(ConfigurationManager.AppSettings["ContainerName"]);
        }
    }
}