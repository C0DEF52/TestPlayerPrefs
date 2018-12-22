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
#include <locale>
#include <codecvt>
#include <iostream>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


using namespace il2cpp::utils;
using namespace il2cpp::vm;


namespace Fiftytwo
{
    typedef bool (EXPORTAPI *PlayerPrefs_TrySetIntPfn)(Il2CppChar* key, int32_t value);
    typedef bool (EXPORTAPI *PlayerPrefs_TrySetFloatPfn)(Il2CppChar* key, float value);
    typedef bool (EXPORTAPI *PlayerPrefs_TrySetSetStringPfn)(Il2CppChar* key, Il2CppChar* value);
    typedef int32_t (EXPORTAPI *PlayerPrefs_GetIntPfn)(Il2CppChar* key, int32_t defaultValue);
    typedef float (EXPORTAPI *PlayerPrefs_GetFloatPfn)(Il2CppChar* key, float defaultValue);
    typedef Il2CppChar* (EXPORTAPI *PlayerPrefs_GetStringPfn)(Il2CppChar* key, Il2CppChar* defaultValue);
    typedef bool (EXPORTAPI *PlayerPrefs_HasKeyPfn)(Il2CppChar* key);
    typedef void (EXPORTAPI *PlayerPrefs_DeleteKeyPfn)(Il2CppChar* key);
    typedef void (EXPORTAPI *PlayerPrefs_DeleteAllPfn)();
    typedef void (EXPORTAPI *PlayerPrefs_SavePfn)();


    typedef struct PlayerPrefs_Callbacks
    {
        PlayerPrefs_TrySetIntPfn TrySetInt;
        PlayerPrefs_TrySetFloatPfn TrySetFloat;
        PlayerPrefs_TrySetSetStringPfn TrySetSetString;
        PlayerPrefs_GetIntPfn GetInt;
        PlayerPrefs_GetFloatPfn GetFloat;
        PlayerPrefs_GetStringPfn GetString;
        PlayerPrefs_HasKeyPfn HasKey;
        PlayerPrefs_DeleteKeyPfn DeleteKey;
        PlayerPrefs_DeleteAllPfn DeleteAll;
        PlayerPrefs_SavePfn Save;
    } PlayerPrefs_Callbacks;


    PlayerPrefs_Callbacks _playerPrefsCallbacks;


    // System.Boolean UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)
    bool PlayerPrefs_TrySetInt(Il2CppString* key, int32_t value)
    {
        return _playerPrefsCallbacks.TrySetInt(StringUtils::GetChars(key), value);
    }
    
    // System.Boolean UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)
    bool PlayerPrefs_TrySetFloat(Il2CppString* key, float value)
    {
        return _playerPrefsCallbacks.TrySetFloat(StringUtils::GetChars(key), value);
    }
    
    // System.Boolean UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)
    bool PlayerPrefs_TrySetSetString(Il2CppString* key, Il2CppString* value)
    {
        /*Il2CppChar* u16Key = StringUtils::GetChars(key);
        Il2CppChar* u16Value = StringUtils::GetChars(value);
        std::string u8Key = StringUtils::Utf16ToUtf8(u16Key);
        std::string u8Value = StringUtils::Utf16ToUtf8(u16Value);
        printf("%s = %s\n", u8Key.c_str(), u8Value.c_str());*/
        return _playerPrefsCallbacks.TrySetSetString(StringUtils::GetChars(key),
                                                     StringUtils::GetChars(value));
    }
    
    // System.Int32 UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)
    int32_t PlayerPrefs_GetInt(Il2CppString* key, int32_t defaultValue)
    {
        return _playerPrefsCallbacks.GetInt(StringUtils::GetChars(key), defaultValue);
    }
    
    // System.Single UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)
    float PlayerPrefs_GetFloat(Il2CppString* key, float defaultValue)
    {
        return _playerPrefsCallbacks.GetFloat(StringUtils::GetChars(key), defaultValue);
    }
    
    // System.String UnityEngine.PlayerPrefs::GetString(System.String,System.String)
    Il2CppString* PlayerPrefs_GetString(Il2CppString* key, Il2CppString* defaultValue)
    {
        Il2CppChar* value = _playerPrefsCallbacks.GetString(StringUtils::GetChars(key),
                                                            StringUtils::GetChars(defaultValue));
        return String::NewUtf16(value, int32_t(StringUtils::StrLen(value)));
    }

    // System.Boolean UnityEngine.PlayerPrefs::HasKey(System.String)
    bool PlayerPrefs_HasKey(Il2CppString* key)
    {
        return _playerPrefsCallbacks.HasKey(StringUtils::GetChars(key));
    }

    // System.Void UnityEngine.PlayerPrefs::DeleteKey(System.String)
    void PlayerPrefs_DeleteKey(Il2CppString* key)
    {
        _playerPrefsCallbacks.DeleteKey(StringUtils::GetChars(key));
    }

    // System.Void UnityEngine.PlayerPrefs::DeleteAll()
    void PlayerPrefs_DeleteAll()
    {
        _playerPrefsCallbacks.DeleteAll();
    }

    // System.Void UnityEngine.PlayerPrefs::Save()
    void PlayerPrefs_Save()
    {
        _playerPrefsCallbacks.Save();
    }
}


using namespace Fiftytwo;

extern "C" void EXPORTAPI Fiftytwo_PlayerPrefs_InstallHooks(PlayerPrefs_Callbacks callbacks)
{
    static bool isInstalled;
    if (isInstalled)
        return;
    isInstalled = true;

    _playerPrefsCallbacks = callbacks;

    InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_TrySetInt));
    InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_TrySetFloat));
    InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_TrySetSetString));
    InternalCalls::Add("UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_GetInt));
    InternalCalls::Add("UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_GetFloat));
    InternalCalls::Add("UnityEngine.PlayerPrefs::GetString(System.String,System.String)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_GetString));
    InternalCalls::Add("UnityEngine.PlayerPrefs::HasKey(System.String)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_HasKey));
    InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteKey(System.String)",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_DeleteKey));
    InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteAll()",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_DeleteAll));
    InternalCalls::Add("UnityEngine.PlayerPrefs::Save()",
                       reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_Save));
}
