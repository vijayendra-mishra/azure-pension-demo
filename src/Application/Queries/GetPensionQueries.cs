using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record GetPensionQuery(int Id) : IRequest<Pension>;

public class GetPensionQueryHandler : IRequestHandler<GetPensionQuery, Pension>
{
    public Task<Pension> Handle(GetPensionQuery request, CancellationToken cancellationToken)
    {
        // Return a mock pension for demo purposes
        var pension = new Pension
        {
            Id = request.Id,
            Name = "John Smith",
            Age = 65,
            PensionStartDate = new DateTime(2024, 1, 15),
            MonthlyAmount = 2500.00m,
            TotalContributions = 125000.00m,
            PensionType = "Defined Benefit",
            EmployerName = "Tech Solutions Ltd",
            IsActive = true,
            CreatedDate = DateTime.UtcNow.AddMonths(-6),
            LastUpdated = DateTime.UtcNow.AddDays(-10)
        };

        return Task.FromResult(pension);
    }
}

public record GetAllPensionsQuery : IRequest<List<Pension>>;

public class GetAllPensionsQueryHandler : IRequestHandler<GetAllPensionsQuery, List<Pension>>
{
    public Task<List<Pension>> Handle(GetAllPensionsQuery request, CancellationToken cancellationToken)
    {
        // Return mock pensions for demo purposes
        var pensions = new List<Pension>
        {
            new()
            {
                Id = 1,
                Name = "John Smith",
                Age = 65,
                PensionStartDate = new DateTime(2024, 1, 15),
                MonthlyAmount = 2500.00m,
                TotalContributions = 125000.00m,
                PensionType = "Defined Benefit",
                EmployerName = "Tech Solutions Ltd",
                IsActive = true,
                CreatedDate = DateTime.UtcNow.AddMonths(-6),
                LastUpdated = DateTime.UtcNow.AddDays(-10)
            },
            new()
            {
                Id = 2,
                Name = "Sarah Johnson",
                Age = 62,
                PensionStartDate = new DateTime(2025, 6, 1),
                MonthlyAmount = 1800.00m,
                TotalContributions = 95000.00m,
                PensionType = "Defined Contribution",
                EmployerName = "Healthcare Plus",
                IsActive = true,
                CreatedDate = DateTime.UtcNow.AddMonths(-3),
                LastUpdated = DateTime.UtcNow.AddDays(-5)
            }
        };

        return Task.FromResult(pensions);
    }
}
