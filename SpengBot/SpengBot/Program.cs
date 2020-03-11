using DSharpPlus;
using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using SpengBot;
using DSharpPlus.Entities;

namespace DiscAura
{
    class Program
    {
        static DiscordClient discord; //important bot stuff
        static CommandsNextModule commands; //more important bot stuff
        static string AuraID = ("232162231465410560"); //used to verify my identity for any admin commands
        static ulong ShutdownAttemptConvert; //deprecated, will be removed soon-ish
        static string virusGay; //used to verify an identity
        static bool virusGayEnabled = false;
        static public int SpengPing; //stores the current ping in ms
        static public string DsharpVer; //stores the current DSharp library version
        static public string SpengTime; //stores the current time
        static public string SpengGuilds; //stores the amount of connected guilds
        static public int SpengUsers; //stores the amount of users in the guild
        static public string GuildMadeTime; //stores when spengbot joined the guild
        static public string SpengRegion; //stores the region of the guild
        static public bool StatsGrabbed; //used to verify that stats have, in fact, been grabbed
        static public bool SpengDebug; //used to verify that debug mode is on/off
        static string AdminID = "232162231465410560";
        static bool MemberBanned; //used to output a different message when someone gets banned in DMs.

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = System.IO.File.ReadAllText(@"X:\Data\SpengBot\token.txt"),
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "."
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
                    AuraID = e.Author.Id.ToString();
                    if (AuraID == (AdminID))
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
                    AuraID = e.Author.Id.ToString();
                    if ((AuraID == ("232162231465410560")))
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

            //stat grabber part 1
            //gets ping, DSharp version, the current time and the amount of guilds SpengBot's in.
            void StatGrab()
            {
                SpengPing = discord.Ping;
                DsharpVer = discord.VersionString;
                SpengTime = DateTime.Now.ToString("h:mm:ss tt");
                SpengGuilds = discord.Guilds.Count.ToString();
                
            }

            //stat grabber part 2
            //grabs the member count, the date that spengbot joined the server, the region of the server and calls part 1
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().Equals(".stats"))
                {
                    SpengUsers = e.Guild.MemberCount;
                    GuildMadeTime = e.Guild.JoinedAt.ToString();
                    SpengRegion = e.Guild.RegionId;
                    StatGrab();
                    StatsGrabbed = true;
                }
            };

            //debug mode
            //disables commands
            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().Equals("spengbot.debug"))
                {
                    if (e.Message.Author.Id.ToString() == AdminID)
                    {
                        if (SpengDebug == false)
                        {
                            await e.Message.RespondAsync("Debug mode activated.");
                            SpengDebug = true;
                        }

                        else if (SpengDebug == true)
                        {
                            await e.Message.RespondAsync("Debug mode deactivated.");
                            SpengDebug = false;
                        }
                    }
                }
            };

            //ban canceller
            //in case I get banned, automatically unbans me. can't shoot me an invite since discord doesn't let bots create invites.
            discord.GuildBanAdded += async e =>
            {
                if (e.Member.Id.ToString().Equals(AdminID))
                {
                    DiscordMember bannedUser = e.Member;
                    await e.Guild.UnbanMemberAsync(bannedUser, "now that wasn't very nice, was it?");
                    await e.Member.CreateDmChannelAsync();
                    MemberBanned = true;
                }
            };

            //this is what happens if someone tries to DM SpengBot

            discord.DmChannelCreated += async e => //if a DM channel is created between SpengBot and someone else
            {
                if (MemberBanned == true)
                {
                    await e.Channel.SendMessageAsync("Uh oh, looks like you got banned.");
                    MemberBanned = false;
                }
                else
                {
                    await e.Channel.SendMessageAsync("Sorry, but SpengBot is not taking DMs at the moment.");
                }
            };

            //message deletion notifier
            //this triggers if a message is deleted in the discord. 
            discord.MessageDeleted += async e =>
            {
                await e.Message.RespondAsync($"smh my head. ayo {e.Message.Author.Mention}, someone deleted your mf message.");
            };

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().ToString().Equals("<@677228648582873089>") && e.Message.Author.Id.ToString().Equals("683859692501467136"))
                {
                    await e.Message.RespondAsync($"fuck off you glorified toaster");
                }
            };
            //actually connects the bot to discord
            await discord.ConnectAsync();

            //this stops the bot from immediately shutting down as otherwise the bot will shut itself down after all current 'tasks' i.e connecting to discord have been completed.
            await Task.Delay(-1);
            
        }
    }
}
