using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlRoot(ElementName = "parts")]
    public class ImportPartsDto
    {
        [XmlElement(ElementName = "partId")]
        public ImportPartsIdDto[] PartsId { get; set; }
    }
}
