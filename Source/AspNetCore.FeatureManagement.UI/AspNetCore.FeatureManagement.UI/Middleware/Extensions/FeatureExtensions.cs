﻿using AspNetCore.FeatureManagement.UI.Core.Data;
using AspNetCore.FeatureManagement.UI.Core.Models;
using System.Linq;

namespace AspNetCore.FeatureManagement.UI.Middleware.Extensions
{
    internal static class FeatureExtensions
    {
        internal static IFeature ToOutput(this Feature feature)
        {
            if (feature.ValueType == FeatureValueTypes.Boolean)
            {
                return new BoolFeature
                {
                    Name = feature.Name,
                    Description = feature.Description,
                    Value = feature.Server.BooleanValue // TODO : Client vs. Server feature
                };
            }
            if (feature.ValueType == FeatureValueTypes.Integer)
            {
                bool hasChoices = feature.IntFeatureChoices?.Any() ?? false;

                return new IntFeature
                {
                    Name = feature.Name,
                    Description = feature.Description,
                    Value = feature.Server.IntValue, // TODO : Client vs. Server feature
                    Choices = hasChoices 
                        ? feature.IntFeatureChoices.Select(c => c.Choice).ToList() 
                        : null
                };
            }
            if (feature.ValueType == FeatureValueTypes.Decimal)
            {
                bool hasChoices = feature.DecimalFeatureChoices?.Any() ?? false;

                return new DecimalFeature
                {
                    Name = feature.Name,
                    Description = feature.Description,
                    Value = feature.Server.DecimalValue, // TODO : Client vs. Server feature
                    Choices = hasChoices
                        ? feature.DecimalFeatureChoices.Select(c => c.Choice).ToList()
                        : null
                };
            }

            {
                bool hasChoices = feature.StringFeatureChoices?.Any() ?? false;

                return new StringFeature
                {
                    Name = feature.Name,
                    Description = feature.Description,
                    Value = feature.Server.StringValue, // TODO : Client vs. Server feature
                    Choices = hasChoices
                        ? feature.StringFeatureChoices.Select(c => c.Choice).ToList()
                        : null
                };
            }
        }
    }
}
