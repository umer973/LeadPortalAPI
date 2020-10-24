using LeadPortalAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeadPortalAPI.Attributes
{
    public class APIException : Exception
    {
        public APIException()
        {
            MessageType = ValidationMessageType.Info;
        }
        public ValidationMessageType MessageType { get; set; }

        public APIException(string message)
        {
            MessageType = ValidationMessageType.Info;
        }

        public APIException(ValidationMessageType messageType, string message)
        {
            MessageType = messageType;
        }

    }
}