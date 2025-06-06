using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject;

public static class Menu
{
    public static T ShowEnumMenu<T>(string title) where T : Enum
    {
        var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        Console.Clear();
        Console.WriteLine($"=== {title} ===");

        for (int i = 0; i < values.Count; i++)
            Console.WriteLine($"{i + 1}. {values[i]}");

        Console.Write("Selection: ");
        return int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= values.Count
            ? values[choice - 1]
            : ShowEnumMenu<T>(title);
    }

    public static void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== PET SIMULATION ===");
            Console.WriteLine("1. Use Item");
            Console.WriteLine("2. List Items");
            Console.WriteLine("0. Exit");
            Console.Write(">> ");

            switch (Console.ReadLine())
            {
                case "1":
                    var pet = ShowEnumMenu<Pet_Type>("Select Pet");
                    var Item_Type = ShowEnumMenu<Item_Type>("Select Item Type");
                    var items = ItemDatabase.GetCompatibleItems(pet, Item_Type);

                    items.ForEach(item => Console.WriteLine($"- {item}"));
                    break;
                case "2":
                    var type = ShowEnumMenu<Item_Type>("Select Category");
                    ItemDatabase.GetItemsByType(type).ForEach(Console.WriteLine);
                    break;
                case "0":
                    return;
            }
            Console.ReadKey();
        }
    }
}
