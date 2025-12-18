// event 키워드 사용 예제
/*
아래 예제는 C#에서 event 키워드를 사용하는 간단한 방법을 제시합니다.
이 예제에서 Button 클래스는 Clicked라는 이벤트를 선언하고 있습니다.
이후 Main 메서드에서 Clicked 이벤트를 인위적으로 발생시켜
OnButtonClicked 메서드가 호출되도록 구현되어 있습니다.
*/
class Button
{
    // 이벤트 선언문
    // 관행적으로 Action 혹은 Func 대리자를 이용해 이벤트를 선언합니다.
    public event Action Clicked;

    // 이벤트를 발생시키는 메서드
    public void OnClick()
    {
        Console.WriteLine("Button was clicked!");

        // 이벤트 자체에 호출이 붙습니다.
        // Invoke 메소드가 호출되면 Clicked에 연결된 모든 메소드가 같이 호출됩니다.
        // ? 키워드를 통해 null 참조 예외를 방지하는 것이 일반적입니다.
        Clicked?.Invoke();
    }
}
class Program
{
    static void Main()
    {
        Button button = new Button();

        // 이벤트에 이벤트 핸들러 연결
        // 이벤트 핸들러를 연결시킬 때 += 연산자를 사용합니다.
        // 대리자로 선언된 변수에 메소드를 추가하는 것이라 += 연산자를 사용한다고 생각하면 됩니다.
        button.Clicked += OnButtonClicked;

        // 버튼 누르기 (이벤트 호출)
        button.OnClick();
    }

    // 이벤트가 발생하면 실행될 이벤트 핸들러
    static void OnButtonClicked()
    {
        Console.WriteLine("이벤트가 실행되었습니다!");
    }
}