using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Player
    {
        private int _length;
        private int[,] _position = new int[3,1];
        private char _simbolPlayer;
        private int _direction;
        private enum WASD
        {
             A = -1,
             W,
             S,
             D
        }
      
        public Player (int _length, int x,int y,char _simbolPlayer,int _direction)
        {
            this._length = _length;
            _position[0, 0] = x;
            _position[1, 0] = y;
            _position[2, 0] = _direction;
            this._simbolPlayer = _simbolPlayer;
            this._direction = _direction;
        }
        private void Resize(ref int[,] arr,int newLength)
        {
            int[,] newArr = new int[arr.GetLength(0),  newLength];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    newArr[i, j] = arr[i, j];
                }
            }
            arr = newArr;
        }
        public void groveSnake()
        {
            _length++;
           
            Resize(ref _position, _length);
            _position[0, _position.GetLength(1) - 1] = _position[0, _position.GetLength(1) - 2];
            _position[1, _position.GetLength(1) - 1] = _position[1, _position.GetLength(1) - 2] + 1;     

        }
        public void moveSnake()
        {
            if (Console.KeyAvailable)
                pressKeys();
            offsetPositionArray();
            switch (_direction) // move head
            {
                case (int)WASD.A: _position[1, 0] -= 1; break;
                case (int)WASD.W: _position[0, 0] -= 1;break;
                case (int)WASD.S: _position[0, 0] += 1; break;
                case (int)WASD.D: _position[1, 0] += 1; break;
                default:
                    break;
            }
           
        }
        
        private void offsetPositionArray()
        {
            for (int i = _position.GetLength(1)-1; i > 0; i--)
            {
                for (int j = 0; j < _position.GetLength(0); j++)
                {
                    _position[j, i] = _position[j, i - 1];
                 
                }
                

            }
        }
        private void pressKeys()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.A) _direction = (int)WASD.A;
            if (key.Key == ConsoleKey.W) _direction = (int)WASD.W;
            if (key.Key == ConsoleKey.S) _direction = (int)WASD.S;
            if (key.Key == ConsoleKey.D) _direction = (int)WASD.D;

        }
        public char getSimbol { get { return _simbolPlayer; } }
        public int getPositionHeadY { get { return _position[0, 0]; } set { _position[0,0] = value; } }
        public int getPositionHeadX { get { return _position[1, 0]; } set { _position[1,0] = value; } }
        public int[,] getArrayOfPosition { get { return _position; } }

    }
}
