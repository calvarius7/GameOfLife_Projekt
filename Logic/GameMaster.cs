using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Logic
{
    public class GameMaster
    {
        private BackgroundWorker backgroundWorker;
        public List<GameCell> Cells { get; }
        public int CubeSize { get; set; }
        public Statistics Statistics { get; set; }

        public GameMaster(int cubeSize)
        {
            CubeSize = cubeSize;
            Cells = new List<GameCell>();
            InitBackGroundWorker();
        }

        /**
         * Start a GameOfLife - run
         * runs as async-background until cancellation
         */
        public bool Start()
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
                return true;
            }
            return false;
        }

        /**
         * Remove all living cells, set statistics to zero
         * Not possible if GameOfLife runs
         */
        public void Reset()
        {
            if (!backgroundWorker.IsBusy)
            {
                foreach (GameCell cell in Cells)
                {
                    cell.IsDead();
                }
                if (Statistics != null)
                {
                    Statistics.SetZero();
                }
            }
        }

        /**
         * Stops the current run of GameOfLife
         */
        public bool Stop()
        {
            if (backgroundWorker.WorkerSupportsCancellation)
            {
                // Cancel the asynchronous operation.
                backgroundWorker.CancelAsync();
                return true;

            }
            return false;
        }

        /**
         * Toggles live/dead of a selected cell
         * Not possible if GameOfLife runs
         */
        public void SelectCell(GameCell cell)
        {
            if (!backgroundWorker.IsBusy)
            {
                if (!cell.Alive)
                {
                    cell.IsAlive();
                }
                else
                {
                    cell.IsDead();
                }
            }
        }
        //Add a cell to the population
        public void AddCells(GameCell cell)
        {
            Cells.Add(cell);
        }
        /**
         * Start GameOfLife-instance
         * Start Game
         */
        public void GameOfLife()
        {
            GameOfLife game = new GameOfLife();
            game.Play(Cells);
        }

        /**
         * Set all neighbors for every cell in the population
         */ 
        public void GetNeighborhood()
        {
            foreach (GameCell cell in Cells)
            {
                SetNeighbors(cell);
            }
        }

        /**
         * Returns a cell from the population by its coordinates
         */
        public GameCell FindByRowAndCol(int row, int col)
        {
            return Cells.Select(cell => cell).First(cell => cell.Row == row && cell.Col == col);
        }

        private void InitBackGroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int runs = 0;
            while (!worker.CancellationPending)
            {
                GameOfLife();
                System.Threading.Thread.Sleep(100);
                worker.ReportProgress(++runs);
            }
            e.Cancel = true;
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Statistics != null)
            {
                Statistics.Generation++;
                Statistics.CurrentlyLiving = Cells.Count(cell => cell.Alive);
                Statistics.ShowStats();
            }
        }

        private void SetNeighbors(GameCell cell)
        {
            int rowAbove = IndexDown(cell.Row);
            int rowBelow = IndexUp(cell.Row);
            int colRight = IndexUp(cell.Col);
            int colLeft = IndexDown(cell.Col);

            List<GameCell> neighbors = new List<GameCell>
            {
                FindByRowAndCol(rowAbove, colLeft),
                FindByRowAndCol(rowAbove, cell.Col),
                FindByRowAndCol(rowAbove, colRight),

                FindByRowAndCol(cell.Row, colLeft),
                FindByRowAndCol(cell.Row, colRight),

                FindByRowAndCol(rowBelow, colLeft),
                FindByRowAndCol(rowBelow, cell.Col),
                FindByRowAndCol(rowBelow, colRight)
            };

            cell.Neighbors = neighbors;
        }

        private int IndexUp(int start)
        {
            int index = start + 1;
          
            return index > CubeSize ? 1 : index;
        }

        private int IndexDown(int start)
        {
            int index = start - 1;
          
            return index < 1 ? CubeSize : index;
        }
    }
}
