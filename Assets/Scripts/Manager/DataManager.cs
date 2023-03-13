using System;
using UnityEngine;

/// <summary>
/// TODO：Use json to save data
/// </summary>
public class DataManager : MonoBehaviour
{
    public static bool HasKeyData(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static void SetFloatData(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
    }

    public static float GetFloatData(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public static void SetIntData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public static int GetIntData(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public static void SetStringData(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
        PlayerPrefs.Save();
    }

    public static string GetStringData(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    #region Set Get String Array

    private static int s_EndianDiff1;
    private static int s_EndianDiff2;
    private static int s_Idx;
    private static byte[] s_ByteBlock;

    enum ArrayType
    {
        String
    }

    public static bool SetStringArray(String key, String[] stringArray)
    {
        var bytes = new byte[stringArray.Length + 1];
        bytes[0] = System.Convert.ToByte(ArrayType.String);
        Initialize();

        for (var i = 0; i < stringArray.Length; i++)
        {
            if (stringArray[i] == null)
            {
                return false;
            }

            if (stringArray[i].Length > 255)
            {
                return false;
            }

            bytes[s_Idx++] = (byte)stringArray[i].Length;
        }

        try
        {
            PlayerPrefs.SetString(key, System.Convert.ToBase64String(bytes) + "|" + String.Join("", stringArray));
            PlayerPrefs.Save();
        }
        catch
        {
            return false;
        }

        return true;
    }

    public static String[] GetStringArray(String key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            var completeString = PlayerPrefs.GetString(key);
            var separatorIndex = completeString.IndexOf("|"[0]);
            if (separatorIndex < 4)
            {
                return new String[0];
            }

            var bytes = System.Convert.FromBase64String(completeString.Substring(0, separatorIndex));
            if ((ArrayType)bytes[0] != ArrayType.String)
            {
                return new String[0];
            }

            Initialize();

            var numberOfEntries = bytes.Length - 1;
            var stringArray = new String[numberOfEntries];
            var stringIndex = separatorIndex + 1;
            for (var i = 0; i < numberOfEntries; i++)
            {
                int stringLength = bytes[s_Idx++];
                if (stringIndex + stringLength > completeString.Length)
                {
                    return new String[0];
                }

                stringArray[i] = completeString.Substring(stringIndex, stringLength);
                stringIndex += stringLength;
            }

            return stringArray;
        }

        return new String[0];
    }

    public static String[] GetStringArray(String key, String defaultValue, int defaultSize)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return GetStringArray(key);
        }

        var stringArray = new String[defaultSize];
        for (int i = 0; i < defaultSize; i++)
        {
            stringArray[i] = defaultValue;
        }

        return stringArray;
    }

    private static void Initialize()
    {
        if (System.BitConverter.IsLittleEndian)
        {
            s_EndianDiff1 = 0;
            s_EndianDiff2 = 0;
        }
        else
        {
            s_EndianDiff1 = 3;
            s_EndianDiff2 = 1;
        }

        if (s_ByteBlock == null)
        {
            s_ByteBlock = new byte[4];
        }

        s_Idx = 1;
    }

    #endregion
}