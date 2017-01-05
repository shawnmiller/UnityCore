using UnityEngine;
using System.ComponentModel;
using System.Collections.Generic;

public static partial class Extensions
{
  #region Collections
  /// <summary>
  /// Adds the element to the list if it is not already there.
  /// </summary>
  /// <param name="element">The element to add.</param>
  public static void AddUnique<T>(this ICollection<T> collection, T element)
  {
    if (!collection.Contains(element))
    {
      collection.Add(element);
    }
  }

  /// <summary>
  /// Remove a collection of values from this collection.
  /// </summary>
  /// <param name="List"></param>
  /// <param name="Remove"></param>
  public static void Remove<T>(this ICollection<T> collection, IEnumerable<T> remove)
  {
    foreach (T obj in remove)
      collection.Remove(obj);
  }
  #endregion

  #region Strings
  /// <summary>
  /// Returns true if the compare string is equal to this string, regardless of case.
  /// </summary>
  /// <param name="compare">The string to compare against.</param>
  public static bool EqualsIgnoreCase(this string source, string compare)
  {
    return source.Equals(compare, System.StringComparison.InvariantCultureIgnoreCase);
  }

  /// <summary>
  /// Creates an object of type T from the given string, if possible.
  /// </summary>
  /// <typeparam name="T">The type to convert to.</typeparam>
  public static T Parse<T>(this string value)
  {
    // Get default value for type so if string
    // is empty then we can return default value.
    T result = default(T);
    if (!string.IsNullOrEmpty(value))
    {
      // we are not going to handle exception here
      // if you need SafeParse then you should create
      // another method specially for that.
      TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
      result = (T)tc.ConvertFrom(value);
    }

    return result;
  }
  #endregion

  #region Lazy Logs
  public static void LOG(this string str)
  {
    UnityEngine.Debug.Log(str);
  }

  public static void LOG(this string str, params object[] args)
  {
    UnityEngine.Debug.Log(System.String.Format(str, args));
  }

  public static void WARN(this string str)
  {
    UnityEngine.Debug.LogWarning(str);
  }

  public static void WARN(this string str, params object[] args)
  {
    UnityEngine.Debug.LogWarning(System.String.Format(str, args));
  }

  public static void ERROR(this string str)
  {
    UnityEngine.Debug.LogError(str);
  }

  public static void ERROR(this string str, params object[] args)
  {
    UnityEngine.Debug.Log(System.String.Format(str, args));
  }
  #endregion
}
