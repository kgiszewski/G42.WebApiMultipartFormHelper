# G42.WebApiMultipartFormHelper

WebApi lacks easy support for parsing `multipart/form-data`, this helper helps parse a request.

## Basic Usage
```
[HttpPost]
[Route("")]
public async Task<IHttpActionResult> SomeMethod() //no model
    var parsedRequest = await MultipartFormHelper.ParseRequest(Request);
    
    var uploadedFile = parsedRequest.Files.FirstOrDefault();//one or more files (or none)
    var message = parsedRequest.Arguments["someArgument"]; //get your args via dictionary
    
    //validate and do stuff with the inputs
    
    //return something
    return Ok();
}
```

## Nuget
Get it on Nuget: https://www.nuget.org/packages/G42.WebApiMultipartFormHelper
