using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonCrawl
{
    class MapGenerator
    {
        private static int MapWidth { get; set; } = 25;
        private static int MapHeight { get; set; } = 20;
        public static void GenerateMap()
        {
            Random rnd = new Random();

            string[] lines = new string[MapHeight];
            string line = string.Empty;
            int roomMaxWidth = MapWidth - 2;
            int roomMinWidth = 6;
            int roomLimiter = (MapWidth / 2) - 2;

            for (int i = 0; i < MapHeight; ++i)
            {
                for (int j = 0; j < MapWidth; ++j)
                {
                    if (j == 0 || j == MapWidth - 1)
                    {
                        line += "#";
                    } 
                    else
                    {
                        int actualRoomWidth = rnd.Next(roomMinWidth, roomMaxWidth);
                        if (actualRoomWidth < roomLimiter)
                        {
                            int neighborRoomWidth = rnd.Next(roomMinWidth, roomMaxWidth - actualRoomWidth - 1);
                            int roomsDistance = rnd.Next(1, roomMaxWidth - (actualRoomWidth + neighborRoomWidth));
                            if (j < actualRoomWidth || j > actualRoomWidth + roomsDistance && j < actualRoomWidth + roomsDistance + neighborRoomWidth)
                            {
                                line += ".";
                            }
                            else
                            {
                                line += "#";
                            }
                        }
                        else
                        {
                            int emptyFieldNumber = roomMaxWidth - actualRoomWidth;
                            int firstWall = rnd.Next(0, emptyFieldNumber);
                            if (j < firstWall)
                            {
                                line += " ";
                            }
                            else if (j == firstWall)
                            {
                                line += "#";
                            }
                            else if (j < firstWall + actualRoomWidth)
                            {
                                line += ".";
                            }
                            else if (j == firstWall + actualRoomWidth)
                            {
                                line += "#";
                            }
                            else if (j > firstWall + actualRoomWidth)
                            {
                                line += " ";
                            }
                        }
                    }
                }
                if (i == 0 || i == MapHeight - 1)
                {
                    lines[i] = "#########################";
                }
                else
                {
                    lines[i] = line;
                }
            }

            File.WriteAllLines("WriteLines.txt", lines);
        }
    }
}
