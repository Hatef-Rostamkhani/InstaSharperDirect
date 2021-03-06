﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper.API.Builder;
using InstaSharper.Classes;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
            Console.ReadKey();
        }

        public static async Task MainAsync(string[] args)
        {
            var api =
               InstaApiBuilder.CreateBuilder()
                   .SetUser(new UserSessionData() { UserName = "advshop08", Password = "z09@rtBN!" }) // "qweQWE123!@#"
                   .SetRequestDelay(TimeSpan.FromSeconds(3))
                   .Build();

            var login = await api.LoginAsync();
            if (!login.Succeeded)
                throw new Exception(login.Info.Message);

            //var user = await api.GetCurrentUserAsync();
            //if (!user.Succeeded)
            //    throw new Exception(user.Info.Message);

            var directInbox = await api.GetDirectInboxAsync();
            if (!directInbox.Succeeded)
                throw new Exception(directInbox.Info.Message);

            var threads = directInbox.Value.Inbox.Threads;

            //if (threads == null || threads.Count == 0)
            //    return;

            //foreach (var thread in threads.Where(x => !x.IsSpam))
            //{
            //    var th = await api.GetDirectInboxThreadAsync(thread.ThreadId);
            //    if (!th.Succeeded)
            //        continue;

            //    foreach (var message in th.Value.Items)
            //    {
            //        Console.WriteLine(message.Text);
            //    }
            //}

            var medias = await api.GetUserMediaByPkAsync(6157611363, PaginationParameters.MaxPagesToLoad(1));
            if (!medias.Succeeded)
                return;

            //var result = await api.SendDirectMessage("6157611363", null, "test123");
            //if (result.Succeeded)
            //{
            //    var thread = result.Value[0];

            //    //thread.ThreadId
            //    //thread.Title
            //    //thread.Items[0].ItemId
            //}

        }
    }
}
