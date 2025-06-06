using System;
using System.Collections.Generic;

namespace MyProject;

public class Game
{
    private bool _isRunning;
    private Pet_Type _selectedPet;
    private Dictionary<Pet_Stat, int> _petStats;

    public Game()
    {
        _petStats = new Dictionary<Pet_Stat, int>
        {
            { Pet_Stat.Hunger, 50 },
            { Pet_Stat.Happiness, 50 },
            { Pet_Stat.Cleanliness, 50 },
            { Pet_Stat.Sleep, 50 }
        };
    }

    public void Start()
    {
        Console.Clear();
        _selectedPet = Menu.ShowEnumMenu<Pet_Type>("Choose A Friend!");
        _isRunning = true;

        while (_isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== SIMULATION WITH YOUR LOVELY FRÝENDS ===");
            Console.WriteLine($"Pet: {_selectedPet}");
            foreach (var stat in _petStats)
                Console.WriteLine($"{stat.Key}: {stat.Value}");

            Console.WriteLine("\n1. Use Item");
            Console.WriteLine("2. List The Items");
            Console.WriteLine("0. Exit");
            Console.Write(">> ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    UseItemMenu();
                    break;
                case "2":
                    ListItemsMenu();
                    break;
                case "0":
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("Unvalid Selection.");
                    Console.ReadKey();
                    break;
            }
        }
        Console.WriteLine("Game is Over !");
    }

    private void UseItemMenu()
    {
        var itemType = Menu.ShowEnumMenu<Item_Type>("Select The Item Type");
        var items = ItemDatabase.GetCompatibleItems(_selectedPet, itemType);

        if (items.Count == 0)
        {
            Console.WriteLine("Unvalid Item.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Items That Can Be Used:");
        for (int i = 0; i < items.Count; i++)
            Console.WriteLine($"{i + 1}. {items[i]}");

        Console.Write("Please choose what item you want to use: ");
        if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= items.Count)
        {
            var selectedItem = items[itemIndex - 1];
            ApplyItemEffect(selectedItem);
            Console.WriteLine($"{selectedItem.Name} item used!");
        }
        else
        {
            Console.WriteLine("Unvalid Selection");
        }
        Console.ReadKey();
    }

    private void ListItemsMenu()
    {
        var type = Menu.ShowEnumMenu<Item_Type>("Select a Category");
        var list = ItemDatabase.GetItemsByType(type);
        list.ForEach(item => Console.WriteLine(item));
        Console.ReadKey();
    }

    private void ApplyItemEffect(Item item)
    {
        if (_petStats.ContainsKey(item.AffectedStat))
            _petStats[item.AffectedStat] += item.EffectAmount;
    }
}

