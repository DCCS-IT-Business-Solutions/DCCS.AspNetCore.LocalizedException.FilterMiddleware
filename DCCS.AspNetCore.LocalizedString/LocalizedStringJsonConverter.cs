using DCCS.LocalizedString.NetStandard;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCCS.AspNetCore.LocalizedString
{

    public class LocalizedStringJsonConverter : JsonConverter
    {
        private readonly JsonSerializer _innerSerializer = new JsonSerializer();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ILocalizedString localizedString)
            {
                LocalizedStringContract localizedStringContract = value as LocalizedStringContract;
                if (localizedStringContract == null)
                    localizedStringContract = new LocalizedStringContract(localizedString);

                _innerSerializer.Serialize(writer, localizedStringContract);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return typeof(ILocalizedString).IsAssignableFrom(objectType);
        }
    }
}
