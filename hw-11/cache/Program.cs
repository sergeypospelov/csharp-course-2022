// See https://aka.ms/new-console-template for more information

using cache;

void Test()
{
    var cache = new Cache<int, DisposableResource>(maxSize: 5, maxUseTime: 3);
    cache[1] = new DisposableResource(1);
    cache[2] = new DisposableResource(2);
    cache[3] = new DisposableResource(3);
    cache[4] = new DisposableResource(4);
    cache[1] = new DisposableResource(1);
    cache[5] = new DisposableResource(5);
    cache[6] = new DisposableResource(6);
}

Test();
GC.Collect();
GC.Collect();
GC.Collect();
GC.Collect();
