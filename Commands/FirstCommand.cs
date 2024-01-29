using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
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
        public async Task poll(CommandContext ctx, string option0, string option1, string option2, string option3, [RemainingText] string polltitle)
        {
            var poll = bot.Client.GetInteractivity();
            var polltime = TimeSpan.FromSeconds(100);
            DiscordEmoji[] emojioptions =
            {
                DiscordEmoji.FromName(bot.Client, ":one:"),
                DiscordEmoji.FromName(bot.Client, ":two:"),
                DiscordEmoji.FromName(bot.Client, ":three:"),
                DiscordEmoji.FromName(bot.Client, ":four:")
            };
            string optionDescr = $"{emojioptions[0]} | {option0} \n" +
                $"{emojioptions[1]} | {option1} \n" + $"{emojioptions[2]} | {option2} \n" + $"{emojioptions[3]} | {option3}";
            var pollmessage = new DiscordEmbedBuilder
            {
                Title = polltitle,
                Color = DiscordColor.Violet,
                Description = optionDescr
            };
           var sendpoll = await ctx.Channel.SendMessageAsync(embed: pollmessage);
            foreach (var emoji in emojioptions)
            {
                await sendpoll.CreateReactionAsync(emoji);
            }
            var totalreac = await poll.CollectReactionsAsync(sendpoll, polltime);
            int count0 = 0;
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            foreach (var emoji in totalreac) 
            {
                if (emoji.Emoji == emojioptions[0]) { count0++; }
                if (emoji.Emoji ==emojioptions[1]) { count1++; }
                if (emoji.Emoji == emojioptions[2]) {count2++; }
                if (emoji.Emoji == emojioptions[3]) { count3++; }
            }



            int total = count0 + count1 + count2 + count3;
            string resultDescr = $"{emojioptions[0]}: {count0} голосів \n" +
                                 $"{emojioptions[1]}: {count1} голосів \n" +
                                 $"{emojioptions[2]}: {count2} голосів \n" +
                                 $"{emojioptions[3]}: {count3} голосів \n";
            var Embedresult = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Violet,
                Title = "Результати квізу",
                Description = resultDescr
            };
            await ctx.Channel.SendMessageAsync(embed: Embedresult);
        }
    }
}