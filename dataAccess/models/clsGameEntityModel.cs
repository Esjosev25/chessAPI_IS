using chessAPI.dataAccess.common;
using chessAPI.models.game;
namespace chessAPI.dataAccess.models;

public sealed class clsGameEntityModel<TI, TC> : relationalEntity<TI, TC>
        where TC : struct
        where TI : struct, IEquatable<TI>
{
  public clsGameEntityModel()
  {
  }

  public TI id { get; set; }
  public DateTime started { get; set; }

  public int whites { get; set; }
  public int blacks { get; set; }

  //white = true; black = false;

  public bool turn { get; set; }

  public int winner { get; set; }
  public override TI key { get => id; set => id = value; }

  public clsGame<TI> getClsGame() =>
    new clsGame<TI>
    {
      id = this.id,
      started = this.started,
      whites = this.whites,
      blacks = this.blacks,
      turn = this.turn,
      winner = this.winner
    };


}