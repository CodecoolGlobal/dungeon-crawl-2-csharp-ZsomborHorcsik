﻿using DungeonCrawl.Core;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using DungeonCrawl.Actors.Items;
using UnityEngine;

namespace DungeonCrawl
{
    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class Utilities
    {
        public static string lastSaveDate;
        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return (0, 1);
                case Direction.Down:
                    return (0, -1);
                case Direction.Left:
                    return (-1, 0);
                case Direction.Right:
                    return (1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }
        public static void SaveGame(GameState gameSave)
        {
            lastSaveDate = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            string filePath = String.Format(@"C:\Users\roola\Desktop\Github\dungeon-crawl-2-csharp-ZsomborHorcsik\Assets\Source\dungeoncrawl-{0:d}.txt", DateTime.Now.ToString("dddd, dd MMMM yyyy"));
            string jsonOutput = JsonConvert.SerializeObject(gameSave, Formatting.Indented);
            File.WriteAllText(filePath, jsonOutput);
        }
        public static GameState LoadGame()
        {
            string jsonInput = File.ReadAllText($@"C:\Users\roola\Desktop\Github\dungeon-crawl-2-csharp-ZsomborHorcsik\Assets\Source\dungeoncrawl-{lastSaveDate}.txt");
            return JsonConvert.DeserializeObject<GameState>(jsonInput);
        }
        public static void LoadSavedInventory(GameState save, List<Item> inventory)
        {
            inventory.Clear();
            foreach (string key in save.SavedInventory.Keys)
            {
                for (int i = 0; i < save.SavedInventory[key]; i++)
                {
                    if(key == "Keys")
                    {
                        Item doorKey = new GameObject().AddComponent<Key>();
                        inventory.Add(doorKey);
                    }
                    if (key == "Swords")
                    {
                        Item sword = new GameObject().AddComponent<Sword>();
                        inventory.Add(sword);
                    }
                    if (key == "Meds")
                    {
                        Item medical = new GameObject().AddComponent<HealthPack>();
                        inventory.Add(medical);
                    }
                }
            }
        }
    }
}
