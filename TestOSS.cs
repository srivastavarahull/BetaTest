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
    static string _clientId = "JuzyDAif25cIAXfZn0rAwimIAZTGLxAQ";
    static string _clientSecret ="WR3JjH9t7wabj6LB";
    // static string _clientId = Environment.GetEnvironmentVariable("CLIENT_ID")!;
    // static string _clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET")!;
    // private string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJkYXRhOnJlYWQiLCJkYXRhOndyaXRlIiwiZGF0YTpjcmVhdGUiLCJkYXRhOnNlYXJjaCIsImJ1Y2tldDpjcmVhdGUiLCJidWNrZXQ6cmVhZCIsImJ1Y2tldDp1cGRhdGUiLCJidWNrZXQ6ZGVsZXRlIiwiYWNjb3VudDpyZWFkIiwiYWNjb3VudDp3cml0ZSIsImNvZGU6YWxsIl0sImNsaWVudF9pZCI6Ikp1enlEQWlmMjVjSUFYZlpuMHJBd2ltSUFaVEdMeEFRIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6ImZVajdtSGxVRWFmYUtaZmhVbURPT1JCMkZRS2tSNUMyMlptT3Zac2ppYzQ1WVBWY1BUUjJNeENKRE85N1pSbWEiLCJleHAiOjE2OTE1ODMyODF9.a8zxqD1L0eDydfqCuxL-gjT9YPfXajutgkQldSUJQnNBcDMAk_r2sluuakDh3sMYQfOakI3JdJ5zbsK1rqdrHE9Xm0VIY3Ajb4qmni5RQQFu5p5opbznFM_kQk3mguuXUFa4m7BEfoQZmenrIgrJEDESVBuQ3XW9CXRs2ZjLYquKGRQcLlVkTbRljWQnTIhx_dT05ylOJpDcpN2bi1zXgpuIw97O500DuCcVIRFv_3h_tc6LUOU6dDCwjrXpD-j8wW3WPFaEizG2ZGdnVuoLQcM9pjeM3dti_5nUNto3gbTjGT6ihRpNFE2AZntHfFIIs_0Gg5JHiCAPyMmBykgeQQ";
    private string bucketKey = "juzydaif25ciaxfzn0rawimiaztglxaq-basic-app";
    private const string urn = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6anV6eWRhaWYyNWNpYXhmem4wcmF3aW1pYXp0Z2x4YXEtYmFzaWMtYXBwL2RvaXQucnZ0";
    public record Token(string AccessToken, DateTime ExpiresAt);
    
    [ClassInitialize]
    public static async Task ClassInitializeAsync(TestContext testContext)
    {

       
        // Console.WriteLine(_clientId);
        // Console.WriteLine(_clientSecret);
        dynamic auth =  await  new TwoLeggedApi().AuthenticateAsync(_clientId, _clientSecret, "client_credentials", new Scope[] { Scope.BucketCreate, Scope.BucketRead, Scope.DataRead, Scope.DataWrite, Scope.DataCreate  });

        // Console.WriteLine(auth.ToString());
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

    // [TestMethod]
    // public async Task TestGetMetadataAsync()
    // {
    //     ModelViews modelViewsResponse = await _mdApi.GetUrnMetadataAsync(urn, accessToken: token);
    //     Assert.IsTrue(modelViewsResponse.Data.Metadata.Count > 0);
    // }

    // [TestMethod]
    // public async Task GetThumbnailAsync()
    // {

    //     Stream thumbnail = await _mdApi.GetUrnThumbnailAsync(urn, WidthEnum.NUMBER_100, HeightEnum.NUMBER_100, accessToken: token);
    //     Assert.AreNotSame(thumbnail, null);

    // }

}