using System.Linq.Expressions;
using System.Net.Mime;
using Application.Models.Requests;
using Application.Models.Views;
using Application.Services;
using Application.Validation;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class CarController(
    CarService carService, 
    CreateCarValidator createCarValidator, 
    UpdateCarValidator updateCarValidator) : ControllerBase
{
    private readonly CarService _carService = carService;
    private readonly CreateCarValidator _createCarValidator = createCarValidator;
    private readonly UpdateCarValidator _updateCarValidator = updateCarValidator;

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CarModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateCarRequestModel request, CancellationToken token)
    {
        await _createCarValidator.ValidateAndThrowAsync(request, token);
        
        return Ok(await _carService.CreateAsync(request, token));
    }
    
    [HttpPost("update")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(CarModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] UpdateCarRequestModel request, CancellationToken token)
    {
        await _updateCarValidator.ValidateAndThrowAsync(request, token);
        
        return Ok(await _carService.UpdateAsync(request, token));
    }
    
    [HttpPost("search")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(List<CarModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromBody] CarsRequestModel request, CancellationToken token)
    {
        return Ok(await _carService.FindAsync<CarModel>(
            predicate: c => true,
            take: request.Pagination.Count,
            skip: request.Pagination.StartIndex,
            token: token,
            includes: new Expression<Func<Car, object>>[]
            {
                c => c.BodyType!,
                c => c.Brand!
            }));
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(Guid id, CancellationToken token)
    {
        return Ok(await _carService.RemoveAsync(c => c.Id == id, token));
    }
}