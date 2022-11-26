using RestSharp;

namespace Movies.Application;

public static class ApplicationExtensions
{

    public static async Task<T> GetMovie<T>(string url)
    {
        try
        {
            using RestClient client = new RestClient();
            RestRequest request = new RestRequest(url);
            request.AddOrUpdateHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddOrUpdateHeader("user-agent", "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 70.0.3538.77 Safari / 537.36");
            RestResponse<T>? response = await client.ExecuteGetAsync<T>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception("Server Not Founded");
            }

            return response.Data ?? throw new InvalidOperationException();
        }
        catch
        {
            throw;
        }
    }

}