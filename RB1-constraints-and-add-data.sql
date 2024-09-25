-- Use database
USE ActivityDB
GO

-- Delete data inserted to table Users from Run3
DELETE FROM dbo.Users
WHERE email = 'larsGmanHenning@gmail.com' OR email = 'Paludan@gmail.com'
   OR email ='henribobendi@gmail.com' OR email ='JensJensJens@gmail.com' OR email ='belastende@gmail.com';

-- Delete data inserted to table ActivityDuration from Run3
DELETE FROM ActivityDuration
WHERE activityId = 1 OR activityId = 2 OR activityId = 3 OR activityId = 4 OR activityId = 5 OR activityId = 6;


-- Delete data inserted to table Activity from Run3
DELETE FROM Activity
WHERE nameActivity = 'Coding' OR nameActivity = 'Watching youtube' OR nameActivity = 'Stackoverflow' or nameActivity = 'No user activity'
    OR nameActivity = 'Discord Meeting' OR nameActivity = 'Playing OSRS';

-- Delete data inserted to table ActivityCategory from Run3
DELETE FROM ActivityCategory
WHERE catName = 'Work' OR catName = 'Leisure' OR catName = 'Research' OR catName = 'Afk' OR catName = 'Meeting' OR catName = 'Gaming';

-- Delete foreign key constraint on Activity table from Run3
ALTER TABLE Activity
DROP CONSTRAINT FK_Activity_categoryName;

-- Delete default value constraint on Activity table from Run3
ALTER TABLE Activity
DROP CONSTRAINT categoryNameDefault;

-- Delete categoryName column on Activity table from Run3
ALTER TABLE Activity
DROP COLUMN categoryName;