using RTIMULibCS;
using System.Device.I2c;
using System.Device.I2c.Drivers;
using System.Runtime.InteropServices;

namespace RPi.SenseHat.Demo.Core
{
    public class CoreDeviceFactory : I2CDeviceFactory
    {
        public static void Init()
        {
            Init(new CoreDeviceFactory());
        }

        public override II2C Create(byte deviceAddress)
        {
            I2cDevice device = CreateI2CDevice(new I2cConnectionSettings(1, deviceAddress));
            return new UwpI2C(device);
        }

        private static I2cDevice CreateI2CDevice(I2cConnectionSettings settings)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new Windows10I2cDevice(settings);
            }

            return new UnixI2cDevice(settings);
        }

        private class UwpI2C : II2C
        {
            private readonly I2cDevice _i2CDevice;

            public UwpI2C(I2cDevice i2CDevice)
            {
                _i2CDevice = i2CDevice;
            }

            public byte[] Read(int length)
            {
                var buffer = new byte[length];
                _i2CDevice.Read(buffer);
                return buffer;
            }

            public void Write(byte[] data)
            {
                _i2CDevice.Write(data);
            }
        }
    }
}
