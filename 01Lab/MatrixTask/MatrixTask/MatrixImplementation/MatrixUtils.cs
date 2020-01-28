namespace MatrixTask.MatrixImplementation
{
    public static class MatrixUtils<T> where T : struct
    {
        #region Utility functions
        internal static T AddMatrixElement(T x, T y)
        {
            dynamic dx = x;
            dynamic dy = y;
            return dx + dy;
        }

        internal static T SetElementToNegative(T x)
        {
            dynamic dx = x;
            return -dx;
        }

        internal static bool IsNotValidType(Matrix<T> matrix)
        {
            switch (matrix[0, 0])
            {
                case sbyte sb:
                case byte b:
                case short s:
                case ushort us:
                case int i:
                case uint ui:
                case long l:
                case ulong ul:
                case float fl:
                case double d:
                case decimal dm:
                    return false;
                default:
                    return true;
            }
        }

        #endregion
    }
}
