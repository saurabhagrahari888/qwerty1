//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmdaniBadhaoSrabh.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class user_land_by_crope
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_land_by_crope()
        {
            this.crop_advisory_user_response = new HashSet<crop_advisory_user_response>();
        }
    
        public int id { get; set; }
        public string Crop_Name { get; set; }
        public string Irrigation_type { get; set; }
        public string Sowing_date { get; set; }
        public int Land_id { get; set; }
        public System.DateTime active { get; set; }
        public Nullable<int> Crop_id { get; set; }
        public Nullable<int> Variety_id { get; set; }
        public string Variety_Name { get; set; }
        public string Soil { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crop_advisory_user_response> crop_advisory_user_response { get; set; }
        public virtual user_map user_map { get; set; }
    }
}
