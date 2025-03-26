using OBiddable.Library.Validations;

namespace OBiddable.Library.Operations;

public abstract class DataOperation : IOperation
{
    public void Run()
    {
        if (Confirm() == false)
        {
            return;
        }
        try
        {
            RunDataOperation();
        }
        catch (DataValidationException ex)
        {
            OnDataValidationException(ex);
        }
        catch (Exception ex)
        {
            OnException(ex);
        }
    }

    public abstract bool Confirm();
    public abstract void OnDataValidationException(DataValidationException e);
    public abstract void OnException(Exception e);
    protected abstract void RunDataOperation();
}
