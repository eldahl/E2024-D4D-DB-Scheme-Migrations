-- Use database
USE ActivityDB
GO

-- Drop the Run1 tables
DROP TABLE ActivityDuration;
DROP TABLE Activity;
DROP TABLE ActivityCategory;
GO

-- Switch to another database, so that the existing connections will be closed, enabling us to drop the ActivityDB.
USE master
GO

-- Drop database
DROP DATABASE ActivityDB;
GO