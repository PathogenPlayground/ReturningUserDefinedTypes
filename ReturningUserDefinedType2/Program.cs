using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ReturningUserDefinedType
{
    public static unsafe class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Vector2 CdeclCallback(int testArgument);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate Vector2 StdcallCallback(int testArgument);

        [DllImport("NativeCode", CallingConvention = CallingConvention.Cdecl)]
        private static extern Vector2 ReturnsVec2();

        [DllImport("NativeCode", CallingConvention = CallingConvention.Cdecl)]
        private static extern void CdeclCallbackTest(CdeclCallback callback);

        [DllImport("NativeCode", CallingConvention = CallingConvention.StdCall)]
        private static extern void StdcallCallbackTest(StdcallCallback callback);

        private static Vector2 TestCallback(int testArgument)
        {
            Console.WriteLine($"TestCallback(0x{testArgument:X})");
            return new Vector2(1879f, 3226f);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
            Vector2 result = ReturnsVec2();
            Console.WriteLine($"ReturnsVec2 = {result}");
            CdeclCallbackTest(TestCallback);
            StdcallCallbackTest(TestCallback);
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
