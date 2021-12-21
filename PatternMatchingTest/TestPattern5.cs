using static TestPattern1;

public class TestPattern5
{
    public static void Execute()
    {
        ExecuteBase(new TestClass1(true, true));
        ExecuteBase(new TestClass1(true, false));
        ExecuteBase(new TestClass1(false, true));
        ExecuteBase(new TestClass1(false, false));
        ExecuteBase(new TestClass1(null, true));
        ExecuteBase(new TestClass1(null, false));
        ExecuteBase("Test".ToCharArray());
        ExecuteBase(DateTime.Now);
        ExecuteBase(null);

        static void ExecuteBase(object o)
        {
            Console.WriteLine($"Method7a [A:{(o as TestClass1)?.A}, B:{(o as TestClass1)?.B}] -> {TestMethod7a(o)}");
            Console.WriteLine($"Method7b [A:{(o as TestClass1)?.A}, B:{(o as TestClass1)?.B}] -> {TestMethod7b(o)}");
        }
    }

    private static string TestMethod7a(object o)
    {
        if (o is TestClass1 t and { A: true, B: true })
        {
            // 正常ルート
            return $"Good 👍 A:{t.A} B:{t.B}";
        }
        return "Bad 👎";
    }

    private static string TestMethod7b(object o)
    {
        if (o is not (TestClass1 t and { A: true, B: true }))
        {
            return "Bad 👎";
        }
        // 正常ルート
        return $"Good 👍 A:{t.A} B:{t.B}";
    }
}