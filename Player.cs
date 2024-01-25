namespace Go_Space
{
    internal class Player
    {
        private Vector _mesto; //Место 

        private bool _live = true; //Жизнь
        public Vector Mesto => _mesto; //Расположение
        public bool Live => _live; //Жизнь
        public Player(Vector mesto)
        {
            _mesto = mesto;
        }

        public Vector PlayerGo(Vector size) //Метод передвижения игрока
        {
            ConsoleKey knopka = Console.ReadKey().Key;

            Console.Clear(); //Чтобы не было видно, что ввели и предыдущих полей

            if (knopka == ConsoleKey.W) //Идет вверх на 1 клетку
            {
                if (_mesto.y > 0) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.y -= 1;
                }
            }
            else if (knopka == ConsoleKey.S) //Идет вниз на 1 клетку
            {
                if (_mesto.y < size.y - 1) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.y += 1;
                }
            }
            else if (knopka == ConsoleKey.A) //Идет влево на 1 клетку
            {
                if (_mesto.x > 0) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.x -= 1;
                }
            }
            else if (knopka == ConsoleKey.D) //Идет вправо на 1 клетку
            {
                if (_mesto.x < size.x - 1) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.x += 1;
                }
            }
            //Console.WriteLine();
            return _mesto; //Возвращает игрока, который двинулся
        }

        public bool LiveOrDead(Enemy Enemy) //Если враг будет на месте игрока, то смерть
        {
            if (_mesto.y == Enemy.Mesto.y && _mesto.x == Enemy.Mesto.x)
            {
                return _live = false;
            }
            return _live = true;
        }
    }
}
