using static TestPattern1;

public class TestPattern4
{
    public static void Execute()
    {
        ExecuteBase(new TestClass1(true, true));
        ExecuteBase(new TestClass1(true, false));
        ExecuteBase(new TestClass1(false, true));
        ExecuteBase(new TestClass1(false, true));
        ExecuteBase(new TestClass1(null, true));
        ExecuteBase(new TestClass1(null, false));
        ExecuteBase(null);

        static void ExecuteBase(TestClass1 t)
        {
            Console.WriteLine($"Method6a [A:{t?.A}, B:{t?.B}] -> {TestMethod6a(t)}");
            Console.WriteLine($"Method6b [A:{t?.A}, B:{t?.B}] -> {TestMethod6b(t)}");
            Console.WriteLine($"Method6c [A:{t?.A}, B:{t?.B}] -> {TestMethod6c(t)}");
            Console.WriteLine($"Method6d [A:{t?.A}, B:{t?.B}] -> {TestMethod6d(t)}");
        }
    }

    private static string TestMethod6a(TestClass1 t)
    {
        if (t is { A: true })
        {
            // 正常ルート
            return "Good 👍";
        }
        return "Bad 👎";
    }

    private static string TestMethod6b(TestClass1 t)
    {
        if (t is { A: null or false })
        {
            return "Bad 👎";
        }
        // 正常ルート（tがnullの場合にも来てしまう）
        return "Good 👍";
    }

    private static string TestMethod6c(TestClass1 t)
    {
        if (t is null or { A: null or false })
        {
            return "Bad 👎";
        }
        // 正常ルート（tがnullの場合には来ない）
        return "Good 👍";
    }

    private static string TestMethod6d(TestClass1 t)
    {
        if (t is not { A: true })
        {
            return "Bad 👎";
        }
        // 正常ルート（tがnullの場合には来ない）
        return "Good 👍";
    }
}