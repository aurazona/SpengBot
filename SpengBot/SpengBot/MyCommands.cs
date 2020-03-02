using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

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
            await ctx.RespondAsync($"🤙 heya, {ctx.User.Mention}!");
        }
        [Command("random")]
        public async Task Random(CommandContext ctx, int min, int max)
        {
            var rnd = new Random();
            await ctx.RespondAsync($"🎲 You rolled a: {rnd.Next(min, max)}");
        }
        [Command("gay")]
        public async Task Gay(CommandContext ctx)
        {
            await ctx.RespondAsync($"no u {ctx.User.Mention}");
        }
        [Command("fuckyou")]

        public async Task FuckYou(CommandContext ctx)
        {
            await ctx.RespondAsync($"speng");
        }
        [Command("helpme")]

        public async Task Helpme(CommandContext ctx)
        {
            string[] lines = System.IO.File.ReadAllLines(@"X:\Data\SpengBot\davidsays.txt");
            var davidRnd = new Random();
            int davidChoice = davidRnd.Next(0, 15);
            string davidSays = lines[davidChoice];
            await ctx.RespondAsync($"David says... {davidSays}");
        }
        [Command("bigboy")]

        public async Task bigBoy(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://drive.google.com/file/d/1eIdxNKDC5zxZfSm1dBkBVJFSLvBxxwo7/view");
        }
        [Command("unityhelp")]

        public async Task unityHelp(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://youtu.be/oOa3oENEuo0");
        }
        [Command("urmarge")]

        public async Task UrMarge(CommandContext ctx)
        {
            await ctx.RespondAsync($"https://68.media.tumblr.com/f81fe91c31732e2d249ec868ae509243/tumblr_o339cnuVFp1uaabd8o1_500.png");
        }
        [Command("harrywarland")]

        public async Task HarryWarland(CommandContext ctx)
        {
            await ctx.RespondAsync($"Harry is a nonce.");
        }
        [Command("ddos")]

        public async Task Ddos(CommandContext ctx)
        {
            string[] lines2 = System.IO.File.ReadAllLines(@"X:\Data\SpengBot\ddos.txt");
            var DdosRnd = new Random();
            int DdosChoice = DdosRnd.Next(0, 17);
            string Ddos = lines2[DdosChoice];
            await ctx.RespondAsync($"shut up i'll ddos {Ddos}");
        }
    }
}
