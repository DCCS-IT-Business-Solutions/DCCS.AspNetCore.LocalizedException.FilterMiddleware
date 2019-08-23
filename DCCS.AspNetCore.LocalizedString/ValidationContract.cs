using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DCCS.AspNetCore.LocalizedString
{
    [Serializable]
    public class ValidationContract
    {
        private ValidationResult[] _fields;        
        public ValidationResult[] Fields {
            get => _fields ?? new ValidationResult[0];
            set => _fields = value;
        }

        private ValidationMessage[] _form;
        public ValidationMessage[] FormMessages
        {
            get => _form ?? new ValidationMessage[0];
            set => _form = value;
        }
    }

    [Serializable]
    public class ValidationResult
    {
        public string FieldName { get; set; }

        private ValidationMessage[] _form;
        public ValidationMessage[] Messages
        {
            get => _form ?? new ValidationMessage[0];
            set => _form = value;
        }
    }

    [Serializable]
    [DataContract]
    public class ValidationMessage
    {
        [DataMember(Name = "type")]
        public ValidationResultType Type { get; set; }


        [DataMember]
        public DCCS.LocalizedString.NetStandard.LocalizedStringContract Message { get; set; }
    }

    public enum ValidationResultType
    {
        Error,
        Warning,
    }
}
