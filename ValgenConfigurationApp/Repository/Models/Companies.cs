﻿namespace ValgenConfigurationApp.Repository.Models
{
    /// <summary>
    /// CompaniesModel class.
    /// </summary>

    public class Companies
    {
        public int Company_ID { get; set; }
        public int Location_ID { get; set; }
        public string Location_Type { get; set; }
        public string Decision_Type { get; set; }
        public string? Corporate_Family_Name { get; set; }
        public string? Company_Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? County { get; set; }
        public string? Region { get; set; }
        public int Company_Phone_Area_Code { get; set; }
        public string? Company_Phone { get; set; }
        public int Total_Fleet { get; set; }
        public string Total_Fleet_Range { get; set; }
        public int Fleet_at_Location { get; set; }
        public string Fleet_at_Location_Range { get; set; }
        public int Total_Locations { get; set; }
        public string Total_Locations_Range { get; set; }
        public int Class_1_Vehicles_Count { get; set; }
        public int Class_2_Vehicles_Count { get; set; }
        public int Class_3_Vehicles_Count { get; set; }
        public int Class_4_Vehicles_Count { get; set; }
        public int Class_5_Vehicles_Count { get; set; }
        public int Class_6_Vehicles_Count { get; set; }
        public int Class_7_Vehicles_Count { get; set; }
        public int Class_8_Vehicles_Count { get; set; }
        public int Class_Unknown_Vehicles_Count { get; set; }
        public int Light_Duty_Vehicles_Count { get; set; }
        public int Medium_Duty_Vehicles_Count { get; set; }
        public int Heavy_Duty_Vehicles_Count { get; set; }
        public string? Light_Duty_Percent_of_Fleet { get; set; }
        public string? Medium_Duty_Percent_of_Fleet { get; set; }
        public string? Heavy_Duty_Percent_of_Fleet { get; set; }
        public int Industry_Tag_Towing { get; set; }
        public int Industry_Tag_Transient { get; set; }
        public int Industry_Tag_Utilities { get; set; }
        public int Industry_Tag_Food_and_Beverage { get; set; }
        public int Industry_Tag_Landscaping { get; set; }
        public int Industry_Tag_Oil_and_Gas { get; set; }
        public int Industry_Tag_Local_Trucking_and_Delivery { get; set; }
        public int Industry_Tag_Non_Local_Trucking { get; set; }
        public int Industry_Tag_Rental { get; set; }
        public int Industry_Tag_Emergency_Services { get; set; }
        public int Industry_Tag_Police_and_Public_Safety { get; set; }
        public int Industry_Tag_Passenger_and_Transit { get; set; }
        public int Industry_Tag_Construction { get; set; }
        public int Industry_Tag_Government_State_and_Local { get; set; }
        public int Industry_Tag_Government_Federal { get; set; }
        public int Industry_Tag_Education_Higher_Ed { get; set; }
        public int Industry_Tag_Field_and_Facility_Services { get; set; }
        public int Industry_Tag_Agriculture { get; set; }
        public int Industry_Tag_Waste_and_Refuse { get; set; }
        public int Industry_Tag_Telecommunications { get; set; }
        public int Industry_Tag_Public_Works { get; set; }
        public int Industry_Tag_Wholesale_Distribution { get; set; }
        public int Industry_Tag_Warehousing { get; set; }
        public int Industry_Tag_Architectural_and_Engineering { get; set; }
        public int Industry_Tag_Non_Land { get; set; }
        public int Corporate_Employees { get; set; }
        public string Corporate_Employees_Range { get; set; }
        public int Corporate_Revenues { get; set; }
        public string Corporate_Revenues_Range { get; set; }
        public string? Website { get; set; }
        public string? Company_LinkedIn_Page { get; set; }
        public string? Company_Facebook_Page { get; set; }
        public long Total_Contacts_Available { get; set; }
        public long Total_Contacts_with_Email { get; set; }
        public long Total_Contacts_Manager_and_above { get; set; }
        public string? Company_Crunchbase_Page { get; set; }
        public string? Company_Twitter_Page { get; set; }
        public int Industry_Tag_Contractors { get; set; }
        public int Industry_Tag_Dealers { get; set; }
        public int Industry_Tag_Finance_Insurance { get; set; }
        public int Industry_Tag_HVAC_Plumbing { get; set; }
        public int Industry_Tag_Health_Care_Pharma { get; set; }
        public int Industry_Tag_K_12 { get; set; }
        public int Industry_Tag_Local_Delivery_Last_Mile { get; set; }
        public int Industry_Tag_Manufacturing { get; set; }
        public int Industry_Tag_Mining { get; set; }
        public int Industry_Tag_Mobile_Field_Service { get; set; }
        public int Industry_Tag_Non_Profit { get; set; }
        public int Industry_Tag_Religious_Organization { get; set; }
        public int Industry_Tag_Retail { get; set; }
        public long Metro_Area_Code { get; set; }
        public string? Metro_Area_Description { get; set; }
        public string? SIC2_Code { get; set; }
        public string? SIC2_Description { get; set; }
        public string? SIC4_Code { get; set; }
        public string? SIC4_Description { get; set; }
        public long SIC_Sector_Code { get; set; }
        public string? SIC_Sector_Description { get; set; }
        public string? State_Abbr { get; set; }
        public int Industry_Tag_Hire_Trucking_and_Brokerage { get; set; }
        public long Total_Class_1_Vehicles_Count { get; set; }
        public long Total_Class_2_Vehicles_Count { get; set; }
        public long Total_Class_3_Vehicles_Count { get; set; }
        public long Total_Class_4_Vehicles_Count { get; set; }
        public long Total_Class_5_Vehicles_Count { get; set; }
        public long Total_Class_6_Vehicles_Count { get; set; }
        public long Total_Class_7_Vehicles_Count { get; set; }
        public long Total_Class_8_Vehicles_Count { get; set; }
        public long Total_Light_Duty_Count { get; set; }
        public long Total_Medium_Duty_Count { get; set; }
        public long Total_Heavy_Duty_Count { get; set; }
        public string? Consolidated_Industry { get; set; }
        public string? Source { get; set; }
        public int Industry_Tag_Wholesale { get; set; }
        public string? Hubspot_Company_ID { get; set; }
        public DateTime Most_Recent_Total_Company_Vehicle_Purchase_Date { get; set; }
        public DateTime Most_Recent_Location_Vehicle_Purchase_Date { get; set; }
        public long Body_Location_Buses_Count { get; set; }
        public long Body_Location_Cement_Mixer_Count { get; set; }
        public long Body_Location_Commercial_Truck_Count { get; set; }
        public long Body_Location_Cutaway_Count { get; set; }
        public long Body_Location_Fire_Truck_Count { get; set; }
        public long Body_Location_Garbage_Refuse_Count { get; set; }
        public long Body_Location_Gliders_Count { get; set; }
        public long Body_Location_Incomplete_Pickup_Count { get; set; }
        public long Body_Location_Incomplete_Strip_Chassis_Count { get; set; }
        public long Body_Location_Passenger_Car_Sedan_Count { get; set; }
        public long Body_Location_Pickup_Count { get; set; }
        public long Body_Location_SUV_Count { get; set; }
        public long Body_Location_Straight_Truck_Count { get; set; }
        public long Body_Summary_Location_Vans_Count { get; set; }
        public long Body_Summary_Total_Company_Van_Count { get; set; }
        public long Body_Total_Company_Buses_Count { get; set; }
        public long Body_Total_Company_Cement_Mixer_Count { get; set; }
        public long Body_Total_Company_Commercial_Truck_Count { get; set; }
        public long Body_Total_Company_Cutaway_Count { get; set; }
        public long Body_Total_Company_Fire_Truck_Count { get; set; }
        public long Body_Total_Company_Garbage_Refuse_Count { get; set; }
        public long Body_Total_Company_Gliders_Count { get; set; }
        public long Body_Total_Company_Incomplete_Pickup_Count { get; set; }
        public long Body_Total_Company_Incomplete_Strip_Chassis_Count { get; set; }
        public long Body_Total_Company_Passenger_Car_Sedan_Count { get; set; }
        public long Body_Total_Company_Pickup_Count { get; set; }
        public long Body_Total_Company_SUV_Count { get; set; }
        public long Body_Total_Company_Straight_Truck_Count { get; set; }
        public long Brand_Chevrolet_Location_Vehicles_Count { get; set; }
        public long Brand_Chevrolet_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Dodge_Location_Vehicles_Count { get; set; }
        public long Brand_Dodge_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Ford_Location_Vehicles_Count { get; set; }
        public long Brand_Ford_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Freightliner_Location_Vehicles_Count { get; set; }
        public long Brand_Freightliner_Total_Company_Vehicles_Count { get; set; }
        public long Brand_GMC_Location_Vehicles_Count { get; set; }
        public long Brand_GMC_Total_Company_Vehicles_Count { get; set; }
        public long Brand_International_Location_Vehicles_Count { get; set; }
        public long Brand_International_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Nissan_Location_Vehicles_Count { get; set; }
        public long Brand_Nissan_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Other_Domestic_Location_Vehicles_Count { get; set; }
        public long Brand_Other_Domestic_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Other_Import_Location_Vehicles_Count { get; set; }
        public long Brand_Other_Import_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Ram_Location_Vehicles_Count { get; set; }
        public long Brand_Ram_Total_Company_Vehicles_Count { get; set; }
        public long Brand_Toyota_Location_Vehicles_Count { get; set; }
        public long Brand_Toyota_Total_Company_Vehicles_Count { get; set; }
        public long Fuel_Diesel_Location_Vehicles_Count { get; set; }
        public long Fuel_Diesel_Total_Company_Vehicles_Count { get; set; }
        public long Fuel_Electric_Location_Vehicles_Count { get; set; }
        public long Fuel_Electric_Total_Company_Vehicles_Count { get; set; }
        public long Fuel_Flex_Fuel_Location_Vehicles_Count { get; set; }
        public long Fuel_Flex_Fuel_Total_Company_Vehicles_Count { get; set; }
        public long Fuel_Gasoline_Location_Vehicles_Count { get; set; }
        public long Fuel_Gasoline_Total_Company_Vehicles_Count { get; set; }
        public long Fuel_Hybrid_Location_Vehicles_Count { get; set; }
        public long Fuel_Hybrid_Total_Company_Vehicles_Count { get; set; }
        public long Fuel_Natural_Gas_Location_Vehicles_Count { get; set; }
        public long Fuel_Natural_Gas_Total_Company_Vehicles_Count { get; set; }
        public long Ownership_New_Purchase_Location_Vehicle_Count { get; set; }
        public long Ownership_New_Purchase_Total_Company_Vehicle_Count { get; set; }
        public long Ownership_Used_Purchase_Location_Vehicle_Count { get; set; }
        public long Ownership_Used_Purchase_Total_Company_Vehicle_Count { get; set; }
        public long Contacts_at_Location { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public int Industry_Tag_Vehicle_Maint { get; set; }
        public int CountyId { get; set; }
        public string? m_geopoint { get; set; }
        public string? last_source { get; set; }
        public string? Dot_Number { get; set; }
        public string? dot_Mc_Number_Consolidated { get; set; }
        public string? dot_Mc_Number_1 { get; set; }
        public string? dot_Mc_Number_2 { get; set; }
        public string? dot_Mc_Number_3 { get; set; }
        public string? dot_Company_Safer_Link { get; set; }
        public string? dot_Operation_Classification_Consolidated { get; set; }
        public bool dot_Operation_Classification_Auth_For_Hire { get; set; }
        public bool dot_Operation_Classification_Exempt_For_Hire { get; set; }
        public bool dot_Operation_Classification_Private_Property { get; set; }
        public bool dot_Operation_Classification_Private_Passenger_Business { get; set; }
        public bool dot_Operation_Classification_Private_Passenger_Nonbusiness { get; set; }
        public bool dot_Operation_Classification_Migrant { get; set; }
        public bool dot_Operation_Classification_Us_Mail { get; set; }
        public bool dot_Operation_Classification_Federal_Govt { get; set; }
        public bool dot_Operation_Classification_State_Govt { get; set; }
        public bool dot_Operation_Classification_Local_Govt { get; set; }
        public bool dot_Operation_Classification_Indian_Tribe { get; set; }
        public bool dot_Operation_Classification_Other { get; set; }
        public string? dot_Cargo_Carried_Consolidated { get; set; }
        public bool dot_Cargo_Carried_General_Freight { get; set; }
        public bool dot_Cargo_Carried_Household_Goods { get; set; }
        public bool dot_Cargo_Carried_Metal { get; set; }
        public bool dot_Cargo_Carried_Motor_Vehicles { get; set; }
        public bool dot_Cargo_Carried_Driveaway { get; set; }
        public bool dot_Cargo_Carried_Logs { get; set; }
        public bool dot_Cargo_Carried_Building_Materials { get; set; }
        public bool dot_Cargo_Carried_Mobile_Homes { get; set; }
        public bool dot_Cargo_Carried_Machinery { get; set; }
        public bool dot_Cargo_Carried_Fresh_Produce { get; set; }
        public bool dot_Cargo_Carried_Liquids_Gases { get; set; }
        public bool dot_Cargo_Carried_Intermodal_Containers { get; set; }
        public bool dot_Cargo_Carried_Passengers { get; set; }
        public bool dot_Cargo_Carried_Oilfield_Equipment { get; set; }
        public bool dot_Cargo_Carried_Livestock { get; set; }
        public bool dot_Cargo_Carried_Grain { get; set; }
        public bool dot_Cargo_Carried_Coal_Coke { get; set; }
        public bool dot_Cargo_Carried_Meat { get; set; }
        public bool dot_Cargo_Carried_Garbage { get; set; }
        public bool dot_Cargo_Carried_Us_Mail { get; set; }
        public bool dot_Cargo_Carried_Chemicals { get; set; }
        public bool dot_Cargo_Carried_Commodities { get; set; }
        public bool dot_Cargo_Carried_Refrigerated_Food { get; set; }
        public bool dot_Cargo_Carried_Beverages { get; set; }
        public bool dot_Cargo_Carried_Paper_Products { get; set; }
        public bool dot_Cargo_Carried_Utility { get; set; }
        public bool dot_Cargo_Carried_Farm_Supplies { get; set; }
        public bool dot_Cargo_Carried_Construction { get; set; }
        public bool dot_Cargo_Carried_Water_Well { get; set; }
        public bool dot_Cargo_Carried_Other { get; set; }
        public string? dot_Power_Units_Range { get; set; }
        public long dot_Power_Units_Total { get; set; }
        public long dot_Power_Units_Owned { get; set; }
        public long dot_Power_Units_Leased { get; set; }
        public long dot_Tractors_Total { get; set; }
        public long dot_Tractors_Owned { get; set; }
        public string? dot_Tractors_Owned_Percent { get; set; }
        public long dot_Tractors_Leased { get; set; }
        public string? dot_Tractors_Leased_Percent { get; set; }
        public long dot_Trucks_Total { get; set; }
        public long dot_Trucks_Owned { get; set; }
        public string? dot_Trucks_Owned_Percent { get; set; }
        public long dot_Trucks_Leased { get; set; }
        public string? dot_Trucks_Leased_Percent { get; set; }
        public long dot_Trailers_Total { get; set; }
        public long dot_Trailers_Owned { get; set; }
        public string? dot_Trailers_Owned_Percent { get; set; }
        public long dot_Trailers_Leased { get; set; }
        public string? dot_Trailers_Leased_Percent { get; set; }
        public long dot_Drivers_Total { get; set; }
        public string? dot_Drivers_Range { get; set; }
        public long dot_Drivers_CDL { get; set; }
        public long dot_Drivers_Interstate { get; set; }
        public long dot_Drivers_Intrastate { get; set; }
        public string? dot_dba_company_name { get; set; }
        public string? NAICS8_code { get; set; }
        public string? NAICS8_description { get; set; }

    }
}
