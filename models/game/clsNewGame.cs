namespace chessAPI.models.game;

public sealed class clsNewGame
{
  public clsNewGame()
  {
  }

  public int whites { get; set; }
  public DateTime started { get; set; } =
  DateTime.Now;
  public bool turn { get; set; } = true;

}