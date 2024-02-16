
public partial class CompanySubBaseDto : BaseBaseIdDto
{
    [Id]
    [Key]
    [ForeignKey(nameof(CompanyDto))]
    public Guid CompanyId { get; set; }
    public override Guid GetId()
    {
        return CompanyId;
    }
}
