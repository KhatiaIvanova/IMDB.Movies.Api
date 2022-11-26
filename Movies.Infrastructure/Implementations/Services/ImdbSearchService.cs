using Microsoft.Extensions.Configuration;
using Movies.Application.Interfaces;
using Movies.Domain.Models;
using RestSharp;

namespace Movies.Infrastructure.ApiServices;

public class ImdbSearchService : IIMdbSearchService
{
    private readonly string _apiUrl;

    public ImdbSearchService(IConfiguration config)
    {
        _apiUrl = config.GetValue<string>("ApiUrl");
    }


    public async Task<SearchMovie> GetMovieAsync(string apikey, string expression, CancellationToken cancellationToken = default)
    {
        string? url = $"{_apiUrl}/API/Search/{apikey}/{expression}";
        using RestClient? client = new RestClient();
        RestRequest? request = new RestRequest(url);
        request.AddOrUpdateHeader("Content-Type", "application/json;charset=UTF-8");
        RestResponse<SearchMovie>? response = await client.ExecuteGetAsync<SearchMovie>(request);

        if (!response.IsSuccessful)
        {
            throw new Exception("Server Not Founded");
        }

        return response.Data ?? throw new InvalidOperationException();
    }
}