using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Mappers
{
    public static class SwimmerMetaDataMapper
    {
        public static GetSwimmerMetaDataDTO MapGetSwimmerMetaDataDTO(this SwimmerMetaData swimmerMetaData)
        {
            var returnSwimmerMetaDataDTO = new GetSwimmerMetaDataDTO
            {
                Id = swimmerMetaData.Id,
                UserOwnerId = swimmerMetaData.UserOwnerId,
            };

            if (swimmerMetaData.MainStroke != null)
            {
                returnSwimmerMetaDataDTO.MainStroke = swimmerMetaData.MainStroke;
            }

            if (swimmerMetaData.MainDistance != null)
            {
                returnSwimmerMetaDataDTO.MainDistance = swimmerMetaData.MainDistance;
            }

            if (swimmerMetaData.GoalTime != null)
            {
                returnSwimmerMetaDataDTO.GoalTime = swimmerMetaData.GoalTime;
            }

            return returnSwimmerMetaDataDTO;
        }
    }
}