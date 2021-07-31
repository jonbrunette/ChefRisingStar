using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ChefRisingStar.Models
{
    [DebuggerDisplay("{GetDebuggerDisplay}")]
    public class FoodPrintCategories
    {
        [JsonProperty("ingredient")]
        public string Ingredient { get; set; }

        [JsonProperty("land_usage")]
        public double LandUsage { get; set; }

        [JsonProperty("farming")]
        public double Farming { get; set; }

        [JsonProperty("animal_feed")]
        public double AimalFeed { get; set; }

        [JsonProperty("processing")]
        public double Processing { get; set; }

        [JsonProperty("transport")]
        public double Transport { get; set; }

        [JsonProperty("retail")]
        public double Retail { get; set; }

        [JsonProperty("packaging")]
        public double Packaging { get; set; }

        [JsonProperty("waste")]
        public double Waste { get; set; }

        [JsonProperty("totalCO2")]
        public double TotalCO2 { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("measured_unit")]
        public string Unit { get; set; }

        [JsonProperty("diet_type")]
        public string DietType { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        private string GetDebuggerDisplay()
        {
            return $"{Ingredient} - {Ingredient}";
        }
    }

    [DebuggerDisplay("{GetDebuggerDisplay}")]
    public class AnnualFoodPrint
    {
        [JsonProperty("ingredients")]
        public string Ingredients { get; set; }

        [JsonProperty("totalCO2")]
        public long AnnualCO2 { get; set; }

        [JsonProperty("car_miles")]
        public long CarMiles { get; set; }

        [JsonProperty("water_usage")]
        public long WaterUsage { get; set; }

        [JsonProperty("parking_space")]
        public long ParkingSpace { get; set; }


        private string GetDebuggerDisplay()
        {
            return $"{Ingredients} - {AnnualCO2}";
        }
    }

    [DebuggerDisplay("{GetDebuggerDisplay}")]
    public class FoodPrint
    {
        [JsonProperty("ingredient")]
        public string Ingredient { get; set; }

        [JsonProperty("product_emission_percentage")]
        public double ProductEmission { get; set; }

        [JsonProperty("totalCO2")]
        public double TotalCO2 { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("measured_unit")]
        public string Unit { get; set; }

        [JsonProperty("diet_type")]
        public string DietType { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        private string GetDebuggerDisplay()
        {
            return $"{Ingredient} - {ProductEmission}";
        }
    }
}
