[Dto]
[UserDto]
public class AccountProgrammingFrameworkDto : BaseUserDto
{
    [ForeignKey(nameof(AccountDto))]
    public required Guid AccountId { get; set; }

    [ForeignKey(nameof(ProgrammingFrameworkDto))]
    public required Guid ProgrammingFrameworkId { get; set; }
}
