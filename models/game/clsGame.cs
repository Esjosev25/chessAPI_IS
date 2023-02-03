namespace chessAPI.models.game;

public sealed class clsGame<TI>
    where TI : struct, IEquatable<TI>
{
  public clsGame(TI _id, int _whites, int _blacks)
  {
    this.id = _id;
    this.whites= _whites;
    this.blacks = _blacks;
    this.started = DateTime.Now;
    this.turn = true;
  }

  public TI id { get; set; }
  public DateTime started { get; set; }

  public int whites { get; set; }
  public int blacks { get; set; }

  //white = true; black = false;

  public bool turn { get; set; }

  public int winner { get; set; }
}