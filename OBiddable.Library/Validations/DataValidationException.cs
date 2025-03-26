namespace OBiddable.Library.Validations;

public class DataValidationException : Exception
{
    public DataValidationException(string message) : base(message) { }
}
