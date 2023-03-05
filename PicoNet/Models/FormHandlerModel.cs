using System.Text.Json.Serialization;

namespace FormAfzarHandler.Models {
#nullable disable


    public class FormAfzarHandler {
        public Form form { get; set; }
    }

    public class Form {
        public int id { get; set; }
        public int formId { get; set; }
        public string formattedId { get; set; }
        public string creatorId { get; set; }
        public string creatorName { get; set; }
        public string createDate { get; set; }
        public object editorId { get; set; }
        public string editorName { get; set; }
        public string editDate { get; set; }
        public int custCode { get; set; }
        public string custName { get; set; }
        public string urlReferrer { get; set; }
        public string browser { get; set; }
        public string ip { get; set; }
        public int paymentStatus { get; set; }
        public string paymentLink { get; set; }
        public string coordinate { get; set; }

        
        [JsonPropertyName("params")]
        public Param[] _params { get; set; }
        public string[] groups { get; set; }
        public int maxGroupNumber { get; set; }
        public bool allowEdit { get; set; }
        public bool allowPublicEdit { get; set; }
        public bool allowDelete { get; set; }
    }

    public class Param {
        public int id { get; set; }
        public int fieldId { get; set; }
        public string fieldName { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public float number { get; set; }
        public string group { get; set; }
        public int action { get; set; }
    }


}

