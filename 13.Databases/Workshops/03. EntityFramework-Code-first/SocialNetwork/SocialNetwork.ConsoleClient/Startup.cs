using System.Data.Entity.Migrations;
using MyWebApi.Common.Extensions;
using SocialNetwork.ConsoleClient.Importers;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Searcher;

    public class Startup
    {
        public static void Main()
        {
            var dbContext = new SocialNetworkDbContext();
            var importer = new XmlImporter(dbContext);
            var friendships = importer.ImportFriendshipFromXml("..\\..\\XmlFiles\\Friendships-Test.xml");
            friendships.ForEach(friendship => dbContext.Friendships.Add(friendship));
            dbContext.SaveChanges();
        }
    }
}
