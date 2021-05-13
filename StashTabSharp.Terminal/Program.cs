using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace StashTabSharp.Terminal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var stashClient = new StashTabClient();
            await foreach(var stashSet in stashClient.GetAsyncDataStream())
            {
                //var itemsQuerySyntax = from Stashes in stashSet.Stashes
                //                       from item in Stashes.Items
                //                       where item.Name == "Headhunter"
                //                       select item;

                //var itemsLinqSyntax = stashSet.Stashes
                //    .SelectMany(stash => stash.Items
                //    .Where(item => item.Name == "Headhunter"));

                Console.WriteLine($"Retreived stash: {stashSet.NextChangeId}");

                foreach(var stash in stashSet.Stashes)
                {
                    foreach (var item in stash.Items)
                    {
                        if (item.Name == "Headhunter")
                        //if (item.Name == "Headhunter")
                        {
                            // Do whatever you want when found
                            Console.WriteLine("Item found");
                            Console.WriteLine($"Item ID: {item.Id}");
                            Console.WriteLine($"Item Name: {item.Name}");
                            Console.WriteLine($"Item Type Line: {item.TypeLine}");
                            Console.WriteLine($"Item Note: {item.Note}");
                            Console.WriteLine($"Stash Name: {stash.StashName}");
                            Console.WriteLine($"Stash Type: {stash.StashType}");
                        }
                    }
                }
            }
        }
    }
}
