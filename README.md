This is a database first type project. To start you have to create database in your sql server called "TeamPanel", 
and then run "Initialization.sql" from TeamPanel.DAL project (folder SQLs). Make sure that you are using "TeamPanel" database.

If you want to change models, create an sql for it, add your sql to "SQLs" folder, and scaffold changes with the following command (run it in the package manager console


Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=TeamPanel;Trusted_Connection=True;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -f -context TeamPanelContext -project "TeamPanel.DAL"

TODO:

Api: All needed methods, new ApiException models, pagination, filtration, excludes and includes

Client: Frontend, model validation for starters

DAL: All methods
