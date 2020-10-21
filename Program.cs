using System;

namespace fuzzyLogicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fuzzy Logic Height Clustering\nType the setpoints to short, medium and tall people:\n");
            float shortHeight = float.Parse(Console.ReadLine());
            float mediumHeight = float.Parse(Console.ReadLine());
            float tallHeight = float.Parse(Console.ReadLine());

            Console.WriteLine("\nNow your height:\n");
            float x = float.Parse(Console.ReadLine());

            // float shortHeight = 150f;
            // float mediumHeight = 170f;
            // float tallHeight = 190f;

            float shortDegree = TrimfShort(x, shortHeight, mediumHeight);
            float mediumDegree = TrimfMedium(x, shortHeight, mediumHeight, tallHeight);
            float tallDegree = TrimfTall(x, mediumHeight, tallHeight);

            if (shortDegree >= mediumDegree && tallDegree == 0)
            {
                Console.WriteLine("You are {0}% a short person", shortDegree * 100);
            }
            else if (mediumDegree >= shortDegree && mediumDegree >= tallDegree)
            {
                Console.WriteLine("You are {0}% a medium person", mediumDegree * 100);
            }
            else if (tallDegree >= mediumDegree && shortDegree == 0)
            {
                Console.WriteLine("You are {0}% a tall person", tallDegree * 100);
            }
        }
        public static float TrimfShort(float x, float s, float m)
        {
            if (x <= s)
            {
                return 1;
            }
            else if (x >= s && x <= m)
            {
                return (m - x) / (m - s);
            }
            else
            {
                return 0;
            }
        }
        public static float TrimfMedium(float x, float s, float m, float t)
        {
            if (x <= s)
            {
                return 0;
            }
            else if (x >= s && x <= m)
            {
                return (x - s) / (m - s);
            }
            else if (x >= m && x <= t)
            {
                return (t - x) / (t - m);
            }
            else
            {
                return 0;
            }
        }
        public static float TrimfTall(float x, float m, float t)
        {
            if (x <= m)
            {
                return 0;
            }
            else if (x >= m && x <= t)
            {
                return (x - m) / (t - m);
            }
            else
            {
                return 1;
            }
        }
    }
}
