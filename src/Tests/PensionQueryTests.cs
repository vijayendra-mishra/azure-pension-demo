using Application.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class PensionQueryTests
{
    [Test]
    public async Task GetPensionQuery_ShouldReturnPension_WhenValidIdProvided()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPensionQuery).Assembly));
        var serviceProvider = services.BuildServiceProvider();
        var mediator = serviceProvider.GetRequiredService<IMediator>();

        var query = new GetPensionQuery(1);

        // Act
        var result = await mediator.Send(query);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result!.Id, Is.EqualTo(1));
        Assert.That(result.Name, Is.EqualTo("John Smith"));
        Assert.That(result.Age, Is.EqualTo(65));
        Assert.That(result.MonthlyAmount, Is.EqualTo(2500.00m));
        Assert.That(result.PensionType, Is.EqualTo("Defined Benefit"));
    }

    [Test]
    public async Task GetPensionQuery_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPensionQuery).Assembly));
        var serviceProvider = services.BuildServiceProvider();
        var mediator = serviceProvider.GetRequiredService<IMediator>();

        var query = new GetPensionQuery(999); // Non-existent ID

        // Act
        var result = await mediator.Send(query);

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetAllPensionsQuery_ShouldReturnMultiplePensions()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllPensionsQuery).Assembly));
        var serviceProvider = services.BuildServiceProvider();
        var mediator = serviceProvider.GetRequiredService<IMediator>();

        var query = new GetAllPensionsQuery();

        // Act
        var result = await mediator.Send(query);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.GreaterThanOrEqualTo(2));
        
        var firstPension = result.First();
        Assert.That(firstPension.Name, Is.EqualTo("John Smith"));
        Assert.That(firstPension.MonthlyAmount, Is.EqualTo(2500.00m));
    }
}
