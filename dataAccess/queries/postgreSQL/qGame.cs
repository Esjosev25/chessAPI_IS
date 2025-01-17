namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qGame : IQGame
{
  private const string _selectAll = @"
    SELECT id, started, whites, blacks, turn, winner
    FROM public.game";
  private const string _selectOne = @"
    SELECT id, started, whites, blacks, turn, winner
    FROM public.game
    WHERE id=@ID";
  private const string _add = @"
    INSERT INTO public.game(started, whites, turn)
    VALUES(@STARTED, @WHITES, @TURN) RETURNING id
   ";

  private const string _delete = @"";
  private const string _update = @"
    UPDATE public.game  
    SET  blacks = @BLACKS, turn = @TURN, winner = @WINNER  WHERE id = @ID 
    AND NOT EXISTS(  
      SELECT tw.player_id from team_player tw  WHERE team_id = @WHITES  
      AND EXISTS (  
        SELECT id  FROM team_player tb  WHERE team_id = @BLACKS and tw.player_id = tb.player_id
        )  
      ) 
    RETURNING id, blacks, whites, started, winner, turn";

  public string SQLGetAll => _selectAll;

  public string SQLDataEntity => _selectOne;

  public string NewDataEntity => _add;

  public string DeleteDataEntity => _delete;

  public string UpdateWholeEntity => _update;
}