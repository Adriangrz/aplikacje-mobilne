﻿namespace GameAm.Database.Entities
{
    public class WebPoint
    {
        public Guid Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Task { get; set; }
        public string Answer { get; set; }
    }
}
