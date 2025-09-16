using UnityEngine;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

public class S3LogWriter
{
    private readonly string bucketName = "guilhermeh";
    private readonly string keyPrefix = "gla/";
    private readonly IAmazonS3 s3Client;

    public S3LogWriter(string accessKey, string secretKey, Amazon.RegionEndpoint region)
    {
        s3Client = new AmazonS3Client(accessKey, secretKey, region);
    }

    public async Task UploadFileAsync(string filePath, string fileName)
    {
        try
        {

            var putRequest = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = $"{keyPrefix}{fileName}",
                FilePath = filePath
            };


            var response = await s3Client.PutObjectAsync(putRequest);

            Debug.Log($"Log enviado para S3 em {bucketName}/{keyPrefix}{fileName} - Status: {response.HttpStatusCode}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Falha ao enviar log para S3: {ex.Message}\n{ex.StackTrace}");
        }
    }

}