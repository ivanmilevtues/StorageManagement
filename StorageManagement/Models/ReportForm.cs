﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class ReportForm
    {
        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
