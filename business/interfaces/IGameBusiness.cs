using chessAPI.models.game;

namespace chessAPI.business.interfaces;

public interface IGameBusiness
{
    // Task<clsGame<TI>> addGame(clsNewGame newGame);
    // Task<clsGame<TI>?> getGame(TI id);
    // Task<clsGame<TI>?> updateGame(clsPutGame<TI> updateGame);
    Task<clsGame?> getGame(long id);
    Task startGame(clsNewGame newGame);
    Task<bool> swapTurn(long id);

}