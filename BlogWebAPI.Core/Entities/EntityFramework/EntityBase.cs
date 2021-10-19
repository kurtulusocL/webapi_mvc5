using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebAPI.Core.Entities.EntityFramework
{
    public class EntityBase : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsDeleted { get; set; }

        public void SetConfirm()
        {
            IsConfirmed = true;
        }

        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }

        public void SetDeleted()
        {
            IsDeleted = false;
        }
        public EntityBase()
        {
            SetCreatedDate();
            SetDeleted();
            SetConfirm();
        }
    }
}
