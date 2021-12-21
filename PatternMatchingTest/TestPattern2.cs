
public class TestPattern2
{
    public static void Execute()
    {
        ExecuteBase(new TestStruct1(true, true));
        ExecuteBase(new TestStruct1(true, false));
        ExecuteBase(new TestStruct1(false, true));
        ExecuteBase(new TestStruct1(false, false));
        ExecuteBase(new TestStruct1(null, true));
        ExecuteBase(new TestStruct1(null, false));

        static void ExecuteBase(TestStruct1 t)
        {
            Console.WriteLine($"Method4 [A:{t.A}, B:{t.B}] -> {TestMethod4(t)}");
        }
    }

    public struct TestStruct1
    {
        public bool? A { get; }
        public bool B { get; }

        public TestStruct1(bool? a, bool b) => (A, B) = (a, b);
    }

    private static string TestMethod4(TestStruct1 t)
    {
        return t switch
        {
            // AがtrueでBもtrueの場合
            { A: true, B: true } => "Hit1",
            // AがtrueでBは何でもよい場合
            { A: true, B: _ } => "Hit2",
            // AがfalseでBは何でもよい場合
            { A: false } => "Hit3",
            // tがnullではなく、AもBも何でもよい場合
            { } => "Hit4",
            // その他の場合
            // （tがnullでない場合はHit4で全てヒットし、tはnullにならないので、
            // 到達できないことになる）
            //_ => "Hit5" // エラー（CS8510）
        };
    }
}