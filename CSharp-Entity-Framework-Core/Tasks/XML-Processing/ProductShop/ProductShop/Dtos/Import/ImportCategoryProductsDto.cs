using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoryProductsDto
    {
        [XmlElement(ElementName = "CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement(ElementName = "ProductId")]
        public int ProductId { get; set; }
    }
}
