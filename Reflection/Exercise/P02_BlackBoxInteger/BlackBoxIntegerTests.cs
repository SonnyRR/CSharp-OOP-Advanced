namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type blackBoxType = typeof(BlackBoxInteger);

            ConstructorInfo[] constructors = blackBoxType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            BlackBoxInteger blackBox = (BlackBoxInteger)constructors[1].Invoke(new object[] { });

            FieldInfo innerVal = blackBoxType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = blackBoxType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            while (true)
            {
                string[] inputArgs = Console.ReadLine().Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

                string command = inputArgs[0];

                if (command == "END")
                    break;

                int numberToOperateWith = int.Parse(inputArgs[1]);

                methods.Where(x => x.Name == command)
                   .FirstOrDefault()
                   .Invoke(blackBox, new object[] { numberToOperateWith });

                Console.WriteLine(innerVal.GetValue(blackBox));

            }
        }
    }
}
