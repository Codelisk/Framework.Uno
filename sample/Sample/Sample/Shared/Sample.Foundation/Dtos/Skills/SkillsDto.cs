
    [Dto]
    public class SkillsDto : AccountSubBaseDto
    {
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public Guid PrimaryProgrammingLanguage { get; set; }
        [ForeignKey(nameof(ProgrammingLanguageDto))]
        public Guid? SecondaryProgrammingLanguage { get; set; }
    }

