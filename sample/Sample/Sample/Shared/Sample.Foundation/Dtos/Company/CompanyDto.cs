
public partial class CompanyDto : BaseDtoWithName
{
    [ForeignKey(nameof(IndustryDto))]
    public Guid IndustryId { get; set; }
    [ForeignKey(nameof(InfrastructureDto))]
    public Guid InfrastructureId { get; set; }
    [ForeignKey(nameof(CompanyLocationDto))]
    public Guid CompanyLocationId { get; set; }
    public int FoundingYear { get; set; }
    public int DeveloperCount { get; set; }
    public string Description { get; set; }
    public string HowWeDevelopDescription { get; set; }
    public string? CareerLink { get; set; }
    public string? WebsiteLink { get; set; }
}
