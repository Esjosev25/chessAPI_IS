using chessAPI.dataAccess.models;
using chessAPI.models.player;

namespace chessAPI.dataAccess.repositores;

public interface IPlayerRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addPlayer(clsNewPlayer player);
    Task<IEnumerable<clsPlayerEntityModel<TI, TC>>> addPlayers(IEnumerable<clsNewPlayer> players);
    Task<IEnumerable<clsPlayerEntityModel<TI, TC>>> getPlayersByGame(TI gameId);
    Task<clsPlayerEntityModel<TI, TC>> getPlayerById(TI playerId);
    Task<clsPlayer<TI>> updatePlayer(clsPlayer<TI> updatedPlayer);
    Task<clsPlayerEntityModel<TI, TC>?> getPlayerByEmail(clsNewPlayer player);
    Task deletePlayer(TI id);
}