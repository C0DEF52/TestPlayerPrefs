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
    class PlayerPrefsHooks
    {
    public:
        typedef bool(*DEFAULT_CALL TrySetIntPfn)(Il2CppChar* key, int32_t value);
        typedef bool(*DEFAULT_CALL TrySetFloatPfn)(Il2CppChar* key, float value);
        typedef bool(*DEFAULT_CALL TrySetSetStringPfn)(Il2CppChar* key, Il2CppChar* value);
        typedef int32_t(*DEFAULT_CALL GetIntPfn)(Il2CppChar* key, int32_t defaultValue);
        typedef float(*DEFAULT_CALL GetFloatPfn)(Il2CppChar* key, float defaultValue);
        typedef Il2CppChar* (*DEFAULT_CALL GetStringPfn)(Il2CppChar* key, Il2CppChar* defaultValue);
        typedef bool(*DEFAULT_CALL HasKeyPfn)(Il2CppChar* key);
        typedef void(*DEFAULT_CALL DeleteKeyPfn)(Il2CppChar* key);
        typedef void(*DEFAULT_CALL DeleteAllPfn)();
        typedef void(*DEFAULT_CALL SavePfn)();

        typedef struct Callbacks
        {
            TrySetIntPfn TrySetInt;
            TrySetFloatPfn TrySetFloat;
            TrySetSetStringPfn TrySetSetString;
            GetIntPfn GetInt;
            GetFloatPfn GetFloat;
            GetStringPfn GetString;
            HasKeyPfn HasKey;
            DeleteKeyPfn DeleteKey;
            DeleteAllPfn DeleteAll;
            SavePfn Save;
        } Callbacks;


        static void SetCallbacks(Callbacks callbacks)
        {
            _callbacks = callbacks;
        }


    private:
        typedef bool(*TrySetIntInternalPfn)(Il2CppString* key, int32_t value);
        typedef bool(*TrySetFloatInternalPfn)(Il2CppString* key, float value);
        typedef bool(*TrySetSetStringInternalPfn)(Il2CppString* key, Il2CppString* value);
        typedef int32_t(*GetIntInternalPfn)(Il2CppString* key, int32_t defaultValue);
        typedef float(*GetFloatInternalPfn)(Il2CppString* key, float defaultValue);
        typedef Il2CppString* (*GetStringInternalPfn)(Il2CppString* key, Il2CppString* defaultValue);
        typedef bool(*HasKeyInternalPfn)(Il2CppString* key);
        typedef void(*DeleteKeyInternalPfn)(Il2CppString* key);
        typedef void(*DeleteAllInternalPfn)();
        typedef void(*SaveInternalPfn)();


        static TrySetIntInternalPfn TrySetIntInternal;
        static TrySetFloatInternalPfn TrySetFloatInternal;
        static TrySetSetStringInternalPfn TrySetSetStringInternal;
        static GetIntInternalPfn GetIntInternal;
        static GetFloatInternalPfn GetFloatInternal;
        static GetStringInternalPfn GetStringInternal;
        static HasKeyInternalPfn HasKeyInternal;
        static DeleteKeyInternalPfn DeleteKeyInternal;
        static DeleteAllInternalPfn DeleteAllInternal;
        static SaveInternalPfn SaveInternal;

        static Callbacks _callbacks;

        static RegisterRuntimeInitializeAndCleanup _runtimeInitializeAndCleanup;


        // System.Boolean UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)
        static bool TrySetInt(Il2CppString* key, int32_t value)
        {
            if (_callbacks.TrySetInt == nullptr)
                return TrySetIntInternal(key, value);

            return _callbacks.TrySetInt(StringUtils::GetChars(key), value);
        }

        // System.Boolean UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)
        static bool TrySetFloat(Il2CppString* key, float value)
        {
            if (_callbacks.TrySetFloat == nullptr)
                return TrySetFloatInternal(key, value);

            return _callbacks.TrySetFloat(StringUtils::GetChars(key), value);
        }

        // System.Boolean UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)
        static bool TrySetSetString(Il2CppString* key, Il2CppString* value)
        {
            /*Il2CppChar* u16Key = StringUtils::GetChars(key);
            Il2CppChar* u16Value = StringUtils::GetChars(value);
            std::string u8Key = StringUtils::Utf16ToUtf8(u16Key);
            std::string u8Value = StringUtils::Utf16ToUtf8(u16Value);
            printf("%s = %s\n", u8Key.c_str(), u8Value.c_str());*/
            if (_callbacks.TrySetSetString == nullptr)
                return TrySetSetStringInternal(key, value);

            return _callbacks.TrySetSetString(StringUtils::GetChars(key),
                StringUtils::GetChars(value));
        }

        // System.Int32 UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)
        static int32_t GetInt(Il2CppString* key, int32_t defaultValue)
        {
            if (_callbacks.GetInt == nullptr)
                return GetIntInternal(key, defaultValue);

            return _callbacks.GetInt(StringUtils::GetChars(key), defaultValue);
        }

        // System.Single UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)
        static float GetFloat(Il2CppString* key, float defaultValue)
        {
            if (_callbacks.GetFloat == nullptr)
                return GetFloatInternal(key, defaultValue);

            return _callbacks.GetFloat(StringUtils::GetChars(key), defaultValue);
        }

        // System.String UnityEngine.PlayerPrefs::GetString(System.String,System.String)
        static Il2CppString* GetString(Il2CppString* key, Il2CppString* defaultValue)
        {
            if (_callbacks.GetString == nullptr)
                return GetStringInternal(key, defaultValue);;

            Il2CppChar* value = _callbacks.GetString(StringUtils::GetChars(key),
                StringUtils::GetChars(defaultValue));
            return String::NewUtf16(value, int32_t(StringUtils::StrLen(value)));
        }

        // System.Boolean UnityEngine.PlayerPrefs::HasKey(System.String)
        static bool HasKey(Il2CppString* key)
        {
            if (_callbacks.HasKey == nullptr)
                return HasKeyInternal(key);

            return _callbacks.HasKey(StringUtils::GetChars(key));
        }

        // System.Void UnityEngine.PlayerPrefs::DeleteKey(System.String)
        static void DeleteKey(Il2CppString* key)
        {
            if (_callbacks.DeleteKey == nullptr)
            {
                DeleteKeyInternal(key);
                return;
            }

            _callbacks.DeleteKey(StringUtils::GetChars(key));
        }

        // System.Void UnityEngine.PlayerPrefs::DeleteAll()
        static void DeleteAll()
        {
            if (_callbacks.DeleteAll == nullptr)
            {
                DeleteAllInternal();
                return;
            }

            _callbacks.DeleteAll();
        }

        // System.Void UnityEngine.PlayerPrefs::Save()
        static void Save()
        {
            if (_callbacks.Save == nullptr)
            {
                SaveInternal();
                return;
            }

            _callbacks.Save();
        }

        static void OnRuntimeInitialize()
        {
            TrySetIntInternal = reinterpret_cast<TrySetIntInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)",
                reinterpret_cast<Il2CppMethodPointer>(TrySetInt));

            TrySetFloatInternal = reinterpret_cast<TrySetFloatInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)",
                reinterpret_cast<Il2CppMethodPointer>(TrySetFloat));

            TrySetSetStringInternal = reinterpret_cast<TrySetSetStringInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)",
                reinterpret_cast<Il2CppMethodPointer>(TrySetSetString));

            GetIntInternal = reinterpret_cast<GetIntInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)",
                reinterpret_cast<Il2CppMethodPointer>(GetInt));

            GetFloatInternal = reinterpret_cast<GetFloatInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)",
                reinterpret_cast<Il2CppMethodPointer>(GetFloat));

            GetStringInternal = reinterpret_cast<GetStringInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::GetString(System.String,System.String)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::GetString(System.String,System.String)",
                reinterpret_cast<Il2CppMethodPointer>(GetString));

            HasKeyInternal = reinterpret_cast<HasKeyInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::HasKey(System.String)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::HasKey(System.String)",
                reinterpret_cast<Il2CppMethodPointer>(HasKey));

            DeleteKeyInternal = reinterpret_cast<DeleteKeyInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::DeleteKey(System.String)"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteKey(System.String)",
                reinterpret_cast<Il2CppMethodPointer>(DeleteKey));

            DeleteAllInternal = reinterpret_cast<DeleteAllInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::DeleteAll()"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::DeleteAll()",
                reinterpret_cast<Il2CppMethodPointer>(DeleteAll));

            SaveInternal = reinterpret_cast<SaveInternalPfn>(
                il2cpp_codegen_resolve_icall("UnityEngine.PlayerPrefs::Save()"));
            InternalCalls::Add("UnityEngine.PlayerPrefs::Save()",
                reinterpret_cast<Il2CppMethodPointer>(Save));

        }

        static void OnRuntimeCleanup()
        {
        }
    };


    PlayerPrefsHooks::TrySetIntInternalPfn PlayerPrefsHooks::TrySetIntInternal;
    PlayerPrefsHooks::TrySetFloatInternalPfn PlayerPrefsHooks::TrySetFloatInternal;
    PlayerPrefsHooks::TrySetSetStringInternalPfn PlayerPrefsHooks::TrySetSetStringInternal;
    PlayerPrefsHooks::GetIntInternalPfn PlayerPrefsHooks::GetIntInternal;
    PlayerPrefsHooks::GetFloatInternalPfn PlayerPrefsHooks::GetFloatInternal;
    PlayerPrefsHooks::GetStringInternalPfn PlayerPrefsHooks::GetStringInternal;
    PlayerPrefsHooks::HasKeyInternalPfn PlayerPrefsHooks::HasKeyInternal;
    PlayerPrefsHooks::DeleteKeyInternalPfn PlayerPrefsHooks::DeleteKeyInternal;
    PlayerPrefsHooks::DeleteAllInternalPfn PlayerPrefsHooks::DeleteAllInternal;
    PlayerPrefsHooks::SaveInternalPfn PlayerPrefsHooks::SaveInternal;

    PlayerPrefsHooks::Callbacks PlayerPrefsHooks::_callbacks;

    RegisterRuntimeInitializeAndCleanup
        PlayerPrefsHooks::_runtimeInitializeAndCleanup(OnRuntimeInitialize, OnRuntimeCleanup);
}


extern "C" void EXPORT_CALL Fiftytwo_PlayerPrefsHooks_SetCallbacks(Fiftytwo::PlayerPrefsHooks::Callbacks callbacks)
{
    Fiftytwo::PlayerPrefsHooks::SetCallbacks(callbacks);
}
