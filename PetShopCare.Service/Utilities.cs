using Microsoft.Azure.Functions.Worker.Http;
using PetShopCare.Foundation;

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

    public static HttpResponseData CreateResponseInternalServerError(HttpRequestData req, Error error)
    {
        HttpResponseData response = error.Category switch
        {
            ErrorCategory.DatabaseError => NewMethod(req, error),
            ErrorCategory.InvalidData => NewMethod1(req, error),
            ErrorCategory.InternalError => NewMethod2(req, error),
        };
        return response;

    }

    private static HttpResponseData NewMethod2(HttpRequestData req, Error error)
    {
        HttpResponseData response = req.CreateResponse(statusCode: System.Net.HttpStatusCode.InternalServerError);
        response.Headers.Add("Content-Type", "application/json");
        response.WriteString(Newtonsoft.Json.JsonConvert.SerializeObject(error));
        return response;
    }

    private static HttpResponseData NewMethod1(HttpRequestData req, Error error)
    {
        HttpResponseData response = req.CreateResponse(statusCode: System.Net.HttpStatusCode.BadRequest);
        response.Headers.Add("Content-Type", "application/json");
        response.WriteString(Newtonsoft.Json.JsonConvert.SerializeObject(error));
        return response;
    }

    private static HttpResponseData NewMethod(HttpRequestData req, Error error)
    {
        HttpResponseData response = req.CreateResponse(statusCode: System.Net.HttpStatusCode.InternalServerError);
        response.Headers.Add("Content-Type", "application/json");
        response.WriteString(Newtonsoft.Json.JsonConvert.SerializeObject(error));
        return response;
    }
}
