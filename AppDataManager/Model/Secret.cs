﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDataManager.Model
{
    public class Secret
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }
        public string Сomment { get; set; }
        public int UserId { get; set; }
    }
}