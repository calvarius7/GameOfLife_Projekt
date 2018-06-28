using Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife_Projekt
{
    public class CellBuilder
    {
        private GameMaster gameMaster;
       public GameMaster GameMaster { get => this.gameMaster; set => gameMaster = value; }


        public CellBuilder(GameMaster gameMaster)
        {
            GameMaster = gameMaster;
        }

       public void BuildCells(Form form, Panel start)
        {
            int row = gameMaster.CubeSize;
            while (row > 0)
            {
                int col = gameMaster.CubeSize;
                while (col > 0)
                {
                    CreateOneCell(form, start, row, col);
                    col--;
                }
                row--;
            }
            gameMaster.GetNeighborhood();
        }

        private void CreateOneCell(Form form, Panel start, int row, int col)
        {
            GameCell cell = new GameCell(row, col)
            {
                Size = start.Size,
                BorderStyle = start.BorderStyle
            };
            cell.Location = new Point(start.Location.X + col * cell.Size.Width, start.Location.Y + row * cell.Size.Width);
            cell.Click += new EventHandler(((Form1)form).gameCell_Click);
            cell.MouseHover += new EventHandler(((Form1)form).gameCell_Hover);

            form.Controls.Add(cell);
            gameMaster.addCells(cell);
            
        }
    }
}
