using System;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        private static void createField(char[,] _field)
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    _field[i, j] = ' ';
                }
            }
        }

        private static void showFild(char[,] _field)
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    Console.Write(_field[i, j] +" ");
                }
                Console.WriteLine();
            }
        }

        private static void clearField(char[,] _field, Player snake)
        {
            for (int i = 0; i < _field.GetLength(0); i++)
                for (int j = 0; j < _field.GetLength(1); j++)
                    _field[i, j] = ' ';
        }

        private static void showPosSnake(Player _snake)
        {
            for (int i = 0; i < _snake.getArrayOfPosition.GetLength(0); i++)
            {
                for (int j = 0; j < _snake.getArrayOfPosition.GetLength(1); j++)
                {
                    Console.Write(_snake.getArrayOfPosition[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void drowObject(Player _snake, char[,] _field, Apple apple)
        {
            for (int i = 0; i < _snake.getArrayOfPosition.GetLength(1); i++)
            {
                _field[_snake.getArrayOfPosition[0, i], _snake.getArrayOfPosition[1, i]] = _snake.getSimbol;
            }
            _field[apple.AppleGetY, apple.AppleGetX] = apple.simbol;
        }

        private static void checkCollision(Player _snake, Apple _apple, ref bool game)
        {
            if ((_snake.getPositionHeadX == _apple.AppleGetX) && (_snake.getPositionHeadY == _apple.AppleGetY))
            {
                _apple.generate_X_Y();
                _snake.groveSnake();
                _apple.score++;
            }
            for (int i = 2; i < _snake.getArrayOfPosition.GetLength(1); i++)
            {
                if (_snake.getPositionHeadY == _snake.getArrayOfPosition[0, i]
                    && _snake.getPositionHeadX == _snake.getArrayOfPosition[1, i]) { game = false; };
            }
        }

        private static void checkOutBorder(char[,] _field, Player _snake)
        {
            if (_snake.getPositionHeadX < 0) _snake.getPositionHeadX = _field.GetLength(1) - 1;

            if (_snake.getPositionHeadX > _field.GetLength(1) - 1) _snake.getPositionHeadX = 0;

            if (_snake.getPositionHeadY < 0) _snake.getPositionHeadY = _field.GetLength(0) - 1;

            if (_snake.getPositionHeadY > _field.GetLength(0) - 1) _snake.getPositionHeadY = 0;
        }

        private static void checkOutBorder(char[,] _field, Player _snake, ref bool game)
        {
            if (_snake.getPositionHeadX < 1 || _snake.getPositionHeadX > _field.GetLength(1) - 2 ||
                _snake.getPositionHeadY < 1 || _snake.getPositionHeadY > _field.GetLength(0) - 2)
                game = false;
        }

        private static void showScore(Apple apple)
        {
            Console.Write($"\t\t\t\t\t\tВаш счет: {apple.score}\t\t\t\t\t\t");
        }

        private static void update(char[,] _field, int _speedGame, Player _snake, Apple _apple, ref bool game, int choice)
        {
            checkCollision(_snake, _apple, ref game);
            if (choice == 1)
                checkOutBorder(_field, _snake);
            else checkOutBorder(_field, _snake, ref game);
            // showPosSnake(_snake);
            drowObject(_snake, _field, _apple);
            showFild(_field);
            showScore(_apple);
            _snake.moveSnake();
            clearField(_field, _snake);
            Thread.Sleep(_speedGame);
            Console.Clear();
        }

        private static void Main(string[] args)
        {
            char[,] _field = new char[20, 50];
            int _speedGame = 1;
            Console.WriteLine("0 - проигрыш при столкновении со стенкой || 1-обычный режим");
            int choice = int.Parse(Console.ReadLine());
            createField(_field);
            Player _snake = new Player(1, _field.GetLength(0) / 2, _field.GetLength(1) / 2, 'o', _direction: -1);
            Apple _apple = new Apple();
            _apple.generate_X_Y();
            bool game = true;
            while (game)
                update(_field, _speedGame, _snake, _apple, ref game, choice);
            Console.WriteLine("YOU LOSE HAHAHAHAHAH");
        }
    }
}