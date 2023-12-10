using Microsoft.AspNetCore.Mvc;
using PackageDemo.Models;
using PackageDemo.Services.Interface;

namespace PackageDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController(ITrackingNumberService trackingNumberService, IPackageService packageService) : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ListTrackingNumbersAsync()
    {
        var trackingNumbers = await packageService.GetTrackingNumbers();
        if (trackingNumbers is null || !trackingNumbers.Any())
            return NoContent();

        return Ok(trackingNumbers);
    }

    [HttpGet("{trackingNumber}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PackageResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetPackageDetails(string trackingNumber)
    {
        if (!trackingNumberService.TryParse(trackingNumber, out long parsedTrackingNumber))
            return BadRequest("Invalid tracking number");

        var package = await packageService.GetByTrackingNumber(parsedTrackingNumber);
        if(package == null)
            return NotFound("No package found with specified tracking number");

        return Ok(package);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> CreatePackageAsync(CreatePackageRequest request)
    {
        var response = await packageService.CreatePackage(request);
        if(response is null || !response.IsValid)
            return BadRequest("Package has invalid measurements");

        return Created($"/package/{response.TrackingNumber}", response.TrackingNumber);
    }
}
