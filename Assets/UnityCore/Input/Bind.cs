
namespace UnityCore.Input
{
  public class Bind
  {
    private string m_Name;
    private InputKey m_Key;

    public Bind(string Name, InputKey Key)
    {
      m_Name = Name;
      m_Key = Key;
    }

    public string GetName()
    {
      return m_Name;
    }
  }
}
