#!/bin/sh
# I don't have a 32-bit Linux machine to test on, so this only tests x64.
rm NativeCode.so 2>/dev/null
gcc -Wpedantic NativeCode/Source.cpp -fPIC -shared -o NativeCode.so
export LD_LIBRARY_PATH=$LD_LIBRARY_PATH:./
echo ================ ReturningUserDefinedType ================
dotnet run --project ReturningUserDefinedType/ReturningUserDefinedType.csproj
echo ================ ReturningUserDefinedType2 ================
dotnet run --project ReturningUserDefinedType2/ReturningUserDefinedType2.csproj
