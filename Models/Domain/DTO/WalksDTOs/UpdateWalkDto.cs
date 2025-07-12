using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.Domain.DTO.WalksDTOs
{
    public class UpdateWalkDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public required string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Length in KM is required.")]
        [Range(0.1, 50, ErrorMessage = "Length must be between 0.1 and 50 KM.")]
        public double LengthInKm { get; set; }

        //[Url(ErrorMessage = "WalksImageUrl must be a valid URL.")]
        public string? WalksImageUrl { get; set; }

        [Required(ErrorMessage = "RegionId is required.")]
        public Guid RegionId { get; set; }

        [Required(ErrorMessage = "DifficultyId is required.")]
        public Guid DifficultyId { get; set; }
    }
}
