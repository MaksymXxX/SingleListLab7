using SingleList;
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SingleLinkedList list = new SingleLinkedList();

        Console.WriteLine("Введіть значення елементів списку (для завершення введіть порожній рядок):");
        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                break;

            if (short.TryParse(input, out short value))
            {
                list.AddAfterFirst(value);
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть числове значення.");
            }
        }

        Console.Write("Поточний список: ");
        list.PrintList();

        Console.Write("Введіть значення для знаходження першого входження елементу більше цього значення: ");
        if (short.TryParse(Console.ReadLine(), out short threshold))
        {
            Node? foundNode = list.FindFirstGreaterThan(threshold);
            Console.Write("Перше входження елементу більше {0}: ", threshold);
            if (foundNode != null)
            {
                Console.WriteLine(foundNode.Data);
            }
            else
            {
                Console.WriteLine("Не знайдено елементу списку, що більше {0}.", threshold);
            }
        }
        else
        {
            Console.WriteLine("Будь ласка, введіть коректне числове значення.");
        }

        Console.Write("Сума елементів більших за середнє значення: ");
        Console.WriteLine(list.SumGreaterThanAverage());

        Console.Write("Новий список зі значень елементів менших за середнє значення: ");
        SingleLinkedList newList = list.GetListLessThanAverage();
        newList.PrintList();

        list.RemoveElementsAfterMax();
        Console.Write("Список після видалення елементів, що розташовані після максимального: ");
        list.PrintList();

        Console.WriteLine("Використання індексатора для доступу до елементів списку:");
        try
        {
            Console.WriteLine("Елемент за індексом 0: " + list[0]);
            Console.WriteLine("Елемент за індексом 1: " + list[1]);
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
