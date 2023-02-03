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

  public Task<clsGame<TI>> addGame(clsNewGame newGame)
  {
    // var player = await gameRepository.getPlayerByEmail(newGame);
    // if (player != null)

    //   return null;


    // var x = await gameRepository.addPlayer(newGame).ConfigureAwait(false);
    // return new clsGame<TI>(x, newPlayer.email);
    throw new NotImplementedException();
  }

 

  public async Task<clsGame<TI>?> getGame(TI id)
  {
    var x = await gameRepository.getGameById(id).ConfigureAwait(false);
    if (x == null) return null;
    Console.WriteLine(x);
    return new clsGame<TI>(id, x.whites,x.blacks);
  }


  public Task<clsGame<TI>?> updateGame(clsGame<TI> updateGame)
  {
    // var player = await gameRepository.getPlayerById(updatePlayer.id).ConfigureAwait(false);

    // if (player != null)
    //   return await gameRepository.updatePlayer(updateGame).ConfigureAwait(false);

    // return null;
    throw new NotImplementedException();

  }

 
}