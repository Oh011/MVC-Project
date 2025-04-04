﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entites
{
    public class ModelBase
    {


        public int Id { get; set; }


        public DateTime CreatedOn { get; set; }


        public int CreatedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }


        public int LastModifiedBy { get; set; }


        public bool IsDeleted { get; set; }
    }
}
