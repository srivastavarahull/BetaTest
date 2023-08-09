namespace Autodesk.OSS.Test;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;
using Autodesk.Oss;
using Autodesk.Oss.Model;

[TestClass]
public class TestModelDerivativeAPi
{
    private static OssApi ossApi= null!;
    private string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJkYXRhOnJlYWQiLCJkYXRhOndyaXRlIiwiZGF0YTpjcmVhdGUiLCJkYXRhOnNlYXJjaCIsImJ1Y2tldDpjcmVhdGUiLCJidWNrZXQ6cmVhZCIsImJ1Y2tldDp1cGRhdGUiLCJidWNrZXQ6ZGVsZXRlIiwiYWNjb3VudDpyZWFkIiwiYWNjb3VudDp3cml0ZSIsImNvZGU6YWxsIl0sImNsaWVudF9pZCI6Ikp1enlEQWlmMjVjSUFYZlpuMHJBd2ltSUFaVEdMeEFRIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6ImZVajdtSGxVRWFmYUtaZmhVbURPT1JCMkZRS2tSNUMyMlptT3Zac2ppYzQ1WVBWY1BUUjJNeENKRE85N1pSbWEiLCJleHAiOjE2OTE1ODMyODF9.a8zxqD1L0eDydfqCuxL-gjT9YPfXajutgkQldSUJQnNBcDMAk_r2sluuakDh3sMYQfOakI3JdJ5zbsK1rqdrHE9Xm0VIY3Ajb4qmni5RQQFu5p5opbznFM_kQk3mguuXUFa4m7BEfoQZmenrIgrJEDESVBuQ3XW9CXRs2ZjLYquKGRQcLlVkTbRljWQnTIhx_dT05ylOJpDcpN2bi1zXgpuIw97O500DuCcVIRFv_3h_tc6LUOU6dDCwjrXpD-j8wW3WPFaEizG2ZGdnVuoLQcM9pjeM3dti_5nUNto3gbTjGT6ihRpNFE2AZntHfFIIs_0Gg5JHiCAPyMmBykgeQQ";
    private string bucketKey = "juzydaif25ciaxfzn0rawimiaztglxaq-basic-app";
    private const string urn = "dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6anV6eWRhaWYyNWNpYXhmem4wcmF3aW1pYXp0Z2x4YXEtYmFzaWMtYXBwL2RvaXQucnZ0";

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        SDKManager sdkManager = SdkManagerBuilder
                .Create() // Creates SDK Manager Builder itself.
                .Add(new ApsConfiguration()
                {
                    //option to override base address 
                    // BaseAddress = new Uri("https://developer.api.autodesk.com/modelderivative/v2/")
                }
                )
                .Add(ResiliencyConfiguration.CreateDefault())
                .Build();
        ossApi =new OssApi (sdkManager);

    }



    // [TestMethod]
    // public async Task TestFormatsAsync()
    // {

    //     Formats formats = await _mdApi.FormatsAsync(authorizationToken: token);
    //     Assert.IsTrue(formats.SupportedFormats.Count() == 10);
    // }

    // [TestMethod]
    // public async Task TestJobAsync()
    // {
    //     // set output formats
    //     List<JobPayloadFormat> outputFormats = new List<JobPayloadFormat>()
    // {
    //   // initialising an Svf2 output class will automatically set the type to Svf2.
    //   // No need to call Type = TypeEnum.Svf2
    //   new JobSvf2OutputFormat()
    //   {

    //      Views =  new List<ViewsEnum>()
    //             {
    //             ViewsEnum._2d,
    //             ViewsEnum._3d
    //             },

    //   },

    //   // initialising a Thumbnail output class will automatically set the type to Thumbnail.
    //   // No need to call Type = TypeEnum.Thumbnail
    //   new JobThumbnailOutputFormat()
    //   {
    //         Advanced = new JobThumbnailOutputFormatAdvanced(){

    //               Width = WidthEnum.NUMBER_100,
    //               Height = HeightEnum.NUMBER_100
    //         }


    //   }

    // };


    //     // specify Job details
    //     JobPayload Job = new JobPayload()
    //     {
    //         Input = new JobPayloadInput()
    //         {
    //             Urn =urn ,
    //             CompressedUrn = false,
    //             RootFilename = "Result (9).ipt",



    //         },
    //         Output = new JobPayloadOutput()
    //         {
    //             Formats = outputFormats,
    //             Destination = RegionEnum.US
    //         },



    //     };

    //     // start the translation job
    //     string jobUrn;
    //     string jobResult ;
    //     Job jobResponse=null!;
    //     try
    //     {
    //         jobResponse = await _mdApi.StartJobAsync(jobPayload: Job, accessToken: token);
    //         // query for urn, result etc...
    //         jobUrn = jobResponse.Urn;
    //         jobResult = jobResponse.Result;
    //     }
    //     catch
    //     (Exception ex)
    //     {
    //         Console.WriteLine(ex.Message);
    //     }
    //     Assert.IsTrue(jobResponse.Result == "created");
    // }

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