﻿namespace TeamSearch.Models
{
    public class UserTeam
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int TeamId { get; set; }
        public Team team { get; set; }
    }
}