﻿using System;
using System.Collections.Generic;

namespace mapgeneratortest
{
    class MapGenerator
    {
        private static int MapWidth { get; set; } = 200;
        private static int MapHeight { get; set; } = 80;
        private static char WallChar = '■';
        private static char FloorChar = '.';
        private static char PlayerChar = 'p';
        private static char SkeletonChar = 's';
        private static char HpChar = 'h';
        private static int RoomArea = 10;
        private static Random rnd = new Random();

        private static int noisePercent = 70;
        private static int CATreshold = 3;
        private static int CACycle = 15;
        private static int SpawnProbability = 5;

        private static char[,] GenerateNoise()
        {
            char[,] noise = new char[MapHeight, MapWidth];
            for (int i = 0; i < MapHeight; ++i)
            {
                for (int j = 0; j < MapWidth; ++j)
                {
                    int randomInt = rnd.Next(1, 100);
                    if (randomInt <= noisePercent)
                    {
                        noise[i, j] = WallChar;
                    }
                    else
                    {
                        noise[i, j] = FloorChar;
                    }
                }
            }
            return noise;
        }

        private static bool validate(int v, int h)
        {
            return v >= 0 && v < h;
        }

        private static string[] ToStringArray(char[,] map)
        {
            string[] stringArray = new string[MapHeight];
            for (int i = 0; i < MapHeight; ++i)
            {
                string line = string.Empty;
                for (int j = 0; j < MapWidth; ++j)
                {
                    line += map[i, j];
                }
                stringArray[i] = line;
            }
            return stringArray;
        }

        private static char[,] CellularAutomata(char[,] map)
        {
            char[,] orderedMap = new char[MapHeight, MapWidth];
            for (int i = 0; i < MapHeight; ++i)
            {
                for (int j = 0; j < MapWidth; ++j)
                {
                    int wallCount = 0;
                    for (int k = -1; k < 2; ++k)
                    {
                        for (int l = -1; l < 2; ++l)
                        {
                            if (j + k > 0 && j + k < MapWidth && i + l > 0 && i + l < MapHeight)
                            {
                                if (map[i + l, j + k] == WallChar && k != 0 && l != 0)
                                {
                                    ++wallCount;
                                }
                            }
                            else
                            {
                                ++wallCount;
                            }
                        }
                    }
                    if (wallCount >= CATreshold)
                    {
                        orderedMap[i, j] = WallChar;
                    }
                    else
                    {
                        orderedMap[i, j] = FloorChar;
                    }
                }
            }
            return orderedMap;
        }

        private static char[,] Refinery(char[,] map)
        {
            char[,] tempGrid = map;
            for (int i = 0; i < MapHeight; ++i)
            {
                for (int j = 0; j < MapWidth; ++j)
                {
                    int counter = 0;
                    for (int k = -1; k < 2; ++k)
                    {
                        for (int l = -1; l < 2; ++l)
                        {
                            if (!(l == 0 && k == 0))
                            {
                                if (validate(i + k, MapHeight) && validate(j + l, MapWidth))
                                {
                                    if (map[i + k, j + l] == WallChar)
                                    {
                                        ++counter;
                                    }
                                }
                                if (!validate(i + k, MapHeight) || !validate(j + l, MapWidth))
                                {
                                    ++counter;
                                }
                            }
                        }
                    }
                    if (counter > CATreshold + 1)
                    {
                        tempGrid[i, j] = WallChar;
                    }
                    else
                    {
                        tempGrid[i, j] = FloorChar;
                    }
                }
            }
            return tempGrid;
        }

        public static string[] GenerateMap()
        {
            char[,] map = GenerateNoise();
            for (int i = 0; i < CACycle; ++i)
            {
                map = CellularAutomata(map);
            }
            //map = Refinery(map);
            map = PopulateMap(map);
            return ToStringArray(map);
        }
    }
}