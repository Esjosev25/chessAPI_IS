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
    private const string _add = @"";
    private const string _delete = @"";
    private const string _update = @"";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;
}