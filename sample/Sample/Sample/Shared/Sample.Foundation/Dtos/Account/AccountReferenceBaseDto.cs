public class AccountReferenceBaseDto : BaseUserDto
{
    [ForeignKey(nameof(AccountDto))]
    public Guid AccountId { get; set; }
}
