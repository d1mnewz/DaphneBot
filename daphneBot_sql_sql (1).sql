-- ---
-- Dropping constraint foreign key on delete
-- ---

--SELECT * 
--FROM sys.foreign_keys
--WHERE referenced_object_id = object_id('Teams')

-- Command that generates a query statement that remove dependencies on Teams table so you can drop all tables

--SELECT 
--    'ALTER TABLE ' +  OBJECT_SCHEMA_NAME(parent_object_id) +
--    '.[' + OBJECT_NAME(parent_object_id) + 
--    '] DROP CONSTRAINT ' + name
--FROM sys.foreign_keys
--WHERE referenced_object_id = object_id('Teams')


-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'Statuses'
-- Table to store statuses
-- ---

DROP TABLE IF EXISTS Statuses;
		
CREATE TABLE Statuses (
  id INTEGER NOT NULL IDENTITY(1,1),
  userId INTEGER NULL DEFAULT NULL,
  whenToCollect DATETIME NULL DEFAULT NULL ,
  PRIMARY KEY (id)
);

-- ---
-- Table 'Users'
-- To store data about user
-- ---

DROP TABLE IF EXISTS Users;
		
CREATE TABLE Users (
  id INTEGER NOT NULL IDENTITY(1,1),
  teamId INTEGER NULL DEFAULT NULL,
  userName VARCHAR(64) NULL DEFAULT NULL ,
  fullName VARCHAR(1024) NULL DEFAULT NULL ,
  PRIMARY KEY (id)
) ;

ALTER TABLE Users
ADD roleId INTEGER DEFAULT NULL
-- ---
-- Table 'Teams'
-- storing teams
-- ---

DROP TABLE IF EXISTS Teams;
		
CREATE TABLE Teams (
  id INTEGER NOT NULL IDENTITY(1,1),
  teamName VARCHAR(256) NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

-- ---
-- Table 'QAs'
-- 
-- ---

DROP TABLE IF EXISTS QAs;
		
CREATE TABLE QAs (
  id INTEGER NOT NULL IDENTITY(1,1),
  questionId INTEGER NULL DEFAULT NULL,
  answer VARCHAR(1024) NOT NULL,
  statusId INTEGER NULL DEFAULT NULL,
  whenCollected DATETIME NULL DEFAULT NULL,
  PRIMARY KEY (id)
);

-- ---
-- Table 'Questions'
-- 
-- ---

DROP TABLE IF EXISTS Questions;
		
CREATE TABLE Questions (
  id INTEGER NOT NULL IDENTITY(1,1),
  questionContent VARCHAR(256) NOT NULL,
  PRIMARY KEY (id)
);

-----
--Role
-----

DROP TABLE IF EXISTS Roles;
CREATE TABLE Roles(
id INTEGER NOT NULL IDENTITY(1,1),
roleName VARCHAR(32) NOT NULL,
PRIMARY KEY(id)
);

-- ---
-- Foreign Keys 
-- ---

ALTER TABLE Statuses ADD FOREIGN KEY (userId) REFERENCES Users (id);
ALTER TABLE Users ADD FOREIGN KEY (teamId) REFERENCES Teams (id);
ALTER TABLE QAs ADD FOREIGN KEY (questionId) REFERENCES Questions (id);
ALTER TABLE QAs ADD FOREIGN KEY (statusId) REFERENCES Statuses (id);
ALTER TABLE Users ADD FOREIGN KEY (roleId) REFERENCES Roles(id);
-- ---
-- Table Properties
-- ---

-- ALTER TABLE Statuses ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE Users ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE Teams ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE QAs ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE Questions ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO Statuses (id,userId,whenToCollect) VALUES
-- ('','','');
-- INSERT INTO Users (id,teamId,userName,fullName,avatarURL) VALUES
-- ('','','','','');
-- INSERT INTO Teams (id,teamName,mentorId) VALUES
-- ('','','');
-- INSERT INTO QAs (id,questionId,answer,statusId,whenCollected) VALUES
-- ('','','','','');
-- INSERT INTO Questions (id,questionContent) VALUES
-- ('','');
-- ---
-- Inserted test data
-- ---

 INSERT INTO Questions (questionContent)  VALUES
 ('What you have already done?'),
 ('What will you do?'),
 ('Do you have any problems that affect your performance?');

 INSERT INTO Teams (teamName) VALUES
 ('Zumwalt'),
 ('Random team'),
 ('id_iot')

 
 INSERT INTO Users (teamId,userName,fullName) VALUES
 (1,'d1mnewz','Zhluktenko Dmytro'),
 (1, 'alede', 'Demyanenko Alexandr'),
 (1, 'goblimgus', 'Vsevolod Pus`'),
 (1, 'vasyl_dzyuba', 'Vasyl Dzyuba'),
 (1, 'd1', 'bbbb')

 INSERT INTO Statuses (userId,whenToCollect) VALUES
 (1,'2017-03-15 00:00:00');

 INSERT INTO QAs (questionId,answer,statusId,whenCollected) VALUES
 (1,'Nothing', 1, '2017-03-14 04:21:00' );
  INSERT INTO QAs (questionId,answer,statusId,whenCollected) VALUES
 (2,'Something',1, '2017-03-14 04:20:45' );
  INSERT INTO QAs (questionId,answer,statusId,whenCollected) VALUES
 (3,'I am fool.',1, '2017-03-14 04:20:42');

 -- YYYY-MM-DD HH:MM:SS pattern

 -- ---
 -- Selects
 -- --- 

 SELECT * FROM Users
 SELECT * FROM Teams
 SELECT * FROM Statuses
 SELECT * FROM Questions
 SELECT * FROM QAs