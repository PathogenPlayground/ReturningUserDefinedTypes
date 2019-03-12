#include <stdio.h>

#ifdef _MSC_VER
#pragma warning(disable : 4190) // '<Function>' has C-linkage specified, but returns UDT '<Type>' which is incompatible with C
#define ARES_API extern "C" __declspec(dllexport)
#elif defined(__GNUC__)
#define ARES_API extern "C"
#ifdef __x86_64__
#define __cdecl
#define __stdcall
#else
#define __cdecl __attribute__((cdecl))
#define __stdcall __attribute__((stdcall))
#endif
#else
#error Unsupported compiler platform.
#endif

#define IM_ASSERT(x)

struct ImVec2
{
    float     x, y;
    ImVec2() { x = y = 0.0f; }
    ImVec2(float _x, float _y) { x = _x; y = _y; }
    float  operator[] (size_t idx) const { IM_ASSERT(idx <= 1); return (&x)[idx]; }    // We very rarely use this [] operator, the assert overhead is fine.
    float& operator[] (size_t idx) { IM_ASSERT(idx <= 1); return (&x)[idx]; }    // We very rarely use this [] operator, the assert overhead is fine.
#ifdef IM_VEC2_CLASS_EXTRA
    IM_VEC2_CLASS_EXTRA     // Define additional constructors and implicit cast operators in imconfig.h to convert back and forth between your math types and ImVec2.
#endif
};

ARES_API ImVec2 __cdecl ReturnsVec2()
{
    return ImVec2(1879.f, 3226.f);
}

typedef ImVec2 (__cdecl *CdeclCallback)(unsigned int testArgument);
ARES_API void __cdecl CdeclCallbackTest(CdeclCallback callback)
{
    ImVec2 result = callback(0xC0FFEEEE);
    printf("Callback returned %f, %f\n", result.x, result.y);
}

typedef ImVec2(__stdcall *StdcallCallback)(unsigned int testArgument);
ARES_API void __stdcall StdcallCallbackTest(StdcallCallback callback)
{
    ImVec2 result = callback(0xC0FFEEEE);
    printf("Callback returned %f, %f\n", result.x, result.y);
}
