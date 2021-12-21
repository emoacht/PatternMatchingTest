
public class TestPattern1
{
    public static void Execute()
    {
        ExecuteBase(new TestClass1(true, true));
        ExecuteBase(new TestClass1(true, false));
        ExecuteBase(new TestClass1(false, true));
        ExecuteBase(new TestClass1(false, false));
        ExecuteBase(new TestClass1(null, true));
        ExecuteBase(new TestClass1(null, false));
        ExecuteBase(null);

        static void ExecuteBase(TestClass1 t)
        {
            Console.WriteLine($"Method1 [A:{t?.A}, B:{t?.B}] -> {TestMethod1(t)}");
            Console.WriteLine($"Method2 [A:{t?.A}, B:{t?.B}] -> {TestMethod2(t)}");
            Console.WriteLine($"Method3 [A:{t?.A}, B:{t?.B}] -> {TestMethod3(t)}");
        }
    }

    public class TestClass1
    {
        public bool? A { get; }
        public bool B { get; }

        public TestClass1(bool? a, bool b) => (A, B) = (a, b);
    }

    private static string TestMethod1(TestClass1 t)
    {
        return t switch
        {
            // AがtrueでBもtrueの場合
            { A: true, B: true } => "Hit1",
            // AがtrueでBは何でもよい場合
            // （BがtrueのときはHit1でヒットするので、Bがfalseの場合）
            { A: true, B: _ } => "Hit2",
            // AがfalseでBは何でもよい場合
            { A: false } => "Hit3",
            // tがnullではなく、AもBも何でもよい場合
            // （Aがtrueの場合はHit2で全てヒットし、Aがfalseの場合はHit3で全てヒットするので、
            // AがnullでBは何でもよい場合）
            { } => "Hit4",
            // その他の場合
            // （tがnullでない場合はHit4で全てヒットするので、tがnullの場合）
            _ => "Hit5"
        };
    }

    private static string TestMethod2(TestClass1 t)
    {
        return t switch
        {
            // AがtrueでBもtrueの場合
            { A: true, B: true } => "Hit1",
            // AがtrueでBはfalseの場合
            { A: true, B: false } => "Hit1b",
            // AがtrueでBは何でもよい場合
            // （Bがtrueの場合はHit1でヒットし、Bがfalseの場合はHit1bでヒットするので、
            // 到達できないことになる）
            //{ A: true, B: _ } => "Hit2", // エラー（CS8510）
            _ => "Hit5"
        };
    }

    private static string TestMethod3(TestClass1 t)
    {
        return t switch
        {
            // AがtrueでBは何でもよい場合
            { A: true, B: _ } => "Hit2",
            // AがfalseでBは何でもよい場合
            { A: false } => "Hit3",
            // AがnullでBは何でもよい場合
            { A: null } => "Hit3b",
            // tがnullではなく、AもBも何でもよい場合
            //（AとBが何でもあってもHit2とHit3とHit3bで全てヒットするので、
            //　到達できないことになる）
            //{ } => "Hit4", // エラー（CS8510）
            _ => "Hit5"
        };
    }
}