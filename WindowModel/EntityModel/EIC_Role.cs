//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowModel.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class EIC_Role
    {
        public string ID { get; set; }
        public string SchoolID { get; set; }
        public string ParentID { get; set; }
        public string RoleName { get; set; }
        public string ReMark { get; set; }
        public Nullable<int> DeleteMark { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Sync { get; set; }
    }
}
