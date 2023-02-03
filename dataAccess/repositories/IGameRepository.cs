using chessAPI.dataAccess.models;
using chessAPI.models.game;

namespace chessAPI.dataAccess.repositores;

public interface IGameRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
  Task<TI> addGame(clsNewGame game);

  Task<clsGameEntityModel<TI, TC>> getGameById(TI id);
  Task<clsGame<TI>> updateGame(clsGame<TI> updatedGame);
  Task deleteGame(TI id);
}