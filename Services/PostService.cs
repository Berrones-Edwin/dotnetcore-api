using System;
using System.Text.Json;
using TodoApi.DTO;

namespace TodoApi.Services;

public class PostService : IPostService
{
    private HttpClient _httpClient;
    // private readonly IHttpClientFactory _httpClientFactory;

    // public PostService(IHttpClientFactory httpClientFactory)
    // {
    //      _httpClientFactory = httpClientFactory;
    // }
   
    // public async Task<IEnumerable<PostDTO>> Get()
    // {
    //     var httpClient = _httpClientFactory.CreateClient("Post");
    //     var result = await httpClient.GetAsync(httpClient.BaseAddress);
    //     var body = await result.Content.ReadAsStringAsync();

    //     var options = new JsonSerializerOptions
    //     {
    //         PropertyNameCaseInsensitive = true
    //     };

    //     var posts = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body, options);
    //     return posts!;
    // }
     public PostService(HttpClient httpClient)
    {
         _httpClient = httpClient;
    }
    public async Task<IEnumerable<PostDTO>> Get()
    {
        var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
        var body = await result.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var posts = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body, options);
        return posts!;
    }
}
