
    [Dto]
    public class SkillsDto : AccountSubBaseDto
    {
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public required Guid PrimaryProgrammingLanguage { get; set; }
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public Guid? SecondaryProgrammingLanguage { get; set; }
    }

