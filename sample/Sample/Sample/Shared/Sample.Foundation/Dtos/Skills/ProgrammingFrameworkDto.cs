
[Dto]
[CustomizeGetAll(AllowAnonymous = true)]
public class ProgrammingFrameworkDto : BaseDtoWithName
{
    [ForeignKey(nameof(ProgrammingLanguageDto))]
    public required Guid ProgrammingLanguageId { get; set; }
}

