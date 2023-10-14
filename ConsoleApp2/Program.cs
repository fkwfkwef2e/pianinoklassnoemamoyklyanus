using System;

public class Piano
{
    private int[][] octaves;
    private int currentOctave;

    public Piano()
    {
        octaves = new int[][]
        {
            new int[] { 261, 293, 329, 349, 392, 440, 493 }, // первая октава (C, D, E, F, G, A, B)
            new int[] { 523, 587, 659, 698, 784, 880, 988 }, // вторая октава (C, D, E, F, G, A, B)
            new int[] { 1047, 1175, 1319, 1397, 1568, 1760, 1976 } // третья октава (C, D, E, F, G, A, B)
            // и так далее для каждой октавы
        };
        currentOctave = 0; // начинаем с первой октавы
    }

    public void SwitchOctave(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.F1:
                currentOctave = 0;
                break;
            case ConsoleKey.F2:
                currentOctave = 1;
                break;
            case ConsoleKey.F3:
                currentOctave = 2;
                break;
            // добавьте обработку других клавиш для переключения октавы
            default:
                Console.WriteLine("Недопустимая клавиша");
                break;
        }
    }

    public void PlaySound(ConsoleKey key)
    {
        int noteIndex = GetNoteIndex(key);
        if (noteIndex != -1)
        {
            int frequency = octaves[currentOctave][noteIndex];
            Console.WriteLine("Играем ноту с частотой " + frequency + " Гц");
        }
        else
        {
            Console.WriteLine("Недопустимая клавиша");
        }
    }

    private int GetNoteIndex(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.A:
                return 0; // нота C
            case ConsoleKey.S:
                return 1; // нота D
            case ConsoleKey.D:
                return 2; // нота E
            case ConsoleKey.F:
                return 3; // нота F
            case ConsoleKey.G:
                return 4; // нота G
            case ConsoleKey.H:
                return 5; // нота A
            case ConsoleKey.J:
                return 6; // нота B
            // добавьте обработку других клавиш для воспроизведения ноты
            default:
                return -1; // недопустимая клавиша
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Piano piano = new Piano();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }

            piano.SwitchOctave(keyInfo.Key);
            piano.PlaySound(keyInfo.Key);
        }
    }
}