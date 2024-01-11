namespace FiyiStack.Library.NET
{
    public static class Math
    {
        public static bool HasDecimalsAfterComma(decimal Decimal)
        {
            return Decimal % 1 != 0;
        }

        public enum RoundType { RoundUp, RoundDown }
        public static int Divide(decimal Dividend, decimal Divisor, RoundType RoundTypeForResult)
        {
            try
            {
                if (Divisor == 0)
                { throw new ArithmeticException("It is not allowed to perform a division with zero divisor"); }

                int Result = 0;
                decimal decResult = Dividend / Divisor;

                switch (RoundTypeForResult)
                {
                    case RoundType.RoundUp:
                        Result = System.Convert.ToInt32(System.Math.Ceiling(decResult));
                        break;
                    case RoundType.RoundDown:
                        Result = System.Convert.ToInt32(System.Math.Floor(decResult));
                        break;
                }

                return Result;
            }
            catch (Exception) { throw; }
        }
    }
}
