using Microsoft.EntityFrameworkCore;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository.Models
{
    /// <summary>
    /// DbContext class.
    /// </summary>
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<LoginDetails> LoginDetails { get; set; }

        public virtual DbSet<Subscribers> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginDetails>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.userName).IsRequired();
                entity.Property(e => e.userPassword).IsRequired();
            });

            modelBuilder.Entity<Subscribers>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.Email);
                entity.Property(e => e.Phone);
                entity.Property(e => e.Token);
                entity.Property(e => e.StartDate).IsRequired(false);
                entity.Property(e => e.EndDate).IsRequired(false);
                entity.Property(e => e.ConfigJSON);
                entity.Property(e => e.isActive);
            });

            modelBuilder.Entity<Subscribers>(entity =>
            {
                entity.ToTable("Subscribers", tb => tb.HasTrigger("UpdateModifiedDate"));
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.Property(e => e.Company_ID);
                entity.Property(e => e.Location_ID);
                entity.Property(e => e.Contact_First_Name);
                entity.Property(e => e.Contact_Last_Name);
                entity.Property(e => e.Title);
                entity.Property(e => e.Contact_Level);
                entity.Property(e => e.Function_Name);
                entity.Property(e => e.Email_Present_Flag);
                entity.Property(e => e.Email);
                entity.Property(e => e.Email_Status);
                entity.Property(e => e.Email_Confidence);
                entity.Property(e => e.Total_Contacts_at_Company);
                entity.Property(e => e.Contact_Phone);
                entity.Property(e => e.Contact_City);
                entity.Property(e => e.Contact_State);
                entity.Property(e => e.Contact_LinkedIn_URL);
                entity.Property(e => e.Source);
                entity.Property(e => e.last_source);
                entity.Property(e => e.VG_Level_Priority_Score);
                entity.Property(e => e.VG_Function_Priority_Score);
                entity.Property(e => e.VG_Combined_Contact_Priority_Score);
            });

            modelBuilder.Entity<Contacts>().HasNoKey();

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.Company_ID);
                entity.Property(e => e.Location_ID);
                entity.Property(e => e.Location_Type);
                entity.Property(e => e.Decision_Type);
                entity.Property(e => e.Corporate_Family_Name);
                entity.Property(e => e.Company_Name);
                entity.Property(e => e.Street);
                entity.Property(e => e.City);
                entity.Property(e => e.State);
                entity.Property(e => e.Zip);
                entity.Property(e => e.County);
                entity.Property(e => e.Region);
                entity.Property(e => e.Company_Phone_Area_Code);
                entity.Property(e => e.Company_Phone);
                entity.Property(e => e.Total_Fleet);
                entity.Property(e => e.Total_Fleet_Range);
                entity.Property(e => e.Fleet_at_Location);
                entity.Property(e => e.Fleet_at_Location_Range);
                entity.Property(e => e.Total_Locations);
                entity.Property(e => e.Total_Locations_Range);
                entity.Property(e => e.Class_1_Vehicles_Count);
                entity.Property(e => e.Class_2_Vehicles_Count);
                entity.Property(e => e.Class_3_Vehicles_Count);
                entity.Property(e => e.Class_4_Vehicles_Count);
                entity.Property(e => e.Class_5_Vehicles_Count);
                entity.Property(e => e.Class_6_Vehicles_Count);
                entity.Property(e => e.Class_7_Vehicles_Count);
                entity.Property(e => e.Class_8_Vehicles_Count);
                entity.Property(e => e.Class_Unknown_Vehicles_Count);
                entity.Property(e => e.Light_Duty_Vehicles_Count);
                entity.Property(e => e.Medium_Duty_Vehicles_Count);
                entity.Property(e => e.Heavy_Duty_Vehicles_Count);
                entity.Property(e => e.Light_Duty_Percent_of_Fleet);
                entity.Property(e => e.Medium_Duty_Percent_of_Fleet);
                entity.Property(e => e.Heavy_Duty_Percent_of_Fleet);
                entity.Property(e => e.Industry_Tag_Towing);
                entity.Property(e => e.Industry_Tag_Transient);
                entity.Property(e => e.Industry_Tag_Utilities);
                entity.Property(e => e.Industry_Tag_Food_and_Beverage);
                entity.Property(e => e.Industry_Tag_Landscaping);
                entity.Property(e => e.Industry_Tag_Oil_and_Gas);
                entity.Property(e => e.Industry_Tag_Local_Trucking_and_Delivery);
                entity.Property(e => e.Industry_Tag_Non_Local_Trucking);
                entity.Property(e => e.Industry_Tag_Rental);
                entity.Property(e => e.Industry_Tag_Emergency_Services);
                entity.Property(e => e.Industry_Tag_Police_and_Public_Safety);
                entity.Property(e => e.Industry_Tag_Passenger_and_Transit);
                entity.Property(e => e.Industry_Tag_Construction);
                entity.Property(e => e.Industry_Tag_Government_State_and_Local);
                entity.Property(e => e.Industry_Tag_Government_Federal);
                entity.Property(e => e.Industry_Tag_Education_Higher_Ed);
                entity.Property(e => e.Industry_Tag_Field_and_Facility_Services);
                entity.Property(e => e.Industry_Tag_Agriculture);
                entity.Property(e => e.Industry_Tag_Waste_and_Refuse);
                entity.Property(e => e.Industry_Tag_Telecommunications);
                entity.Property(e => e.Industry_Tag_Public_Works);
                entity.Property(e => e.Industry_Tag_Wholesale_Distribution);
                entity.Property(e => e.Industry_Tag_Warehousing);
                entity.Property(e => e.Industry_Tag_Architectural_and_Engineering);
                entity.Property(e => e.Industry_Tag_Non_Land);
                entity.Property(e => e.Corporate_Employees);
                entity.Property(e => e.Corporate_Employees_Range);
                entity.Property(e => e.Corporate_Revenues);
                entity.Property(e => e.Corporate_Revenues_Range);
                entity.Property(e => e.Website);
                entity.Property(e => e.Company_LinkedIn_Page);
                entity.Property(e => e.Company_Facebook_Page);
                entity.Property(e => e.Total_Contacts_Available);
                entity.Property(e => e.Total_Contacts_with_Email);
                entity.Property(e => e.Total_Contacts_Manager_and_above);
                entity.Property(e => e.Company_Crunchbase_Page);
                entity.Property(e => e.Company_Twitter_Page);
                entity.Property(e => e.Industry_Tag_Contractors);
                entity.Property(e => e.Industry_Tag_Dealers);
                entity.Property(e => e.Industry_Tag_Finance_Insurance);
                entity.Property(e => e.Industry_Tag_HVAC_Plumbing);
                entity.Property(e => e.Industry_Tag_Health_Care_Pharma);
                entity.Property(e => e.Industry_Tag_K_12);
                entity.Property(e => e.Industry_Tag_Local_Delivery_Last_Mile);
                entity.Property(e => e.Industry_Tag_Manufacturing);
                entity.Property(e => e.Industry_Tag_Mining);
                entity.Property(e => e.Industry_Tag_Mobile_Field_Service);
                entity.Property(e => e.Industry_Tag_Non_Profit);
                entity.Property(e => e.Industry_Tag_Religious_Organization);
                entity.Property(e => e.Industry_Tag_Retail);
                entity.Property(e => e.Metro_Area_Code);
                entity.Property(e => e.Metro_Area_Description);
                entity.Property(e => e.SIC2_Code);
                entity.Property(e => e.SIC2_Description);
                entity.Property(e => e.SIC4_Code);
                entity.Property(e => e.SIC4_Description);
                entity.Property(e => e.SIC_Sector_Code);
                entity.Property(e => e.SIC_Sector_Description);
                entity.Property(e => e.State_Abbr);
                entity.Property(e => e.Industry_Tag_Hire_Trucking_and_Brokerage);
                entity.Property(e => e.Total_Class_1_Vehicles_Count);
                entity.Property(e => e.Total_Class_2_Vehicles_Count);
                entity.Property(e => e.Total_Class_3_Vehicles_Count);
                entity.Property(e => e.Total_Class_4_Vehicles_Count);
                entity.Property(e => e.Total_Class_5_Vehicles_Count);
                entity.Property(e => e.Total_Class_6_Vehicles_Count);
                entity.Property(e => e.Total_Class_7_Vehicles_Count);
                entity.Property(e => e.Total_Class_8_Vehicles_Count);
                entity.Property(e => e.Total_Light_Duty_Count);
                entity.Property(e => e.Total_Medium_Duty_Count);
                entity.Property(e => e.Total_Heavy_Duty_Count);
                entity.Property(e => e.Consolidated_Industry);
                entity.Property(e => e.Source);
                entity.Property(e => e.Industry_Tag_Wholesale);
                entity.Property(e => e.Hubspot_Company_ID);
                entity.Property(e => e.Most_Recent_Total_Company_Vehicle_Purchase_Date);
                entity.Property(e => e.Most_Recent_Location_Vehicle_Purchase_Date);
                entity.Property(e => e.Body_Location_Buses_Count);
                entity.Property(e => e.Body_Location_Cement_Mixer_Count);
                entity.Property(e => e.Body_Location_Commercial_Truck_Count);
                entity.Property(e => e.Body_Location_Cutaway_Count);
                entity.Property(e => e.Body_Location_Fire_Truck_Count);
                entity.Property(e => e.Body_Location_Garbage_Refuse_Count);
                entity.Property(e => e.Body_Location_Gliders_Count);
                entity.Property(e => e.Body_Location_Incomplete_Pickup_Count);
                entity.Property(e => e.Body_Location_Incomplete_Strip_Chassis_Count);
                entity.Property(e => e.Body_Location_Passenger_Car_Sedan_Count);
                entity.Property(e => e.Body_Location_Pickup_Count);
                entity.Property(e => e.Body_Location_SUV_Count);
                entity.Property(e => e.Body_Location_Straight_Truck_Count);
                entity.Property(e => e.Body_Summary_Location_Vans_Count);
                entity.Property(e => e.Body_Summary_Total_Company_Van_Count);
                entity.Property(e => e.Body_Total_Company_Buses_Count);
                entity.Property(e => e.Body_Total_Company_Cement_Mixer_Count);
                entity.Property(e => e.Body_Total_Company_Commercial_Truck_Count);
                entity.Property(e => e.Body_Total_Company_Cutaway_Count);
                entity.Property(e => e.Body_Total_Company_Fire_Truck_Count);
                entity.Property(e => e.Body_Total_Company_Garbage_Refuse_Count);
                entity.Property(e => e.Body_Total_Company_Gliders_Count);
                entity.Property(e => e.Body_Total_Company_Incomplete_Pickup_Count);
                entity.Property(e => e.Body_Total_Company_Incomplete_Strip_Chassis_Count);
                entity.Property(e => e.Body_Total_Company_Passenger_Car_Sedan_Count);
                entity.Property(e => e.Body_Total_Company_Pickup_Count);
                entity.Property(e => e.Body_Total_Company_SUV_Count);
                entity.Property(e => e.Body_Total_Company_Straight_Truck_Count);
                entity.Property(e => e.Brand_Chevrolet_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Chevrolet_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Dodge_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Dodge_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Ford_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Ford_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Freightliner_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Freightliner_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_GMC_Location_Vehicles_Count);
                entity.Property(e => e.Brand_GMC_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_International_Location_Vehicles_Count);
                entity.Property(e => e.Brand_International_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Nissan_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Nissan_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Other_Domestic_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Other_Domestic_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Other_Import_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Other_Import_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Ram_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Ram_Total_Company_Vehicles_Count);
                entity.Property(e => e.Brand_Toyota_Location_Vehicles_Count);
                entity.Property(e => e.Brand_Toyota_Total_Company_Vehicles_Count);
                entity.Property(e => e.Fuel_Diesel_Location_Vehicles_Count);
                entity.Property(e => e.Fuel_Diesel_Total_Company_Vehicles_Count);
                entity.Property(e => e.Fuel_Electric_Location_Vehicles_Count);
                entity.Property(e => e.Fuel_Electric_Total_Company_Vehicles_Count);
                entity.Property(e => e.Fuel_Flex_Fuel_Location_Vehicles_Count);
                entity.Property(e => e.Fuel_Flex_Fuel_Total_Company_Vehicles_Count);
                entity.Property(e => e.Fuel_Gasoline_Location_Vehicles_Count);
                entity.Property(e => e.Fuel_Gasoline_Total_Company_Vehicles_Count);
                entity.Property(e => e.Fuel_Hybrid_Location_Vehicles_Count);
                entity.Property(e => e.Fuel_Hybrid_Total_Company_Vehicles_Count);
                entity.Property(e => e.Fuel_Natural_Gas_Location_Vehicles_Count);
                entity.Property(e => e.Fuel_Natural_Gas_Total_Company_Vehicles_Count);
                entity.Property(e => e.Ownership_New_Purchase_Location_Vehicle_Count);
                entity.Property(e => e.Ownership_New_Purchase_Total_Company_Vehicle_Count);
                entity.Property(e => e.Ownership_Used_Purchase_Location_Vehicle_Count);
                entity.Property(e => e.Ownership_Used_Purchase_Total_Company_Vehicle_Count);
                entity.Property(e => e.Contacts_at_Location);
                entity.Property(e => e.Latitude);
                entity.Property(e => e.Longitude);
                entity.Property(e => e.Industry_Tag_Vehicle_Maint);
                entity.Property(e => e.CountyId);
                entity.Property(e => e.m_geopoint);
                entity.Property(e => e.last_source);
                entity.Property(e => e.Dot_Number);
                entity.Property(e => e.dot_Mc_Number_Consolidated);
                entity.Property(e => e.dot_Mc_Number_1);
                entity.Property(e => e.dot_Mc_Number_2);
                entity.Property(e => e.dot_Mc_Number_3);
                entity.Property(e => e.dot_Company_Safer_Link);
                entity.Property(e => e.dot_Operation_Classification_Consolidated);
                entity.Property(e => e.dot_Operation_Classification_Auth_For_Hire);
                entity.Property(e => e.dot_Operation_Classification_Exempt_For_Hire);
                entity.Property(e => e.dot_Operation_Classification_Private_Property);
                entity.Property(e => e.dot_Operation_Classification_Private_Passenger_Business);
                entity.Property(e => e.dot_Operation_Classification_Private_Passenger_Nonbusiness);
                entity.Property(e => e.dot_Operation_Classification_Migrant);
                entity.Property(e => e.dot_Operation_Classification_Us_Mail);
                entity.Property(e => e.dot_Operation_Classification_Federal_Govt);
                entity.Property(e => e.dot_Operation_Classification_State_Govt);
                entity.Property(e => e.dot_Operation_Classification_Local_Govt);
                entity.Property(e => e.dot_Operation_Classification_Indian_Tribe);
                entity.Property(e => e.dot_Operation_Classification_Other);
                entity.Property(e => e.dot_Cargo_Carried_Consolidated);
                entity.Property(e => e.dot_Cargo_Carried_General_Freight);
                entity.Property(e => e.dot_Cargo_Carried_Household_Goods);
                entity.Property(e => e.dot_Cargo_Carried_Metal);
                entity.Property(e => e.dot_Cargo_Carried_Motor_Vehicles);
                entity.Property(e => e.dot_Cargo_Carried_Driveaway);
                entity.Property(e => e.dot_Cargo_Carried_Logs);
                entity.Property(e => e.dot_Cargo_Carried_Building_Materials);
                entity.Property(e => e.dot_Cargo_Carried_Mobile_Homes);
                entity.Property(e => e.dot_Cargo_Carried_Machinery);
                entity.Property(e => e.dot_Cargo_Carried_Fresh_Produce);
                entity.Property(e => e.dot_Cargo_Carried_Liquids_Gases);
                entity.Property(e => e.dot_Cargo_Carried_Intermodal_Containers);
                entity.Property(e => e.dot_Cargo_Carried_Passengers);
                entity.Property(e => e.dot_Cargo_Carried_Oilfield_Equipment);
                entity.Property(e => e.dot_Cargo_Carried_Livestock);
                entity.Property(e => e.dot_Cargo_Carried_Grain);
                entity.Property(e => e.dot_Cargo_Carried_Coal_Coke);
                entity.Property(e => e.dot_Cargo_Carried_Meat);
                entity.Property(e => e.dot_Cargo_Carried_Garbage);
                entity.Property(e => e.dot_Cargo_Carried_Us_Mail);
                entity.Property(e => e.dot_Cargo_Carried_Chemicals);
                entity.Property(e => e.dot_Cargo_Carried_Commodities);
                entity.Property(e => e.dot_Cargo_Carried_Refrigerated_Food);
                entity.Property(e => e.dot_Cargo_Carried_Beverages);
                entity.Property(e => e.dot_Cargo_Carried_Paper_Products);
                entity.Property(e => e.dot_Cargo_Carried_Utility);
                entity.Property(e => e.dot_Cargo_Carried_Farm_Supplies);
                entity.Property(e => e.dot_Cargo_Carried_Construction);
                entity.Property(e => e.dot_Cargo_Carried_Water_Well);
                entity.Property(e => e.dot_Cargo_Carried_Other);
                entity.Property(e => e.dot_Power_Units_Range);
                entity.Property(e => e.dot_Power_Units_Total);
                entity.Property(e => e.dot_Power_Units_Owned);
                entity.Property(e => e.dot_Power_Units_Leased);
                entity.Property(e => e.dot_Tractors_Total);
                entity.Property(e => e.dot_Tractors_Owned);
                entity.Property(e => e.dot_Tractors_Owned_Percent);
                entity.Property(e => e.dot_Tractors_Leased);
                entity.Property(e => e.dot_Tractors_Leased_Percent);
                entity.Property(e => e.dot_Trucks_Total);
                entity.Property(e => e.dot_Trucks_Owned);
                entity.Property(e => e.dot_Trucks_Owned_Percent);
                entity.Property(e => e.dot_Trucks_Leased);
                entity.Property(e => e.dot_Trucks_Leased_Percent);
                entity.Property(e => e.dot_Trailers_Total);
                entity.Property(e => e.dot_Trailers_Owned);
                entity.Property(e => e.dot_Trailers_Owned_Percent);
                entity.Property(e => e.dot_Trailers_Leased);
                entity.Property(e => e.dot_Trailers_Leased_Percent);
                entity.Property(e => e.dot_Drivers_Total);
                entity.Property(e => e.dot_Drivers_Range);
                entity.Property(e => e.dot_Drivers_CDL);
                entity.Property(e => e.dot_Drivers_Interstate);
                entity.Property(e => e.dot_Drivers_Intrastate);
                entity.Property(e => e.dot_dba_company_name);
                entity.Property(e => e.NAICS8_code);
                entity.Property(e => e.NAICS8_description);
            });

            modelBuilder.Entity<Companies>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
