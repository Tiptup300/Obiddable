## ⚙️ SQL Server Setup Instructions

To set up and connect the application to a local SQL Server Express instance, follow these steps precisely:

1. **Install SQL Server Express**  
   Make sure SQL Server Express is installed on your machine. You can download it from the official Microsoft website.

2. **Configure the Connection String**  
   Paste the appropriate connection string into:  
   `Ccd.Bidding.Manager.Library.EF.Dbc`

   Example:
   ```plaintext
   Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

3. **Update the Database

Open **Package Manager Console** in Visual Studio.**

   * Set the Default Project to:
       `Ccd.Bidding.Manager.Library`

   * Run the following command to apply migrations:
     ```
     Update-Database -Context Ccd.Bidding.Manager.Library.EF.Dbc
     ```

4. **Ensure Configuration File is Correct**

Check the .config file located in the binary (bin) directory. Ensure the connection string reflects your local instance of SQL Server Express.

5. **Access via SQL Server Management Studio (SSMS)**

* Connect to: localhost\SQLEXPRESS
* Ensure "Encrypt" is set to Optional
