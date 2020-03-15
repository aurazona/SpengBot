using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscAura;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace SpengBot
{
    class MyCommands
    {
        /***
         * notes:
         * ``` allows for code formatting, best for multiline responses i.e command lists
         ***/
        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            if (Program.SpengDebug == false){
                await ctx.RespondAsync($"🤙 heya, {ctx.User.Mention}!");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("random")]
        public async Task Random(CommandContext ctx, int min, int max)
        {
            if (Program.SpengDebug == false)
            {
                var rnd = new Random();
                await ctx.RespondAsync($"🎲 You rolled a: {rnd.Next(min, max)}");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("gay")]
        public async Task Gay(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                await ctx.RespondAsync($"no u {ctx.User.Mention}");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("fuckyou")]

        public async Task FuckYou(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                await ctx.RespondAsync($"speng");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("helpme")]

        public async Task Helpme(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                string[] lines = System.IO.File.ReadAllLines(@"davidsays.txt"); //look into changing for pi
                int davidLines = System.IO.File.ReadAllLines(@"davidsays.txt").Length; //grabs how many lines are in the file. Refer to github issue #9 for info.
                var davidRnd = new Random();
                int davidChoice = davidRnd.Next(0, davidLines);
                string davidSays = lines[davidChoice];
                await ctx.RespondAsync($"David says... {davidSays}");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("bigboy")]

        public async Task bigBoy(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                await ctx.RespondWithFileAsync(@"jim.PNG");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("unityhelp")]

        public async Task unityHelp(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                await ctx.RespondWithFileAsync(@"unity.mp3");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("urmarge")]

        public async Task UrMarge(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                await ctx.RespondAsync($"https://68.media.tumblr.com/f81fe91c31732e2d249ec868ae509243/tumblr_o339cnuVFp1uaabd8o1_500.png");

            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("harrywarland")]

        public async Task HarryWarland(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                await ctx.RespondAsync($"Harry is a nonce.");

            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("ddos")]

        public async Task Ddos(CommandContext ctx)
        {
            if (Program.SpengDebug == false)
            {
                string[] lines2 = System.IO.File.ReadAllLines(@"ddos.txt"); //look into changing for pi
                var DdosRnd = new Random();
                int DdosChoice = DdosRnd.Next(0, 17);
                string Ddos = lines2[DdosChoice];
                await ctx.RespondAsync($"shut up i'll ddos {Ddos}");
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
        }
        [Command("stats")]
        /***
         * Stats:
         * Ping
         * Connected Guilds
         * Users in current guild
         * time of stat call
         * DSharp library version
         * guild voice region
         * guild creation date
         * ***/
        public async Task Stats(CommandContext ctx) //work on this
        {
            if (Program.SpengDebug == false)
            {
                Program.StatsGrabbed = true;
                while (Program.StatsGrabbed == true)
                {
                    await ctx.RespondAsync("here you go you fucking nerd");
                    await ctx.RespondAsync($"``` Ping: {Program.SpengPing} \n Number of connected guilds: {Program.SpengGuilds} \n Number of users in current guild: {Program.SpengUsers} \n Current DSharp library version: {Program.DsharpVer} \n Guild joined: {Program.GuildMadeTime} \n Guild region: {Program.SpengRegion} \n Time of stat call: {Program.SpengTime}```");
                    Program.StatsGrabbed = false;
                }
            }
            else
            {
                await ctx.RespondAsync("Wait a second, I'm currently being tested/debugged.");
            }
            
        }

        [Command("define")]

        public async Task Define(CommandContext ctx, string define)
        {
            await ctx.RespondAsync("check this shit out:");
            await ctx.RespondAsync($"https://www.dictionary.com/browse/{define}");
        }

        [Command("ud")]

        public async Task UrbanDefine(CommandContext ctx, string udefine)
        {
            await ctx.RespondAsync("spengbot is not responsible for any mental/emotional scarring:");
            await ctx.RespondAsync($"https://www.urbandictionary.com/define.php?term={udefine}");
        }

        [Command("roast")]

        /***
        *Roast text file formatting:
        * assume that the mention is like the first word
        * i.e if there's a word after, add a space first.
        * for things like 's, just slap em straight on
         ***/
        public async Task Roast(CommandContext ctx, string Roastee)
        {
            string[] roastLines = System.IO.File.ReadAllLines(@"roast.txt"); //look into changing for pi
            int roastMax = System.IO.File.ReadAllLines(@"roast.txt").Length;
            var RoastRand = new Random();
            int RoastChoice = RoastRand.Next(0, roastMax);
            string Roast = roastLines[RoastChoice];
            await ctx.RespondAsync($"{Roastee}{Roast}");
        }
    }
}
