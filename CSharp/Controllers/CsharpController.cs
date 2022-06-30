using System.Text.Json;
using CSharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharp.Controllers;

public class CsharpController : ControllerBase
{
    private readonly IHttpClientFactory _client;

    public CsharpController(IHttpClientFactory client)
    {
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var httpClient = _client.CreateClient();
        var httpResponseMessage = await httpClient.GetAsync("http://localhost:5217/Brewery");
        
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
            // Allbreweries = JsonSerializer.Deserialize<IEnumerable<BreweryModel>>(contentStream);
        }
        
        return Ok();
    }
}