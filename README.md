# mIRC-compatible-Discord-quote-bot
A basic random quote database bot for Discord servers that accesses text file quote DBs usually operated by mIRC quote bots

This quotes bot stores quotes in a text file. The reason to do this instead of using a better service like SQLite is because this bot is built to work with mIRC-based bots such as [my channel command twitch bot](https://github.com/pidgezero-one/SMRPG-Contest-Bot), which generally use text files for quotes.

#How to Use

Step 1: Go to https://discordapp.com/developers/applications/me and create a new application. Then choose the option to register a bot user. You will be given a bot token. In the file "Program.cs", replace "YOUR_BOT_TOKEN" with your bot token (surrounded by quote marks).

Step 2: If you want to restrict the ability to add quotes to only users with a certain role in your server, you must replace YOUR_ROLE_ID with the number that is the role ID you want. (If you don't know this number, go into your User Settings on Discord, go into Appearance, and enable Developer Mode. Then in your server, mention the role you want to apply it to, and right click your message to copy the role ID to your clipboard.) If you don't want to restrict this function, follow the instructions in program.cs to remove this requirement.

Step 3: Find the txt file where your mIRC bot stores quotes and replace every instance of @"path\to\your\quotes\textfile.txt" with the full system directory to the quotes file. This will usually be in the directory where your mIRC.exe is located.

Step 4: Build or run the project in Microsoft Visual Studio 2017.

Then people with the right permissions can use **!addquote *text to add*** to save quotes, and others can use **!quote** to get a random quote or **!quote *text to search*** to get a random quote matching a search phrase.