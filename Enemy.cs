namespace Go_Space
{
    internal class Enemy
    {
        private Vector _mesto; //Место 
        public Vector Mesto => _mesto;
        public Enemy(Vector mesto)
        {
            _mesto = mesto;
        }
        public Vector EnemyGo(Player Player, Vector Size) //Преследование за игроком. Все эти 4 условия, следуют от игрока, если игрок выше, враг поднимается вверх и наоборот
        {
            if (Player.Mesto.y <= _mesto.y)
            {
                if (_mesto.y > 0) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.y -= 1;
                }
            }
            else if (Player.Mesto.y >= _mesto.x)
            {
                if (_mesto.y < Size.y - 1) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.y += 1;
                }
            }
            else if (Player.Mesto.x <= _mesto.x)
            {
                if (_mesto.x > 0) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.x -= 1;
                }
            }
            else if (Player.Mesto.x >= _mesto.x)
            {
                if (_mesto.x < Size.x - 1) //Ограничитель, чтоб не ушел за границу Space
                {
                    _mesto.x += 1;
                }
            }
            //Доделать разум врага по поводу, если игрок будет рядом с границей Space
            return _mesto;
        }
    }
}
