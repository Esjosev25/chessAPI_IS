using Autofac;
using Autofac.Extensions.DependencyInjection;
using chessAPI;
using chessAPI.business.interfaces;
using chessAPI.models.player;
using chessAPI.models.game;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Serilog.Events;

//Serilog logger (https://github.com/serilog/serilog-aspnetcore)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
  Log.Information("chessAPI starting");
  var builder = WebApplication.CreateBuilder(args);

  var connectionStrings = new connectionStrings();
  builder.Services.AddOptions();
  builder.Services.Configure<connectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
  builder.Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);

  // Two-stage initialization (https://github.com/serilog/serilog-aspnetcore)
  builder.Host.UseSerilog((context, services, configuration) => configuration.ReadFrom
           .Configuration(context.Configuration)
           .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning).ReadFrom
           .Services(services).Enrich
           .FromLogContext().WriteTo
           .Console());

  // Autofac como inyección de dependencias
  builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
  builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new chessAPI.dependencyInjection<int, int>()));
  var app = builder.Build();
  app.UseSerilogRequestLogging();
  app.UseMiddleware(typeof(chessAPI.customMiddleware<int>));
  app.MapGet("/", () =>
  {
    return "hola mundo";
  });
  // * Player
  app.MapPost("player",
  [AllowAnonymous] async (IPlayerBusiness<int> bs, clsNewPlayer newPlayer) =>
  {
    var player = await bs.addPlayer(newPlayer);
    if (player != null)
      return Results.Ok(player);
    return Results.BadRequest(new errorMessage($"Email {newPlayer.email} already exists "));
  }
    );

  app.MapGet("player",
  [AllowAnonymous] async (IPlayerBusiness<int> bs, int playerId) =>
  {
    Console.WriteLine(playerId);
    var player = await bs.getPlayer(playerId);
    if (player != null) return Results.Ok(player);

    return Results.NotFound(new errorMessage($"Player with id {playerId} not found"));
  });

  app.MapPut("player",
 [AllowAnonymous] async (IPlayerBusiness<int> bs, clsPlayer<int> updatePlayer) =>
 {
   Console.WriteLine("lol");
   var player = await bs.updatePlayer(updatePlayer);
   if (player != null)
     return Results.Ok(player);

   return Results.NotFound(new errorMessage($"Player with id {updatePlayer.id} not found"));
 });
  // * Team
  app.MapPost("team",
   [AllowAnonymous] async (IPlayerBusiness<int> bs, clsNewPlayer newPlayer) => Results.Ok(await bs.addPlayer(newPlayer)));

  // * Game
  app.MapPost("game",
   [AllowAnonymous] async (IGameBusiness<int> bs, clsNewGame newGame) =>
   {
     try
     {
       var game = await bs.addGame(newGame);
       return Results.Ok(game);
     }
     catch (Exception ex)
     {
       var code = ex.Message.Split(":")[0];
       if (code.Equals("23503"))
         return Results.NotFound(new errorMessage($"Game with id {newGame.whites} doesn't exist"));

       throw ex;

     }


   });

  app.MapGet("game",
  [AllowAnonymous] async (IGameBusiness<int> bs, int id) =>
  {
    Console.WriteLine(id);
    var game = await bs.getGame(id);
    if (game != null) return Results.Ok(game);

    return Results.NotFound(new errorMessage($"Game with id {id} not found"));
  });

  app.MapPut("game",
 [AllowAnonymous] async (IGameBusiness<int> bs, clsPutGame<int> updateGame) =>
 {
  try
  {
     Console.WriteLine("lol");
     var player = await bs.updateGame(updateGame);
     if (player != null)
       return Results.Ok(player);
     return Results.BadRequest(new errorMessage($"One or more players belongs to both teams"));
  }
  catch (Exception ex)
  {
     var code = ex.Message.Split(":")[0];
     if (code.Equals("23503"))
       return Results.NotFound(new errorMessage($"Team with id {updateGame.blacks} or {updateGame.whites} doesn't exist"));

     throw ex;
  }
   
 });


  app.Run();
}
catch (Exception ex)
{
  Log.Fatal(ex, "chessAPI terminated unexpectedly");
}
finally
{
  Log.CloseAndFlush();
}
