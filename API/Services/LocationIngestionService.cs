using API.DTO;
using API.Extensions;
using API.Interfaces;
using Domain.Entities.v1;
using NetTopologySuite.Geometries;

namespace API.Services
{
    public class LocationIngestionService : ILocationIngestionService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IDataPointRepository _dataPointRepository;

        public LocationIngestionService(IAssetRepository assetRepository, IDataPointRepository dataPointRepository)
        {
            _assetRepository = assetRepository;
            _dataPointRepository = dataPointRepository;
        }

        public async Task IngestLocationUpdate(ParticleWebhookPayload locationUpdate)
        {
            var data = locationUpdate.ParsePayloadData();
            
            // Get Asset
            var asset = await _assetRepository.GetAssetByParticleDeviceId(locationUpdate.CoreId);

            // Create Update
            var dataPoint = new DataPoint()
            {
                Location = new Point(new Coordinate((double)data.Lat, (double)data.Lng)),
                Speed = data.Speed,
                Altitude = data.Altitude,
                Angle = data.Angle,
                ReadDateTime = DateTime.SpecifyKind(data.Timestamp, DateTimeKind.Utc),
                Asset = asset
            };

            // Send WS update

            // Save to Db
            await _dataPointRepository.AddDataPoint(dataPoint);
        }
    }
}
