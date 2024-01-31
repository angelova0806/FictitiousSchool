using FictitiousSchool.Context;
using FictitiousSchool.Interfaces;
using FictitiousSchool.Models;

namespace FictitiousSchool.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _context;

        public ParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddParticipantsAsync(IEnumerable<Participants> participants)
        {
            await _context.Participants.AddRangeAsync(participants);
        }
       
    }
}
   
