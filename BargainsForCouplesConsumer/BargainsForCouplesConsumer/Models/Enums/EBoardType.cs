using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BargainsForCouplesConsumer.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EBoardType
    {
        [EnumMember(Value = "None")]
        None = 0,
        [EnumMember(Value = "No Meals")]
        NoMeals = 1,
        [EnumMember(Value = "Half Board")]
        HalfBoard = 2,
        [EnumMember(Value = "Full Board")]
        FullBoard = 3
    }
}