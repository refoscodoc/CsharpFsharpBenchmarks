using System.Text.Json;
using CSharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using PopulateDb.Services;

namespace PopulateDb.Controllers;

[ApiController]
[Route("[controller]")]
public class BreweryController : ControllerBase
{
    private readonly BusinessProvider _provider;
    private readonly IHttpClientFactory _httpClientFactory;
    
    public IEnumerable<BreweryModel>? Allbreweries { get; set; }

    public BreweryController(BusinessProvider provider, IHttpClientFactory httpClientFactory)
    {
        _provider = provider;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _provider.GetAllBreweries();
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PopulateDb()
    {
        // var httpRequestMessage = new HttpRequestMessage(
        //     HttpMethod.Get,
        //     "https://api.openbrewerydb.org/breweries");
        
        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.GetAsync("https://api.openbrewerydb.org/breweries?per_page=50");

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
            Allbreweries = JsonSerializer.Deserialize<IEnumerable<BreweryModel>>(contentStream);
        }

        if (Allbreweries is null) return Problem();

        await _provider.WriteAllToDb(Allbreweries);
        return Ok(Allbreweries);
    }
}