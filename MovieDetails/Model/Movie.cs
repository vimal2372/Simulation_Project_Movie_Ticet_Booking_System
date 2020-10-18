﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDetails.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Movie_Name { get; set; }
        public string Movie_Description { get; set; }
        public string DateAndTime { get; set; }
        public string MoviePicture { get; set; }
    }
}
