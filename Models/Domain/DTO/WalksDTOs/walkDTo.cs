﻿namespace NZWalks.Api.Models.Domain.DTO.WalksDTOs
{
    public class WalkDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalksImageUrl { get; set; }

        
        public RegionDto Region { get; set; }

        public DifficultyDto Difficulty { get; set; }
    }
}
