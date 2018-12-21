#include "il2cpp-config.h"

#ifndef _MSC_VER
#include <alloca.h>
#define EXPORTAPI
#else
#include <malloc.h>
#define EXPORTAPI __declspec(dllexport) __stdcall
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


#ifndef STRING_T_H
#define STRING_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((&___Empty_5), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // STRING_T_H


//bool Initialize ()
//{
//    printf("=== INITIALIZE ===\n");
//    typedef void (*PlayerPrefs_Save_ftn) ();
//    PlayerPrefs_Save_ftn _il2cpp_icall_func =
//        (PlayerPrefs_Save_ftn)il2cpp::vm::InternalCalls::Resolve("UnityEngine.PlayerPrefs::Save()");
//    //_il2cpp_icall_func();
//    printf("UnityEngine.PlayerPrefs::Save() is set?%d", _il2cpp_icall_func != NULL);
//    return true;
//}
//bool _isInitialized = Initialize();


// System.Boolean UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)
bool PlayerPrefs_TrySetInt(String_t* key, int32_t value)
{
    //printf("PlayerPrefs_TrySetInt\n");
    return true;
}
// System.Boolean UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)
bool PlayerPrefs_TrySetFloat(String_t* key, float value)
{
    //printf("PlayerPrefs_TrySetFloat\n");
    return true;
}
// System.Boolean UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)
bool PlayerPrefs_TrySetSetString(String_t* key, String_t* value)
{
    //printf("PlayerPrefs_TrySetSetString\n");
    return true;
}
// System.Int32 UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)
int32_t PlayerPrefs_GetInt(String_t* key, int32_t defaultValue)
{
    //printf("PlayerPrefs_GetInt\n");
    return defaultValue;
}
// System.Single UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)
float PlayerPrefs_GetFloat(String_t* key, float defaultValue)
{
    //printf("PlayerPrefs_GetFloat\n");
    return defaultValue;
}
// System.String UnityEngine.PlayerPrefs::GetString(System.String,System.String)
String_t* PlayerPrefs_GetString(String_t* key, String_t* defaultValue)
{
    //printf("PlayerPrefs_GetString\n");
    return defaultValue;
}
// System.Boolean UnityEngine.PlayerPrefs::HasKey(System.String)
bool PlayerPrefs_HasKey(String_t* key)
{
    //printf("PlayerPrefs_HasKey\n");
    return false;
}
// System.Void UnityEngine.PlayerPrefs::DeleteKey(System.String)
void PlayerPrefs_DeleteKey(String_t* key)
{
    //printf("PlayerPrefs_DeleteKey\n");
}
// System.Void UnityEngine.PlayerPrefs::DeleteAll()
void PlayerPrefs_DeleteAll()
{
    //printf("PlayerPrefs_DeleteAll\n");
}
// System.Void UnityEngine.PlayerPrefs::Save()
void PlayerPrefs_Save()
{
    //printf("PlayerPrefs_Save\n");
}


extern "C" void EXPORTAPI InstallHooks()
{
    static bool isInstalled;
    if (isInstalled)
        return;
    isInstalled = true;
    //printf("=== InstallHooks() ===\n");
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)",
                                   (Il2CppMethodPointer)PlayerPrefs_TrySetInt);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)",
                                   (Il2CppMethodPointer)PlayerPrefs_TrySetFloat);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)",
                                   (Il2CppMethodPointer)PlayerPrefs_TrySetSetString);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)",
                                   (Il2CppMethodPointer)PlayerPrefs_GetInt);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)",
                                   (Il2CppMethodPointer)PlayerPrefs_GetFloat);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::GetString(System.String,System.String)",
                                   (Il2CppMethodPointer)PlayerPrefs_GetString);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::HasKey(System.String)",
                                   (Il2CppMethodPointer)PlayerPrefs_HasKey);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteKey(System.String)",
                                   (Il2CppMethodPointer)PlayerPrefs_DeleteKey);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteAll()",
                                   (Il2CppMethodPointer)PlayerPrefs_DeleteAll);
    il2cpp::vm::InternalCalls::Add("UnityEngine.PlayerPrefs::Save()",
                                   (Il2CppMethodPointer)PlayerPrefs_Save);
}


extern "C" int EXPORTAPI CountLettersInString(char16_t* str, char16_t* str2)
{
    printf("=== CountLettersInString ===\n");

    int length = 0;
    while (*str++ != L'\0')
        length++;

    while (*str2++ != L'\0')
        length--;

    return length;
}
