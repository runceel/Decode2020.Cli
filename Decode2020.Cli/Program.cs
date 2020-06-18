using Decode2020.Cli.Apis;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Decode2020.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowUsage();
                return;
            }

            await ExecuteAsync(args);
        }

        private static async Task ExecuteAsync(string[] args)
        {
            switch ((args[0], args.ElementAtOrDefault(1)))
            {
                case ("list", var keyword): await ShowSessionList(keyword); break;
                case ("show", var sessionId): await ShowSession(sessionId); break;
                default: ShowUsage(); break;
            };
        }

        private static async Task ShowSession(string sessionId)
        {
            var c = new Client(new HttpClient());
            var sessions = await c.GetSessionsAsync();
            var session = sessions.FirstOrDefault(x => x.Code.ToLower(CultureInfo.InvariantCulture) == sessionId.ToLower(CultureInfo.InvariantCulture));
            if (session != null)
            {
                Console.WriteLine($"{session.Title} をブラウザーで表示します。");
                Process.Start(new ProcessStartInfo($"https://decode20-vevent.cloud-config.jp/session/{session.Id}")
                {
                    UseShellExecute = true,
                });
            }
            else
            {
                Console.WriteLine("見つかりませんでした");
            }
        }

        private static async Task ShowSessionList(string keyword)
        {
            var c = new Client(new HttpClient());
            var sessions = await c.GetSessionsAsync();
            foreach (var session in sessions.Where(x => string.IsNullOrWhiteSpace(keyword) || x.Title.Contains(keyword)))
            {
                PrintSession(session);
            }
        }

        private static void PrintSession(Anonymous session)
        {
            Console.WriteLine($"Session ID: {session.Code}, {session.Level.Name.Substring(0, session.Level.Name.IndexOf("-")).Trim()}, ステータス: {(session.Status == "OPEN" ? "公開中" : "準備中")}, タイトル: {session.Title}");
        }

        private static void ShowUsage()
        {
            var versionString = Assembly.GetEntryAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion
                .ToString();

            Console.WriteLine($"decode20 v{versionString}");
            Console.WriteLine("-------------");
            Console.WriteLine("\nUsage:");
            Console.WriteLine("  decode20 show a01");
            Console.WriteLine("  decode20 list");
            Console.WriteLine("  decode20 list Xamarin");
            return;
        }
    }
}
