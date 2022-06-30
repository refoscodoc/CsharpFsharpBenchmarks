using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CSharp.Models;

public class BreweryModel
{
    [JsonPropertyName("id")]
    [Column("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("name")]
    [Column("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("brewery_type")]
    [Column("brewery_type")]
    public string? BreweryType { get; set; }
    
    [JsonPropertyName("street")]
    [Column("street")]
    public string? Street { get; set; }
    
    [JsonPropertyName("city")]
    [Column("city")]
    public string? City { get; set; }
    
    [JsonPropertyName("state")]
    [Column("state")]
    public string? State { get; set; }
    
    [JsonPropertyName("postal_code")]
    [Column("postal_code")]
    public string? PostalCode { get; set; }
    
    [JsonPropertyName("country")]
    [Column("country")]
    public string? Country { get; set; }
    
    [JsonPropertyName("longitude")]
    [Column("longitude")]
    public string? Longitude { get; set; }
    
    [JsonPropertyName("latitude")]
    [Column("latitude")]
    public string? Latitude { get; set; }
    
    [JsonPropertyName("phone")]
    [Column("phone")]
    public string? Phone { get; set; }
    
    [JsonPropertyName("website_url")]
    [Column("website_url")]
    public string? WebsiteUrl { get; set; }
    
    [JsonPropertyName("update_at")]
    [Column("update_at")]
    public string? UpdateAt { get; set; }
    
    [JsonPropertyName("created_at")]
    [Column("created_at")]
    public string? CreatedAt { get; set; }
}