using System;
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
    }
}