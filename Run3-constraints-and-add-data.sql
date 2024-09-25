-- Use database
use ActivityDB
go

-- Create foreign key constraint on activityId
alter table ActivityDuration
add constraint FK_ActivityDuration_ActivityId
foreign key (activityId) references Activity(id);
GO

-- Create new column categoryName, and create default constraint and foreign key constraint
alter table Activity
add categoryName varchar(100) not null
    CONSTRAINT categoryNameDefault default 'uncategorized',
    CONSTRAINT FK_Activity_categoryName
    foreign key (categoryName) references ActivityCategory(catName);
GO

-- Insert data into ActivityCategory
-- This is done first, as Activity requires a category to be defined.
INSERT INTO ActivityCategory (catName) values ('Work');
INSERT INTO ActivityCategory (catName) values ('Leisure');
INSERT INTO ActivityCategory (catName) values ('Research');
INSERT INTO ActivityCategory (catName) values ('Afk');
INSERT INTO ActivityCategory (catName) values ('Meeting');
INSERT INTO ActivityCategory (catName) values ('Gaming');

-- Insert data into Activity
INSERT INTO Activity (nameActivity, activityDescription, categoryName) values ('Coding', 'Actively using IDE', 'Work');
INSERT INTO Activity (nameActivity, activityDescription, categoryName) values ('Watching youtube', 'Relaxing on youtube', 'Leisure');
INSERT INTO Activity (nameActivity, activityDescription, categoryName) values ('Stackoverflow', 'Aquiring new knowledge', 'Research');
INSERT INTO Activity (nameActivity, activityDescription, categoryName) values ('No user activity', 'PC is idle', 'Afk');
INSERT INTO Activity (nameActivity, activityDescription, categoryName) values ('Discord Meeting', 'Planning..? Shittalking..? Its on discord atleast.', 'Meeting');
INSERT INTO Activity (nameActivity, activityDescription, categoryName) values ('Playing OSRS', 'Limiting EXP waste', 'Gaming');

-- Insert data into ActivityDuration
INSERT INTO ActivityDuration (activityId, startTime, durationTime) values (1, '2024-09-20 14:00:02', '15:24:02');
INSERT INTO ActivityDuration (activityId, startTime, durationTime) values (2, '2024-09-20 15:00:02', '15:24:02');
INSERT INTO ActivityDuration (activityId, startTime, durationTime) values (3, '2024-09-20 17:00:02', '15:24:02');
INSERT INTO ActivityDuration (activityId, startTime, durationTime) values (4, '2024-09-20 13:00:02', '15:24:02');
INSERT INTO ActivityDuration (activityId, startTime, durationTime) values (5, '2024-09-20 10:00:02', '15:24:02');
INSERT INTO ActivityDuration (activityId, startTime, durationTime) values (6, '2024-09-20 19:00:02', '20:24:02');

-- Insert data into Users
INSERT INTO Users (userName, email) values ('Lars Henning', 'larsGmanHenning@gmail.com');
INSERT INTO Users (userName, email) values ('Peter Paludan', 'Paludan@gmail.com');
INSERT INTO Users (userName, email) values ('Henriette', 'henribobendi@gmail.com');
INSERT INTO Users (userName, email) values ('Jens Jensen', 'JensJensJens@gmail.com');
INSERT INTO Users (userName, email) values ('Bent Belastende', 'belastende@gmail.com');