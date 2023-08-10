namespace Autodesk.OSS.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;
using Autodesk.Oss;
using Autodesk.Oss.Model;
using Autodesk.Forge;

[TestClass]
public class TestModelDerivativeAPi
{
    private static OssApi ossApi= null!;
    private static string token;
    string clientId = Environment.GetEnvironmentVariable("CLIENT_ID") ?? "ClientId not found";
    string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET") ?? "ClientSecret not found";
    private string bucketKey = "juzydaif25ciaxfzn0rawimiaztglxaq-basic-app";
    private const string urn = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6anV6eWRhaWYyNWNpYXhmem4wcmF3aW1pYXp0Z2x4YXEtYmFzaWMtYXBwL2RvaXQucnZ0";
    public record Token(string AccessToken, DateTime ExpiresAt);
    
    [ClassInitialize]
    public static async Task ClassInitializeAsync(TestContext testContext)
    {

     string clientId = Environment.GetEnvironmentVariable("Client_Id") ?? "ClientId not found";
    string clientSecret = Environment.GetEnvironmentVariable("Client_Secret") ?? "ClientSecret not found";

    
    Console.WriteLine($"CLIENT_ID: {clientId}");
    Console.WriteLine($"CLIENT_SECRET: {clientSecret}");
        dynamic auth =  await  new TwoLeggedApi().AuthenticateAsync(clientId,clientSecret, "client_credentials", new Scope[] { Scope.BucketCreate, Scope.BucketRead, Scope.DataRead, Scope.DataWrite, Scope.DataCreate  });
        token = auth.access_token;
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration()
                {
                }
                )
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();
        ossApi =new OssApi (sdkManager);
    }
    [TestMethod]
    public async Task TestGetbucktes()
    {
        
        Bucket bucket = await ossApi.GetBucketDetailsAsync(bucketKey, accessToken:token);
        string bucketkey = bucket.BucketKey;
        string bucketOwner = bucket.BucketOwner;
        Assert.IsTrue(bucketOwner != null);
    }


}