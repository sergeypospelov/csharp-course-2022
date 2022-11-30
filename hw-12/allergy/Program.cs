// See https://aka.ms/new-console-template for more information

using allergy;

var alls = new[]
{
    new Allergies("Mary"),
    new Allergies("Joe", 65),
    new Allergies("Rob", "Peanuts Chocolate Cats Strawberries")
};

foreach (var person in alls)
{
    Console.Out.WriteLine(person.Name);
    Console.Out.WriteLine(person.ToString());
}

alls[0].AddAllergy("Eggs");
alls[1].DeleteAllergy("Peanuts");
Console.Out.WriteLine("Is Rob allergic to chocolate: " + alls[2].IsAllergicTo("Chocolate"));
alls[2].DeleteAllergy(Allergen.Cats);

foreach (var person in alls)
{
    Console.Out.WriteLine(person.ToString());
}