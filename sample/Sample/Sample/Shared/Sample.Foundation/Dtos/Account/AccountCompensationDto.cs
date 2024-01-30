
    [Dto]
    public class AccountCompensationDto : AccountSubBaseDto
    {
        public required decimal Wage { get; set; }
        public required CompensationTypeEnum Type { get; set; }
    }

