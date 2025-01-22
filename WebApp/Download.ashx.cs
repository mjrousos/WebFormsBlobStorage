using System.Web;

namespace WebApp
{
    /// <summary>
    /// Summary description for Download
    /// </summary>
    public class Download : IHttpHandler
    {

        // By handling requests to access blobs in a custom handler, this app can control the download process.
        // Authentication and authorization can be added here and the Azure storage account doesn't need a public endpoint.
        public void ProcessRequest(HttpContext context)
        {
            var fileName = context.Request.QueryString["file"];

            if (string.IsNullOrEmpty(fileName))
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = "Bad Request";
                context.Response.End();
                return;
            }

            var container = BlobHelper.GetBlobContainerClient();
            var blobClient = container.GetBlobClient(fileName);
            if (!blobClient.Exists())
            {
                context.Response.StatusCode = 404;
                context.Response.StatusDescription = "Not Found";
                context.Response.End();
                return;
            }

            using (var fileStream = blobClient.OpenRead())
            {
                context.Response.ContentType = "application/octet-stream";
                context.Response.AddHeader("Content-Disposition", $"attachment; filename=\"{fileName}\"");
                fileStream.CopyTo(context.Response.OutputStream);
                context.Response.Flush();
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}