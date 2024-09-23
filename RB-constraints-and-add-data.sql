USE ActivityDB
GO

DELETE FROM dbo.Users
WHERE email = 'larsGmanHenning@gmail.com' OR email = 'Paludan@gmail.com'
   OR email ='henribobendi@gmail.com' OR email ='JensJensJens@gmail.com' OR email ='belastende@gmail.com';


DELETE FROM ActivityDuration
WHERE activityId = 1 OR activityId = 2 OR activityId = 3 OR activityId = 4 OR activityId = 5 OR activityId = 6;


DELETE FROM Activity
WHERE nameActivity = 'Coding' OR nameActivity = 'Watching youtube' OR nameActivity = 'Stackoverflow' or nameActivity = 'No user activity'
    OR nameActivity = 'Discord Meeting' OR nameActivity = 'Playing OSRS';


DELETE FROM ActivityCategory
WHERE catName = 'Work' OR catName = 'Leisure' OR catName = 'Research' OR catName = 'Afk' OR catName = 'Meeting' OR catName = 'Gaming';


ALTER TABLE Activity
DROP CONSTRAINT FK_Activity_categoryName;

ALTER TABLE Activity
DROP CONSTRAINT categoryNameDefault;


ALTER TABLE Activity
DROP COLUMN categoryName;

SELECT *
FROM Activity;