
[Dto]
[CustomizeGetAll(AllowAnonymous = true)]
public class ProgrammingFrameworkDto : BaseDtoWithName
{
    [ForeignKey(nameof(ProgrammingLanguageDto))]
    public Guid ProgrammingLanguageId { get; set; }
}

