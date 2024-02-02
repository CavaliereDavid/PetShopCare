using Microsoft.Azure.Functions.Worker.Http;

namespace PetShopCare.Service;

internal static class Utilities
{
    public static HttpResponseData CreateResponseOk<T>(HttpRequestData req, T entity)
    {
        var response = req.CreateResponse(statusCode: System.Net.HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json");
        response.WriteString(Newtonsoft.Json.JsonConvert.SerializeObject(entity));
        return response;
    }

    public static HttpResponseData CreateResponseNotFound(HttpRequestData req)
    {
        var response = req.CreateResponse(statusCode: System.Net.HttpStatusCode.NotFound);
        return response;
    }
}
