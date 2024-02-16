[Dto]
[UserDto]
public class AccountProgrammingFrameworkDto : BaseUserDto
{
    [ForeignKey(nameof(AccountDto))]
    public Guid AccountId { get; set; }

    [ForeignKey(nameof(ProgrammingFrameworkDto))]
    public Guid ProgrammingFrameworkId { get; set; }
}
