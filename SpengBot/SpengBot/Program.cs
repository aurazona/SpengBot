using DSharpPlus;
using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using SpengBot;

namespace DiscAura
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;
        static string shutdownAttempt;
        static ulong ShutdownAttemptConvert;
        static string virusGay;
        static bool virusGayEnabled = false;
        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "Njc3MjI4NjQ4NTgyODczMDg5.XkROTw.kvkH0Q5Ntc17L9pHKUb3kvvdacM",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "!!"
            });

            commands.RegisterCommands<MyCommands>();

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("spengbot.shutdown"))
                {
                    shutdownAttempt = e.Author.Id.ToString();
                    if (shutdownAttempt == ("232162231465410560"))
                    {
                        await e.Message.RespondAsync("EMERGENCY SHUTDOWN INITIATED");
                        Environment.Exit(-1);
                    }
                    else
                    {
                        await e.Message.RespondAsync("Nice try, but last I checked you weren't Aurazona.");
                    }

                }
            };

            discord.MessageCreated += async e => //harry
            {
                virusGay = e.Author.Id.ToString();
                if (virusGay == ("548944800762560533")) //ID changed
                {
                    if (virusGayEnabled == true)
                    {
                        await e.Message.RespondAsync("nonce");
                    }
                }
            };

            discord.MessageCreated += async e => //josh
            {
                virusGay = e.Author.Id.ToString();
                if (virusGay == ("342697919201280000")) //id changed
                {
                    if (virusGayEnabled == true)
                    {
                        await e.Message.RespondAsync("shush");
                    }
                }
            };

            discord.MessageCreated += async e => //jacob
            {
                virusGay = e.Author.Id.ToString();
                if (virusGay == ("450390645723365387")) //id changed
                {
                    if (virusGayEnabled == true)
                    {
                        await e.Message.RespondAsync("mcdonalds headass");
                    }
                }
            };

            discord.MessageCreated += async e => //mahdi
            {
                virusGay = e.Author.Id.ToString();
                if (virusGay == ("474276732711469062")) //id changed
                {
                    if (virusGayEnabled == true)
                    {
                        await e.Message.RespondAsync("your marj");
                    }
                }
            };

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("terrabot.spengrespond"))
                {
                    shutdownAttempt = e.Author.Id.ToString();
                    if ((shutdownAttempt == ("232162231465410560")))
                    {
                        if (virusGayEnabled == true)
                        {
                            await e.Message.RespondAsync("Stopped responding to spengs.");
                            virusGayEnabled = false;
                        }
                        else if (virusGayEnabled == false)
                        {
                            await e.Message.RespondAsync("Now responding to spengs.");
                            virusGayEnabled = true;
                        }
                    }
                }

            };


            await discord.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}
