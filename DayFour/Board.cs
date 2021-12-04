using System;
using System.Collections.Generic;
using System.Linq;

namespace DayFour
{
    public class Board
    {
        private List<List<Unit>> _board;

        public Board()
        {
            _board = new();
        }

        private Pos GetNumberPos(int number)
        {
            for(int y = 0; y < _board.Count; y++)
            {
                var v = _board[y].FindIndex(x => x.Value == number);
                if(v >= 0){ return new Pos{ XPos = v, YPos = y};}
            }
            return null;
        }

        public int MarkNumber(int number)
        {
            var pos = GetNumberPos(number);

            if(pos == null) return 0;

            _board[pos.YPos][pos.XPos].Marked = true;

            return CheckIfWon();
        }

        private int CheckRow(int i)
        {
            int sum = 0;
            for(int j = 0; j < _board.Count; j++)
            {
                if(!_board[i][j].Marked) return 0;
                sum += _board[i][j].Value;
            }
            return sum;
        }

        private int CheckRows()
        {
            for(int i = 0; i < _board.Count; i++)
            {
                var r = CheckRow(i);
                if(r > 0 ) return r;
            }
            return 0;
        }

        private int CheckColumn(int j)
        {
            int sum = 0;
            for(int i = 0; i < _board.Count; i++)
            {
                if(!_board[i][j].Marked) return 0;
                sum += _board[i][j].Value;
            }
            return sum;
        }

        internal int SumOfEmpty()
        {
            int sum = 0;
            for(int i  = 0; i < _board.Count; i++)
            {
                for(int j = 0; j < _board[i].Count; j++)
                {
                    if(!_board[i][j].Marked)
                    {
                        sum += _board[i][j].Value;
                    }
                }
            }
            return sum;
        }

        private int CheckColumns()
        {
           for(int j = 0; j < _board.Count; j++)
            {
                var r = CheckColumn(j);
                if(r > 0 ) return r;
            }
            return 0;
        }

        public int CheckIfWon()
        {
            var col = CheckColumns();
            return col > 0 ? col : CheckRows();
        }

        public void AddRow(List<string> row)
        {
            row.RemoveAll(x => x == "");
            _board.Add(row.Select(x => new Unit{ Marked = false, Value = Convert.ToInt32(x) }).ToList());
            
        }

    }
}