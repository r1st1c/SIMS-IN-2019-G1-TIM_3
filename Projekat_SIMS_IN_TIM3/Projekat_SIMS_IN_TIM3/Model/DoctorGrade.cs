﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_SIMS_IN_TIM3.Model
{
    public class DoctorGrade
    {
        public int id { get; set; }
        public int doctorId { get; set; }

        public int knowledgeGrade { get; set; }

        public int helpfulnessGrade { get; set; }

        public int punctualityGrade { get; set; }

        public int pleasantnessGrade { get ; set; } 
    }
}