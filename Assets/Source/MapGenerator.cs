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
    }
}