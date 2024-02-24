namespace Physio.Domain.Entities
{
    public sealed class SchedulingWithDetailsEntity
    {
        public DateTime Date { get; set; }
        public List<SchedulingEntity> Schedulings { get; set; }
    }
}