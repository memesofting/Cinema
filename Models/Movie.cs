﻿namespace Cinema.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public TimeOnly ShowTime { get; set; }
        public DateOnly ShowDate { get; set; }
        public string Location { get; set; }
    }
}
