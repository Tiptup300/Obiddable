# <img width="32px" height="32px" alt="image" src="https://github.com/user-attachments/assets/7bf82bbb-6cc4-4a24-acd7-ec175e62db46" /> Obiddable

Obiddable is an open source bidding application & process for Pennsylvania school districts.

## Setup Instructions

1. **Build and Run**  
   Build and run the application. The database will be automatically created in your AppData folder.

2. **Location of Data**  
   The SQLite database will be created at:  
   `%AppData%\Ccd.Bidding.Manager\bidding.db`

3. **First Run**  
   On first run, the application will:
   - Create necessary directories
   - Initialize the SQLite database
   - Apply all required migrations

No additional database setup is required.
