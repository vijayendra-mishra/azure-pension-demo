using Domain.Entities;
using MediatR;

namespace Application.Queries;

/// <summary>
/// Query handler for retrieving pension information by ID
/// </summary>
public record GetPensionQuery(int Id) : IRequest<Pension?>;

public class GetPensionQueryHandler : IRequestHandler<GetPensionQuery, Pension?>
{
    // Common static pension data source - internal access for sharing between handlers
    internal static readonly List<Pension> _pensionData = new()
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
        },
        new()
        {
            Id = 3,
            Name = "Neal Hutchinson",
            Age = 37,
            PensionStartDate = new DateTime(2027, 3, 1),
            MonthlyAmount = 3200.00m,
            TotalContributions = 180000.00m,
            PensionType = "Executive Plan",
            EmployerName = "Financial Corp",
            IsActive = true,
            CreatedDate = DateTime.UtcNow.AddMonths(-12),
            LastUpdated = DateTime.UtcNow.AddDays(-2)
        }
    };

    public Task<Pension?> Handle(GetPensionQuery request, CancellationToken cancellationToken)
    {
        // Return pension matching ID, or null if not found
        var pension = _pensionData.FirstOrDefault(p => p.Id == request.Id);
        return Task.FromResult(pension);
    }
}

public record GetAllPensionsQuery : IRequest<List<Pension>>;

public class GetAllPensionsQueryHandler : IRequestHandler<GetAllPensionsQuery, List<Pension>>
{
    public Task<List<Pension>> Handle(GetAllPensionsQuery request, CancellationToken cancellationToken)
    {
        // Return all pensions from the common data source
        return Task.FromResult(GetPensionQueryHandler._pensionData.ToList());
    }
}
