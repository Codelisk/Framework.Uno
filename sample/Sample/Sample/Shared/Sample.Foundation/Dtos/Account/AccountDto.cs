[Dto]
[UserDto]
public class AccountDto : BaseUserDtoWithName
{
    public required string Email { get; set; }
    public required AccountTypeEnum AccountType { get; set; }
    [ForeignKey(nameof(DistrictDto))]
    public required Guid DistrictId { get; set; }
}
