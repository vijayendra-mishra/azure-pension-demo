using Application.Queries;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Functions;

// Test deployment with shared App Service Plan

public class PensionFunctions
{
    private readonly ILogger<PensionFunctions> _logger;
    private readonly IMediator _mediator;

    public PensionFunctions(ILogger<PensionFunctions> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [Function("GetPension")]
    public async Task<HttpResponseData> GetPension(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "pension/{id:int}")] HttpRequestData req,
        int id)
    {
        _logger.LogInformation("Getting pension with ID: {Id}", id);

        try
        {
            var pension = await _mediator.Send(new GetPensionQuery(id));
            
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            
            await response.WriteStringAsync(JsonSerializer.Serialize(pension, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting pension with ID: {Id}", id);
            
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteStringAsync("Internal server error");
            return errorResponse;
        }
    }

    [Function("GetAllPensions")]
    public async Task<HttpResponseData> GetAllPensions(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "pensions")] HttpRequestData req)
    {
        _logger.LogInformation("Getting all pensions");

        try
        {
            var pensions = await _mediator.Send(new GetAllPensionsQuery());
            
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            
            await response.WriteStringAsync(JsonSerializer.Serialize(pensions, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all pensions");
            
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteStringAsync("Internal server error");
            return errorResponse;
        }
    }

    [Function("HealthCheck")]
    public async Task<HttpResponseData> HealthCheck(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "health")] HttpRequestData req)
    {
        _logger.LogInformation("Health check requested");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        
        var healthStatus = new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Environment = Environment.GetEnvironmentVariable("Environment") ?? "Unknown"
        };

        await response.WriteStringAsync(JsonSerializer.Serialize(healthStatus, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }));

        return response;
    }
}
