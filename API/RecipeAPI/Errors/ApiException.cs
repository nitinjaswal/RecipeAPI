namespace RecipeAPI.Errors;
using System.Text.Json;

public class ApiException
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

