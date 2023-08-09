using Autodesk.Oss;
using Autodesk.Oss.Model;
using Autodesk.SDKManager;

string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjY0RE9XMnJoOE9tbjNpdk1NU0xlNGQ2VHEwUSIsInBpLmF0bSI6Ijd6M2gifQ.eyJzY29wZSI6WyJkYXRhOnJlYWQiLCJkYXRhOndyaXRlIiwiZGF0YTpjcmVhdGUiLCJidWNrZXQ6cmVhZCIsImJ1Y2tldDpjcmVhdGUiXSwiY2xpZW50X2lkIjoiQnZ5TVFwZ3UyNjFVUnd5dm9GOTVwU0Z6QmUyOUt2U1IiLCJhdWQiOiJodHRwczovL2F1dG9kZXNrLmNvbS9hdWQvYWp3dGV4cDYwIiwianRpIjoiZk50Z045OVhoamFNc3QyNUs3ck1acmVZdGNTU1NlZnlWUmh6bm02RkJiMEtwNjJsMkdGMUVReFVGdGtuS3VvNiIsImV4cCI6MTY5MTU2NDk4N30.HopNSV_kqRFofBpnLeIJTJOrp8Ryo5ClfM0jvHygkNi7pWKMlud8ZBdkVHKboaJO4_0pSSv7xTUku6dqKPOOThb2G3T-mOeZegOgSSYczOUjtYVFemvffBhz8Ja1RlF2rsZnIxX234DiOOTJI_r_9Xg9udtE4SMWTPk1bxi5Za-RYUMSG_lBK8UJgmSpYHX5hGRDxGCOoSt5DUqqqWKnDY_e3mxsrFc1YIEm_Hh73rOzIKnZwJjngJyKlouuA8UZr1brlpafaK_GzOh2a_WK-ZsufEiWsAgbzyltVrKj56oTwYUpAhp2ID0P-ExylF73hclXQDWA-dU1-jseyasP7g";
string bucketKey = "tstbucket123";


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
        