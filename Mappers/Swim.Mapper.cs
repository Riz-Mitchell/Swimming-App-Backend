using SwimmingAppBackend.DataTransferObjects;
using SwimmingAppBackend.Models;

namespace SwimmingAppBackend.Mappers
{
    public static class SwimMapper
    {
        public static GetSwimDTO MapGetSwimDTO(this Swim swimModel)
        {
            var returnSwim = new GetSwimDTO
            {
                Id = swimModel.Id,
                Time = swimModel.Time,
                Stroke = swimModel.Stroke,
                Distance = swimModel.Distance,
                Dive = swimModel.Dive,
                SwimmerMetaDataId = swimModel.SwimmerMetaDataId,
            };

            // Optionals
            if (swimModel.StrokeRate != null)
            {
                returnSwim.StrokeRate = swimModel.StrokeRate;
            }

            if (swimModel.Pace != null)
            {
                returnSwim.Pace = swimModel.Pace;
            }

            if (swimModel.PerceivedExertion != null)
            {
                returnSwim.PerceivedExertion = swimModel.PerceivedExertion;
            }

            return returnSwim;
        }

        public static Swim MapCreateSwimDTO(this CreateSwimDTO createSwimDTO, SwimmerMetaData swimmerMetaData)
        {
            var createdSwim = new Swim
            {
                Time = createSwimDTO.Time,
                Stroke = createSwimDTO.Stroke,
                Distance = createSwimDTO.Distance,
                Dive = createSwimDTO.Dive,
                SwimmerMetaDataId = createSwimDTO.SwimmerMetaDataId,
                SwimmerMetaData = swimmerMetaData
            };

            // Optionals
            if (createdSwim.StrokeRate != null)
            {
                createdSwim.StrokeRate = createdSwim.StrokeRate;
            }

            if (createdSwim.Pace != null)
            {
                createdSwim.Pace = createdSwim.Pace;
            }

            if (createdSwim.PerceivedExertion != null)
            {
                createdSwim.PerceivedExertion = createdSwim.PerceivedExertion;
            }

            return createdSwim;
        }
    }
}