// See https://aka.ms/new-console-template for more information

using FitnessOne.BusinessLogic.Controller;
using FitnessOne.BusinessLogic.Model;

Console.WriteLine("Hello ");
Console.WriteLine("Enter your name");

var name = Console.ReadLine();

var userController = new UserController(name);

var mealController = new MealController(userController.CurrentUser);

if (userController.IsNewUser)
{
    Console.Write("Введите пол: ");
    var gender = Console.ReadLine();
    DateTime birthDate = ParseDateTime();
    double weight = ParseDouble("weight");
    double height = ParseDouble("height");

    userController.SetNewUserData(gender, birthDate, weight, height);
}
Console.WriteLine(userController.CurrentUser);

Console.WriteLine("What do you want to do?");
Console.WriteLine("E - enter meal/eating");
var key = Console.ReadKey();
Console.WriteLine();

if (key.Key == ConsoleKey.E)
{
   var foods = EnterEating();
   mealController.Add(foods.Food, foods.Weight);
    foreach (var item in mealController.Meal.Foods)
    {
        Console.WriteLine($"\t {item.Key} - {item.Value}");
    }
}

Console.ReadLine();

static (Food Food, double Weight) EnterEating()
{
    Console.WriteLine("Enter food name: ");
    var food = Console.ReadLine();

    var calories = ParseDouble("Enter calories ");
    var prots = ParseDouble("Enter protein ");
    var fats = ParseDouble("Enter fats ");
    var carbs = ParseDouble("Enter carbohydrates ");
    var weight = ParseDouble("Portion weight ");
    var product = new Food(food, prots, fats, carbs, calories);

    return (Food: product, Weight: weight);
}

static DateTime ParseDateTime()
{
    DateTime birthDate;
    while (true)
    {
        Console.Write("Введите дату рождения(dd.mm.yyyy): ");
        if (DateTime.TryParse(Console.ReadLine(), out birthDate))
        {
            break;
        }
        else
        {
            Console.WriteLine("Wrong birth date format");
        }
    }
    return birthDate;
}

static double ParseDouble (string name)
{
    while (true)
    {
        Console.Write($"Введите {name}: ");
        if (double.TryParse(Console.ReadLine(), out double value))
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Wrong {name} format");
        }
    }
}