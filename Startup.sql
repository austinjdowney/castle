-- CREATE TABLE castles (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   yearbuilt INT NOT NULL,
--   yearlastinvaded INT default 0,
--   location VARCHAR(255) NOT NULL,
--   imgurl VARCHAR(255),
--   PRIMARY KEY (id)
-- );

INSERT INTO castles
(name, yearbuilt, yearlastinvaded, location, imgurl)
VALUES
("Warm Springs Castle", 2011, 0, "Boise,Idaho", "http://placehold.it/300x300");

INSERT INTO castles
(name, yearbuilt, yearlastinvaded, location, imgurl)
VALUES
("Idanha Castle", 1901, 0, "Boise,Idaho", "http://placehold.it/300x300");

INSERT INTO castles
(name, yearbuilt, yearlastinvaded, location, imgurl)
VALUES
("Bamburgh Castle", 500, 993, "Bamburgh,England", "http://placehold.it/300x300");

-- GET ALL CASTLES
SELECT * FROM `castle`.`castles` LIMIT 1000;



