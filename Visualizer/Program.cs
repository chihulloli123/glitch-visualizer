using System;
using System.Threading;

Console.Clear();
Console.CursorVisible = false;

int width = Console.WindowWidth;
int height = Console.WindowHeight;

double t = 0;
Random rng = new Random(1337); // seeded chaos

while (true)
{
    Console.Clear();

    bool glitchFrame = rng.NextDouble() < 0.08; // ~8% glitch chance

    for (int x = 0; x < width; x += 2)
    {
        double baseWave =
            Math.Sin(t + x * 0.15) *
            Math.Sin(t * 0.5);

        // glitch injection
        if (glitchFrame && rng.NextDouble() < 0.15)
        {
            baseWave *= rng.NextDouble() * 4;
        }

        int barHeight = (int)((baseWave + 1) * height / 4);

        // horizontal tear
        int xOffset = glitchFrame ? rng.Next(-6, 6) : 0;
        int drawX = Math.Clamp(x + xOffset, 0, width - 1);

        for (int y = 0; y < barHeight; y++)
        {
            int drawY = height - 1 - y;

            if (drawY >= 0 && drawY < height)
            {
                Console.SetCursorPosition(drawX, drawY);
                Console.Write("█");
            }
        }
    }

    // time distortion
    t += glitchFrame ? 0.25 : 0.08;

    Thread.Sleep(1000 / 60);
}
