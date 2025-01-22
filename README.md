# WebForms App Serving Files from Blob Storage

This small sample demonstrates how to serve files from Azure Blob Storage in a WebForms application. The sample uses the Azure Blob Storage SDK to securely retrieve files from a blob storage container without a public endpoint and make them available to authorized users.

This is a useful alternative to serving files that are local to the app (keeping the app lightweight) or using a public blob endpoint with SAS tokens which is less secure.
