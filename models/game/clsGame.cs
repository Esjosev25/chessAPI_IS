using chessAPI.dataAccess.models;

namespace chessAPI.models.game;

public sealed class clsGame<TI>
    where TI : struct, IEquatable<TI>
{
  public clsGame(TI _id, int _whites, int _blacks, DateTime _started, bool _turn)
  {
    this.id = _id;
    this.whites= _whites;
    this.blacks = _blacks;
    this.started = _started;
    this.turn = _turn;
  }

  public clsGame(TI _id, clsNewGame newGame){
    this.id = _id;
    this.whites = newGame.whites;
    this.blacks = newGame.blacks;
    this.started = newGame.started;
    this.turn = newGame.turn;
  }
  public TI id { get; set; }
  public DateTime started { get; set; }

  public int whites { get; set; }
  public int blacks { get; set; }

  //white = true; black = false;

  public bool turn { get; set; }

  public int winner { get; set; }
}