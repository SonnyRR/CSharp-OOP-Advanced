namespace _04.Froggy
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            int[] inputNums = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            

            Lake<int> myLake = new Lake<int>(inputNums);
            StringBuilder builder = new StringBuilder();

            foreach (var item in myLake)
            {
                builder.Append($"{item}, ");
            }

            Console.WriteLine(builder.ToString().TrimEnd(' ', ','));
        }
    }
}
