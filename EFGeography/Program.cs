using EFGeography;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetTopologySuite.Geometries;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((_, services) =>
    services.AddDbContext<BrandDataContext>()
    ).Build();

//await host.RunAsync();

var SouthWestLat = 44.25066640967907;
var SouthWestLng = -19.9158203125;
var NorthEastLat = 62.697810720504194;
var NorthEastLng = 12.515820312499981;
//var SouthWestLat = 0.25066640967907;
//var SouthWestLng = -19.9158203125;
//var NorthEastLat = 62.697810720504194;
//var NorthEastLng = 19.515820312499981;

using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
var gf = new GeometryFactory(new PrecisionModel(), 4326);
var bounds = gf.CreatePolygon(new Coordinate[]
{
    new Coordinate(SouthWestLng, SouthWestLat ),
    new Coordinate(NorthEastLng, SouthWestLat ),
    new Coordinate(NorthEastLng, NorthEastLat ),
    new Coordinate(SouthWestLng, NorthEastLat ),
    new Coordinate(SouthWestLng, SouthWestLat),
});
var db = provider.GetRequiredService<BrandDataContext>();
var brands = db
    .Brands
    .Where(b => b.Location.Within(bounds))
    .ToList();
Console.WriteLine(brands.Count);