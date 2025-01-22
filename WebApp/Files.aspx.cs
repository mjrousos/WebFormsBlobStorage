using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;
using WebApp.Models;

namespace WebApp
{
    public partial class Files : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptDocs.DataSource = GetDocuments();
            rptDocs.DataBind();
        }

        private IEnumerable<Document> GetDocuments()
        {
            var container = BlobHelper.GetBlobContainerClient();

            foreach (var blob in container.GetBlobs())
            {
                yield return new Document { Name = blob.Name };
            }
        }
    }
}