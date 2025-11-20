using Obiddable.Library.Validations;

namespace Obiddable.Library.Operations;
public abstract class DataOperation : IOperation
{
   public void Run()
   {
      if (Confirm() == false)
      {
         return;
      }
      if(System.Diagnostics.Debugger.IsAttached)
      {
         RunDataOperation();

      }
      else
      {
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
   }

   public abstract bool Confirm();
   public abstract void OnDataValidationException(DataValidationException e);
   public abstract void OnException(Exception e);
   protected abstract void RunDataOperation();
}
