namespace allergy;

public class Allergies
{
    public readonly string Name;
    private int _mask;

    public Allergies(string name)
    {
        Name = name;
        _mask = 0;
    }

    public Allergies(string name, int mask)
    {
        Name = name;
        _mask = mask;
    }

    public Allergies(string name, string allergens)
    {
        Name = name;
        var names = allergens.Split(" ").Select(f => f.ToLower()).ToHashSet();
        foreach (var enumType in Enum.GetValues<Allergen>())
        {
            if (names.Contains(Enum.GetName(enumType)!.ToLower()))
            {
                _mask |= 1 << (int)enumType;
            }
        }
    }

    public int Score
    {
        get
        {
            int res = 0;
            for (int b = 0; b < Enum.GetValues<Allergen>().Length; b++)
            {
                if ((_mask >> b & 1) != 0)
                {
                    res += 1 << b;
                }
            }

            return res;
        }
    }

    public bool IsAllergicTo(Allergen allergen) =>
        (_mask >> (int)allergen & 1) != 0;

    public bool IsAllergicTo(string allergen) =>
        IsAllergicTo(AllergenFromString(allergen));

    public void AddAllergy(Allergen allergen) =>
        _mask |= 1 << (int)allergen;

    public void AddAllergy(string allergen) =>
        AddAllergy(AllergenFromString(allergen));

    private static Allergen AllergenFromString(string allergen) =>
        Enum.GetValues<Allergen>()
            .First(it => Enum.GetName(it)!.ToLower() == allergen.ToLower());

    public void DeleteAllergy(Allergen allergen) =>
        _mask &= ~(1 << (int)allergen);

    public void DeleteAllergy(string allergen) =>
        DeleteAllergy(AllergenFromString(allergen));

    public override string ToString()
    {
        if (_mask == 0)
        {
            return $"{Name} has no allergies.";
        }

        var allergiesStr = "";
        foreach (var allergen in Enum.GetValues<Allergen>())
        {
            if ((_mask >> (int)allergen & 1) != 0)
            {
                var allergenStr = Enum.GetName(allergen)!.ToLower();
                allergiesStr += allergenStr + ", ";
            }
        }

        allergiesStr = allergiesStr.Remove(allergiesStr.Length - 2, 2); // remove last ", "

        return $"{Name} has these allergies: " + allergiesStr + ".";
    }
}