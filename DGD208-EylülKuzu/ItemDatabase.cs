namespace MyProject
{
    public enum PetType
    {
        Rabbit,
        Fox,
        Axolotl
    }

    public enum Item_Type
    {
        Food,
        Toy,
        Soap,
        SleepMask
    }

    public enum Pet_Stat
    {
        Hunger,
        Happiness,
        Cleanliness,
        Sleep
    }

    // Item class to represent game items
    public class Item
    {
        public string Name { get; set; }
        public Item_Type Type { get; set; }
        public List<Pet_Type> CompatibleWith { get; set; }
        public Pet_Stat AffectedStat { get; set; }
        public int EffectAmount { get; set; }
        public float Duration { get; set; }

        public Item()
        {
            CompatibleWith = new List<Pet_Type>();
        }

        public override string ToString()
        {
            return $"{Name} - Affects: {AffectedStat}, Amount: +{EffectAmount}, Duration: {Duration}s";
        }
    }

    public static class ItemDatabase
    {
        public static List<Item> AllItems = new List<Item>
        {
            // Food Items
            new Item {
                Name = "Wonderful Carrot",
                Type = Item_Type.Food,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Rabbit },
                AffectedStat = Pet_Stat.Hunger,
                EffectAmount = 15,
                Duration = 2.5f
            },
            new Item {
                Name = "Worm",
                Type = Item_Type.Food,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Fox },
                AffectedStat = Pet_Stat.Hunger,
                EffectAmount = 20,
                Duration = 2.5f
            },
            new Item {
                Name = "Little Bugs",
                Type = Item_Type.Food,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Axolotl },
                AffectedStat = Pet_Stat.Hunger,
                EffectAmount = 15,
                Duration = 3.0f
            },
            
            // Toy Items
            new Item {
                Name = "Chew Toy",
                Type = Item_Type.Toy,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Rabbit },
                AffectedStat = Pet_Stat.Happiness,
                EffectAmount = 15,
                Duration = 2.0f
            },
            new Item {
                Name = "An Unfortunate Rat",
                Type = Item_Type.Toy,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Fox },
                AffectedStat = Pet_Stat.Happiness,
                EffectAmount = 15,
                Duration = 2.0f
            },
            new Item {
                Name = "Bubbles",
                Type = Item_Type.Toy,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Axolotl },
                AffectedStat = Pet_Stat.Happiness,
                EffectAmount = 15,
                Duration = 2.0f
            },
            
            // Soap Item
            new Item {
                Name = "Gentle Baby Soap",
                Type = Item_Type.Soap,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Axolotl, Pet_Type.Fox, Pet_Type.Rabbit },
                AffectedStat = Pet_Stat.Cleanliness,
                EffectAmount = 22,
                Duration = 5.0f
            },
            
            // Sleep Mask Item
            new Item {
                Name = "Cute Sleep Mask",
                Type = Item_Type.SleepMask,
                CompatibleWith = new List<Pet_Type> { Pet_Type.Rabbit, Pet_Type.Axolotl, Pet_Type.Fox },
                AffectedStat = Pet_Stat.Sleep,
                EffectAmount = 35,
                Duration = 5.5f
            }
        };

       
        public static List<Item> GetItemsByType(Item_Type type)
        {
            return AllItems.FindAll(item => item.Type == type);
        }

        public static List<Item> GetItemsForPet(Pet_Type petType)
        {
            return AllItems.FindAll(item => item.CompatibleWith.Contains(petType));
        }

        public static List<Item> GetCompatibleItems(Pet_Type petType, Item_Type itemType)
        {
            return AllItems.FindAll(item => item.Type == itemType && item.CompatibleWith.Contains(petType));
        }

        public static Item GetItemByName(string name)
        {
            return AllItems.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
