using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaKings.Core.Models
{
    [Serializable]
    public class BaseModel
    {
        public BaseModel()
        {
            if (this.GetType().Namespace == "System.Data.Entity.DynamicProxies")
                EntityType = this.GetType().BaseType.FullName;
            else EntityType = this.GetType().FullName;
        }

        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public virtual string Name { get; set; }
        [NotMapped]
        public virtual string EntityType { get; set; }
        private DateTime _createDate = DateTime.Now;
        public virtual DateTime CreateDate { get { return _createDate; } }
    }
}
