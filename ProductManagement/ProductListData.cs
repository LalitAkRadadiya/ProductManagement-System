//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductManagement
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;
    public partial class ProductListData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Short_Description { get; set; }
        public string Long_Description { get; set; }
        [DisplayName("Upload File")]
        public string Small_image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [DisplayName("Upload File")]
        public string Large_image { get; set; }

        public HttpPostedFileBase Large_ImageFile { get; set; }
    }
}
