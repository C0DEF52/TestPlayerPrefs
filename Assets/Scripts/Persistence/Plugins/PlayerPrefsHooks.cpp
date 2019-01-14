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
        typedef bool(*DEFAULT_CALL TrySetStringPfn)(Il2CppChar* key, Il2CppChar* value);
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
            TrySetStringPfn TrySetString;
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
        typedef bool(*TrySetStringInternalPfn)(Il2CppString* key, Il2CppString* value);
        typedef int32_t(*GetIntInternalPfn)(Il2CppString* key, int32_t defaultValue);
        typedef float(*GetFloatInternalPfn)(Il2CppString* key, float defaultValue);
        typedef Il2CppString* (*GetStringInternalPfn)(Il2CppString* key, Il2CppString* defaultValue);
        typedef bool(*HasKeyInternalPfn)(Il2CppString* key);
        typedef void(*DeleteKeyInternalPfn)(Il2CppString* key);
        typedef void(*DeleteAllInternalPfn)();
        typedef void(*SaveInternalPfn)();

        typedef struct InternalCallbacks
        {
            TrySetIntInternalPfn TrySetIntInternal;
            TrySetFloatInternalPfn TrySetFloatInternal;
            TrySetStringInternalPfn TrySetStringInternal;
            GetIntInternalPfn GetIntInternal;
            GetFloatInternalPfn GetFloatInternal;
            GetStringInternalPfn GetStringInternal;
            HasKeyInternalPfn HasKeyInternal;
            DeleteKeyInternalPfn DeleteKeyInternal;
            DeleteAllInternalPfn DeleteAllInternal;
            SaveInternalPfn SaveInternal;
        } InternalCallbacks;

        typedef struct ManagedNames
        {
            static constexpr char TrySetInt[] = "UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)";
            static constexpr char TrySetFloat[] = "UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)";
            static constexpr char TrySetString[] = "UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)";
            static constexpr char GetInt[] = "UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)";
            static constexpr char GetFloat[] = "UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)";
            static constexpr char GetString[] = "UnityEngine.PlayerPrefs::GetString(System.String,System.String)";
            static constexpr char HasKey[] = "UnityEngine.PlayerPrefs::HasKey(System.String)";
            static constexpr char DeleteKey[] = "UnityEngine.PlayerPrefs::DeleteKey(System.String)";
            static constexpr char DeleteAll[] = "UnityEngine.PlayerPrefs::DeleteAll()";
            static constexpr char Save[] = "UnityEngine.PlayerPrefs::Save()";
        } ManagedNames;

        static InternalCallbacks _internalCallbacks;

        static Callbacks _callbacks;

        static const RegisterRuntimeInitializeAndCleanup _runtimeInitializeAndCleanup;


        // System.Boolean UnityEngine.PlayerPrefs::TrySetInt(System.String,System.Int32)
        static bool TrySetInt(Il2CppString* key, int32_t value)
        {
            if (_callbacks.TrySetInt == nullptr)
                return _internalCallbacks.TrySetIntInternal(key, value);

            return _callbacks.TrySetInt(StringUtils::GetChars(key), value);
        }

        // System.Boolean UnityEngine.PlayerPrefs::TrySetFloat(System.String,System.Single)
        static bool TrySetFloat(Il2CppString* key, float value)
        {
            if (_callbacks.TrySetFloat == nullptr)
                return _internalCallbacks.TrySetFloatInternal(key, value);

            return _callbacks.TrySetFloat(StringUtils::GetChars(key), value);
        }

        // System.Boolean UnityEngine.PlayerPrefs::TrySetSetString(System.String,System.String)
        static bool TrySetString(Il2CppString* key, Il2CppString* value)
        {
            if (_callbacks.TrySetString == nullptr)
                return _internalCallbacks.TrySetStringInternal(key, value);

            return _callbacks.TrySetString(StringUtils::GetChars(key),
                StringUtils::GetChars(value));
        }

        // System.Int32 UnityEngine.PlayerPrefs::GetInt(System.String,System.Int32)
        static int32_t GetInt(Il2CppString* key, int32_t defaultValue)
        {
            if (_callbacks.GetInt == nullptr)
                return _internalCallbacks.GetIntInternal(key, defaultValue);

            return _callbacks.GetInt(StringUtils::GetChars(key), defaultValue);
        }

        // System.Single UnityEngine.PlayerPrefs::GetFloat(System.String,System.Single)
        static float GetFloat(Il2CppString* key, float defaultValue)
        {
            if (_callbacks.GetFloat == nullptr)
                return _internalCallbacks.GetFloatInternal(key, defaultValue);

            return _callbacks.GetFloat(StringUtils::GetChars(key), defaultValue);
        }

        // System.String UnityEngine.PlayerPrefs::GetString(System.String,System.String)
        static Il2CppString* GetString(Il2CppString* key, Il2CppString* defaultValue)
        {
            if (_callbacks.GetString == nullptr)
                return _internalCallbacks.GetStringInternal(key, defaultValue);

            Il2CppChar* value = _callbacks.GetString(StringUtils::GetChars(key),
                defaultValue ? StringUtils::GetChars(defaultValue) : nullptr);
            if (!value)
                return nullptr;
            return String::NewUtf16(value, int32_t(StringUtils::StrLen(value)));
        }

        // System.Boolean UnityEngine.PlayerPrefs::HasKey(System.String)
        static bool HasKey(Il2CppString* key)
        {
            if (_callbacks.HasKey == nullptr)
                return _internalCallbacks.HasKeyInternal(key);

            return _callbacks.HasKey(StringUtils::GetChars(key));
        }

        // System.Void UnityEngine.PlayerPrefs::DeleteKey(System.String)
        static void DeleteKey(Il2CppString* key)
        {
            if (_callbacks.DeleteKey == nullptr)
            {
                _internalCallbacks.DeleteKeyInternal(key);
                return;
            }

            _callbacks.DeleteKey(StringUtils::GetChars(key));
        }

        // System.Void UnityEngine.PlayerPrefs::DeleteAll()
        static void DeleteAll()
        {
            if (_callbacks.DeleteAll == nullptr)
            {
                _internalCallbacks.DeleteAllInternal();
                return;
            }

            _callbacks.DeleteAll();
        }

        // System.Void UnityEngine.PlayerPrefs::Save()
        static void Save()
        {
            if (_callbacks.Save == nullptr)
            {
                _internalCallbacks.SaveInternal();
                return;
            }

            _callbacks.Save();
        }

        static void OnRuntimeInitialize()
        {
            _internalCallbacks.TrySetIntInternal =
                reinterpret_cast<TrySetIntInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::TrySetInt));
            InternalCalls::Add(ManagedNames::TrySetInt, reinterpret_cast<Il2CppMethodPointer>(TrySetInt));

            _internalCallbacks.TrySetFloatInternal =
                reinterpret_cast<TrySetFloatInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::TrySetFloat));
            InternalCalls::Add(ManagedNames::TrySetFloat, reinterpret_cast<Il2CppMethodPointer>(TrySetFloat));

            _internalCallbacks.TrySetStringInternal =
                reinterpret_cast<TrySetStringInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::TrySetString));
            InternalCalls::Add(ManagedNames::TrySetString, reinterpret_cast<Il2CppMethodPointer>(TrySetString));

            _internalCallbacks.GetIntInternal =
                reinterpret_cast<GetIntInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::GetInt));
            InternalCalls::Add(ManagedNames::GetInt, reinterpret_cast<Il2CppMethodPointer>(GetInt));

            _internalCallbacks.GetFloatInternal =
                reinterpret_cast<GetFloatInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::GetFloat));
            InternalCalls::Add(ManagedNames::GetFloat, reinterpret_cast<Il2CppMethodPointer>(GetFloat));

            _internalCallbacks.GetStringInternal =
                reinterpret_cast<GetStringInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::GetString));
            InternalCalls::Add(ManagedNames::GetString, reinterpret_cast<Il2CppMethodPointer>(GetString));

            _internalCallbacks.HasKeyInternal =
                reinterpret_cast<HasKeyInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::HasKey));
            InternalCalls::Add(ManagedNames::HasKey, reinterpret_cast<Il2CppMethodPointer>(HasKey));

            _internalCallbacks.DeleteKeyInternal =
                reinterpret_cast<DeleteKeyInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::DeleteKey));
            InternalCalls::Add(ManagedNames::DeleteKey, reinterpret_cast<Il2CppMethodPointer>(DeleteKey));

            _internalCallbacks.DeleteAllInternal =
                reinterpret_cast<DeleteAllInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::DeleteAll));
            InternalCalls::Add(ManagedNames::DeleteAll, reinterpret_cast<Il2CppMethodPointer>(DeleteAll));

            _internalCallbacks.SaveInternal =
                reinterpret_cast<SaveInternalPfn>(il2cpp_codegen_resolve_icall(ManagedNames::Save));
            InternalCalls::Add(ManagedNames::Save, reinterpret_cast<Il2CppMethodPointer>(Save));
        }

        static void OnRuntimeCleanup()
        {
        }
    };


    PlayerPrefsHooks::InternalCallbacks PlayerPrefsHooks::_internalCallbacks;

    PlayerPrefsHooks::Callbacks PlayerPrefsHooks::_callbacks;

    const RegisterRuntimeInitializeAndCleanup
        PlayerPrefsHooks::_runtimeInitializeAndCleanup(OnRuntimeInitialize, OnRuntimeCleanup);
}


extern "C" void EXPORT_CALL Fiftytwo_PlayerPrefsHooks_SetCallbacks(Fiftytwo::PlayerPrefsHooks::Callbacks callbacks)
{
    Fiftytwo::PlayerPrefsHooks::SetCallbacks(callbacks);
}
