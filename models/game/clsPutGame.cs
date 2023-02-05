namespace chessAPI.models.game;

public sealed class clsPutGame<TI>
    where TI : struct, IEquatable<TI>
{
  public clsPutGame()
  {

  }

  public TI id { get; set; }

  public int whites { get; set; }
  public int blacks { get; set; }

  //white = true; black = false;

  public bool ? turn { get; set; }

  public int ? winner { get; set; }
}