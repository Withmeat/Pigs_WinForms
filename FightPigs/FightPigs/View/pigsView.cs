using FightPigs.Main.Model;
using FightPigs.Main.Persistance;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FightPigs.Main.View
{
    public partial class pigsView : Form
    {
        private pigsModel _model;
        private sizeDialog _sizeChanger;
        private FightPigsDataAccess _dataAccess;

        private Pen myPen = new Pen(Color.Black);
        private Graphics? g;
        private List<Point[]> TableLines = new List<Point[]>();
        private (Rectangle, Rectangle) PlayerDots;
        private (Point[], Point[]) PlayerDotsDir;

        public pigsView()
        {
            _sizeChanger = new sizeDialog();
            _dataAccess = new FightPigsDataAccess();
            InitializeComponent();
            _sizeChanger.SendSize += NewTable;
            saveGame.Click += SaveGame;
            loadGame.Click += LoadGame;
            _model = new pigsModel(_dataAccess);
            _model.GameAdvanced += GameAdvanced;
            GenerateTableLines(size.Medium);
            newGame.Click += delegate { _sizeChanger.Show(); };
        }

        private void NewTable(object? sender, sizeEventArgs e)
        {
            GenerateTableLines(e.setSize);
            _sizeChanger.Hide();
        }

        private void GetPlayers()
        {
            int col1, row1, col2, row2;
            gameTable.Direction? dir1, dir2;
            col1 = _model.GameTable.GetPlayer(1).Item1;
            row1 = _model.GameTable.GetPlayer(1).Item2;
            col2 = _model.GameTable.GetPlayer(2).Item1;
            row2 = _model.GameTable.GetPlayer(2).Item2;
            dir1 = _model.GameTable[col1, row1];
            dir2 = _model.GameTable[col2, row2];

            var p1_posX = col1 * canvas.Width / _model.GameTable.Size + (canvas.Width / _model.GameTable.Size / 2);
            var p1_posY = row1 * canvas.Height / _model.GameTable.Size + (canvas.Height / _model.GameTable.Size / 2);
            var p2_posX = col2 * canvas.Width / _model.GameTable.Size + (canvas.Width / _model.GameTable.Size / 2);
            var p2_posY = row2 * canvas.Height / _model.GameTable.Size + (canvas.Height / _model.GameTable.Size / 2);

            int p1_Xmod = 0, p1_Ymod = 0, p2_Xmod = 0, p2_Ymod = 0;
            switch(dir1)
            {
                case gameTable.Direction.Right: p1_Xmod = 15; break;
                case gameTable.Direction.Left: p1_Xmod = -15; break;
                case gameTable.Direction.Up: p1_Ymod = -15; break;
                case gameTable.Direction.Down: p1_Ymod = 15; break;
            }
            switch (dir2)
            {
                case gameTable.Direction.Right: p2_Xmod = 15; break;
                case gameTable.Direction.Left: p2_Xmod = -15; break;
                case gameTable.Direction.Up: p2_Ymod = -15; break;
                case gameTable.Direction.Down: p2_Ymod = 15; break;
            }

            PlayerDotsDir.Item1 =
                new Point[]
                {
                    new Point(p1_posX, p1_posY),
                    new Point(p1_posX + p1_Xmod, p1_posY + p1_Ymod)
                };

            PlayerDotsDir.Item2 =
                new Point[]
                {
                    new Point(p2_posX, p2_posY),
                    new Point(p2_posX + p2_Xmod, p2_posY + p2_Ymod)
                };

            PlayerDots.Item1 = new Rectangle(p1_posX - 15, p1_posY - 15, 30, 30);
            PlayerDots.Item2 = new Rectangle(p2_posX - 15, p2_posY - 15, 30, 30);
        }

        private void GenerateTableLines(size k)
        {
            saveGame.Enabled = true;
            _model.Size = k;
            _model.NewGame();
            _sizeChanger.Hide();
            TableLines.Clear();

            GetPlayers();
            int numLines = (_model.GameTable.Size - 1) * 2;
            int size = _model.GameTable.Size;
            g = canvas.CreateGraphics();
            for (int i = 1; i <= numLines / 2; i++)
            {
                Point[] newLine =
                {
                    new Point(0, i * canvas.Height / size),
                    new Point(canvas.Width, i * canvas.Height / size)
                };
                TableLines.Add(newLine);
            }
            for (int i = 1; i <= numLines / 2; i++)
            {
                Point[] newLine =
                {
                    new Point(i * canvas.Width / size, 0),
                    new Point(i * canvas.Width / size, canvas.Height)
                };
                TableLines.Add(newLine);
            }

            statusLabel.Text = $"Jelenleg a {(_model.Player == 0 ? "piros" : "kék")} játékos van soron. | Piros: | Kék: ";
            healthBar.Text = $"Piros: {_model.GameTable.Health.Item1}hp | Kék: {_model.GameTable.Health.Item2}hp";
            canvas.Refresh();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Point[] line in TableLines)
            {
                myPen = new Pen(Color.Black);
                g.DrawLines(myPen, line);
            }

            SolidBrush myBrush;
            myPen = new Pen(Color.Black, 5);
            myBrush = new SolidBrush(Color.Red);
            g.FillEllipse(myBrush, PlayerDots.Item1);
            g.DrawLines(myPen, PlayerDotsDir.Item1);

            myBrush = new SolidBrush(Color.Blue);
            g.FillEllipse(myBrush, PlayerDots.Item2);
            g.DrawLines(myPen, PlayerDotsDir.Item2);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Left ||
                keyData == Keys.Right || keyData == Keys.Q || keyData == Keys.R ||
                keyData == Keys.W || keyData == Keys.E)
            {
                _model.KeyInputHandler(keyData);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GameAdvanced(object? sender, pigsEventArgs e)
        {
            if( e.stepsOver )
            {
                GetPlayers();
                canvas.Refresh();
            }
            
            string redStepsText = "";
            string blueStepsText = "";
            foreach (Keys k in e.redSteps)
                switch (k)
                {
                    case Keys.Up: redStepsText += " \u2191"; break;
                    case Keys.Down: redStepsText += " \u2193"; break;
                    case Keys.Right: redStepsText += " \u2192"; break;
                    case Keys.Left: redStepsText += " \u2190"; break;
                    case Keys.Q: redStepsText += " \u21BA"; break;
                    case Keys.R: redStepsText += " \u21BB"; break;
                    case Keys.W: redStepsText += " \u00A6"; break;
                    case Keys.E: redStepsText += " \u00A4"; break;
                    default: redStepsText += ' ' + k.ToString(); break;
                }
            foreach(Keys k in e.blueSteps)
                switch (k)
                {
                    case Keys.Up: blueStepsText += " \u2191"; break;
                    case Keys.Down: blueStepsText += " \u2193"; break;
                    case Keys.Right: blueStepsText += " \u2192"; break;
                    case Keys.Left: blueStepsText += " \u2190"; break;
                    case Keys.Q: blueStepsText += " \u21BA"; break;
                    case Keys.R: blueStepsText += " \u21BB"; break;
                    case Keys.W: blueStepsText += " \u00A6"; break;
                    case Keys.E: blueStepsText += " \u00A4"; break;
                    default: blueStepsText += ' ' + k.ToString(); break;
                }

            statusLabel.Text = $"Jelenleg a {(_model.Player == 0 ? "piros" : "kék")} játékos van soron. | " + 
                $"Piros: {redStepsText} | Kék: {blueStepsText}";
            healthBar.Text = $"Piros: {_model.GameTable.Health.Item1}hp | Kék: {_model.GameTable.Health.Item2}hp";

            if(e.whoWon != 0)
            {
                MessageBox.Show(e.whoWon == 1 ? "Piros nyert!" : e.whoWon == 2 ? "Kék nyert!" : "Döntetlen!",
                    "Játéknak vége!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GenerateTableLines(_model.Size);
            }
        }

        private async void SaveGame(object? sender, EventArgs e)
        {
            if( saveFileDialog.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    await _model.SaveGameAsync(saveFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Failure during saving game!" + Environment.NewLine + "Wrong path or unwriteable directory.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void LoadGame(object? sender, EventArgs e)
        {
            saveGame.Enabled = true;
            if ( openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await _model.LoadGameAsync(openFileDialog.FileName);
                    GenerateTableLines(size.NoChange);
                    canvas.Refresh();
                }
                catch ( FightPigsDataException )
                {
                    MessageBox.Show("Loading game was unsuccessful!" + Environment.NewLine + "Wrong path or file format.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}