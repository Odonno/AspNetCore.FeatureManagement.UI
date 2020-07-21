using System.Collections.Generic;

namespace AspNetCore.FeatureManagement.UI.Core.Data
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool? BooleanValue { get; set; }
        public int? IntValue { get; set; }
        public decimal? DecimalValue { get; set; }
        public string StringValue { get; set; }

        public List<IntFeatureChoice> IntFeatureChoices { get; set; }
        public List<DecimalFeatureChoice> DecimalFeatureChoices { get; set; }
        public List<StringFeatureChoice> StringFeatureChoices { get; set; }
    }
}