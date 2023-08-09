namespace Autodesk.ModelDerivativeApi.Test;

using Autodesk.ModelDerivativeApi;
using Autodesk.ModelDerivativeApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autodesk.SDKManager;



[TestClass]
public class TestModelDerivativeAPi
{
    private static ModelDerivativeApi _mdApi = null!;

    private const string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJkYXRhOnJlYWQiLCJkYXRhOndyaXRlIiwiZGF0YTpjcmVhdGUiLCJkYXRhOnNlYXJjaCIsImJ1Y2tldDpjcmVhdGUiLCJidWNrZXQ6cmVhZCIsImJ1Y2tldDp1cGRhdGUiLCJidWNrZXQ6ZGVsZXRlIiwiYWNjb3VudDpyZWFkIiwiYWNjb3VudDp3cml0ZSIsImNvZGU6YWxsIl0sImNsaWVudF9pZCI6Ikp1enlEQWlmMjVjSUFYZlpuMHJBd2ltSUFaVEdMeEFRIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6IlhOSWZzMnQ4U0FRcEd4eHFNT3J3bWVvaU91UndNN1hRWVpQRjN0U0tyazluUzNmZmNaRUk1R093Q2hvZHN2dzUiLCJleHAiOjE2OTE1NzE4NDN9.wNSvOZtqItCoN1tEs0NTKtPMIdQi1bOqfaXcYrA5VBWIVGcY80XEhYxPHwouB9KGMx9ywkjkws5sW8n8Sb_JiuMcanSpnp4qguUltkbQHfIuBVIQasOjdO3W_NDBOqUtvDYWQasmoEO3LclVgy9buJmIEPXXPjmJbl3eWW1xhRy_Y98u0_cI6CS_JWK_iJxE-cDPZHkXr_OYN5GB-VMkbLBafkGLt9fjh6Cfl66aYE96SpF3qy9nAIA7NUWEvnt-mzmQAezvN8D2AI2YG6i08GT6YAGIsCciUTthInI0oqz2icARYB-mDIgFiZ9OxuhusYcKO4XjGYA2uRHjeW2w0g";
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

        _mdApi = new ModelDerivativeApi(sdkManager);

    }



    // [TestMethod]
    // public async Task TestFormatsAsync()
    // {

    //     Formats formats = await _mdApi.FormatsAsync(authorizationToken: token);
    //     Assert.IsTrue(formats.SupportedFormats.Count() == 10);
    // }

    [TestMethod]
    public async Task TestJobAsync()
    {
        // set output formats
        List<JobPayloadFormat> outputFormats = new List<JobPayloadFormat>()
    {
      // initialising an Svf2 output class will automatically set the type to Svf2.
      // No need to call Type = TypeEnum.Svf2
      new JobSvf2OutputFormat()
      {

         Views =  new List<ViewsEnum>()
                {
                ViewsEnum._2d,
                ViewsEnum._3d
                },

      },

      // initialising a Thumbnail output class will automatically set the type to Thumbnail.
      // No need to call Type = TypeEnum.Thumbnail
      new JobThumbnailOutputFormat()
      {
            Advanced = new JobThumbnailOutputFormatAdvanced(){

                  Width = WidthEnum.NUMBER_100,
                  Height = HeightEnum.NUMBER_100
            }


      }

    };


        // specify Job details
        JobPayload Job = new JobPayload()
        {
            Input = new JobPayloadInput()
            {
                Urn =urn ,
                CompressedUrn = false,
                RootFilename = "Result (9).ipt",



            },
            Output = new JobPayloadOutput()
            {
                Formats = outputFormats,
                Destination = RegionEnum.US
            },



        };

        // start the translation job
        string jobUrn;
        string jobResult ;
        Job jobResponse=null!;
        try
        {
            jobResponse = await _mdApi.StartJobAsync(jobPayload: Job, accessToken: token);
            // query for urn, result etc...
            jobUrn = jobResponse.Urn;
            jobResult = jobResponse.Result;
        }
        catch
        (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Assert.IsTrue(jobResponse.Result == "created");
    }

    // [TestMethod]
    // public async Task TestGetManifestAsync()
    // {
    //     Manifest manifestResponse = await _mdApi.GetUrnManifestAsync(urn, accessToken: token);
    //     string progress = manifestResponse.Progress;
    //     Assert.IsTrue(progress == "complete");
    // }

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