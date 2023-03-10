#pragma warning disable
/*
 * OSIcon
 * Author: Tiago Concei玢o
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;

namespace OSIcon;

/// <summary>
/// Some utilities
/// </summary>
public static class Utilities
{
  #region IsOS Methods
  /// <summary>
  /// Is current operative system XP or above?
  /// </summary>
  public static bool IsXpOrAbove()
  {
    if (Environment.OSVersion.Version.Major > 5)
      return true;
    return (Environment.OSVersion.Version.Major == 5) &&
           (Environment.OSVersion.Version.Minor >= 1);
  }
  /// <summary>
  /// Is current operative system Vista or above?
  /// </summary>
  public static bool IsVistaOrAbove()
  {
    if (Environment.OSVersion.Version.Major > 6)
      return true;
    return (Environment.OSVersion.Version.Major == 6) &&
           (Environment.OSVersion.Version.Minor >= 0);
  }
  /// <summary>
  /// Is current operative system Seven or above?
  /// </summary>
  public static bool IsSevenOrAbove()
  {
    if (Environment.OSVersion.Version.Major > 6)
      return true;
    return (Environment.OSVersion.Version.Major == 6) &&
           (Environment.OSVersion.Version.Minor >= 1);
  }
  #endregion

  #region Size Convert
  const int CONVERSION_VALUE = 1024;
  public enum SizeBytes : ulong
  {
    BY = 1, // Byte
    KB = CONVERSION_VALUE * BY, // Kilobyte
    MB = CONVERSION_VALUE * KB, // Megabyte
    GB = CONVERSION_VALUE * MB, // Gigabyte
    TB = CONVERSION_VALUE * GB, // Terabyte
  }

  public static double ConvertSize(long bytes, SizeBytes type)
  {
    //determine what conversion they want
    switch (type)
    {
      case SizeBytes.BY:
        //convert to bytes (default)
        return bytes;
      case SizeBytes.KB:
        //convert to kilobytes
        return (bytes / CONVERSION_VALUE);
      case SizeBytes.MB:
        //convert to megabytes
        return (bytes / Math.Pow(CONVERSION_VALUE, 2));
      case SizeBytes.GB:
        //convert to gigabytes
        return (bytes / Math.Pow(CONVERSION_VALUE, 3));
      case SizeBytes.TB:
        //convert to terabytes
        return (bytes / Math.Pow(CONVERSION_VALUE, 4));
      default:
        //default
        return bytes;
    }
  }

  public static double FormatByteSize(long bytes)
  {
    if (bytes > (long)SizeBytes.TB)
      return ConvertSize(bytes, SizeBytes.TB);
    if (bytes > (int)SizeBytes.GB)
      return ConvertSize(bytes, SizeBytes.GB);
    if (bytes > (int)SizeBytes.MB)
      return ConvertSize(bytes, SizeBytes.MB);
    if (bytes > (int)SizeBytes.KB)
      return ConvertSize(bytes, SizeBytes.KB);
    return bytes;
  }

  public static double ConvertSizeToOther(double value, SizeBytes from, SizeBytes to)
  {
    if (from == to) return value;
    double bytes = value;
    switch (from)
    {
      /* case SizeBytes.BY:
           bytes = value;
           break;*/
      case SizeBytes.KB:
        bytes = value * CONVERSION_VALUE;
        break;
      case SizeBytes.MB:
        bytes = value * Math.Pow(CONVERSION_VALUE, 2);
        break;
      case SizeBytes.GB:
        bytes = value * Math.Pow(CONVERSION_VALUE, 3);
        break;
      case SizeBytes.TB:
        bytes = value * Math.Pow(CONVERSION_VALUE, 4);
        break;
    }
    return to == SizeBytes.BY ? bytes : ConvertSize((long)bytes, to);
  }

  public static string GetSizeNameFromBytes(long bytes, bool longName)
  {
    if (bytes > (long)SizeBytes.TB)
      return longName ? "Terabytes" : "TB";
    if (bytes > (int)SizeBytes.GB)
      return longName ? "Gigabytes" : "GB";
    if (bytes > (int)SizeBytes.MB)
      return longName ? "Megabytes" : "MB";
    if (bytes > (int)SizeBytes.KB)
      return longName ? "Kilobytes" : "KB";
    return longName ? "Bytes" : "B";
  }
  #endregion

  #region String Utilities

  /// <summary>
  /// Append a 's' to the given text if the number is bigger than 1
  /// </summary>
  /// <param name="num">Number to check</param>
  /// <param name="text">Text to use</param>
  /// <returns>Singular or plural text</returns>
  public static string ConvertPlural(int num, string text)
  {
    if (num <= 1)
      return text;

    return string.Format("{0}s", text);
  }

  /// <summary>
  /// Append a 's' to the given text if the number is bigger than 1
  /// </summary>
  /// <param name="num">Number to check</param>
  /// <param name="text">Text to use</param>
  /// <returns>Singular or plural text</returns>
  public static string ConvertPlural(long num, string text)
  {
    if (num <= 1)
      return text;

    return string.Format("{0}s", text);
  }
  #endregion
}
