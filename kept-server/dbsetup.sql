-- CREATE TABLE profiles (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id)
-- )

--   CREATE TABLE keepstable (
--     id INT NOT NULL AUTO_INCREMENT,
--     creatorId VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     description VARCHAR(1000) NOT NULL,
--     img VARCHAR(255) NOT NULL,
--     views INT NOT NULL,
--     keeps INT NOT NULL,
--     shares INT NOT NULL,
--     tags VARCHAR(255),
--       PRIMARY KEY (id),
--       FOREIGN KEY (creatorId)
--       REFERENCES profiles(id)
--       ON DELETE CASCADE
-- )


    -- CREATE TABLE vaults (
    --     id INT NOT NULL AUTO_INCREMENT,
    --     name VARCHAR(255) NOT NULL,
    --     creatorId VARCHAR(255) NOT NULL,
    --     isPrivate TINYINT NOT NULL,
    --     description VARCHAR(255) NOT NULL,
    --     PRIMARY KEY (id),
    --         FOREIGN KEY (creatorId)
    --         REFERENCES profiles(id)
    --         ON DELETE CASCADE
    -- )

  -- CREATE TABLE vaultKeeps (
  --   id INT NOT NULL AUTO_INCREMENT,
  --   vaultId INT NOT NULL,
  --   keepId INT NOT NULL,
  --   creatorId VARCHAR(255) NOT NULL,
  --     PRIMARY KEY (id),
    
  --     FOREIGN KEY(vaultId)
  --     REFERENCES vaults (id)
  --     ON DELETE CASCADE,

  --     FOREIGN KEY(keepId)
  --     REFERENCES keepstable (id)
  --     ON DELETE CASCADE,
    
  --     FOREIGN KEY(creatorId)
  --     REFERENCES profiles (id)
  --     ON DELETE CASCADE

  -- )

-- ALTER TABLE keepstable
-- MODIFY COLUMN views INT DEFAULT 0,
-- MODIFY COLUMN keeps INT DEFAULT 0,
-- MODIFY COLUMN shares INT DEFAULT 0
-- ADD COLUMN isPublished TINYINT DEFAULT 1

-- UPDATE profiles SET name = 'Kevin' WHERE id = '4f041796-e380-4297-ba5a-5181a84e1a7c'
-- UPDATE profiles SET picture = 'https://images.pexels.com/photos/3789888/pexels-photo-3789888.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500' WHERE id = '4f041796-e380-4297-ba5a-5181a84e1a7c'

-- UPDATE profiles SET picture = 'https://images.pexels.com/photos/3777944/pexels-photo-3777944.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500' WHERE id = '3e2ec1fd-bdfe-4cff-a154-9a718f2d2035'

-- UPDATE profiles SET name = 'Rosabel' WHERE id = '78b68cdf-c6e2-458d-a031-a4dc7f98e99b'

UPDATE profiles SET picture = 'https://images.pexels.com/photos/3523073/pexels-photo-3523073.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500' WHERE id = '78b68cdf-c6e2-458d-a031-a4dc7f98e99b'

