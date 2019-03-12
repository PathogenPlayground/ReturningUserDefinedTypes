using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ReturningUserDefinedType
{
    public static unsafe class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Vector2* CdeclCallback(out Vector2 result, int testArgument);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate Vector2* StdcallCallback(out Vector2 result, int testArgument);

        [DllImport("NativeCode", CallingConvention = CallingConvention.Cdecl)]
        private static extern Vector2* ReturnsVec2(out Vector2 result);

        [DllImport("NativeCode", CallingConvention = CallingConvention.Cdecl)]
        private static extern void CdeclCallbackTest(CdeclCallback callback);

        [DllImport("NativeCode", CallingConvention = CallingConvention.StdCall)]
        private static extern void StdcallCallbackTest(StdcallCallback callback);

        private static Vector2* TestCallback(out Vector2 result, int testArgument)
        {
            Console.WriteLine($"TestCallback(0x{testArgument:X})");
            result = new Vector2(1879f, 3226f);
            return (Vector2*)Unsafe.AsPointer(ref result);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
            Vector2 result;
            Vector2* resultP = ReturnsVec2(out result);
            Console.WriteLine($"ReturnsVec2 = {result} ({resultP == &result})");
            CdeclCallbackTest(TestCallback);
            StdcallCallbackTest(TestCallback);
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
