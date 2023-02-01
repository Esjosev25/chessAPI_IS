using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.player;

namespace chessAPI.business.impl;

public sealed class clsPlayerBusiness<TI, TC> : IPlayerBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
    internal readonly IPlayerRepository<TI, TC> playerRepository;

    public clsPlayerBusiness(IPlayerRepository<TI, TC> playerRepository)
    {
        this.playerRepository = playerRepository;
    }

    public async Task<clsPlayer<TI>> addPlayer(clsNewPlayer newPlayer)
    {
        var x = await playerRepository.addPlayer(newPlayer).ConfigureAwait(false);
        return new clsPlayer<TI>(x, newPlayer.email);
    }

  public async Task<clsPlayer<TI>?> getPlayer(TI playerId)
  {
    var x = await playerRepository.getPlayerById(playerId).ConfigureAwait(false);
    if(x==null) return null;
    return new clsPlayer<TI>(playerId, x.email);
  }

  public async Task<clsPlayer<TI>?> updatePlayer(clsPlayer<TI> updatePlayer)
  {
    var x = await playerRepository.updatePlayer(updatePlayer).ConfigureAwait(false);
    if (x == null) return null;
    return new clsPlayer<TI>(x.id, x.email);
  }

}