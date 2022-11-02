using System.Text;

string Merge(string s1, string s2)
{
    var ans = new List<String>();

    var strs1 = s1.Split(" ");
    var strs2 = s2.Split(" ");

    var ptr1 = 0;
    var ptr2 = 0;

    while (ptr1 < strs1.Length && ptr2 < strs2.Length)
    {
        if (strs1[ptr1].Equals(strs2[ptr2]))
        {
            ans.Add(strs1[ptr1]);
            
            ptr1++;
            ptr2++;
            continue;
        }


        bool ok = false;
        for (int i = ptr2 + 1; i < strs2.Length; i++)
        {
            if (strs1[ptr1] == strs2[i])
            {
                while (ptr2 <= i)
                {
                    ans.Add(strs2[ptr2++]);
                }

                ok = true;
                break;
            }
        }

        if (!ok)
        {
            ans.Add(strs1[ptr1]);
        }
        ptr1++;
    }

    while (ptr1 < strs1.Length)
    {
        ans.Add(strs1[ptr1++]);
    }

    while (ptr2 < strs2.Length)
    {
        ans.Add(strs2[ptr2++]);
    }
    
    return string.Join(" ", ans);
}

var examples = new[]
{
    new[] { "Шла Маша по шоссе пешком", "Шла Саша по горе" },
    new[] { "a b c d e f h", "a d e f g h" },
};

foreach (var example in examples)
{
    var str1 = example[0];
    var str2 = example[1];
    var res = Merge(str1, str2);
    
    Console.OutputEncoding = Encoding.UTF8;

    Console.Out.WriteLine($"{str1} + {str2} = {res}");
}