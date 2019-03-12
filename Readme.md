# ReturningUserDefinedType

This repository contains experiments involving .NET code interoperating with C code which returns so-called "user-defined types".

## Background

For background, see [this comment on the ImGui repo](https://github.com/ocornut/imgui/issues/1879#issuecomment-472219067).

Short version: On x64 Windows, the following code snippet:

```cpp
ImVec2 GetWindowPos(ImGuiViewport* viewport)
{
    printf("GetWindowPos(%d)\n", viewport->ID);
    return ImVec2(1879.f, 3226.f);
}
```

is effectively rewritten to look like this:

```cpp
ImVec2* GetWindowPos(ImVec2* ret, ImGuiViewport* viewport)
{
    printf("GetWindowPos(%d)\n", viewport->ID);
    *ret = ImVec2(1879.f, 3226.f);
    return ret;
}
```

## Findings

* You can write a C# P/Invoke definition or callback in the translated format and it works as expected.
* This also applies to x86 Windows for both `__cdecl` and `__stdcall`. (Not sure if this is officially documented anywhere.)
* This does not apply on x64 Linux, which returns values via register like you'd generally expect. (Tested with WSL and GCC. You can run `LinuxTest.sh` to try it.)
  * It is expected that ReturningUserDefinedType fails since it uses the Windows calling convention. However, ReturningUserDefinedType2 should work.
* Since x86 Linux is not supported by .NET Core, I can't test it. (Plus I don't have an x86 Linux install available.)
  * If someone has an ARM32 or ARM64 Linux setup supported by .NET Core, I'd like to know what this does!
  * Likewise for Mono on x86 or someone who happens to have an experimental CoreCLR build for x86 Linux.

### Expected `LinuxTest.sh` output

If you run the `LinuxTest.sh` script, this is the expected output on x64:

```
pathogen-david@Lovelance:/mnt/c/Development/Playground/ReturningUserDefinedType$ ./LinuxTest.sh
================ ReturningUserDefinedType ================
Hello, world!
ReturnsVec2 = <0, 0> (False)
TestCallback(0x5BF83474)
================ ReturningUserDefinedType2 ================
Hello, world!
ReturnsVec2 = <1879, 3226>
TestCallback(0xC0FFEEEE)
Callback returned 1879.000000, 3226.000000
TestCallback(0xC0FFEEEE)
Callback returned 1879.000000, 3226.000000
Done.
```
