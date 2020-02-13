using DSharpPlus;
using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using SpengBot;

namespace DiscAura
{
    class Program
    {
        static DiscordClient discord; //core bot variable
        static CommandsNextModule commands; //required for commands
        static string shutdownAttempt; //variable for my ID
        static ulong ShutdownAttemptConvert; //not really a point of having this, isn't used at all. Will probably delete in an upcoming push.
        static string virusGay; //rename this at some point
        static bool virusGayEnabled = false; //rename this at some point
        static void Main(string[] args) //very important, do not delete
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args) //this handles the bot's connection to discord
        {
            discord = new DiscordClient(new DiscordConfiguration //defines the bot
            {
                Token = "Njc3MjI4NjQ4NTgyODczMDg5.XkROTw.kvkH0Q5Ntc17L9pHKUb3kvvdacM", //bot token
                TokenType = TokenType.Bot, //lets discord know this is a bot
                UseInternalLogHandler = true, //brings up a command prompt on launch, useful for tracking errors
                LogLevel = LogLevel.Debug //actually pushes errors and heartbeat checks to the command prompt
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration //this handles the prefix for the bot
            {
                StringPrefix = "!!" //maybe change so it doesn't overlap with terraBot and discAura?
            });

            commands.RegisterCommands<MyCommands>(); //tells the script to use MyCommands.cs as the command source

            discord.MessageCreated += async e => //basic ping pong script
            {
                if (e.Message.Content.ToLower().StartsWith("ping")) //if the message begins with ping
                    await e.Message.RespondAsync("pong!"); //send a message with pong
            };

            discord.MessageCreated += async e => //emergency shutdown
            {
                if (e.Message.Content.ToLower().StartsWith("spengbot.shutdown")) //if the message begins with spengbot.shutdown
                {
                    shutdownAttempt = e.Author.Id.ToString(); //grab the id of the author of the message and convert it to a string
                    if (shutdownAttempt == ("232162231465410560")) //if the string matches the defined id (mine)
                    {
                        await e.Message.RespondAsync("EMERGENCY SHUTDOWN INITIATED"); //send a message to confirm the shutdown occurs
                        Environment.Exit(-1); //actually shut the bot down
                    }
                    else
                    {
                        await e.Message.RespondAsync("Nice try, but last I checked you weren't Aurazona."); //sent if the ID doesn't match.
                    }

                }
            };

            discord.MessageCreated += async e => //harry
            {
                virusGay = e.Author.Id.ToString(); //grab the ID of the author of the most recently sent message in the discord
                if (virusGay == ("548944800762560533")) //if the ID matches the person, in this case Harry
                {
                    if (virusGayEnabled == true) //and if the toggle for spengRespond is on
                    {
                        await e.Message.RespondAsync("nonce"); //reply to every one of their messages with 'nonce'
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
                if (e.Message.Content.ToLower().StartsWith("terrabot.spengrespond")) //pretty much the same as spengbot.shutdown
                {
                    shutdownAttempt = e.Author.Id.ToString();
                    if ((shutdownAttempt == ("232162231465410560")))
                    {
                        if (virusGayEnabled == true) //simple toggle system, if it's true it turns off, if it's false it turns on
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


            await discord.ConnectAsync(); //actually connects the bot to discord's servers

            await Task.Delay(-1); //needed so the bot doesn't immediately shut down on startup
        }
    }
}
