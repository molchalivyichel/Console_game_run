namespace Go_Space
{
    internal class Space
    {
        private Vector _size; //Размер 

        private List<Vector> _objects;

        private int _countRun = 0; //Ходы игрока
        public int CountRun => _countRun;

        public Vector Size => _size;

        public Space(Vector size, List<Vector> Objects)
        {
            _size = size;
            _objects = Objects;
        }

        private string[,] Create_Space() //Создание пространства
        {
            string[,] Space = new string[_size.x, _size.y]; //Объявляю Space 

            for (int i = 0; i < _size.x; i++)
            {
                for (int j = 0; j < _size.y; j++)
                {
                    Space[i, j] = "{}"; //Заполнение Space
                }
            }
            return Space;
        }

        public string[,] Edit_Space(Enemy Enemy,Player Player, Money Money) //Добавление объектов в Space
        {
            int count = _objects.Count-2;
            if (_countRun % 50 == 0)
            {
                Create_Enemy(_countRun, Enemy);
            }

            string[,] Space = Create_Space(); //Вызов создания Space

            _objects[0] = Player.PlayerGo(_size); //Выдаем список с измененным местоположением игрока
            Space[_objects[0].x, _objects[0].y] = "@@"; //Изменение местонахождения игрока

            _objects[1] = Enemy.EnemyGo(Player, _size); //Выдаем список с измененным местоположением врага
            Space[_objects[1].x, _objects[1].y] = "XX"; //Изменение местонахождения врага

            _objects[2] = Money.MoneyNew(Player, _size); //Выдаем список с измененным местоположением монеты
            Space[_objects[2].x, _objects[2].y] = "MM"; //Изменение местонахождения монеты

            if (count > 2)
            {
                for (int i = 3; i < _objects.Count; i++)
                {
                    _objects[i] = Enemy.EnemyGo(Player, _size); //Выдаем список с измененным местоположением врага
                    Space[_objects[i].x, _objects[i].y] = "XX"; //Изменение местонахождения врага
                }
            }

            return Space;
        }

        public List<Vector> Create_Enemy(int _countRun, Enemy Enemy)
        {
            Random rnd = new Random(); //Рандом местоположение

            int x = rnd.Next(0, Size.x - 1);

            int y = rnd.Next(0, Size.y - 1);

            Vector Mesto = new(x, y);

            _objects.Add(Enemy.Mesto);

            return _objects;
        }
    }
}
