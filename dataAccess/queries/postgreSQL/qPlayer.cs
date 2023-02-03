namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qPlayer : IQPlayer
{
    private const string _selectAll = @"
    SELECT id, email 
    FROM public.player";

    private const string _selectOne = @"
    SELECT id, email 
    FROM public.player
    WHERE id=@ID";

    private const string _add = @"
    INSERT INTO public.player(email)
	VALUES (@EMAIL) RETURNING id";

    private const string _delete = @"
    DELETE FROM public.player 
    WHERE id = @ID";
    
    private const string _update = @"
    UPDATE public.player
	SET email=@EMAIL
	WHERE id=@ID";

    private const string _findEmail = @"
    SELECT id, email 
    FROM public.player
    WHERE email=@EMAIL";
    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;
    public string SQLGetByEmail => _findEmail;
}