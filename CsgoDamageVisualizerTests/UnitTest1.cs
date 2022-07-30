using System.Text.Json;

namespace CsgoDamageVisualizerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            String json = File.ReadAllText(@"C:\SteamLibrary\steamapps\common\Counter-Strike Global Offensive\csgo\scripts\items\items_game.txt");
            JsonDocument itemsGame = JsonDocument.Parse(json);

            Assert.IsNotNull(itemsGame);
        }
    }
}