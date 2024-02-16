[Dto]
[UserDto]
public class AccountDto : BaseUserDtoWithName
{
    public string Email { get; set; }
    public AccountTypeEnum AccountType { get; set; }
    [ForeignKey(nameof(DistrictDto))]
    public Guid DistrictId { get; set; }
}
