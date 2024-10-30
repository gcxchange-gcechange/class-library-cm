using System.Text.Json;

namespace CareerMarketplace
{
    public class JobOpportunity
    {
        public required string ContactObjectId { get; set; }
        public required string ContactName { get; set; }
        public required string Department { get; set; }
        public required string ContactEmail { get; set; }
        public required string JobTitleEn { get; set; }
        public required string JobTitleFr { get; set; }
        public required string JobType { get; set; }
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
        public required string SecurityClearance { get; set; }
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
            string jobType,
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
            string securityClearance,
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

        public string ToHTML()
        {
            string htmlContent = @$"
            <div style='max-width: 600px; margin: 20px auto; background: #ffffff; padding: 20px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.2); font-family: Arial, sans-serif;'>
                <div style='text-align: center; padding-bottom: 20px; border-bottom: 1px solid #ddd;'>
                    <h1 style='color: #333;'>Job Opportunity Preview</h1>
                </div>
                <div style='padding: 20px;'>
                    <h2 style='color: #4CAF50; font-size: 1.2em; margin-bottom: 10px;'>Contact Information</h2>
                    <p><strong>Contact Name:</strong> {ContactName}</p>
                    <p><strong>Contact Email:</strong> {ContactEmail}</p>
                    <p><strong>Department:</strong> {Department}</p>
        
                    <h2 style='color: #4CAF50; font-size: 1.2em; margin-bottom: 10px;'>Job Details</h2>
                    <p><strong>Job Title (EN):</strong> {JobTitleEn}</p>
                    <p><strong>Job Title (FR):</strong> {JobTitleFr}</p>
                    <p><strong>Job Type:</strong> {JobType}</p>
                    <p><strong>Program Area:</strong> {ProgramArea}</p>
                    <p><strong>Classification Code:</strong> {ClassificationCode}</p>
                    <p><strong>Classification Level:</strong> {ClassificationLevel}</p>
                    <p><strong>Number of Opportunities:</strong> {NumberOfOpportunities}</p>
                    <p><strong>Duration:</strong> {Duration}</p>
                    <p><strong>Application Deadline:</strong> {ApplicationDeadline:MMMM dd, yyyy}</p>
        
                    <h2 style='color: #4CAF50; font-size: 1.2em; margin-bottom: 10px;'>Job Description</h2>
                    <p><strong>Description (EN):</strong> {JobDescriptionEn}</p>
                    <p><strong>Description (FR):</strong> {JobDescriptionFr}</p>
                    <p><strong>Essential Skills:</strong> {EssentialSkills}</p>
                    <p><strong>Asset Skills:</strong> {AssetSkills}</p>
        
                    <h2 style='color: #4CAF50; font-size: 1.2em; margin-bottom: 10px;'>Work Conditions</h2>
                    <p><strong>Work Schedule:</strong> {WorkSchedule}</p>
                    <p><strong>Location:</strong> {Location}</p>
                    <p><strong>Security Clearance:</strong> {SecurityClearance}</p>
                    <p><strong>Language Requirement:</strong> {LanguageRequirement}</p>
                    <p><strong>Work Arrangement:</strong> {WorkArrangement}</p>
                    <p><strong>Approved Staffing:</strong> {(ApprovedStaffing.HasValue ? (ApprovedStaffing.Value ? "Yes" : "No") : "Pending")}</p>
        
                    {(Attachments != null ? $"<h2 style='color: #4CAF50; font-size: 1.2em; margin-bottom: 10px;'>Attachments</h2><p>{Attachments}</p>" : "")}
                </div>
                <div style='text-align: center; color: #999; padding: 10px; font-size: 0.9em; border-top: 1px solid #ddd; margin-top: 20px;'>
                    <p>&copy; {DateTime.Now.Year} GCXChange - Job Opportunity Preview</p>
                </div>
            </div>";
            return htmlContent;
        }
    }
}
