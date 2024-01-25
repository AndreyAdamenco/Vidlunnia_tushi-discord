using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Відлуння_beta1;



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
        public async Task Mycommand(CommandContext ctx, double num1, double num2)
        {
            double result = num1 + num2;
            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("embed")]
        public async Task EmmbedMessage(CommandContext ctx)
        {
            var message = new DiscordEmbedBuilder
            {
                Title = "new and better embed",
                Description = $"нянянянняняннянняняняняннянянянянянняняняяняняняняняняняннянянн{ctx.Member.Nickname}",
                Color = DiscordColor.HotPink,
            };
            await ctx.Channel.SendMessageAsync(embed: message);
        }
        [Command("cardgame")]
        public async Task CardGame(CommandContext ctx)
        {
            var userCard = new CardSys();

            var userCArdemm = new DiscordEmbedBuilder 
            {
                Title =$"Твоя картка це {userCard.SelectedCARD}",
                Color= DiscordColor.MidnightBlue
            };
            var botCard = new CardSys();
            await ctx.Channel.SendMessageAsync(embed: userCArdemm);
            var botCArdemm = new DiscordEmbedBuilder
            {
                Title = $"В бота була {botCard.SelectedCARD}",
                Color = DiscordColor.Teal
            };
            await ctx.Channel.SendMessageAsync(embed: botCArdemm);

            if (userCard.SelectedNUM > botCard.SelectedNUM)
            {
                var winmessage = new DiscordEmbedBuilder
                {
                    Title = $"{ctx.Member} вийграв(-ла) o(*^▽^*)┛",
                    Color = DiscordColor.HotPink
                };
                await ctx.Channel.SendMessageAsync(embed:winmessage);
            }
            
            else
            {
                var lostmessage = new DiscordEmbedBuilder
                {
                    Title = $"{ctx.Member} о ні ти програв(-ла)",
                    Color = DiscordColor.Rose
                };
                await ctx.Channel.SendMessageAsync(embed: lostmessage);
            }
            
        }
        [Command("Інтеракція")]
        public async Task Interaction (CommandContext ctx)
        {
            var interact = bot.Client.GetInteractivity();
            var messageToARrive = await interact.WaitForMessageAsync(message => message.Content == "Привітик^^");
            if (messageToARrive.Result.Content == "Привітик^^") 
            {
                await ctx.Channel.SendMessageAsync($"Привітик {ctx.User.Username} як справи в тебе?∼");
            }
            



        }
        [Command("няня")]
        public async Task nua(CommandContext ctx)
        {
            var nua = bot.Client.GetInteractivity();
            var messageTonua = await nua.WaitForMessageAsync(message => message.Content == "нянянянян");
            if (messageTonua.Result.Content == "нянянянян")
            {
                await ctx.Channel.SendMessageAsync($"няняннянянянянняняняняннянянянянняняняняннянянянянняняняняняняннянянянянняняняняннянянянянняняняняннянянянянняняняняннянянянянняняняняннянянянянняняняняннянянянян");
            }




        }
        [Command("реакції")]
        public async Task reaction(CommandContext ctx)
        {
            var Interactivity = bot.Client.GetInteractivity();

            var messtoreac = await Interactivity.WaitForReactionAsync(message => message.Message.Id == 1200153295759609906);
            if (messtoreac.Result.Message.Id == 1200153295759609906) 
            {
                await ctx.Channel.SendMessageAsync($"{ctx.User.Username} поставив це {messtoreac.Result.Emoji.Name}");
            }




        }
        [Command("квізи")]
        public async Task poll(CommandContext ctx)
        {
            var poll = bot.Client.GetInteractivity();
            




        }
    }
}
