using System.Net.Http.Headers;

namespace Go_Space
{
    internal class Money
    {
        private Vector _mesto; //Место 

        private int _moneyCount = 0;

        public Vector Mesto => _mesto;

        public Money(Space Space)
        {
            _mesto = new(Space.Size.x/2, Space.Size.y / 2);
        }

        public Vector MoneyNew(Player Player, Vector Size) //Объект Монетка
        {
            if (Player.Mesto.x == _mesto.x && Player.Mesto.y == _mesto.y) //Если игрок возьмет монетку, то меняется местоположение монетки
            {
                Console.Beep(); //Звук взятия монетки

                Random rnd = new Random(); //Рандом местоположение

                int y = rnd.Next(0, Size.y - 1);

                int x = rnd.Next(0, Size.x - 1);

                _mesto.y = x;
                _mesto.x = y;

            }
            return _mesto;
        }
        public void PrintMoney(Player Player) //Вывод кол-во монеток (неработает)
        {
            if (Player.Mesto.y == _mesto.y && Player.Mesto.x == _mesto.x)
            {
                _moneyCount += 1;
            }
            Console.WriteLine($"Счёт {_moneyCount} монет(-ок)");
        }
    }
}
