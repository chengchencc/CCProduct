﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubSonic.SqlGeneration.Schema;

namespace BlackMamba.Framework.SubSonic
{
    public abstract class EntityBase
    {
        [SubSonicPrimaryKey]
        public virtual int Id { get; set; }


        private DateTime? _createdDate = DateTime.Now;
        [Display(Name = "创建时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [ScaffoldColumn(false)]
        public virtual DateTime? CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                _createdDate = value;
            }
        }

        [Display(Name = "状态")]
        public EntityStatus Status { get; set; }

        private DateTime? _modifiedDate = DateTime.Now;
        [Display(Name = "更新时间"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [ScaffoldColumn(false)]
        public virtual DateTime? LastModifiedDate
        {
            get
            {
                return _modifiedDate;
            }
            set
            {
                _modifiedDate = value;
            }
        }

        public EntityBase()
        {
            this.Status = EntityStatus.Enabled;
            this.CreatedDate = DateTime.Now;
        }

    }
}
