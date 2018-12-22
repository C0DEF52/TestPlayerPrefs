#include "il2cpp-config.h"

#ifndef _MSC_VER
#include <alloca.h>
#define DEFAULT_CALL
#define EXPORT_CALL
#else
#include <malloc.h>
#define DEFAULT_CALL __stdcall
#define EXPORT_CALL __declspec(dllexport) DEFAULT_CALL
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
    typedef bool(*DEFAULT_CALL PlayerPrefs_TrySetIntPfn)(Il2CppChar* key, int32_t value);
    typedef bool(*DEFAULT_CALL PlayerPrefs_TrySetFloatPfn)(Il2CppChar* key, float value);
    typedef bool(*DEFAULT_CALL PlayerPrefs_TrySetSetStringPfn)(Il2CppChar* key, Il2CppChar* value);
    typedef int32_t(*DEFAULT_CALL PlayerPrefs_GetIntPfn)(Il2CppChar* key, int32_t defaultValue);
    typedef float(*DEFAULT_CALL PlayerPrefs_GetFloatPfn)(Il2CppChar* key, float defaultValue);
    typedef Il2CppChar* (*DEFAULT_CALL PlayerPrefs_GetStringPfn)(Il2CppChar* key, Il2CppChar* defaultValue);
    typedef bool(*DEFAULT_CALL PlayerPrefs_HasKeyPfn)(Il2CppChar* key);
    typedef void(*DEFAULT_CALL PlayerPrefs_DeleteKeyPfn)(Il2CppChar* key);
    typedef void(*DEFAULT_CALL PlayerPrefs_DeleteAllPfn)();
    typedef void(*DEFAULT_CALL PlayerPrefs_SavePfn)();


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


    typedef bool(*PlayerPrefs_TrySetIntInternalPfn)(Il2CppString* key, int32_t value);
    typedef bool(*PlayerPrefs_TrySetFloatInternalPfn)(Il2CppString* key, float value);
    typedef bool(*PlayerPrefs_TrySetSetStringInternalPfn)(Il2CppString* key, Il2CppString* value);
    typedef int32_t(*PlayerPrefs_GetIntInternalPfn)(Il2CppString* key, int32_t defaultValue);
    typedef float(*PlayerPrefs_GetFloatInternalPfn)(Il2CppString* key, float defaultValue);
    typedef Il2CppString* (*PlayerPrefs_GetStringInternalPfn)(Il2CppString* key, Il2CppString* defaultValue);
    typedef bool(*PlayerPrefs_HasKeyInternalPfn)(Il2CppString* key);
    typedef void(*PlayerPrefs_DeleteKeyInternalPfn)(Il2CppString* key);
    typedef void(*PlayerPrefs_DeleteAllInternalPfn)();
    typedef void(*PlayerPrefs_SaveInternalPfn)();

    PlayerPrefs_TrySetIntInternalPfn PlayerPrefs_TrySetIntInternal;
    PlayerPrefs_TrySetFloatInternalPfn PlayerPrefs_TrySetFloatInternal;
    PlayerPrefs_TrySetSetStringInternalPfn PlayerPrefs_TrySetSetStringInternal;
    PlayerPrefs_GetIntInternalPfn PlayerPrefs_GetIntInternal;
    PlayerPrefs_GetFloatInternalPfn PlayerPrefs_GetFloatInternal;
    PlayerPrefs_GetStringInternalPfn PlayerPrefs_GetStringInternal;
    PlayerPrefs_HasKeyInternalPfn PlayerPrefs_HasKeyInternal;
    PlayerPrefs_DeleteKeyInternalPfn PlayerPrefs_DeleteKeyInternal;
    PlayerPrefs_DeleteAllInternalPfn PlayerPrefs_DeleteAllInternal;
    PlayerPrefs_SaveInternalPfn PlayerPrefs_SaveInternal;

    // System.Boolean UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)
    bool PlayerPrefs_TrySetInt(Il2CppString* key, int32_t value)
    {
        if (_playerPrefsCallbacks.TrySetInt == nullptr)
            return PlayerPrefs_TrySetIntInternal(key, value);

        return _playerPrefsCallbacks.TrySetInt(StringUtils::GetChars(key), value);
    }

    // System.Boolean UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)
    bool PlayerPrefs_TrySetFloat(Il2CppString* key, float value)
    {
        if (_playerPrefsCallbacks.TrySetFloat == nullptr)
            return PlayerPrefs_TrySetFloatInternal(key, value);

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
        if (_playerPrefsCallbacks.TrySetSetString == nullptr)
            return PlayerPrefs_TrySetSetStringInternal(key, value);

        return _playerPrefsCallbacks.TrySetSetString(StringUtils::GetChars(key),
            StringUtils::GetChars(value));
    }

    // System.Int32 UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)
    int32_t PlayerPrefs_GetInt(Il2CppString* key, int32_t defaultValue)
    {
        if (_playerPrefsCallbacks.GetInt == nullptr)
            return PlayerPrefs_GetIntInternal(key, defaultValue);

        return _playerPrefsCallbacks.GetInt(StringUtils::GetChars(key), defaultValue);
    }

    // System.Single UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)
    float PlayerPrefs_GetFloat(Il2CppString* key, float defaultValue)
    {
        if (_playerPrefsCallbacks.GetFloat == nullptr)
            return PlayerPrefs_GetFloatInternal(key, defaultValue);

        return _playerPrefsCallbacks.GetFloat(StringUtils::GetChars(key), defaultValue);
    }

    // System.String UnityEngine.PlayerPrefs::GetString(System.String,System.String)
    Il2CppString* PlayerPrefs_GetString(Il2CppString* key, Il2CppString* defaultValue)
    {
        if (_playerPrefsCallbacks.GetString == nullptr)
            return PlayerPrefs_GetStringInternal(key, defaultValue);;

        Il2CppChar* value = _playerPrefsCallbacks.GetString(StringUtils::GetChars(key),
            StringUtils::GetChars(defaultValue));
        return String::NewUtf16(value, int32_t(StringUtils::StrLen(value)));
    }

    // System.Boolean UnityEngine.PlayerPrefs::HasKey(System.String)
    bool PlayerPrefs_HasKey(Il2CppString* key)
    {
        if (_playerPrefsCallbacks.HasKey == nullptr)
            return PlayerPrefs_HasKeyInternal(key);

        return _playerPrefsCallbacks.HasKey(StringUtils::GetChars(key));
    }

    // System.Void UnityEngine.PlayerPrefs::DeleteKey(System.String)
    void PlayerPrefs_DeleteKey(Il2CppString* key)
    {
        if (_playerPrefsCallbacks.DeleteKey == nullptr)
        {
            PlayerPrefs_DeleteKeyInternal(key);
            return;
        }

        _playerPrefsCallbacks.DeleteKey(StringUtils::GetChars(key));
    }

    // System.Void UnityEngine.PlayerPrefs::DeleteAll()
    void PlayerPrefs_DeleteAll()
    {
        if (_playerPrefsCallbacks.DeleteAll == nullptr)
        {
            PlayerPrefs_DeleteAllInternal();
            return;
        }

        _playerPrefsCallbacks.DeleteAll();
    }

    // System.Void UnityEngine.PlayerPrefs::Save()
    void PlayerPrefs_Save()
    {
        if (_playerPrefsCallbacks.Save == nullptr)
        {
            PlayerPrefs_SaveInternal();
            return;
        }

        _playerPrefsCallbacks.Save();
    }

    void OnRuntimeInitialize()
    {
        PlayerPrefs_TrySetIntInternal = reinterpret_cast<PlayerPrefs_TrySetIntInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_TrySetInt));

        PlayerPrefs_TrySetFloatInternal = reinterpret_cast<PlayerPrefs_TrySetFloatInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_TrySetFloat));

        PlayerPrefs_TrySetSetStringInternal = reinterpret_cast<PlayerPrefs_TrySetSetStringInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_TrySetSetString));

        PlayerPrefs_GetIntInternal = reinterpret_cast<PlayerPrefs_GetIntInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_GetInt));

        PlayerPrefs_GetFloatInternal = reinterpret_cast<PlayerPrefs_GetFloatInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_GetFloat));

        PlayerPrefs_GetStringInternal = reinterpret_cast<PlayerPrefs_GetStringInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::GetString(System.String,System.String)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::GetString(System.String,System.String)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_GetString));

        PlayerPrefs_HasKeyInternal = reinterpret_cast<PlayerPrefs_HasKeyInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::HasKey(System.String)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::HasKey(System.String)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_HasKey));

        PlayerPrefs_DeleteKeyInternal = reinterpret_cast<PlayerPrefs_DeleteKeyInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::DeleteKey(System.String)"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteKey(System.String)",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_DeleteKey));

        PlayerPrefs_DeleteAllInternal = reinterpret_cast<PlayerPrefs_DeleteAllInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::DeleteAll()"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteAll()",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_DeleteAll));

        PlayerPrefs_SaveInternal = reinterpret_cast<PlayerPrefs_SaveInternalPfn>(
            il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::Save()"));
        InternalCalls::Add("UnityEngine.PlayerPrefs::Save()",
            reinterpret_cast<Il2CppMethodPointer>(PlayerPrefs_Save));

    }

    void OnRuntimeCleanup()
    {
    }

    RegisterRuntimeInitializeAndCleanup _runtimeInitializeAndCleanup(OnRuntimeInitialize, OnRuntimeCleanup);
}


using namespace Fiftytwo;

extern "C" void EXPORT_CALL Fiftytwo_PlayerPrefs_SetCallbacks(PlayerPrefs_Callbacks callbacks)
{
    _playerPrefsCallbacks = callbacks;
}
