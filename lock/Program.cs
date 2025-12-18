// lock 키워드 사용 예제
/*
아래 예제는 C#에서 lock 키워드를 사용하는 간단한 방법을 제시합니다.
이 예제에서 두 스레드는 하나의 전역 변수인 num을 동시에 10회 증가시키려고 시도합니다.
이러한 경쟁상태에서는 보통 데이터의 결과값을 보장받지 못하고 갱신 손실이 발생할 수 있으나
lock 키워드를 통해 경쟁 대상이 되는 num 변수에 대한 접근을 제한하여 하나의 스레드만
해당 코드블록에 접근할 수 있도록 캡슐화 되어있습니다.
*/

class Program
{
    static void Main()
    {
        Data data = new Data();

        // 스레드를 두 개 생성합니다.
        Thread thread1 = new Thread(AccessData);
        Thread thread2 = new Thread(AccessData);

        // 두 스레드가 같은 Data 인스턴스를 사용하도록 전달합니다.
        thread1.Start(data);
        thread2.Start(data);

        thread1.Join();
        thread2.Join();
    }

    // 두 스레드는 동일한 Data 인스턴스의 AccessData 메서드를 호출합니다.
    // 이는 일부러 스레드가 같은 데이터에 접근하도록 만든 것입니다.
    // 따라서 lock 키워드를 사용하지 않으면 데이터의 일관성이 깨질 수 있습니다.
    static void AccessData(object obj)
    {
        Data targetData = obj as Data;

        for (int i = 0; i < 10; i++)
        {
            targetData.Increase();
        }
    }
}
class Data
{
    public int num = 0;
    private readonly object _lock = new object();
    public void Increase()
    {
        lock (_lock)
        {
            num++;
            Console.WriteLine($"Data Value: {num}");
            Thread.Sleep(1);
        }
    }
}