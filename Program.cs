using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using System.IO;

namespace Pidgler
{
    class Program
    {
        static void Main(string[] args) => new Program().Start();


        public void Start()
        {
            var bot = new Discord.DiscordClient();
            
            bot.MessageReceived += async (s, e) =>
            {
                var _server = e.Server;
                var _channel = e.Channel;
                var _user = e.User;
                char[] charSeparator = new char[] { ' ' };
                string[] ex = e.Message.RawText.Trim().Split(charSeparator); 
                if (e.Message.RawText.StartsWith("!addquote"))
                {
                    var UserPerms = _user.Roles;
					//This restricts quote-adding to only people with a certain role.
					//Replace YOUR_ROLE_ID with the role ID of whatever you want it restricted to. This is a number with no quote marks.
					//If you don't want it restricted, change the following like to say true instead of false, and then remove the "foreach" statement.
                    Boolean hasPerm = false;
                    foreach (Role role in UserPerms)
                    {
                        if (role.Id == YOUR_ROLE_ID)
                        {
                            hasPerm = true;
                        }
                    }
                    if (hasPerm)
                    {
                        if (ex.Length > 1)
                        {
                            String[] arr = ex.Skip(1).ToArray();
                            List<string> lines = new List<string>();
                            lines.Add(String.Join(" ", arr).Trim());
                            File.AppendAllLines(@"path\to\your\quotes\textfile.txt", lines);
                            await e.Channel.SendMessage("Quote added.");
                            Console.WriteLine("Quote added: " + String.Join(" ", arr).Trim());
                        }
                        else
                        {
                            await e.Channel.SendMessage("Don't add a blank quote you dingus");
                        }
                    }
                    else
                    {
                        await e.Channel.SendMessage("This function is restricted to users with special roles");
                    }
                }
                else if (e.Message.RawText.StartsWith("!quote"))
                {
                    string[] lines = System.IO.File.ReadAllLines(@"path\to\your\quotes\textfile.txt");
                    var max = lines.Length;

                    if (lines.Length > 0)
                    {

                        if (ex.Length > 1)
                        {
                            String[] arr = ex.Skip(1).ToArray();
                            var searchTerm = String.Join(" ", arr).Trim();
                            List<String> returnedResults = new List<String>();

                            for (int i = 0; i < max; i++)
                            {
                                if (lines[i].ToLower().Contains(searchTerm.ToLower()))
                                {
                                    returnedResults.Add(lines[i]);
                                }
                            }
                            if (returnedResults.Count > 0)
                            {
                                int index = new Random().Next(0, returnedResults.Count);
                                await e.Channel.SendMessage("Quote: " + returnedResults[index]);
                            }
                            else
                            {
                                await e.Channel.SendMessage("No quotes found matching " + searchTerm);
                            }
                        }
                        else
                        {
                            int index = new Random().Next(0, max);
                            string line = lines[index];
                            await e.Channel.SendMessage("Quote: " + line);
                        }
                    }
                    else
                    {
                        await e.Channel.SendMessage("Quotes DB is empty.");
                    }
                }
            };

            bot.ExecuteAndWait(async () =>
            {
                await bot.Connect("YOUR_BOT_TOKEN", TokenType.Bot);

            });

        }
    }
}
