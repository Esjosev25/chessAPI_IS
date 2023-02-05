using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.game;

namespace chessAPI.business.impl;

public sealed class clsGameBusiness<TI, TC> : IGameBusiness<TI>
    where TI : struct, IEquatable<TI>
    where TC : struct
{
  internal readonly IGameRepository<TI, TC> gameRepository;

  public clsGameBusiness(IGameRepository<TI, TC> gameRepository)
  {
    this.gameRepository = gameRepository;
  }

  public async Task<clsGame<TI>> addGame(clsNewGame newGame)
  {
    // var player = await gameRepository.getPlayerByEmail(newGame);
    // if (player != null)

    //   return null;


    var x = await gameRepository.addGame(newGame).ConfigureAwait(false);

    return new clsGame<TI>(x, newGame);
  }



  public async Task<clsGame<TI>?> getGame(TI id)
  {
    var x = await gameRepository.getGameById(id).ConfigureAwait(false);
    if (x == null) return null;
    Console.WriteLine(x);

    return new clsGame<TI>(id, x.whites, x.blacks, x.started, x.turn);
  }


  public async Task<clsGame<TI>?> updateGame(clsPutGame<TI> updateGame)
  {
    var game = await gameRepository.getGameById(updateGame.id).ConfigureAwait(false);

    if (game != null)
    {

      var gameModel = await gameRepository.updateGame(updateGame, game.turn).ConfigureAwait(false);
      if(gameModel != null)
      return gameModel.getClsGame();

      return null;
    }

    return null;


  }


}