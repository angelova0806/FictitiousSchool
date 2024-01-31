using FictitiousSchool.Models;

namespace FictitiousSchool.Interfaces
{
    public interface IParticipantRepository
    {
        Task AddParticipantsAsync(IEnumerable<Participants> participants);
    }
}
