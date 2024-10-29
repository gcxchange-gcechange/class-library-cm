using System.Text.Json;
using class_library_cm.enums;

namespace class_library_cm
{
    public class JobOpportunity
    {
        public required string ContactObjectId { get; set; }
        public required string ContactName { get; set; }
        public required string Department { get; set; }
        public required string ContactEmail { get; set; }
        public required string JobTitleEn { get; set; }
        public required string JobTitleFr { get; set; }
        public required JobType JobType { get; set; }
        public required string ProgramArea { get; set; }
        public required string ClassificationCode { get; set; }
        public required string ClassificationLevel { get; set; }
        public required byte NumberOfOpportunities { get; set; }
        public required string Duration { get; set; }
        public required DateTime ApplicationDeadline { get; set; }
        public required string JobDescriptionEn { get; set; }
        public required string JobDescriptionFr { get; set; }
        public required string EssentialSkills { get; set; }
        public required string WorkSchedule { get; set; }
        public required string Location { get; set; }
        public required SecurityClearance SecurityClearance { get; set; }
        public required string LanguageRequirement { get; set; }
        public required string WorkArrangement { get; set; }
        public bool? ApprovedStaffing { get; set; }
        public required string AssetSkills { get; set; }
        public string? Attachments { get; set; }

        public JobOpportunity()
        {

        }

        public JobOpportunity(
            string contactObjectId,
            string contactName,
            string department,
            string contactEmail,
            string jobTitleEn,
            string jobTitleFr,
            JobType jobType,
            string programArea,
            string classificationCode,
            string classificationLevel,
            byte numberOfOpportunities,
            string duration,
            DateTime applicationDeadline,
            string jobDescriptionEn,
            string jobDescriptionFr,
            string essentialSkills,
            string workSchedule,
            string location,
            SecurityClearance securityClearance,
            string languageRequirement,
            string workArrangement,
            string assetSkills,
            bool? approvedStaffing = null,
            string? attachments = null
        )
        {
            ContactObjectId = contactObjectId;
            ContactName = contactName;
            Department = department;
            ContactEmail = contactEmail;
            JobTitleEn = jobTitleEn;
            JobTitleFr = jobTitleFr;
            JobType = jobType;
            ProgramArea = programArea;
            ClassificationCode = classificationCode;
            ClassificationLevel = classificationLevel;
            NumberOfOpportunities = numberOfOpportunities;
            Duration = duration;
            ApplicationDeadline = applicationDeadline;
            JobDescriptionEn = jobDescriptionEn;
            JobDescriptionFr = jobDescriptionFr;
            EssentialSkills = essentialSkills;
            WorkSchedule = workSchedule;
            Location = location;
            SecurityClearance = securityClearance;
            LanguageRequirement = languageRequirement;
            WorkArrangement = workArrangement;
            AssetSkills = assetSkills;
            ApprovedStaffing = approvedStaffing;
            Attachments = attachments;
        }

        public bool IsExpired()
        {
            return ApplicationDeadline > DateTime.Now;
        }

        public int DaysUntilExpired()
        {
            return (ApplicationDeadline - DateTime.Now).Days;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static JobOpportunity FromJson(string json)
        {
            return JsonSerializer.Deserialize<JobOpportunity>(json);
        }

        public string GetJobSummary(Language language)
        {
            switch (language)
            {
                case Language.French:
                    return $"Job Title: {JobTitleFr} in {Department} - {Location} ({ClassificationCode}-{ClassificationLevel})";
                case Language.English:
                default:
                    return $"Job Title: {JobTitleEn} in {Department} - {Location} ({ClassificationCode}-{ClassificationLevel})";
            }
            
        }
    }
}
