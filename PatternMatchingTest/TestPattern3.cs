
public class TestPattern3
{
    public static void Execute()
    {
        ExecuteBase(new TestClass2(true, true));
        ExecuteBase(new TestClass2(true, false));
        ExecuteBase(new TestClass2(false, true));
        ExecuteBase(new TestClass2(false, false));
        ExecuteBase(new TestClass2(null, true));
        ExecuteBase(new TestClass2(null, false));
        ExecuteBase(null);

        static void ExecuteBase(TestClass2 t)
        {
            Console.WriteLine($"Method5 [A:{t?.A}, B:{t?.B}] -> {TestMethod5(t)}");
        }
    }

    public class TestClass2
    {
        public bool? A
        {
            get
            {
                CountA++;
                return _a;
            }
        }
        private readonly bool? _a;
        public int CountA { get; private set; } = 0;

        public bool B
        {
            get
            {
                CountB++;
                return _b;
            }
        }
        private readonly bool _b;
        public int CountB { get; private set; } = 0;

        public TestClass2(bool? a, bool b) => (_a, _b) = (a, b);

        public void Reset() => (CountA, CountB) = (0, 0);
    }

    private static string TestMethod5(TestClass2 t)
    {
        t?.Reset();

        return t switch
        {
            { A: true, B: true } => "Hit1",
            { A: true, B: false } => "Hit2",
            { A: false } => "Hit3",
            { } => "Hit4",
            _ => "Hit5"
        } + $" CountA:{t?.CountA}, CountB:{t?.CountB}";
    }
}