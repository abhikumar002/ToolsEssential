using System.Threading.Tasks;

namespace Tools.Interfaces
{
    public interface IJsonValidationService
    {
        bool ValidateJson(string jsonString, string schemaString, out List<string> errors);
    }
}