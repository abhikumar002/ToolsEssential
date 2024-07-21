using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Tools.Interfaces;
using System;
using System.Collections.Generic;

namespace Tools.Services
{
    public class JsonValidationService : IJsonValidationService
    {
        public bool ValidateJson(string jsonString, string schemaString, out List<string> errors)
        {
            errors = new List<string>();

            try
            {
                var schema = JSchema.Parse(schemaString);
                var json = JToken.Parse(jsonString);
                bool isValid = json.IsValid(schema, out IList<string> validationErrors);

                errors.AddRange(validationErrors);
                return isValid;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                return false;
            }
        }
    }
}
