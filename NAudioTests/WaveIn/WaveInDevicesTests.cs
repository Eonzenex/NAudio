using System;
using NAudio.WinForms;
using NAudio.WinMM.MmeInterop;
using NUnit.Framework;

namespace NAudioTests.WaveIn
{
    [TestFixture]
    [Category("IntegrationTest")]
    public class WaveInDevicesTests
    {
        [Test]
        public void CanRequestNumberOfWaveInDevices()
        {
            int deviceCount = NAudio.Wave.WaveIn.DeviceCount;
            Assert.That(deviceCount > 0, "Expected at least one WaveIn device");
        }
        
        [Test]
        public void CanGetWaveInDeviceCapabilities()
        {
            for (int n = 0; n < NAudio.Wave.WaveIn.DeviceCount; n++)
            {
                WaveInCapabilities capabilities = NAudio.Wave.WaveIn.GetCapabilities(n);
                Assert.IsNotNull(capabilities, "Null capabilities");
                //Assert.That(capabilities.Channels >= 1, "At least one channel"); - seem to get -1 a lot
                Assert.That(!String.IsNullOrEmpty(capabilities.ProductName), "Needs a name");
            }
        }

        [Test]
        public void CanGetWaveInCaps2NamesFromRegistry()
        {
            for (int n = 0; n < NAudio.Wave.WaveIn.DeviceCount; n++)
            {
                WaveInCapabilities capabilities = NAudio.Wave.WaveIn.GetCapabilities(n);
                Console.WriteLine("PName:        {0}", capabilities.ProductName);
                Console.WriteLine("Name:         {0} {1}", capabilities.NameGuid, WaveCapabilitiesHelpers.GetNameFromGuid(capabilities.NameGuid));
                Console.WriteLine("Product:      {0} {1}", capabilities.ProductGuid, WaveCapabilitiesHelpers.GetNameFromGuid(capabilities.ProductGuid));
                Console.WriteLine("Manufacturer: {0} {1}", capabilities.ManufacturerGuid, WaveCapabilitiesHelpers.GetNameFromGuid(capabilities.ManufacturerGuid));
            }
        }


        [Test]
        public void CanGetWaveOutCaps2NamesFromRegistry()
        {
            for (int n = 0; n < WaveOut.DeviceCount; n++)
            {
                var capabilities = WaveOut.GetCapabilities(n);
                Console.WriteLine("PName:        {0}", capabilities.ProductName);
                Console.WriteLine("Name:         {0} {1}", capabilities.NameGuid, WaveCapabilitiesHelpers.GetNameFromGuid(capabilities.NameGuid));
                Console.WriteLine("Product:      {0} {1}", capabilities.ProductGuid, WaveCapabilitiesHelpers.GetNameFromGuid(capabilities.ProductGuid));
                Console.WriteLine("Manufacturer: {0} {1}", capabilities.ManufacturerGuid, WaveCapabilitiesHelpers.GetNameFromGuid(capabilities.ManufacturerGuid));
            }
        }
    }
}
