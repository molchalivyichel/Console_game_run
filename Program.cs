namespace Go_Space
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Vector> _List_Objects = new();

            Vector SizeSpace = new(9, 9); //Размер Space

            Player _Player = new(new(0, 0)); // Игрок

            Enemy _Enemy = new(new(SizeSpace.x - 1, SizeSpace.y - 1)); // Враг

            Space _Space = new(SizeSpace, _List_Objects); //Пространство (Размер, лист объектов)

            Money _Money = new(_Space); // Монетка

            _List_Objects.Add(_Player.Mesto);
            _List_Objects.Add(_Enemy.Mesto);
            _List_Objects.Add(_Money.Mesto);

            int _moneyCount = 0;

            while (_Player.Live == true) //Цикл для бесконечного хождения по полю
            {

                string[,] space = _Space.Edit_Space(_Enemy, _Player, _Money); //Вызов измененного Space

                for (int i = 0; i < _Space.Size.x; i++)
                {
                    for (int j = 0; j < _Space.Size.y; j++)
                    {
                        if (space[j, i] == "XX")
                        {
                            Console.ForegroundColor = ConsoleColor.Red; //Чтобы враг выделялся красным
                        }
                        else if (space[j, i] == "@@")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow; //Чтобы игрок выделялся желтым
                        }
                        else if (space[j, i] == "MM")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan; //Чтобы монетка выделялся желтым
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green; //Чтобы пустые поля были зелеными
                        }
                        Console.Write(space[j, i]);
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White; //Обнуление цвета


                if (_Player.LiveOrDead(_Enemy) == false) //Проверка на жизнь
                {
                    break;
                }
            }
            Console.WriteLine("Вы проиграли...");
            Console.ReadLine();

        }
    }
}