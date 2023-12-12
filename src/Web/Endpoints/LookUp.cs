using MacClientSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MacClientSystem.Web.Endpoints;

public class LookUp : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGet(GetBloodType, "bloodTypes");
    }

    public List<KeyValuePair<int, string?>> GetBloodType()
    {
        var bloodTypes = Enum.GetValues(typeof(BloodTypes)).Cast<int>()
            .ToDictionary(value => value, value => Enum.GetName(typeof(BloodTypes), value)).ToList();
            
        return bloodTypes;
    }
}
