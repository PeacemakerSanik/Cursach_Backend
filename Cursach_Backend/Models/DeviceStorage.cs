using System.Collections.Concurrent;

namespace Cursach_Backend.Models
{
    public static class DeviceStorage
    {
        private static ConcurrentBag<IMSIModel> _devices = new ConcurrentBag<IMSIModel>();
        public static DateTime LastChanged { get; private set; }

        // Добавить устройство
        public static void AddDevice(IMSIModel device)
        {
            _devices.Add(device);
            LastChanged = DateTime.Now;
        }

        // Получить все устройства
        public static List<IMSIModel> GetAllDevices()
        {
            return _devices.ToList();
        }

        public static bool Contains(IMSIModel device) 
        {
            return _devices.FirstOrDefault(x => x.IMSI == device.IMSI && x.Ki == device.Ki) != null;
        }
    }
}
