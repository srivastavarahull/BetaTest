using Autodesk.Oss;
using Autodesk.Oss.Model;
using Autodesk.SDKManager;

string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJkYXRhOnJlYWQiLCJkYXRhOndyaXRlIiwiZGF0YTpjcmVhdGUiLCJkYXRhOnNlYXJjaCIsImJ1Y2tldDpjcmVhdGUiLCJidWNrZXQ6cmVhZCIsImJ1Y2tldDp1cGRhdGUiLCJidWNrZXQ6ZGVsZXRlIiwiYWNjb3VudDpyZWFkIiwiYWNjb3VudDp3cml0ZSIsImNvZGU6YWxsIl0sImNsaWVudF9pZCI6Ikp1enlEQWlmMjVjSUFYZlpuMHJBd2ltSUFaVEdMeEFRIiwiYXVkIjoiaHR0cHM6Ly9hdXRvZGVzay5jb20vYXVkL2Fqd3RleHA2MCIsImp0aSI6ImZVajdtSGxVRWFmYUtaZmhVbURPT1JCMkZRS2tSNUMyMlptT3Zac2ppYzQ1WVBWY1BUUjJNeENKRE85N1pSbWEiLCJleHAiOjE2OTE1ODMyODF9.a8zxqD1L0eDydfqCuxL-gjT9YPfXajutgkQldSUJQnNBcDMAk_r2sluuakDh3sMYQfOakI3JdJ5zbsK1rqdrHE9Xm0VIY3Ajb4qmni5RQQFu5p5opbznFM_kQk3mguuXUFa4m7BEfoQZmenrIgrJEDESVBuQ3XW9CXRs2ZjLYquKGRQcLlVkTbRljWQnTIhx_dT05ylOJpDcpN2bi1zXgpuIw97O500DuCcVIRFv_3h_tc6LUOU6dDCwjrXpD-j8wW3WPFaEizG2ZGdnVuoLQcM9pjeM3dti_5nUNto3gbTjGT6ihRpNFE2AZntHfFIIs_0Gg5JHiCAPyMmBykgeQQ";
string bucketKey = "juzydaif25ciaxfzn0rawimiaztglxaq-basic-app";


// Instantiate SDK manager as below.   
// You can also optionally pass configurations, logger, etc. 
SDKManager sdkManager = SdkManagerBuilder
      .Create() // Creates SDK Manager Builder itself.
      .Build();

OssApi ossApi = new OssApi(sdkManager);

Bucket bucket = await ossApi.GetBucketDetailsAsync(bucketKey, accessToken:token);
// query for required properties
string bucketkey = bucket.BucketKey;
string bucketOwner = bucket.BucketOwner;

        