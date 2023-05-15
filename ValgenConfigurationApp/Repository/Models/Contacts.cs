namespace ValgenConfigurationApp.Repository.Models
{
    /// <summary>
    /// ContactsModel class.
    /// </summary>

    public class Contacts
    {
        public int Company_ID { get; set; }
        public int Location_ID { get; set; }
        public string? Contact_First_Name { get; set; }
        public string? Contact_Last_Name { get; set; }
        public string? Title { get; set; }
        public string? Contact_Level { get; set; }
        public string? Function_Name { get; set; }
        public string? Email_Present_Flag { get; set; }
        public string? Email { get; set; }
        public string? Email_Status { get; set; }
        public string? Email_Confidence { get; }
        public string? Total_Contacts_at_Company { get; set; }
        public string? Contact_Phone { get; set; }
        public string? Contact_City { get; set; }
        public string? Contact_State { get; set; }
        public string? Contact_LinkedIn_URL { get; set; }
        public string? Source { get; set; }
        public string? last_source { get; set; }
        public string? VG_Level_Priority_Score { get; set; }
        public string? VG_Function_Priority_Score { get; set; }
        public string? VG_Combined_Contact_Priority_Score { get; set; }
    }
}