using FictitiousSchool.Interfaces;
using FictitiousSchool.Models;

namespace FictitiousSchool.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IParticipantRepository _participantRepository;

        public ApplicationService(IApplicationRepository applicationRepository,
                                  IParticipantRepository participantRepository)
        {
            _applicationRepository = applicationRepository;
            _participantRepository = participantRepository;
        }

        public async Task<CommonModel.TransactionStatus> GetApplicationsListAsync()
        {
            var status = new CommonModel.TransactionStatus { IsSuccess = true };
            try
            {
                var data = await _applicationRepository.GetAllApplicationsAsync();
                status.data = data;
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;
            }
            return status;
        }

        public async Task<CommonModel.TransactionStatus> SaveApplicationAsync(Application model)
        {
            var status = new CommonModel.TransactionStatus { IsSuccess = true };
            try
            {
                if (model.lstParticipants != null && model.lstParticipants.Any())
                {
                    await _applicationRepository.AddApplicationAsync(model);
                    await _participantRepository.AddParticipantsAsync(model.lstParticipants);

                    if (await _applicationRepository.SaveChangesAsync() > 0)
                    {
                        status.data = model.ApplicationId;
                        status.message = "Saved successfully!";
                    }
                }
                else
                {
                    status.message = "Please add at least one participant";
                    status.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                status.IsSuccess = false;                
            }
            return status;
        }
    }
}
