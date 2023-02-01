namespace chessAPI.models.player;

public sealed class clsPutPlayer<TI>
    where TI : struct, IEquatable<TI>
{
  public clsPutPlayer(TI id, string email)
  {
    this.id = id;
    this.email = email;
  }

  public  TI? id { get; set; }
  public string? email { get; set; }
}