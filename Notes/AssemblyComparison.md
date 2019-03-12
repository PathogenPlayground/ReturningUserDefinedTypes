# Default with ImVec2
```
static void TestCallback(ImGuiPlatformIO* platformIo)
{
mov         qword ptr [rsp+8],rcx
push        rbp
push        rdi
sub         rsp,128h
lea         rbp,[rsp+20h]
mov         rdi,rsp
mov         ecx,4Ah
mov         eax,0CCCCCCCCh
rep stos    dword ptr [rdi]
mov         rcx,qword ptr [rsp+148h]
mov         rax,qword ptr [__security_cookie (07FFB9CA6F6E8h)]
xor         rax,rbp
mov         qword ptr [rbp+0F8h],rax
lea         rcx,[__FA1243CE_imgui@cpp (07FFB9CA88024h)]
call        __CheckForDebuggerJustMyCode (07FFB9C8BFAFFh)
    auto v = platformIo->Platform_GetWindowPos((ImGuiViewport*)0xC0FFEEEEull);
mov         edx,0C0FFEEEEh
lea         rcx,[rbp+0E4h]
mov         rax,qword ptr [platformIo]
call        qword ptr [rax+20h]
mov         rax,qword ptr [rax]
mov         qword ptr [v],rax
    PrintTest(v.x, v.y);
movss       xmm1,dword ptr [rbp+0Ch]
movss       xmm0,dword ptr [v]
call        PrintTest (07FFB9C959220h)
}
lea         rcx,[rbp-20h]
lea         rdx,[string L"g.LogEnabled ==\x4000\0\0\0\0"...+0E0h (07FFB9CA13160h)]
call        _RTC_CheckStackVars (07FFB9C8C2A16h)
mov         rcx,qword ptr [rbp+0F8h]
xor         rcx,rbp
call        __security_check_cookie (07FFB9C8C001Dh)
lea         rsp,[rbp+108h]
pop         rdi
pop         rbp
ret
```

# Default with RawVec2
```
static void TestCallback(ImGuiPlatformIO* platformIo)
{
mov         qword ptr [rsp+8],rcx
push        rbp
push        rdi
sub         rsp,128h
lea         rbp,[rsp+20h]
mov         rdi,rsp
mov         ecx,4Ah
mov         eax,0CCCCCCCCh
rep stos    dword ptr [rdi]
mov         rcx,qword ptr [rsp+148h]
lea         rcx,[__FA1243CE_imgui@cpp (07FFB9CA88024h)]
call        __CheckForDebuggerJustMyCode (07FFB9C8BFAFFh)
    auto v = platformIo->Platform_GetWindowPos((ImGuiViewport*)0xC0FFEEEEull);
mov         ecx,0C0FFEEEEh
mov         rax,qword ptr [platformIo]
call        qword ptr [rax+20h]
mov         qword ptr [rbp+0E4h],rax
mov         rax,qword ptr [rbp+0E4h]
mov         qword ptr [v],rax
    PrintTest(v.x, v.y);
movss       xmm1,dword ptr [rbp+0Ch]
movss       xmm0,dword ptr [v]
call        PrintTest (07FFB9C959220h)
}
lea         rcx,[rbp-20h]
lea         rdx,[string L"g.LogEnabled ==\x4000\0\0\0\0"...+0E0h (07FFB9CA13160h)]
call        _RTC_CheckStackVars (07FFB9C8C2A16h)
lea         rsp,[rbp+108h]
pop         rdi
pop         rbp
ret
```
