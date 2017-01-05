
namespace UnityCore.Controllers
{
  public class PlayerController : Controller
  {
    private int index;

    public int GetIndex()
    {
      return index;
    }

    public void SetIndex(int Index)
    {
      index = Index;
    }

    public override void Awake()
    {
      base.Awake();
    }

    public override void Update()
    {
      base.Update();
    }
  }
}
