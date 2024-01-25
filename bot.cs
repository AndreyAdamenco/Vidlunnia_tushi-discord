using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using DSharpPlus.Interactivity;
using System.Threading.Tasks;
using Vidlunnia_tushi_discord;
using Vidlunnia_tushi_discord.Commands;

namespace Відлуння_beta1
{
    internal class bot
    {
        public static DiscordClient Client { get; set; }
        public static CommandsNextExtension Comands { get; set; }
        static async Task Main(string[] args)
        {
            var jsonReader = new JsonReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };
                Client = new DiscordClient(discordConfig);

            Client.UseInteractivity(new InteractivityConfiguration() 
            {
                Timeout =TimeSpan.FromMinutes(5)
            });

            Client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };

            Comands = Client.UseCommandsNext(commandsConfig);

            Comands.RegisterCommands<FirstCommand>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
            

        }
        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
