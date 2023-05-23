using FightPigs.Main.Model;
using FightPigs.Main.Persistance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Windows.Forms;

namespace FightPigs.Test
{
    [TestClass]
    public class pigsTest
    {
        private pigsModel? _model;
        private gameTable? _mockedTable;
        private Mock<IFightPigsDataAccess>? _mock;

        [TestInitialize]
        public void Initialize()
        {
            _mockedTable = new gameTable(6);
            Queue<Keys> red = new Queue<Keys>();
            Queue<Keys> blue = new Queue<Keys>();

            _mock = new Mock<IFightPigsDataAccess>();
            _mock.Setup(mock => mock.LoadAsync(It.IsAny<string>())).Returns(() => Task.FromResult(_mockedTable));

            _model = new pigsModel(_mock.Object);

            _model.GameAdvanced += new EventHandler<pigsEventArgs>(Model_GameAdvanced);
        }

        [TestMethod]
        public void PigsModelNewGameBig()
        {
            _model.Size = size.Big;
            _model.NewGame();

            Assert.AreEqual(size.Big, _model.Size);
            Assert.AreEqual(8, _model.GameTable.Size);

            Assert.AreEqual((4, 0), _model.GameTable.GetPlayer(1));
            Assert.AreEqual((3, 7), _model.GameTable.GetPlayer(2));
        }

        [TestMethod]
        public void PigsModelBaseConstruct()
        {
            Assert.AreEqual(size.Medium, _model.Size);
            Assert.AreEqual(6, _model.GameTable.Size);

            Assert.AreEqual((3, 0), _model.GameTable.GetPlayer(1));
            Assert.AreEqual((2, 5), _model.GameTable.GetPlayer(2));
        }

        [TestMethod]
        public void PigsModelNewGameSmall()
        {
            _model.Size = size.Small;
            _model.NewGame();

            Assert.AreEqual(size.Small, _model.Size);
            Assert.AreEqual(4, _model.GameTable.Size);

            Assert.AreEqual((2, 0), _model.GameTable.GetPlayer(1));
            Assert.AreEqual((1, 3), _model.GameTable.GetPlayer(2));
        }

        [TestMethod]
        public void PigsModelStep()
        {
            Assert.AreEqual(size.Medium, _model.Size);

            Assert.AreEqual(_model.GameTable[3, 0], gameTable.Direction.Down);
            Assert.AreEqual(_model.GameTable[2, 5], gameTable.Direction.Up);

            Queue<Keys> red = new Queue<Keys>(), blue = new Queue<Keys>();

            red.Enqueue(Keys.Up);
            red.Enqueue(Keys.Up);
            red.Enqueue(Keys.Left);
            red.Enqueue(Keys.R);
            red.Enqueue(Keys.Down);

            blue.Enqueue(Keys.Down);
            blue.Enqueue(Keys.Q);
            blue.Enqueue(Keys.Left);
            blue.Enqueue(Keys.Up);
            blue.Enqueue(Keys.Q);

            _model.GameTable.Step(red, blue);

            Assert.AreEqual(_model.GameTable[5, 2], gameTable.Direction.Left);
            Assert.AreEqual(_model.GameTable[1, 5], gameTable.Direction.Down);
        }

        [TestMethod]
        public void KeyInputHandler()
        {
            _model.NewGame();

            _model.KeyInputHandler(Keys.Up);
            _model.KeyInputHandler(Keys.Down);
            _model.KeyInputHandler(Keys.W);

            Keys[] test = {Keys.Up, Keys.Down, Keys.W};
            Keys[] red = _model.Keys.Item1.ToArray();

            for( int i = 0; i < test.Length; i++ )
                Assert.AreEqual(test[i], red[i]);

            _model.KeyInputHandler(Keys.Q);
            _model.KeyInputHandler(Keys.Down);
            _model.KeyInputHandler(Keys.Left);

            Keys[] test2 = { Keys.Left };
            Keys[] blue = _model.Keys.Item2.ToArray();

            for( int i = 0; i < test2.Length; i++)
                Assert.AreEqual(test2[i], blue[i]);
        }

        [TestMethod]
        public void HPLoss()
        {
            _model.NewGame();
            
            Queue<Keys> redStep = new Queue<Keys>();
            redStep.Enqueue(Keys.R);
            redStep.Enqueue(Keys.Up);
            redStep.Enqueue(Keys.Q);
            redStep.Enqueue(Keys.W);
            redStep.Enqueue(Keys.Up);

            Queue<Keys> blueStep = new Queue<Keys>();
            blueStep.Enqueue(Keys.Up);
            blueStep.Enqueue(Keys.Up);
            blueStep.Enqueue(Keys.Up);
            blueStep.Enqueue(Keys.Up);
            blueStep.Enqueue(Keys.E);

            _model.GameTable.Step(redStep, blueStep);

            Assert.AreEqual((2, 2), _model.GameTable.Health);
        }

        [TestMethod]
        public void GameOver()
        {
            _model.NewGame();

            Queue<Keys> redStep = new Queue<Keys>();
            redStep.Enqueue(Keys.R);
            redStep.Enqueue(Keys.Up);
            redStep.Enqueue(Keys.Q);
            redStep.Enqueue(Keys.W);
            redStep.Enqueue(Keys.W);

            Queue<Keys> blueStep = new Queue<Keys>();
            blueStep.Enqueue(Keys.W);
            blueStep.Enqueue(Keys.W);
            blueStep.Enqueue(Keys.W);
            blueStep.Enqueue(Keys.W);
            blueStep.Enqueue(Keys.W);

            _model.GameTable.Step(redStep, blueStep);

            Assert.AreEqual((0, 2), _model.GameTable.Health);
            Assert.AreEqual(2, _model.whoWon);
        }

        public void Model_GameAdvanced(object? sender, pigsEventArgs e)
        {
            
            Assert.IsTrue(((e.whoWon == 1 || e.whoWon == 2 || e.whoWon == 3) && e.stepsOver) || (e.whoWon == 0 && !e.stepsOver));
        }
    }
}