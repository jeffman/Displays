using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Displays.Windows;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Converters;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace Displays.Test.Windows
{
    public class Serialization
    {
        private JsonSerializerSettings defaultSettings;

        public Serialization()
        {
            defaultSettings = new JsonSerializerSettings();
            defaultSettings.Converters.Add(new StringEnumConverter());
        }

        [Fact]
        public void PathRoundTrip()
        {
            AssertStructRoundTrip<DisplayConfigPathInfo>(defaultSettings);
        }

        [Fact]
        public void ModeRoundTrip()
        {
            AssertStructRoundTrip<DisplayConfigModeInfo>(defaultSettings);
        }

        private static void AssertStructRoundTrip<T>(JsonSerializerSettings settings) where T : unmanaged
        {
            T value = CreateFilledStruct<T>();
            string json = JsonConvert.SerializeObject(value, settings);
            T deserialized = JsonConvert.DeserializeObject<T>(json);
            AssertStructsAreEqual(value, deserialized);
        }

        private static T CreateFilledStruct<T>() where T : unmanaged
        {
            // We need to pass the struct data through the marshaller because in
            // general we cannot just write arbitrary data to the struct and expect
            // round-trip serialization to pass -- for example, any non-zero integer
            // is true for a bool, but true will always serialize to 1
            int structSize = Marshal.SizeOf<T>();
            IntPtr structBuffer = Marshal.AllocHGlobal(structSize);
            try
            {
                byte currentValue = 1;
                for (int i = 0; i < structSize; i++)
                {
                    Marshal.WriteByte(structBuffer, i, currentValue);
                    currentValue = Math.Max((byte)1, (byte)(currentValue + 1));
                }
                
                return Marshal.PtrToStructure<T>(structBuffer);
            }
            finally
            {
                Marshal.FreeHGlobal(structBuffer);
            }
        }

        private unsafe static void AssertStructsAreEqual<T>(in T expected, in T actual) where T : unmanaged
        {
            fixed (void* expectedPtr = &expected)
            {
                fixed (void* actualPtr = &actual)
                {
                    int structSize = Marshal.SizeOf<T>();
                    byte* expectedBytePtr = (byte*)expectedPtr;
                    byte* actualBytePtr = (byte*)actualPtr;

                    for (int i = 0; i < structSize; i++)
                    {
                        if (*actualBytePtr != *expectedBytePtr)
                        {
                            throw new XunitException($"Structs differ at byte {i}: expected 0x{*expectedBytePtr:X2}, actual 0x{*actualBytePtr:X2}");
                        }
                        actualBytePtr++;
                        expectedBytePtr++;
                    }
                }
            }
        }
    }
}
