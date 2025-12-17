using System;
using System.Threading;

Console.Clear();
Console.CursorVisible = false;

int frame = 0;

while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"glitch-visualizer running | frame {frame++}");
    Thread.Sleep(1000 / 60); // 60 FPS heartbeat
}
