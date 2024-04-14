// Custom exception classes
public class ArrayTypeMismatchException : Exception {
    public ArrayTypeMismatchException(string message) : base(message) { }
}

public class DivideByZeroException : Exception {
    public DivideByZeroException(string message) : base(message) { }
}

public class IndexOutOfRangeException : Exception {
    public IndexOutOfRangeException(string message) : base(message) { }
}

public class InvalidCastException : Exception {
    public InvalidCastException(string message) : base(message) { }
}

public class OutOfMemoryException : Exception {
    public OutOfMemoryException(string message) : base(message) { }
}

public class OverflowException : Exception {
    public OverflowException(string message) : base(message) { }
}

public class StackOverflowException : Exception {
    public StackOverflowException(string message) : base(message) { }
}
