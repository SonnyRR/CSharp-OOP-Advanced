namespace P01_HarvestingFields
{
    using System;
    using System.Text;
    using System.Reflection;
    using System.Linq;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            StringBuilder builder = new StringBuilder();
            Type typeOfHrv = typeof(HarvestingFields);

            var fields = typeOfHrv
                .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "HARVEST")
                    break;

                if (command != "all")
                {
                    fields.Where(x => x.Attributes.ToString().ToLower()
                    == (command == "protected" ? command = "family" : command = command))
                        .ToList()
                        .ForEach(x =>
                        {
                            builder.AppendLine($"{x.Attributes.ToString().ToLower()} {x.FieldType.Name} {x.Name}");
                        });
                }

                else
                {
                    fields.ForEach(x =>
                    {
                        builder.AppendLine($"{x.Attributes.ToString().ToLower()} {x.FieldType.Name} {x.Name}");
                    });
                }
            }

            Console.WriteLine(builder.ToString().TrimEnd().Replace("family", "protected"));
        }
    }
}
