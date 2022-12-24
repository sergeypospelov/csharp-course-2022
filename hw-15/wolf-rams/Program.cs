// See https://aka.ms/new-console-template for more information

const int minDelay = 500;
const int maxDelay = 1000;

Random rng = new();
var directions = new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

var ramId = 0;
var rams = new HashSet<int>();
var ramToPosition = new Dictionary<int, (int, int)>();

(int, int) wolfPosition;

object mapLock = new();

bool CheckInside(int mapSize, (int, int) pos)
{
    return 0 <= pos.Item1 && pos.Item1 < mapSize && 0 <= pos.Item2 && pos.Item2 < mapSize;
}

bool MoveRam(int mapSize, int id, (int, int) newPos)
{
    Console.Out.WriteLine($"Ram {id} moves to {newPos}");
    if (newPos == wolfPosition)
    {
        Console.Out.WriteLine($"Ram {id} was killed by the Wolf");
        rams.Remove(id);
        ramToPosition.Remove(id);
        return true;
    }

    if (ramToPosition.ContainsValue(newPos))
    {
        var newId = ramId++;
        rams.Add(newId);
        ramToPosition.Add(newId, newPos);

        var ramThread = new Thread(() => RamAction(mapSize, newId));
        ramThread.Start();

        Console.Out.WriteLine($"Ram <{newId}> was born in the cell {newPos}");
    }

    ramToPosition[id] = newPos;

    return false;
}

void RamAction(int mapSize, int id)
{
    while (true)
    {
        (int, int) newPos;
        (int, int) oldPos;
        lock (mapLock)
        {
            if (!rams.Contains(id))
            {
                return;
            }
            oldPos = ramToPosition[id];
        }

        do
        {
            var dir = directions[rng.Next(8)];
            newPos = (oldPos.Item1 + dir.Item1, oldPos.Item2 + dir.Item2);
        } while (!CheckInside(mapSize, newPos));

        var delay = rng.Next(minDelay, maxDelay);
        Thread.Sleep(delay);

        lock (mapLock)
        {
            if (!rams.Contains(id))
            {
                return;
            }

            var dead = MoveRam(mapSize, id, newPos);

            if (dead)
            {
                return;
            }
        }
    }
}

void MoveWolf((int, int) newPos)
{
    Console.Out.WriteLine($"The Wolf moves to {newPos}");
    var ids = ramToPosition
        .Where(it => it.Value == newPos)
        .Select(it => it.Key);
    foreach (var id in ids)
    {
        ramToPosition.Remove(id);
        rams.Remove(id);
        Console.Out.WriteLine($"Ram {id} was killed by the Wolf");
    }

    wolfPosition = newPos;
}

void WolfAction(int mapSize)
{
    while (true)
    {
        lock (mapLock)
        {
            (int, int) newPos;
            var oldPos = wolfPosition;
            do
            {
                var dir = directions[rng.Next(8)];
                newPos = (oldPos.Item1 + dir.Item1, oldPos.Item2 + dir.Item2);
            } while (!CheckInside(mapSize, newPos));

            var delay = rng.Next(minDelay, maxDelay);
            Thread.Sleep(delay);

            lock (mapLock)
            {
                MoveWolf(newPos);
            }
        }
    }
}

void Simulate(int mapSize)
{
    for (int i = 0; i < 3; i++)
    {
        var newId = ramId++;
        
        var pos = (rng.Next(mapSize), rng.Next(mapSize));
        while (ramToPosition.ContainsValue(pos))
        {
            pos = (rng.Next(mapSize), rng.Next(mapSize));
        }

        rams.Add(newId);
        ramToPosition[newId] = pos;

        Console.Out.WriteLine($"Ram <{newId}> was born in the cell {pos}");
    }

    wolfPosition = (rng.Next(mapSize), rng.Next(mapSize));
    while (ramToPosition.ContainsValue(wolfPosition))
    {
        wolfPosition = (rng.Next(mapSize), rng.Next(mapSize));
    }

    Console.Out.WriteLine($"The Wolf spawned in the cell {wolfPosition}");


    for (int i = 0; i < 3; i++)
    {
        var i1 = i;
        var ram = new Thread(() => RamAction(mapSize, i1));
        ram.Start();
    }

    var wolf = new Thread(() => WolfAction(mapSize));
    wolf.Start();
}

Simulate(4);