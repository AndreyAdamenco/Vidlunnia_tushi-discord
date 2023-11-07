using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;



namespace Vidlunnia_tushi_discord.Commands
{
    public class FirstCommand : BaseCommandModule
    {
        [Command("test")]
        public async Task Mycommand(CommandContext ctx) 
        {
            await ctx.Channel.SendMessageAsync($"Привітик я відлунник чим я можу тобі допомогти{ctx.User}?");
     
        }

        [Command("math")]
        public async Task Mycommand(CommandContext ctx, int num1, int num2)
        {
            int result = num1 + num2;
            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("embed")]
        public async Task EmmbedMessage(CommandContext ctx) 
        {
            var messageBuilder = new DiscordMessageBuilder();
            messageBuilder.WithTitle("My message title");
            messageBuilder.WithContent("My message content");
            await messageBuilder.SendAsync();

        }
    }
}
