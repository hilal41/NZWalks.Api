namespace NZWalks.Api.Models.Domain.DTO.WalksDTOs
{
    public class WalksDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalksImageUrl { get; set; }


        public RegionDto region { get; set; }

        public DifficultyDto difficulty { get; set; }





















    }
}
