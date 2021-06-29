using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BargainsForCouplesConsumer.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ERateType
    {
        [EnumMember(Value = "None")]
        None = 0,
        [EnumMember(Value = "PerNight")]
        PerNight = 1,
        [EnumMember(Value = "Stay")]
        Stay = 2
    }
}