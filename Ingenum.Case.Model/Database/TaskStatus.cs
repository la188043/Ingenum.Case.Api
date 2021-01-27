namespace Ingenum.Case.Model.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskStatus
    {
        TODO,
        DOING,
        DONE
    }
}
