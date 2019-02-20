using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MathService" in code, svc and config file together.
public class MathService : IMathService
{
    static int Count;
    public int Add(int a, int b)
    {
        Count++;
        return a + b + 100;
    }

    public Complex AddComplex(Complex a, Complex b)
    {
        Count++;
        Complex c = new Complex();
        c.Real = a.Real + b.Real;
        c.Imag = a.Imag + b.Imag;
        return c;
    }

    public int GetCounter()
    {
        return Count;
    }
}
