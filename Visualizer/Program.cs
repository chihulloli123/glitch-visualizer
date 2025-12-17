using System;
using System.Threading;

Console.Clear();
Console.CursorVisible = false;

int frame = 0;
int width = Console.WindowWidth;
int height = Console.WindowHeight;
double t = 0;

while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.Clear();

    // fake "spectrum"
    for (int x = 0; x < width; x += 2)
    {
        // sine wave pretending to be music
        double value =
            Math.Sin(t + x * 0.15) *
            Math.Sin(t * 0.5);

        int barHeight = (int)((value + 1) * height / 4);

        for (int y = 0; y < barHeight; y++)
        {
            Console.SetCursorPosition(x, height - 1 - y);
            Console.Write("█");
        }
    }

    t += 0.08;      // speed = tempo
    frame++;

    Thread.Sleep(1000 / 60);
}
