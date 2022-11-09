using System.Text;

static void Shuffle<T>(IList<T> list, Random rng) 
{  
    int n = list.Count;  
    while (n > 1) {  
        n--;  
        int k = rng.Next(n + 1);  
        (list[k], list[n]) = (list[n], list[k]);
    }  
}

void GenerateRandomNumbers(string fileName, int numbersCount, int width = 8, int maxBuckets = 10_000)
{
    if (numbersCount % maxBuckets != 0)
    {
        throw new ArgumentException();
    } 
    
    var random = new Random();

    using Stream file = new FileStream(fileName, FileMode.Create);

    var bucketsCount = Math.Min(numbersCount, maxBuckets);
    var bucketSize = numbersCount / bucketsCount;
    var bucketSizes = Enumerable.Repeat(bucketSize, bucketsCount).ToArray();

    var randomPermutation = Enumerable.Range(0, bucketSize).ToList();
    Shuffle(randomPermutation, random);


    var nonEmptyBuckets = Enumerable.Range(0, bucketsCount).ToList();


    while (nonEmptyBuckets.Count > 0)
    {
        var bucketIdx = random.Next(nonEmptyBuckets.Count);
        var bucket = nonEmptyBuckets[bucketIdx];

        var randomPermutationIdx = (bucket * 37 + bucketSizes[bucket]) % bucketSize;
        var number = bucket * bucketSize + randomPermutation[randomPermutationIdx];
        
        
        var numberAsString = number.ToString().PadLeft(width, '0') + "\n";
        file.Write(Encoding.ASCII.GetBytes(numberAsString));

        bucketSizes[bucket]--;
        if (bucketSizes[bucket] == 0)
        {
            nonEmptyBuckets[bucketIdx] = nonEmptyBuckets.Last();
            nonEmptyBuckets.RemoveAt(nonEmptyBuckets.Count - 1);
        }
    }
}

GenerateRandomNumbers("random-numbers.txt", 1_000_000, 6, 1_000);