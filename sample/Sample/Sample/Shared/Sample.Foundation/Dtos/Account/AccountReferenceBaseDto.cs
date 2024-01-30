public class AccountReferenceBaseDto : BaseUserDto
{
    [ForeignKey(nameof(AccountDto))]
    public required Guid AccountId { get; set; }
}
