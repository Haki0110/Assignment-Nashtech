using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace ASPNETAPIAssignment2.Model
{

    // Format lại DateTime lúc Get Thành định dạng dd/MM/yyyy
    public static class JsonFormat
    {
        public static string ToJsonString(this object obj)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented, 
                Converters = new JsonConverter[] { new CustomDateFormatConverter(), new StringEnumConverter() }
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }

    public class CustomDateFormatConverter : IsoDateTimeConverter
    {
        public CustomDateFormatConverter()
        {
            DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
