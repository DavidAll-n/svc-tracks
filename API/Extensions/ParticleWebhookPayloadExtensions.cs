using API.DTO;

namespace API.Extensions
{
    public static class ParticleWebhookPayloadExtensions
    {
        public static PostLocationUpdate ParsePayloadData(this ParticleWebhookPayload payload)
        {
            if (payload.Data == null || string.IsNullOrWhiteSpace(payload.Data))
            {
                throw new InvalidOperationException("Invalid Payload");
            }

            // lat|lng|speed|altitude|angle|timestamp
            var data = payload.Data.Split("|");
            return new PostLocationUpdate()
            {
                Lat = decimal.Parse(data[0]),
                Lng = decimal.Parse(data[1]),
                Speed = decimal.Parse(data[2]),
                Altitude = decimal.Parse(data[3]),
                Angle = decimal.Parse(data[4]),
                Timestamp = DateTime.Parse(data[5]),
            };
        }
    }
}
