// See https://aka.ms/new-console-template for more information

using System.Collections.Immutable;

double Process(string path, int threadsCount)
{
    var files = Directory.GetFiles(path).Where(file => !file.EndsWith("out.dat")).ToList();
    var filesCount = files.Count;
    var chunkSize = (filesCount + threadsCount - 1) / threadsCount;
    var chunks = files.Chunk(chunkSize);

    object mutex = new();
    var result = 0.0;
    
    var threads = chunks.Select(chunk =>
    {
        var thread = new Thread(_ =>
        {
            foreach (var path in chunk)
            {
                var reader = File.OpenText(path);
                var action = int.Parse(reader.ReadLine() ?? "1");
                var args = reader.ReadLine()?.Split(" ").Select(double.Parse) ?? new List<double>();

                var res = action switch
                {
                    1 => args.Sum(),
                    2 => args.Aggregate(1.0, (was, x) => was * x),
                    3 => args.Select(x => x * x).Sum(),
                    _ => 0.0,
                };
                
                lock (mutex)
                {
                    result += res;
                }
            }
        });

        thread.Start();
        return thread;
    });

    foreach (var thread in threads)
    {
        thread.Join();
    }

    return result;
}

var res = Process("./data", 4);
var file = File.CreateText("./data/out.dat");
file.WriteLine(res);
file.Flush();