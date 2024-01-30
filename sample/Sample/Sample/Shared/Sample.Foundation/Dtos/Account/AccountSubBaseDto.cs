
[PrimaryKey(nameof(AccountId))]
public partial class AccountSubBaseDto : BaseBaseIdDto
{
    [Id]
    [Key]
    [ForeignKey(nameof(AccountDto))]
    public required Guid AccountId { get; set; }

    public override Guid GetId()
    {
        return AccountId;
    }
}

