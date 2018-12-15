namespace _07.Custom_list
{
    using System;
    using CustomList;
    public class StartUp
    {
        public static void Main()
        {
            var myList = new CustomList<string>();

            while (true)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputLine[0] == "END")
                    break;

                string command = inputLine[0];

                switch (command)
                {
                    case "Add":
                        myList.Add(inputLine[1]);
                        break;
                    case "Remove":
                        myList.Remove(int.Parse(inputLine[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(myList.Contains(inputLine[1]));
                        break;
                    case "Swap":
                        myList.SwapElements(int.Parse(inputLine[1]), int.Parse(inputLine[2]));
                        break;
                    case "Sort":
                        myList.SortAscending();
                        break;
                    case "Greater":
                        Console.WriteLine(myList.GetGreaterThan(inputLine[1]));
                        break;
                    case "Max":
                        Console.WriteLine(myList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(myList.Min());
                        break;
                    case "Print":
                        {
                            foreach (var item in myList)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
