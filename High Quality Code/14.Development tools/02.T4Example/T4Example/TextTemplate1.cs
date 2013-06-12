using System;

public class SimpleClass
{
    public int MyNewProperty0 { get; private set; }
    public int MyNewProperty1 { get; private set; }
    public int MyNewProperty2 { get; private set; }
    public int MyNewProperty3 { get; private set; }


    public SimpleClass(int variable0, int variable1, int variable2, int variable3)
    {
        this.MyNewProperty0 = variable0;
        this.MyNewProperty1 = variable1;
        this.MyNewProperty2 = variable2;
        this.MyNewProperty3 = variable3;
    }

    public int Sum()
    {
        int sum = 0;
        sum += this.MyNewProperty0;
        sum += this.MyNewProperty1;
        sum += this.MyNewProperty2;
        sum += this.MyNewProperty3;

        return sum;
    }
}