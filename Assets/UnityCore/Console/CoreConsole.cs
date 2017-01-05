using UnityCore.Collections;
using UnityEngine;
using System.Collections.Generic;

namespace UnityCore
{

  public enum ConsoleDuplicateStrategy
  {
    /// <summary>
    /// Ignores existing messages, creating the new one as if it were the
    /// only one in the console.
    /// </summary>
    IgnoreExisting,
    /// <summary>
    /// Extends the current message's duration to the newly added message.
    /// Does not update the message text.
    /// </summary>
    RefreshExisting,
    /// <summary>
    /// Removes the existing message and creates the new one.
    /// Text will be updated appropriately.
    /// </summary>
    RemoveAndCreateNew,
    /// <summary>
    /// If a duplicate exists, the new message is discarded.
    /// </summary>
    DoNothing,
  }

  public class CoreConsole : Singleton<CoreConsole>
  {
    private class ConsoleMessage
    {
      private const string MESSAGE_FORMAT = "<color={0}>{1}</color>";

      public string Message { get; private set; }
      public float Created { get; private set; }
      public float Duration { get; set; }
      public int Index { get; set; }
      public bool IsValid
      {
        get
        {
          return Duration < (Time.realtimeSinceStartup - Created);
        }
      }

      public ConsoleMessage(string Message, Color Color)
      {
        string HexColor = ColorToHex(Color);

        this.Message = string.Format(MESSAGE_FORMAT, Message, HexColor);
        this.Created = Time.realtimeSinceStartup;
      }

      private string ColorToHex(Color Convert)
      {
        string Result = "#";
        Result += ((int)(Convert.r * 255)).ToString("X");
        Result += ((int)(Convert.b * 255)).ToString("X");
        Result += ((int)(Convert.g * 255)).ToString("X");
        Result += ((int)(Convert.a * 255)).ToString("X");

        return Result;
      }
    }

    /// <summary>
    /// Value used for ignoring duplication strategies.
    /// </summary>
    private const int NO_INDEX = -1;

    /// <summary>
    /// Whether the console will also log to Unity's in-editor console.
    /// </summary>
    private bool redundantLogs = true;

    /// <summary>
    /// Strategy for handling duplicate messages.
    /// </summary>
    private ConsoleDuplicateStrategy duplicateStrategy = ConsoleDuplicateStrategy.IgnoreExisting;

    /// <summary>
    /// List of all messages in the queue.
    /// </summary>
    private List<ConsoleMessage> messages = new List<ConsoleMessage>();

    /// <summary>
    /// Logs a message to the console.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="duration">The duration that the message should remain in the console.</param>
    /// <param name="textColor">The color of the text in the message.</param>
    /// <param name="index">(optional)The message index, used for handling duplicates.</param>
    public static void Log(string message, float duration, Color textColor, int index = NO_INDEX)
    {
      var console = Get();
      
      if(index == NO_INDEX)
      {
        var CM = Generate(message, duration, textColor, index);
        console.messages.Add(CM);
      }
    }

    public static void Log(string message, float duration, Color textColor)
    {
      Log(message, duration, textColor, NO_INDEX);
    }

    public static void Log(string message, float duration, int index)
    {
      Log(message, duration, Color.white, index);
    }

    public static void LogWarn(string message, float duration, int index)
    {
      Log(message, duration, Color.yellow, index);
    }

    public static void LogWarn(string message, float duration)
    {
      Log(message, duration, Color.yellow, NO_INDEX);
    }

    public static void LogErr(string message, float duration, int index)
    {
      Log(message, duration, Color.red, index);
    }

    public static void LogErr(string message, float duration)
    {
      Log(message, duration, Color.red, NO_INDEX);
    }

    public void SetDuplicateStrategy(ConsoleDuplicateStrategy Strategy)
    {
      duplicateStrategy = Strategy;
    }

    private static ConsoleMessage Generate(string Message, float Duration, Color TextColor, int Index)
    {
      var CM = new ConsoleMessage(Message, TextColor);
      CM.Duration = Duration;
      CM.Index = Index;
      return CM;
    }
  }
}
